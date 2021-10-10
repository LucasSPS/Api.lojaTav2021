using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace lojaTAV.Model
{
    public class Frete
    {
        public int idFrete { get; set; }
        public double valorFrete { get; set; }
        public int cep { get; set; }
        public string pais { get; set; }
    }
}
