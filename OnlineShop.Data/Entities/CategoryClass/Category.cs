﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Data.Entities.Identity;

namespace OnlineShop.Data.Entities.CategoryClass
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int SortOrder { set; get; }
        public bool IsShowOnHome { set; get; }

    }
}
