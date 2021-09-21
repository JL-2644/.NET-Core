using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compsci335_A1.Dtos
{
    public class StaffCardOut
    {
        public string Name { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Url { get; set; }
        public string Company { get; set; }
        public int Uid { get; set; }
        public string Photo { get; set; }
        public string Categories { get; set; }
        public string PhotoType { get; set; }
        public string Logo { get; set; }
        public string LogoType { get; set; }
    }
}
