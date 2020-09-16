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




        public List<Jogo> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Jogos.Where(p => p.Nome.Contains(nome)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }




        public void Editar(Jogo jogo)
        {
            try
            {
                //busca jogo pelo id
                Jogo jogoTemp = BuscarPorId(jogo.Id);
                //verifica se o jogo existe no sistema, caso nao exista gera um exception
                if (jogoTemp == null)
                    throw new Exception("Jogo não encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //caso exista altera suas propriedades
                jogoTemp.Nome = jogo.Nome;
                jogoTemp.Descricao = jogo.Descricao;
                jogoTemp.OrderDate = jogo.OrderDate;



                //altera jogo no seu contexto
                _ctx.Jogos.Update(jogoTemp);
                //salva suas alteraçoes
                _ctx.SaveChanges();

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





        public void Remover(Guid id)
        {
            try
            {
                //busca jogo pelo id
                Jogo jogoTemp = BuscarPorId(id);
                //verifica se o jogo existe no sistema, caso nao exista gera um exception
                if (jogoTemp == null)
                    throw new Exception("Jogo não encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //remove jogo no contexto atual
                _ctx.Jogos.Remove(jogoTemp);
                //salva as alteraçoes
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
