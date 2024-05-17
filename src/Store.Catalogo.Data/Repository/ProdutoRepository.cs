using Microsoft.EntityFrameworkCore;
using Store.Catalogo.Domain;
using Store.Core.Data;

namespace Store.Catalogo.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _catalogoContext;
    
        public ProdutoRepository(CatalogoContext catalogoContext)
        {
            _catalogoContext = catalogoContext;
        }

        public IUnitOfWork UnitOfWork => _catalogoContext;

        public void AddCategoria(Categoria categoria)
        {
            _catalogoContext.Categorias.Add(categoria);
        }

        public void AddProduto(Produto produto)
        {
            _catalogoContext.Produtos.Add(produto);
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _catalogoContext.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> GetAllCategorias()
        {
            return await _catalogoContext.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetByIdCategoria(int codigo)
        {
            return await _catalogoContext.Produtos.AsNoTracking().Include(p => p.Categoria).Where(c => c.Categoria.Codigo == codigo).ToListAsync();
        }

        public async Task<Produto> GetById(Guid id)
        {
            return await _catalogoContext.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public void UpdateCategoria(Categoria categoria)
        {
            _catalogoContext.Categorias.Update(categoria);
        }

        public void UpdateProduto(Produto produto)
        {
            _catalogoContext.Produtos.Update(produto);
        }

        public void Dispose()
        {
            _catalogoContext?.Dispose();
        }
    }
}
