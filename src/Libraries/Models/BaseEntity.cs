﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateUTC { get; set; }
    }
}
