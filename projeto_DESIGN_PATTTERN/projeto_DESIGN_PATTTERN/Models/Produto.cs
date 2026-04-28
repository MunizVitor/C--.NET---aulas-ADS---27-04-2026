namespace projeto_DESIGN_PATTTERN.Models
{
    public abstract class Produto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NomeProduto { get; set; } = string.Empty;
        public string DescricaoProduto { get; set; } = string.Empty;
        public double PrecoProduto { get; set; } = 0.0;

        public abstract string Tipo { get; }
    }

    public class ProdutoDigital : Produto
    {
        public string LinkDownload { get; set; } = string.Empty;
        public override string Tipo => "Digital";
    }

    public class ProdutoFisico : Produto
    {
        public double Peso { get; set; }
        public override string Tipo => "Físico";
    }
}
