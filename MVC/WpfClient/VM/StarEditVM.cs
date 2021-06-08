using GalaSoft.MvvmLight;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient.VM
{
    class StarEditVM : ViewModelBase
    {
        private Star star;
        public StarEditVM()
        {
            star = new Star();
            if (IsInDesignMode)
            {
                star.Name = "The Sun";
                star.StarType = StarType.Red_Dwarfs;
                star.Age = 100000000;
            }
        }
        public Array Stars
        {
            get { return Enum.GetValues(typeof(StarType)); }
        }

        public Star Star { get { return star; } set { Set(ref star, value); } }
    }
}
