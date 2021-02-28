using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyNLayerProject.Web.DTOs
{
    public class ProductWithCategory :ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
