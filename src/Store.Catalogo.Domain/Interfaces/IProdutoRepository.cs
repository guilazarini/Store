using Store.Core.Data;

namespace Store.Catalogo.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetById(Guid id);
        Task<IEnumerable<Produto>> GetByIdCategoria(int codigo);
        Task<IEnumerable<Categoria>> GetAllCategorias();

        void AddProduto(Produto produto);
        void UpdateProduto(Produto produto);

        void AddCategoria(Categoria categoria);
        void UpdateCategoria(Categoria categoria);
    }
}
