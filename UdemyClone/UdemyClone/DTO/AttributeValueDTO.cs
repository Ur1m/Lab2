﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyClone.DTO
{
    public class AttributeValueDTO
    {
        public int AttributeValueId { get; set; }
        public string Value { get; set; }
        public int AttributeId { get; set; }
        public Attribute attribute { get; set; }
    }
}
