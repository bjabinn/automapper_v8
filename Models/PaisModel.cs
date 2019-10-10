using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automapper
{
    public class PaisModel
    {
        public int id { get; set; }
        public List<CiudadModel> ciudades { get; set; }
    }
}
