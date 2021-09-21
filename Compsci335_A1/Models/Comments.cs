using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Compsci335_A1.Models
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string Time { get; set; }
    }
}
