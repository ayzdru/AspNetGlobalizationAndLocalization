﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetGlobalizationAndLocalization.Entities
{
    public class Resource
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public virtual Culture Culture { get; set; }
        public int CultureId { get; set; }  
    }
}
