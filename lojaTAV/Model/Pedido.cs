using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using lojaTAV.interfaces;

namespace lojaTAV.Model
{
    public class Pedido
    {
        public int id { get; set; }
        public int idCliente { get; set; }
        public int idEntrega { get; set; }
        public double valorTotal { get; set; }
        public ICliente Cliente { get; }
        public IFrete Frete { get; }

        public Pedido(int _id, int _cliente, int _idEntrega, double _valorTotal)
        {
            id = _id;
            idCliente = _cliente;
            idEntrega = _idEntrega;
            valorTotal = _valorTotal;
        }

        public Pedido(int _id, int _idCliente, ICliente cliente, IFrete frete, int _idEntrega, double _valorTotal)
        {
            id = _id;
            Cliente = cliente;
            idCliente = _idCliente;
            Frete = frete;
            idEntrega = _idEntrega;
            valorTotal = _valorTotal;
        }

        public bool ValidaEntrega(IEntrega entrega)
        {
            if (entrega == null || idEntrega < 1)
            {
                return false;
            }
            return true;
        }
        public double CalcularFrete()
        {
            int cep = Cliente.getCepById(idCliente);
            double valorFrete = Frete.GetValorFrete(cep);
            return valorFrete;
        }
    }
}
