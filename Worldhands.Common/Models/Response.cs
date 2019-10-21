﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Worldhands.Common.Models
{
    public class LandResponse<T> where T : class
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public T Result { get; set; }
    }
}
