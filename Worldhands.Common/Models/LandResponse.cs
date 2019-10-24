﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Worldhands.Common.Models
{
    public class LandResponse
    {
      
        public string Name { get; set; }

        public List<string> TopLevelDomain { get; set; }

    
        public string Alpha2Code { get; set; }

     
        public string Alpha3Code { get; set; }

    
        public List<string> CallingCodes { get; set; }

      
        public string Capital { get; set; }

     
        public List<object> AltSpellings { get; set; }

    
        public string Region { get; set; }

    
        public string Subregion { get; set; }

    
        public int Population { get; set; }

      
        public List<double> Latlng { get; set; }

     
        public string Demonym { get; set; }

     
        public double? Area { get; set; }

     
        public double? Gini { get; set; }

       
        public List<string> Timezones { get; set; }

      
        public List<object> Borders { get; set; }

      
        public string NativeName { get; set; }

    
        public string NumericCode { get; set; }

     
        public List<CurrencyResponse> Currencies { get; set; }

      
        public List<LanguageResponse> Languages { get; set; }

        public Translations Translations { get; set; }

    
        public string Flag { get; set; }

      
        public List<object> RegionalBlocs { get; set; }

      
        public string Cioc { get; set; }
    }
}
