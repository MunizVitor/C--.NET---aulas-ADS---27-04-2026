using projeto_DESIGN_PATTTERN.Data.Context;
using projeto_DESIGN_PATTTERN.Models;
using projeto_DESIGN_PATTTERN.Repository;

namespace projeto_DESIGN_PATTTERN.Data
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> GetAll() => _context.Produtos.ToList();

        public Produto GetById(Guid id) => _context.Produtos.FirstOrDefault(p => p.Id == id);

        public void Add(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Update(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var produto = GetById(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
        }
    }
}
