using Store.Core.DomainObjects.Dtos;
using Store.Core.Messages;
using Store.Core.Messages.IntagrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Vendas.Application.Events
{
    public class PedidoIniciadoEvent : IntegrationEvent
    {
        public Guid PedidoID { get; private set; }
        public Guid ClienteId { get; private set; }
        public decimal Total{ get; private set; }
        public ListaProdutosPedido ProdutosPedidos { get; private set; }
        public string NomeCartao { get; private set; }
        public string NumeroCartao { get; private set; }
        public string ExpiracaoCartao { get; private set; }
        public string CvvCartao { get; private set; }
        public Guid Id { get; }
        public ListaProdutosPedido ListaProdutosPedido { get; }
        public decimal ValorTotal { get; }

        public PedidoIniciadoEvent(Guid id, Guid clienteId, ListaProdutosPedido listaProdutosPedido, decimal valorTotal, string nomeCartao, string numeroCartao, string expiracaoCartao, string cvvCartao)
        {
            Id = id;
            ClienteId = clienteId;
            ListaProdutosPedido = listaProdutosPedido;
            ValorTotal = valorTotal;
            NomeCartao = nomeCartao;
            NumeroCartao = numeroCartao;
            ExpiracaoCartao = expiracaoCartao;
            CvvCartao = cvvCartao;
        }
    }
}
