﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaberesSyllabus.Models
{
    public class Aprendizaje
    {
        public int codigo { get; set; }
        public string categoria { get; set; }
        public string descripcion { get; set; }
        public List<Saber> saberes { get; set; }
    }
}