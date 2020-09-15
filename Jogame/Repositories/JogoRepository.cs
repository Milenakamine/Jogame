using Jogame.Contexts;
using Jogame.Domains;
using Jogame.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jogame.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly JogoContext _ctx;
        public JogoRepository()
        {
            _ctx = new JogoContext();
        }



        public Jogo Adicionar(List<JogoJogadores> jogoJogadores)
        {
            try
            {
                //criacao do objeto ja passando os valores
                Jogo jogo = new Jogo
                {
                    Nome = "God of War",
                    Descricao = "God of War é uma série de jogos eletrônicos de ação-aventura vagamente baseado nas mitologias grega e nórdica sendo criado originalmente por David Jaffe da Santa Monica Studio. Iniciada em 2005, a série tornou-se carro-chefe para a marca PlayStation, que consiste em oito jogos em várias plataformas",
                    OrderDate = DateTime.Now,
                };

                foreach (var item in jogoJogadores)
                {
                    //adiciona um alunoescola a lista
                    jogo.JogosJogadores.Add(new JogoJogadores
                    {

                        IdJogo = jogo.Id,
                        IdJogador = item.IdJogador

                    });
                }
                _ctx.Jogos.Add(jogo);
                _ctx.SaveChanges();

                return jogo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        


        public Jogo BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Jogos
                    .Include(c => c.JogosJogadores)
                    .ThenInclude(c => c.Jogador)
                    .FirstOrDefault(p => p.Id == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        public List<Jogo> Listar()
        {
            try
            {
                return _ctx.Jogos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
