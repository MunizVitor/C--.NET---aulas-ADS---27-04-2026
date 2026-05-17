using Org.BouncyCastle.Asn1.Esf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umfgcloud.loja.dominio.service.DTO;

namespace umfgcloud.aplicacao.service.testes.Classes
{
    [TestClass]
    public sealed class ProdutoServicoTestes : AbstractServicoTestes
    {
        private const string C_OWNER = "Juliano Maciel";
        private const string C_CATEGORY = "produto";
        private const decimal C_VALOR_NEGATIVO = -89.90m;

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public async Task ProdutoServico_AdicionarAsync_Sucesso()
        {
            try
            {
                //o objetivo do using é o desenvolvedor ter controlle sobre o 
                //dispose do objeto
                using var context = GetSqlServerDatabaseContext(Guid.NewGuid().ToString());

                var servico = GetProdutoServicoValidJWT(context);
                var dto = new ProdutoDTO.ProdutoRequest()
                {
                    Descricao = "TESTE",
                    EAN = "123456789",
                    ValorCompra = 39.90m,
                    ValorVenda = 89.90m,
                };

                await servico.AdicionarAsync(dto);

                var produto = (await servico.ObterTodosAsync()).FirstOrDefault();

                Assert.IsNotNull(produto);
                Assert.AreNotEqual(Guid.Empty, produto.Id);
                Assert.AreEqual("TESTE", produto.Descricao);
                Assert.AreEqual("123456789", produto.EAN);
                Assert.AreEqual(39.90m, produto.ValorCompra);
                Assert.AreEqual(89.90m, produto.ValorVenda);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public async Task ProdutoServico_AdicionarAsync_FalhaValorCompraNegativo()
        {
            try
            {
                //o objetivo do using é o desenvolvedor ter controlle sobre o 
                //dispose do objeto
                using var context = GetSqlServerDatabaseContext(Guid.NewGuid().ToString());

                var servico = GetProdutoServicoValidJWT(context);
                var dto = new ProdutoDTO.ProdutoRequest()
                {
                    Descricao = "TESTE",
                    EAN = "123456789",
                    ValorCompra = -39.90m,
                    ValorVenda = 89.90m,
                };

                await Assert.ThrowsExceptionAsync<InvalidDataException>(() => servico.AdicionarAsync(dto));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public async Task ProdutoServico_AdicionarAsync_FalhaValorVendaNegativo()
        {
            try
            {
                //o objetivo do using é o desenvolvedor ter controlle sobre o 
                //dispose do objeto
                using var context = GetSqlServerDatabaseContext(Guid.NewGuid().ToString());

                var servico = GetProdutoServicoValidJWT(context);
                var dto = new ProdutoDTO.ProdutoRequest()
                {
                    Descricao = "TESTE",
                    EAN = "123456789",
                    ValorCompra = 39.90m,
                    ValorVenda = -89.90m,
                };

                await Assert.ThrowsExceptionAsync<InvalidDataException>(() => servico.AdicionarAsync(dto));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public void ProdutoServico_Instanciar_Falha()
        {
            try
            {
                //o objetivo do using é o desenvolvedor ter controlle sobre o 
                //dispose do objeto
                using var context = GetSqlServerDatabaseContext(Guid.NewGuid().ToString());

                Assert.ThrowsException<InvalidDataException>(() => GetProdutoServicoInvalidJWT(context));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public async Task ProdutoServico_RemoverAsync_Sucesso()
        {
            using var context = GetSqlServerDatabaseContext(Guid.NewGuid().ToString());
            var servico = GetProdutoServicoValidJWT(context);

            var dto = new ProdutoDTO.ProdutoRequest()
            {
                Descricao = "Produto Removido",
                EAN = "333333333",
                ValorCompra = 30m,
                ValorVenda = 50m,
            };

            // Adiciona o produto
            await servico.AdicionarAsync(dto);

            // Busca o produto recém-adicionado
            var produto = (await servico.ObterTodosAsync()).FirstOrDefault();

            // Remove
            await servico.RemoverAsync(produto.Id);

            // Confirma que não existe mais
            var produtoRemovido = await servico.ObterPorIdAsync(produto.Id);
            Assert.IsNull(produtoRemovido);
        }



        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public async Task ProdutoServico_RemoverAsync_FalhaProdutoInexistente()
        {
            using var context = GetSqlServerDatabaseContext(Guid.NewGuid().ToString());
            var servico = GetProdutoServicoValidJWT(context);

            await Assert.ThrowsExceptionAsync<InvalidDataException>(
                () => servico.RemoverAsync(Guid.NewGuid())
            );
        }

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public async Task ProdutoServico_ObterPorIdAsync_Sucesso()
        {
            using var context = GetSqlServerDatabaseContext(Guid.NewGuid().ToString());
            var servico = GetProdutoServicoValidJWT(context);

            var dto = new ProdutoDTO.ProdutoRequest()
            {
                Descricao = "Produto Consulta",
                EAN = "444444444",
                ValorCompra = 40m,
                ValorVenda = 60m,
            };

            await servico.AdicionarAsync(dto);

            var produto = (await servico.ObterTodosAsync()).FirstOrDefault();

            var produtoConsultado = await servico.ObterPorIdAsync(produto.Id);

            Assert.IsNotNull(produtoConsultado);
            Assert.AreEqual(produto.Id, produtoConsultado.Id);
            Assert.AreEqual("Produto Consulta", produtoConsultado.Descricao);
        }

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public async Task ProdutoServico_ObterPorIdAsync_FalhaProdutoInexistente()
        {
            using var context = GetSqlServerDatabaseContext(Guid.NewGuid().ToString());
            var servico = GetProdutoServicoValidJWT(context);

            await Assert.ThrowsExceptionAsync<InvalidDataException>(
                () => servico.ObterPorIdAsync(Guid.NewGuid())
            );
        }

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public async Task ProdutoServico_ObterTodosAsync_Sucesso()
        {
            using var context = GetSqlServerDatabaseContext(Guid.NewGuid().ToString());
            var servico = GetProdutoServicoValidJWT(context);

            var dto1 = new ProdutoDTO.ProdutoRequest()
            {
                Descricao = "Produto 1",
                EAN = "555555555",
                ValorCompra = 50m,
                ValorVenda = 70m,
            };

            var dto2 = new ProdutoDTO.ProdutoRequest()
            {
                Descricao = "Produto 2",
                EAN = "666666666",
                ValorCompra = 60m,
                ValorVenda = 80m,
            };

            await servico.AdicionarAsync(dto1);
            await servico.AdicionarAsync(dto2);

            var produtos = await servico.ObterTodosAsync();

            Assert.IsTrue(produtos.Count() >= 2);
        }



        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public async Task ProdutoServico_ObterTodosAsync_FalhaListaVazia()
        {
            using var context = GetSqlServerDatabaseContext(Guid.NewGuid().ToString());
            var servico = GetProdutoServicoValidJWT(context);

            var produtos = await servico.ObterTodosAsync();

            Assert.AreEqual(0, produtos.Count());
        }
        


    }
}
