﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibAutheur.Data.Framework
{
    public class SelectResult : BaseResult
    {
        public DataTable Datatable { get; set; }
    }
}
