using System;
using System.Collections.Generic;
using System.Text;
using Worldhands.Common.Models;

namespace Worldhands.Prism.ViewModels
{
    class MainViewModel
    {
        public List<Land> LandsList
        {
            get;
            set;
        }
        public TokenResponse Token
        {
            get;
            set;
        }
        public LandsPageViewModel Lands
        {
            get;
            set;
        }

        public LandItemViewModel Land
        {
            get;
            set;
        }

        private static MainViewModel instance;
        public MainViewModel()
        {
            instance = this;        
        }
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
    }
}
