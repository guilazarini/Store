using MediatR;
using NerdStore.Vendas.Data.Repository;
using Store.Catalogo.Application.Services;
using Store.Catalogo.Data;
using Store.Catalogo.Data.Repository;
using Store.Catalogo.Domain;
using Store.Catalogo.Domain.Interfaces;
using Store.Core.Communication.Mediator;
using Store.Core.Data;
using Store.Core.Messages.CommonMessages.Norifications;
using Store.Core.Messages.CommonMessages.Notifications;
using Store.Vendar.Domain;
using Store.Vendas.Application.Commands;

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

            //Vendas
            services.AddScoped<IRequestHandler<AddItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
        }
    }
}
