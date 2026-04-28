namespace projeto_DESIGN_PATTTERN.Models
{
    public static class ProdutoCriar
    {
        public static Produto CriarProduto(string tipo)
        {
            return tipo.ToLower() switch
            {
                "digital" => new ProdutoDigital(),
                "fisico" => new ProdutoFisico(),
                _ => throw new ArgumentException("Tipo inválido")
            };
        }
    }
}
