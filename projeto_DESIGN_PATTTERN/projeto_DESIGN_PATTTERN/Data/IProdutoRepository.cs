using projeto_DESIGN_PATTTERN.Models;

namespace projeto_DESIGN_PATTTERN.Repository
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll();
        Produto GetById(Guid id);
        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(Guid id);
    }
}
