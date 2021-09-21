using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Compsci335_A1.Models;
using System.ComponentModel.DataAnnotations;

namespace Compsci335_A1.Dtos
{
    public class CommentInDto
    {
        public string Comment { get; set; }
        public string Name { get; set; }
    }
}
