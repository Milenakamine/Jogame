using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Jogame.Domains;
using Jogame.Interfaces;
using Jogame.Repositories;
using Jogame.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jogame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorsController : ControllerBase
    {
        private readonly IJogadorRepository jogadorRepository;
        
        public JogadorsController()
        {
            jogadorRepository = new JogadorRepository();
        }




        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //lista de jogadores
                var jogadors = jogadorRepository.Listar();

                //verifica se existe no conxtexto atual
                //caso nao exista ele retorna NoContext
                if (jogadors.Count == 0)
                    return NoContent();

                //caso exista retorno Ok e o total de jogadores cadastrados
                return Ok(new
                {
                    totalCount = jogadors.Count,
                    data = jogadors
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        // GET api/<JogadorsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //busca jogador por id
                Jogador jog  = jogadorRepository.BuscarPorId(id);

                //faz a verificacao no contexto para ver se o jogador foi encontrado 
                //caso nao for encontrado o sistema retornara NotFound 
                if (jog == null)
                    return NotFound();

                //se existir retorno vai passar o Ok e os dados do jogador  
                return Ok(jog);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }


        // POST api/<JogadorsController>
        [HttpPost]
        public IActionResult Post([FromForm]Jogador jogador)
        {
            try
            {


                if (jogador.Imagem != null)
                {
                    var urlImagem = Upload.Local(jogador.Imagem);

                    jogador.UrlImagem = urlImagem;
                }





                //adiciona um novo jogador
                jogadorRepository.Adicionar(jogador);

                //retorna Ok se o jogador tiver sido cadastrado
                return Ok(jogador);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }




        // PUT api/<JogadorsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Jogador jogador)
        {
            try
            {
                //edita o jogador
                jogadorRepository.Editar(jogador);

                //retorna o Ok com os dados do jogador
                return Ok(jogador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        // DELETE api/<JogadorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //busca o jogador pelo Id
                var jog = jogadorRepository.BuscarPorId(id);

                //verifica se o jogador existe
                //caso não exista retorna NotFound
                if (jog == null)
                    return NotFound();

                //caso exista remove o jogador
                jogadorRepository.Remover(id);
                //retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
