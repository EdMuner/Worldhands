using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Worldhands.Common.Models;
using Worldhands.Common.Services;

namespace Worldhands.Prism.ViewModels
{
    public class LandPageViewModel
    {

        public LandPageViewModel(LandResponse land)
        {
            this.Land = land;
               
        }
       
        public  LandResponse Land
        {
            get;
            set;
        }
      
    }
}
