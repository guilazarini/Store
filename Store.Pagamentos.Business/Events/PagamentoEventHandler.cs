﻿using MediatR;
using Store.Core.DomainObjects.Dtos;
using Store.Vendas.Application.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Pagamentos.Business.Events
{
    public class PagamentoEventHandler : INotificationHandler<PedidoEstoqueConfirmadoEvent>
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoEventHandler(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        public async Task Handle(PedidoEstoqueConfirmadoEvent message, CancellationToken cancellationToken)
        {
            var pagamentoPedido = new PagamentoPedido
            {
                PedidoId = message.PedidoId,
                ClienteId = message.ClienteId,
                Total = message.Total,
                NomeCartao = message.NomeCartao,
                NumeroCartao = message.NumeroCartao,
                ExpiracaoCartao = message.ExpiracaoCartao,
                CvvCartao = message.CvvCartao
            };

            await _pagamentoService.RealizarPagamentoPedido(pagamentoPedido);
        }
    }
}
