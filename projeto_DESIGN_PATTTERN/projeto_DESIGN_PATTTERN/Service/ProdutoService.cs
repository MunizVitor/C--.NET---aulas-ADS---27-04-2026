using projeto_DESIGN_PATTTERN.Models;
using projeto_DESIGN_PATTTERN.Repository;

namespace projeto_DESIGN_PATTTERN.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Produto> ListarProdutos() => _repository.GetAll();

        public Produto BuscarProduto(Guid id) => _repository.GetById(id);

        public void CriarProduto(Produto produto) => _repository.Add(produto);

        public void AtualizarProduto(Produto produto) => _repository.Update(produto);

        public void RemoverProduto(Guid id) => _repository.Delete(id);
    }
}
