using System;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Text;
using lojaTAV.interfaces;
using lojaTAV.Model;

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
        public void CalculaFreteTestBR()
        {
            // Arrange
            _mockCliente = new Mock<ICliente>();
            
            int cep = 20123456;
            string pais = "Brasil";
            Cliente cliente = new Cliente()
            {
                idCliente = 3,
                endereco = "Clarimundo de Melo 857",
                cep = cep,
                pais = pais
            };
            double esperado = 7.26;
            
            _mockCliente.Setup(x1 => x1.getCepById(3)).Returns(cliente.cep);
            _mockCliente.Setup(x2 => x2.getPaisById(3)).Returns(cliente.pais);

            Mock<IFrete> _mockFrete = new Mock<IFrete>();
            Frete frete = new Frete()
            {
                idFrete = 25,
                cep = 20123456,
                pais = "Brasil",
                valorFrete = 7.26
                
            };
            //_mockFrete.Setup(y => y.GetValorFrete(cep, pais)).Returns(frete.valorFrete);
            _mockFrete.Setup(y => y.GetValorFreteBR(cep)).Returns(frete.valorFrete);

            // ACT
            Pedido pedido = new(1, 3, _mockCliente.Object, _mockFrete.Object, 5, 25.56);
            double resultado = pedido.CalcularFrete();

            //Assert
            Assert.Equal(esperado, resultado);
        }
        [Fact]
        public void CalculaFreteUSA()
        {
            int cep = 2112345;
            string pais = "Estados Unidos";
            // Arrange
            _mockCliente = new Mock<ICliente>();
            Cliente cliente = new Cliente()
            {
                idCliente = 4,
                endereco = "rua abcdef",
                cep = cep,
                pais = pais
            };
            double esperado = 240.50;
            //_mockCliente.Setup(x1 => x1.getCepById(3)).Returns(cliente.cep);
            _mockCliente.Setup(x2 => x2.getPaisById(4)).Returns(cliente.pais);

            Mock<IFrete> _mockFrete = new Mock<IFrete>();
            Frete frete = new Frete()
            {
                idFrete = 26,
                cep = cep,
                pais = "pais",
                valorFrete = 150.00

            };
            
            _mockFrete.Setup(y => y.GetValorFreteInternacional(pais)).Returns(frete.valorFrete);

            // ACT
            Pedido pedido = new Pedido(2, 4, _mockCliente.Object, _mockFrete.Object, 5, 25.56);
            double resultado = pedido.CalcularFrete();

            //Assert
            Assert.Equal(esperado, resultado);
        }
        [Fact]
        public void CalculaFreteMexico()
        {
            int cep = 11245;
            string pais = "Mexico";
            // Arrange
            _mockCliente = new Mock<ICliente>();
            Cliente cliente = new Cliente()
            {
                idCliente = 5,
                endereco = "rua abcdef",
                cep = cep,
                pais = pais
            };
            double esperado = 54.50;

            _mockCliente.Setup(x2 => x2.getPaisById(5)).Returns(cliente.pais);

            Mock<IFrete> _mockFrete = new Mock<IFrete>();
            Frete frete = new Frete()
            {
                idFrete = 27,
                cep = cep,
                pais = "pais",
                valorFrete = 140.00

            };
            
            _mockFrete.Setup(y => y.GetValorFreteInternacional(pais)).Returns(frete.valorFrete);

            // ACT
            Pedido pedido = new Pedido(3, 5, _mockCliente.Object, _mockFrete.Object, 5, 25.56);
            double resultado = pedido.CalcularFrete();

            //Assert
            Assert.Equal(esperado, resultado);
        }
    }
}
