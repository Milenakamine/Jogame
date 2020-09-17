using System;
using System.Collections.Generic;
using System.IO;
using Jogame.Domains;
using Jogame.Interfaces;
using Jogame.Repositories;
using Jogame.Utils;
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



        //fromform - recebe os dados via form-data
        [HttpPost]
        public IActionResult Post([FromForm]List<JogoJogadores> jogoJogadores)
        {
            try
            {
                Jogo jogo = jogoRepository.Adicionar(jogoJogadores);

                if (jogo.Imagem != null)
                {
                    var urlImagem = Upload.Local(jogo.Imagem);

                    jogo.UrlImagem = urlImagem ;
                }

             
                return Ok(jogo);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Mostra todos os jogos cadastrado 
        /// </summary>
        /// <returns>Lista com todos os jogos</returns>
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


        /// <summary>
        /// Mostra um único jogo
        /// </summary>
        /// <param name="id">ID do jogo</param>
        /// <returns>Um jogo</returns>
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




        // DELETE api/<JogoController>/5
        /// <summary>
        /// Exclui um jogo
        /// </summary>
        /// <param name="id">ID do jogo</param>
        /// <returns>ID excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //busca o jogo pelo Id
                var jog = jogoRepository.BuscarPorId(id);

                //verifica se o jogo existe
                //caso não exista retorna NotFound
                if (jog == null)
                    return NotFound();

                //caso exista remove o jogador
                jogoRepository.Remover(id);
                //retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        // PUT api/<JogoController>/5
        /// <summary>
        /// Altera determinado jogo
        /// </summary>
        /// <param name="id">ID do jogo</param>
        /// <param name="jogo">Objeto Jogo com as alterações</param>
        /// <returns>Info do jogo alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Jogo jogo)
        {
            try
            {
                //edita o jogo
                jogoRepository.Editar(jogo);

                //retorna o Ok com os dados do jogo
                return Ok(jogo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }



}

