using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace lojaTAV.interfaces
{
    public interface ICliente
    {
        public int getCepById(int idCliente);
        public string getPaisById(int idCliente);
    }
}