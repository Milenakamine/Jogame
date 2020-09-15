using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jogame.Domains;
using Jogame.Interfaces;
using Jogame.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jogame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoRepository jogoRepository;
        public JogosController()
        {
            jogoRepository = new JogoRepository();
        }



        [HttpPost]
        public IActionResult Post(List<JogoJogadores> jogoJogadores)
        {
            try
            {
                Jogo jogo = jogoRepository.Adicionar(jogoJogadores);
                return Ok(jogo);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var jogos = jogoRepository.Listar();

                if (jogos.Count == 0)
                    return NoContent();

                return Ok(jogos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var jogo = jogoRepository.BuscarPorId(id);

                if (jogo == null)
                    return NotFound();

                return Ok(jogo);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }



}

