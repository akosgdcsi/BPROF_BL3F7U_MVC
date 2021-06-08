using GalaSoft.MvvmLight;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient.VM
{
    class PlanetEditVM : ViewModelBase
    {
        private Planet planet;
        public PlanetEditVM()
        {
            this.planet = new Planet();
            if (this.IsInDesignMode)
            {
                planet.Name = "Kepler 11-B2";
                planet.Habitable = false;
                planet.Population = 0;
                planet.PlanetType = PlanetType.Jovian;
            }
        }

        public Array Planets
        {
            get { return Enum.GetValues(typeof(PlanetType)); }
        }

        public Planet Planet { get { return planet; } set { Set(ref planet, value); } }
    }
}
