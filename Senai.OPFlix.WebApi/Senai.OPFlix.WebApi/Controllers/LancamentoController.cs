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
    public class LancamentoController : ControllerBase
    {
        LancamentoRepository LancamentoRepository = new LancamentoRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LancamentoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamentos)
        {
            try
            {
                LancamentoRepository.Cadastrar(lancamentos);
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
            Lancamentos lancamentos = LancamentoRepository.BuscarPorId(id);
            if (lancamentos == null)
                return NotFound();
            return Ok(lancamentos);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            LancamentoRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(Lancamentos lancamentos)
        {
            try
            {
                Lancamentos LancamentoBuscado = LancamentoRepository.BuscarPorId(lancamentos.IdLancamento);
                if (LancamentoBuscado == null)
                    return NotFound();
                LancamentoRepository.Atualizar(lancamentos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Deu Erro" } + ex.Message);
            }
        }
    }
}