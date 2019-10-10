using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automapper
{
    public class Pais
    {
        public int id { get; set; }
        public List<Ciudad> ciudades { get; set; }
    }
}
