﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyClone.Models
{
    public class Category{
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Desctription { get; set; }
    }
}