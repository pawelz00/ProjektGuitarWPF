﻿using System;
using System.Collections.Generic;

namespace ProjektGuitarWPF.Models
{
    public class Guitarist
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<GuitaristGuitar> GuitaristsGuitars { get; set; }
    }
}
