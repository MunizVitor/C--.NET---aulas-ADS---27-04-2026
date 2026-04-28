using projeto_DESIGN_PATTTERN.Models;

namespace projeto_DESIGN_PATTTERN.Service
{
    public interface IProdutoService
    {
        IEnumerable<Produto> ListarProdutos();
        Produto BuscarProduto(Guid id);
        void CriarProduto(Produto produto);
        void AtualizarProduto(Produto produto);
        void RemoverProduto(Guid id);
    }
}
