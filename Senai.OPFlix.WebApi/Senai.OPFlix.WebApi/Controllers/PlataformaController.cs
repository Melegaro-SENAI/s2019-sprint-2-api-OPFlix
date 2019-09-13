using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OPFlix.WebApi.Domains;
using Senai.OPFlix.WebApi.Repositories;

namespace Senai.OPFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PlataformaController : ControllerBase
    {
        PlataformaRepository PlataformaRepository = new PlataformaRepository();

        [HttpGet]
        public IActionResult listar()
        {
            return Ok(PlataformaRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Plataformas plataformas)
        {
            try
            {
                PlataformaRepository.Cadastrar(plataformas);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, erro: " + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Plataformas plataformas = PlataformaRepository.BuscarPorId(id);
            if (plataformas == null)
                return NotFound();
            return Ok(plataformas);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            PlataformaRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(Plataformas plataformas)
        {
            try
            {
                Plataformas PlataformaBuscada = PlataformaRepository.BuscarPorId(plataformas.IdPlataforma);
                if (PlataformaBuscada == null)
                    return NotFound();
                PlataformaRepository.Atualizar(plataformas);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Deu Erro" } + ex.Message);
            }
        }
    }
}