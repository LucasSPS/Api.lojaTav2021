using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using lojaTAV.interfaces;

namespace lojaTAV.Model
{
    public class Entrega : IEntrega
    {
        public int idEntrega { get; set; }
        public int idEndereco { get; set; }
        //public int idPaisDestino { get; set; }
        public DateTime agendamento { get; set; }
        public bool ValidaEntrega(IEntrega entrega)
        {
            return true;
        }
    }
}
