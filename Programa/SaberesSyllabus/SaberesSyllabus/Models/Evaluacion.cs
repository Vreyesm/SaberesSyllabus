﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaberesSyllabus.Models
{
    public class Evaluacion
    {
        public EnumTipoEvaluacion tipo { get; set; }
        public List<Saber> saberes { get; set; }
    }
}