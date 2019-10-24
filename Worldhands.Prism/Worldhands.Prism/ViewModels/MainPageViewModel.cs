using System;
using System.Collections.Generic;
using System.Text;
using Worldhands.Common.Models;

namespace Worldhands.Prism.ViewModels
{
    class MainPageViewModel
    {

        private static MainPageViewModel _instance;

        public MainPageViewModel()
        {
            _instance = this;
        }

        public List<LandResponse> _landList { get; set; }

        public LandsPageViewModel Lands
        {
            get;
            set;
        }

        public LandPageViewModel Land
        {
            get;
            set;
        }

        //Singleton abstracto para que cada que inicie se posicione sobre la MainViewModel
        public static MainPageViewModel GetInstance()
        {
            if (_instance == null)
            {
                return new MainPageViewModel();
            }
            return _instance;
        }
    }
}
