using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaInterativa.Data;
using LojaInterativa.Models;
using LojaInterativa.ViewModels.Produto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaInterativa.Controllers
{
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpPost("produto")]
        public async Task<IActionResult> CriarProduto(
            [FromBody] CriaProdutoViewModel model,
            [FromServices] DataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var produto = new Produto
            {
                idProduto = 0,
                descricaoProduto = model.descricaoProduto,
                precoProduto = model.precoProduto,
                idFabricante = model.idFabricante,
                Categoria = model.categoriaProduto
            };

            try
            {
                var categoriaDb = await context.Fabricantes
                    .Where(x => x.categoria1 == model.categoriaProduto || x.categoria2 == model.categoriaProduto || x.categoria3 == model.categoriaProduto)
                    .FirstOrDefaultAsync();

                if (categoriaDb == null)
                    return NotFound();
                if (categoriaDb.idFabricante != model.idFabricante)
                    return BadRequest("Esse fabricante não contem essa categoria");

                await context.Produtos.AddAsync(produto);
                await context.SaveChangesAsync();

                return Ok(new
                {
                    produto = model.descricaoProduto,
                    mensagem = "Produto criado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno - {ex.Message}");
            }
        }

        [HttpGet("produto")]
        public async Task<IActionResult> ColecaoProdutos(
            [FromServices] DataContext context
        )
        {
            try
            {
                var produto = await context
                    .Produtos
                    .Include(x => x.Fabricante)
                    .Select(x => new
                    {
                        idProduto = x.idProduto,
                        descricaoProduto = x.descricaoProduto,
                        nomeFabricante = x.Fabricante.nomeFabricante,
                        nomeCategoria = x.Categoria,
                        precoProduto = x.precoProduto,
                        idFabricante = x.idFabricante
                    })
                    .ToListAsync();

                if (produto.Count == 0)
                    return NotFound("Nenhum produto encontrado");

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno - {ex.Message}");
            }
        }

        [HttpPut("produto")]
        public async Task<IActionResult> EditarProduto(
            [FromBody] EditarProdutoViewModel model,
            [FromServices] DataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var produtoDb = await context.Produtos.FirstOrDefaultAsync(x => x.idProduto == model.idProduto);
            var categoriaDb = await context.Fabricantes
                    .Where(x => x.categoria1 == model.categoriaProduto || x.categoria2 == model.categoriaProduto || x.categoria3 == model.categoriaProduto)
                    .FirstOrDefaultAsync();

            if (categoriaDb == null)
                return NotFound();
            if (categoriaDb.idFabricante != model.idFabricante)
                return BadRequest("Esse fabricante não contem essa categoria");

            produtoDb.descricaoProduto = model.descricaoProduto;
            produtoDb.precoProduto = model.precoProduto;
            produtoDb.idFabricante = model.idFabricante;
            produtoDb.Categoria = model.categoriaProduto;
            try
            {
                context.Produtos.Update(produtoDb);
                await context.SaveChangesAsync();

                return Ok(new
                {
                    produto = model.descricaoProduto,
                    mensagem = "Produto editado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno - {ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(
            [FromRoute] int id,
            [FromServices] DataContext context
        )
        {
            try
            {
                var produto = await context.Produtos.FirstOrDefaultAsync(x => x.idProduto == id);
                if (produto == null)
                    return NotFound(new
                    {
                        erro = "Produto não encontrado"
                    });

                context.Produtos.Remove(produto);
                await context.SaveChangesAsync();

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno - {ex.Message}");
            }
        }
    }
}