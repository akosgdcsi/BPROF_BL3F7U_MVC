using System;
using Models;
using Moq;
using NUnit.Framework;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Tests
{
    [TestFixture]
    public class LogicTests
    {
        [Test]
        public void TestAdd()
        {
            Mock<IRepository<Planet>> planetRepo = new Mock<IRepository<Planet>>();
            Mock<IRepository<Star>> starRepo = new Mock<IRepository<Star>>();
            Mock<IRepository<Models.System>> systemRepo = new Mock<IRepository<Models.System>>();
            planetRepo.Setup(r => r.Add(It.IsAny<Planet>()));
            PlanetLogic logic = new PlanetLogic(planetRepo.Object, starRepo.Object, systemRepo.Object);

            logic.AddPlanet(new Planet());

            planetRepo.Verify(r => r.Add(It.IsAny<Planet>()), Times.Once);
        }

        [Test]
        public void TestDelete()
        {
            Mock<IRepository<Planet>> planetRepo = new Mock<IRepository<Planet>>();
            Mock<IRepository<Star>> starRepo = new Mock<IRepository<Star>>();
            Mock<IRepository<Models.System>> systemRepo = new Mock<IRepository<Models.System>>();
            starRepo.Setup(r => r.Delete(It.IsAny<string>()));
            StarLogic logic = new StarLogic(planetRepo.Object, starRepo.Object, systemRepo.Object);

            logic.DeleteStar("TEST_ID");

            starRepo.Verify(r => r.Delete(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void TestGetSystem()
        {
            Mock<IRepository<Planet>> planetRepo = new Mock<IRepository<Planet>>();
            Mock<IRepository<Star>> starRepo = new Mock<IRepository<Star>>();
            Mock<IRepository<Models.System>> systemRepo = new Mock<IRepository<Models.System>>();
            systemRepo.Setup(r => r.Read(It.IsAny<string>())).Returns(new Models.System() { SystemID = "TEST_ID" });
            SystemLogic logic = new SystemLogic(planetRepo.Object, starRepo.Object, systemRepo.Object);

            Models.System result = logic.GetSystem("TEST_ID");

            Assert.That(result, Is.EqualTo(new Models.System() { SystemID = "TEST_ID" }));
            systemRepo.Verify(r => r.Read(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void TestGetAllPlanet()
        {
            Mock<IRepository<Planet>> planetRepo = new Mock<IRepository<Planet>>();
            Mock<IRepository<Star>> starRepo = new Mock<IRepository<Star>>();
            Mock<IRepository<Models.System>> systemRepo = new Mock<IRepository<Models.System>>();
            List<Planet> planets = new List<Planet>()
            {
                new Planet() {PlanetID = "#1"},
                new Planet() {PlanetID = "#2"},
                new Planet() {PlanetID = "#3"},
            };

            planetRepo.Setup(r => r.Read()).Returns(planets.AsQueryable());
            PlanetLogic logic = new PlanetLogic(planetRepo.Object, starRepo.Object, systemRepo.Object);

            var result = logic.GetAllPlanet();

            Assert.That(result, Is.EquivalentTo(planets));
            planetRepo.Verify(r => r.Read(), Times.Once);
        }

        [Test]
        public void TestUpdate()
        {
            Mock<IRepository<Planet>> planetRepo = new Mock<IRepository<Planet>>();
            Mock<IRepository<Star>> starRepo = new Mock<IRepository<Star>>();
            Mock<IRepository<Models.System>> systemRepo = new Mock<IRepository<Models.System>>();
            starRepo.Setup(r => r.Update(It.IsAny<string>(), It.IsAny<Star>()));
            StarLogic logic = new StarLogic(planetRepo.Object, starRepo.Object, systemRepo.Object);

            logic.UpdateStar("TEST_ID", new Star() { StarID = "TEST_ID" });

            starRepo.Verify(r => r.Update(It.IsAny<string>(), It.IsAny<Star>()), Times.Once);
        }

        [Test]
        public void TestStarsWithLife()
        {
            Mock<IRepository<Planet>> planetRepo = new Mock<IRepository<Planet>>();
            Mock<IRepository<Star>> starRepo = new Mock<IRepository<Star>>();
            Mock<IRepository<Models.System>> systemRepo = new Mock<IRepository<Models.System>>();

            List<Star> stars = new List<Star>()
            {
                new Star() { StarID ="#1"},
                new Star() { StarID ="#2"},
                new Star() { StarID ="#3"},
            };

            List<Star> expected = new List<Star>()
            {
                new Star() { StarID ="#1"},
                new Star() { StarID ="#2"},
            };


            List<Planet> planets = new List<Planet>()
            {
                new Planet() { PlanetID = "#1", Habitable = true, StarID = "#1"},
                new Planet() { PlanetID = "#2", Habitable = false, StarID = "#1"},
                new Planet() { PlanetID = "#3", Habitable = false, StarID = "#2"},
                new Planet() { PlanetID = "#4", Habitable = false, StarID = "#2"},
                new Planet() { PlanetID = "#5", Habitable = true, StarID = "#2"},
            };

            planetRepo.Setup(r => r.Read()).Returns(planets.AsQueryable());
            starRepo.Setup(r => r.Read()).Returns(stars.AsQueryable());

            StatsLogic logic = new StatsLogic(planetRepo.Object, starRepo.Object, systemRepo.Object);

            var result = logic.StarsWithLife();

            Assert.That(result, Is.EquivalentTo(expected));
            starRepo.Verify(r => r.Read(), Times.Once);
            planetRepo.Verify(r => r.Read(), Times.Once);
        }

        [Test]
        public void TestPopulationInSectors()
        {
            Mock<IRepository<Planet>> planetRepo = new Mock<IRepository<Planet>>();
            Mock<IRepository<Star>> starRepo = new Mock<IRepository<Star>>();
            Mock<IRepository<Models.System>> systemRepo = new Mock<IRepository<Models.System>>();

            List<Planet> planets = new List<Planet>()
            {
                new Planet() { PlanetID = "#1",  StarID = "#1", Population = 10},
                new Planet() { PlanetID = "#2",  StarID = "#1", Population = 20},
                new Planet() { PlanetID = "#3",  StarID = "#2", Population = 30},
                new Planet() { PlanetID = "#4",  StarID = "#3", Population = 40},
                new Planet() { PlanetID = "#5",  StarID = "#4", Population = 50},
            };

            List<Star> stars = new List<Star>()
            {
                new Star() { StarID ="#1", SystemID = "#1", Planets = new Planet[] { planets[0], planets[1] } },
                new Star() { StarID ="#2", SystemID = "#2", Planets = new Planet[] { planets[2] }},
                new Star() { StarID ="#3", SystemID = "#2", Planets = new Planet[] { planets[3] }},
                new Star() { StarID ="#4", SystemID = "#3", Planets = new Planet[] { planets[4] }},
            };

            List<Models.System> systems = new List<Models.System>()
            {
                new Models.System() { SystemID = "#1", SectorName = "A",
                                    Stars = new Star[] { stars[0] } },
                new Models.System() { SystemID = "#2", SectorName = "A",
                                    Stars = new Star[] { stars[1], stars[2] } },
                new Models.System() { SystemID = "#3", SectorName = "B",
                                    Stars = new Star[] { stars[3] } }
            };

            planetRepo.Setup(r => r.Read()).Returns(planets.AsQueryable());
            starRepo.Setup(r => r.Read()).Returns(stars.AsQueryable());
            systemRepo.Setup(r => r.Read()).Returns(systems.AsQueryable());

            StatsLogic logic = new StatsLogic(planetRepo.Object, starRepo.Object, systemRepo.Object);

            var result = logic.PopulationInSectors();

            Assert.That(result.Single(x => x.SectorType == "A").Population, Is.EqualTo(100));
            Assert.That(result.Single(x => x.SectorType == "B").Population, Is.EqualTo(50));
            systemRepo.Verify(r => r.Read(), Times.Once);
            starRepo.Verify(r => r.Read(), Times.Once);
            planetRepo.Verify(r => r.Read(), Times.Once);
        }

        [Test]
        public void TestPlanetTypeGrouped()
        {
            Mock<IRepository<Planet>> planetRepo = new Mock<IRepository<Planet>>();
            Mock<IRepository<Star>> starRepo = new Mock<IRepository<Star>>();
            Mock<IRepository<Models.System>> systemRepo = new Mock<IRepository<Models.System>>();

            List<Planet> planets = new List<Planet>()
            {
                new Planet() { PlanetID = "#1",  StarID = "#1", PlanetType = PlanetType.Terran},
                new Planet() { PlanetID = "#2",  StarID = "#1", PlanetType = PlanetType.Terran },
                new Planet() { PlanetID = "#3",  StarID = "#2", PlanetType = PlanetType.Jovian},
                new Planet() { PlanetID = "#4",  StarID = "#3", PlanetType = PlanetType.Neptunian},
                new Planet() { PlanetID = "#5",  StarID = "#4", PlanetType = PlanetType.Subterran},
            };

            List<Star> stars = new List<Star>()
            {
                new Star() { StarID ="#1", Age = 1500000 },
                new Star() { StarID ="#2", Age = 800000},
                new Star() { StarID ="#3", Age = 1000001},
                new Star() { StarID ="#4", Age = 999999},
            };


            planetRepo.Setup(r => r.Read()).Returns(planets.AsQueryable());
            starRepo.Setup(r => r.Read()).Returns(stars.AsQueryable());

            StatsLogic logic = new StatsLogic(planetRepo.Object, starRepo.Object, systemRepo.Object);

            var result = logic.PlanetTypeGrouped();

            Assert.That(result.Single(x => x.Type == PlanetType.Terran).NumberOfStars, Is.EqualTo(1));
            Assert.That(result.Single(x => x.Type == PlanetType.Neptunian).NumberOfStars, Is.EqualTo(1));
            starRepo.Verify(r => r.Read(), Times.Once);
            planetRepo.Verify(r => r.Read(), Times.Once);
        }
    }
}
