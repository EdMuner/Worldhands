using System;
using System.Collections.Generic;
using System.Text;
using Worldhands.Common.Models;

namespace Worldhands.Prism.ViewModels
{
    class MainViewModel
    {

        private static MainViewModel _instance;

        public MainViewModel()
        {
            _instance = this;
        }

        public List<LandResponse> LandList { get; set; }

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
        public static MainViewModel GetInstance()
        {
            if (_instance == null)
            {
                return new MainViewModel();
            }
            return _instance;
        }
    }
}
