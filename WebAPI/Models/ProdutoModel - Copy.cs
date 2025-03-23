namespace WebAPI.Models {
    public class ProdutoModel {

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty ;
        public int QuantidadeEstoque { get; set; }
        public string CodigoDeBarras { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public bool Ativo { get; set; }

        public void UpdateProduct(ProdutoModel produto) {
            this.Nome = produto.Nome;
            this.Descricao = produto.Descricao;
            this.QuantidadeEstoque = produto.QuantidadeEstoque;
            this.CodigoDeBarras = produto.CodigoDeBarras;
            this.Marca = produto.Marca;
            this.Ativo = produto.Ativo;

        }

        public void SoftDelete(ref ProdutoModel produto) {
            produto.Ativo = false;
        }
    }
}
