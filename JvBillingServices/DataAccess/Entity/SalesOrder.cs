﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entity
{
    public class Billing : DTOBase
    {
        public string Name { get; set; }
        public bool State { get; set; }
    }
}