﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.Dto
{
    public class ProductWithCategoryDto :ProductDto
    {
        public CategoryDto Category { get; set; }


    }
}
