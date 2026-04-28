using Microsoft.AspNetCore.Mvc;
using projeto_DESIGN_PATTTERN.Models;
using projeto_DESIGN_PATTTERN.Service;

namespace projeto_DESIGN_PATTTERN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }


        [HttpPost("{tipo}")]
        public IActionResult CriarProduto(string tipo, [FromBody] Produto produto)
        {
            var novoProduto = ProdutoCriar.CriarProduto(tipo);

            novoProduto.NomeProduto = produto.NomeProduto;
            novoProduto.DescricaoProduto = produto.DescricaoProduto;
            novoProduto.PrecoProduto = produto.PrecoProduto;

            return Ok(novoProduto);
        }

        [HttpGet("all")]
        public IActionResult PegarTodos()
        {
            return Ok(_service.ListarProdutos());
        }
    }
}