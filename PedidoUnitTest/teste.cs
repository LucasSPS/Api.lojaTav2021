using System;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Text;
using lojaTAV.interfaces;
using lojaTAV.Model;

//quando for brasil segue essa regra, quando não for eu farei um preço unico
// criar atributo país na classe cliente, refatorar essa classe, cada pais tem um frete 

namespace lojaTav2021.testes
{
    public class PedidoUnitTest
    {
        private Mock<ICliente> _mockCliente;

        [Fact]
        public void ValidaEntregaIdZerado()
        {
            // Arrange
            Pedido pedido = new Pedido(1, 12, 0, 15.98);
            bool esperado = false;
            IEntrega entrega = new Entrega();
            Mock<IEntrega> mock = new Mock<IEntrega>();
            mock.Setup(m => m.ValidaEntrega(entrega)).Returns(true);

            //ACT
            var result = pedido.ValidaEntrega(entrega);

            // Assert
            Assert.Equal(result, esperado);
        }
        [Fact]
        public void CalculaFreteTest1()
        {
            // Arrange
            _mockCliente = new Mock<ICliente>();
            Cliente cliente = new Cliente()
            {
                idCliente = 3,
                endereco = "Clarimundo de Melo 857",
                cep = 20123456
            };
            double esperado = 7.26;
            int cep = 20123456;
            _mockCliente.Setup(x => x.getCepById(3)).Returns(cliente.cep);

            Mock<IFrete> _mockFrete = new Mock<IFrete>();
            Frete frete = new Frete()
            {
                idFrete = 25,
                cep = 20123456,
                valorFrete = 7.26
            };
            _mockFrete.Setup(y => y.GetValorFrete(cep)).Returns(frete.valorFrete);

            // ACT
            Pedido pedido = new Pedido(1, 3, _mockCliente.Object, _mockFrete.Object, 5, 25.56);
            double resultado = pedido.CalcularFrete();

            //Assert
            Assert.Equal(esperado, resultado);
        }
    }
}
