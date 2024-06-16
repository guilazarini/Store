using MediatR;
using NerdStore.Vendas.Data.Repository;
using Store.Catalogo.Application.Services;
using Store.Catalogo.Data;
using Store.Catalogo.Data.Repository;
using Store.Catalogo.Domain;
using Store.Catalogo.Domain.Interfaces;
using Store.Core.Communication.Mediator;
using Store.Core.Messages.CommonMessages.Norifications;
using Store.Core.Messages.CommonMessages.Notifications;
using Store.Pagamentos.AntiCorruption;
using Store.Pagamentos.Business;
using Store.Pagamentos.Data;
using Store.Pagamentos.Data.Repository;
using Store.Vendar.Domain;
using Store.Vendas.Application.Commands;
using Store.Vendas.Application.Events;
using Store.Vendas.Application.Queries;
using Store.Vendas.Data;
using ConfigurationManager = Store.Pagamentos.AntiCorruption.ConfigurationManager;
using IConfigurationManager = Store.Pagamentos.AntiCorruption.IConfigurationManager;

namespace Store.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services) 
        {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Notification
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            // Vendas
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();
            services.AddScoped<VendasContext>();

            services.AddScoped<IRequestHandler<AddItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AplicarVoucherPedidoCommand, bool>, PedidoCommandHandler>();

            services.AddScoped<INotificationHandler<PedidoRascunhoIniciadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoAtualizadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<ItemPedidoAdicionadoEvent>, PedidoEventHandler>();

            // Pagamento
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IPagamentoCartaoCreditoFacade, PagamentoCartaoCreditoFacade>();
            services.AddScoped<IPayPalGateway, PayPalGateway>();
            services.AddScoped<IConfigurationManager, ConfigurationManager>();
            services.AddScoped<PagamentoContext>();

        }
    }
}
