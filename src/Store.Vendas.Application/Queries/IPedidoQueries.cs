﻿using Store.Vendar.Domain;
using Store.Vendas.Application.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Vendas.Application.Queries
{
    public interface IPedidoQueries
    {
        Task<CarrinhoDto> ObterCarrinhoCliente(Guid clienteId);
        Task<IEnumerable<PedidoDto>> ObterPedidosCLiente(Guid clientId);
    }

    public class PedidoQueries : IPedidoQueries
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoQueries(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<CarrinhoDto> ObterCarrinhoCliente(Guid clienteId)
        {
            var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(clienteId);
            if (pedido == null) return null;

            var carrinho = new CarrinhoDto
            {
                ClienteId = pedido.ClienteId,
                ValorTotal = pedido.ValorTotal,
                PedidoId = pedido.Id,
                ValorDesconto = pedido.Desconto,
                SubTotal = pedido.Desconto + pedido.ValorTotal
            };

            if (pedido.VoucherId != null)
            {
                carrinho.VoucherCodigo = pedido.Voucher.Codigo;
            }

            foreach (var item in pedido.PedidoItems)
            {
                carrinho.Items.Add(new CarrinhoItemDto
                {
                    ProdutoId = item.ProdutoId,
                    ProdutoNome = item.ProdutoNome,
                    Quantidade = item.Quantidade,
                    ValorUnitario = item.ValorUnitario,
                    ValorTotal = item.ValorUnitario * item.Quantidade
                });
            }

            return carrinho;
        }

        public async Task<IEnumerable<PedidoDto>> ObterPedidosCLiente(Guid clientId)
        {
            var pedidos = await _pedidoRepository.ObterListaPorClienteId(clientId);

            pedidos = pedidos.Where(p => p.PedidoStatus == PedidoStatus.Pago || p.PedidoStatus == PedidoStatus.Cancelado)
                .OrderByDescending(p => p.Codigo);

            if (!pedidos.Any()) return null;

            var pedidosView = new List<PedidoDto>();

            foreach (var pedido in pedidos)
            {
                pedidosView.Add(new PedidoDto
                {
                    ValorTotal = pedido.ValorTotal,
                    PedidoStatus = (int)pedido.PedidoStatus,
                    Codigo = pedido.Codigo,
                    DataCadastro = pedido.DataCadastro
                });
            }

            return pedidosView;
        }
    }
}
