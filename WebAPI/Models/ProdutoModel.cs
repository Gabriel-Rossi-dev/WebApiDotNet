namespace WebAPI.Models {
    public class ProdutoModel {


        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
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
            this.Ativo = true;

        }

        public void SoftDelete(ref ProdutoModel produto) {
            produto.Ativo = false;
        }

        public void ProductDtoChangesPatch(ProdutoModelDto produtoModelDto) {

            this.Nome = string.IsNullOrEmpty(produtoModelDto.Nome) ? this.Nome : produtoModelDto.Nome;
            this.Descricao = string.IsNullOrEmpty(produtoModelDto.Descricao) ? this.Descricao : produtoModelDto.Descricao;
            this.CodigoDeBarras = string.IsNullOrEmpty(produtoModelDto.CodigoDeBarras) ? this.CodigoDeBarras : produtoModelDto.CodigoDeBarras;
            this.Marca = string.IsNullOrEmpty(produtoModelDto.Marca) ? this.Marca : produtoModelDto.Marca;
            //this.Ativo = true; O produto que está sendo alterado sempre terá que estar ativo, se não estiver ativo não deve ser possível alterar qualquer informação.
        }

        public bool ProductDtoChangesPut(ProdutoModelDto produtoModelDto) {

            if (!string.IsNullOrEmpty(produtoModelDto.Nome) && !string.IsNullOrEmpty(produtoModelDto.Descricao) && !string.IsNullOrEmpty(produtoModelDto.CodigoDeBarras) && !string.IsNullOrEmpty(produtoModelDto.Marca)) {

                this.Nome = produtoModelDto.Nome;
                this.Descricao = produtoModelDto.Descricao;
                this.CodigoDeBarras = produtoModelDto.CodigoDeBarras;
                this.Marca = produtoModelDto.Marca;
                this.Ativo = true;
                return true;
            }
            return false;
        }


    }
}
