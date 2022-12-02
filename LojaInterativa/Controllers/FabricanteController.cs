using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaInterativa.Data;
using LojaInterativa.Models;
using LojaInterativa.ViewModels.Fabricante;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaInterativa.Controllers
{
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        [HttpPost("fabricante")]
        public async Task<IActionResult> CriarFabricante(
            [FromBody] CriarFabricanteViewModel model,
            [FromServices] DataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var fabricante = new Fabricante
            {
                idFabricante = 0,
                nomeFabricante = model.nomeFabricante,
                categoria1 = model.categoria1,
                categoria2 = model.categoria2,
                categoria3 = model.categoria3
            };

            try
            {
                await context.Fabricantes.AddAsync(fabricante);
                await context.SaveChangesAsync();

                return Ok(fabricante);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno - {ex.Message}");
            }
        }

        [HttpGet("fabricante")]
        public async Task<IActionResult> PegarFabricantes(
            [FromServices] DataContext context
        )


        {
            try
            {
                var fabricantes = await context.Fabricantes
                    .Select(x => new
                    {
                        idFabricante = x.idFabricante,
                        nomeFabricante = x.nomeFabricante,
                        categorias = new string[]
                        {
                            x.categoria1,
                            x.categoria2,
                            x.categoria3
                        },

                    })
                    .ToListAsync();

                if (fabricantes.Count == 0)
                    return BadRequest();

                return Ok(fabricantes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno - {ex.Message}");
            }
        }
    }
}