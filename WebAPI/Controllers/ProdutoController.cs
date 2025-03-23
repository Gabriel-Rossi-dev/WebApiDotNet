using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase {

        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context) {
            _context = context;
        }

        [HttpGet("produtos")]
        public ActionResult<List<ProdutoModel>> SearchProdutc() {

            var produtos = _context.Produtos.Where(productModel => productModel.Ativo).ToList();
            return Ok(produtos.ToList());
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProdutoModel> SearchProdutcById(int id) {

            var produto = _context.Produtos.Find(id);
            if (produto == null || produto.Ativo == false) {
                return NotFound("Produto não encontrado!");
            }
            return Ok(produto);
        }

        [HttpPost("inserir")]
        public ActionResult<ProdutoModel> InsertProduct(ProdutoModelDto produtoModelDto) {

            if (produtoModelDto == null) {
                return BadRequest("Ocorreu um erro na solicitação!");
            }

            ProdutoModel produtoModel = new ProdutoModel();

            produtoModel.ProductDtoChangesPatch(produtoModelDto);


            _context.Add(produtoModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchProdutcById), new { id = produtoModel.Id }, produtoModel);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<ProdutoModel> ProductSoftDelete(int id) {

            var product = _context.Produtos.Find(id);
            if (product == null || product.Ativo is false) {
                return NotFound("Produto não encontrado!");
            }

            product.SoftDelete(ref product);
            _context.Update(product);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<ProdutoModel> UpdateProduct(ProdutoModelDto produtoModelDto, int id) {

            var product = _context.Produtos.Find(id);
            if (product == null || product.Ativo is false) {
                return NotFound("Produto não encontrado!");
            }

            if (product.ProductDtoChangesPut(produtoModelDto)) {
                _context.Produtos.Update(product);
                _context.SaveChanges();
                return NoContent();
            }
            return BadRequest("Ocorreu um erro na solicitação!");

        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<ProdutoModel> SoftUpdate(ProdutoModelDto produtoModelDto, int id) {

            var product = _context.Produtos.Find(id);
            if (product == null || product.Ativo is false) {
                return NotFound("Produto não encontrado!");
            }

            ProdutoModel produtoModel = new ProdutoModel();

            product.ProductDtoChangesPatch(produtoModelDto);
            _context.Produtos.Update(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
