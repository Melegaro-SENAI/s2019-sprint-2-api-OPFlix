using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OPFlix.WebApi.Domains;
using Senai.OPFlix.WebApi.Repositories;

namespace Senai.OPFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        CategoriaRepository CategoriaRepository = new CategoriaRepository();
        
        // [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }

        // [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Categoria categorias)
        {
            try
            {
                CategoriaRepository.Cadastrar(categorias);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, erro: " + ex.Message });
           }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categoria categorias = CategoriaRepository.BuscarPorId(id);
            if (categorias == null)
                return NotFound();
            return Ok(categorias);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            CategoriaRepository.Deletar(id);
            return Ok();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult Atualizar(Categoria categoria)
        {
            try
            {
                Categoria CategoriaBuscada = CategoriaRepository.BuscarPorId(categoria.IdCategoria);
                if (CategoriaBuscada == null)
                    return NotFound();
                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Deu Erro" } + ex.Message);
            }
        }
    }
}