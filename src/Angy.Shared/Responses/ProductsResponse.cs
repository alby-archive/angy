﻿using System.Collections.Generic;
using Angy.Model.Model;

namespace Angy.Shared.Responses
{
    public class ProductsResponse
    {
        public IEnumerable<Product> Products { get; set; }
    }
}