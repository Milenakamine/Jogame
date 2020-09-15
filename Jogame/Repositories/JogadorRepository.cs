using Jogame.Contexts;
using Jogame.Domains;
using Jogame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jogame.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {

        private readonly JogoContext _ctx;
        public JogadorRepository()
        {
            _ctx = new JogoContext();
        }



        //adiciona um jogador
        public void Adicionar(Jogador jogador)
        {
            try
            {
               
                //adiciona o objeto no contexto
                _ctx.Jogadors.Add(jogador);
                //salva as alteracoes
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        //busca um jogador por id
        public Jogador BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Jogadors.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        //busca um jogador por nome
        public List<Jogador> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Jogadors.Where(p => p.Nome.Contains(nome)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        //edita um jogador
        public void Editar(Jogador jogador)
        {
            try
            {
                //busca jogador pelo id
                Jogador jogadorTemp = BuscarPorId(jogador.Id);
                //verifica se o jogador existe no sistema, caso nao exista gera um exception
                if (jogadorTemp == null)
                    throw new Exception("Jogador não encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //caso exista altera suas propriedades
                jogadorTemp.Nome = jogador.Nome;
                jogadorTemp.Email = jogador.Email;
                //questao de seguranca
                jogadorTemp.Senha = jogador.Senha;
                jogadorTemp.DataNasc = jogador.DataNasc;



                //altera jogador no seu contexto
                _ctx.Jogadors.Update(jogadorTemp);
                //salva suas alteraçoes
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }




        public List<Jogador> Listar()
        {
            try
            {
                return _ctx.Jogadors.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        //deleta um jogador
        public void Remover(Guid id)
        {
            try
            {
                //busca jogador pelo id
                Jogador jogadorTemp = BuscarPorId(id);
                //verifica se o jogador existe no sistema, caso nao exista gera um exception
                if (jogadorTemp == null)
                    throw new Exception("Jogador não encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //remove jogador no contexto atual
                _ctx.Jogadors.Remove(jogadorTemp);
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
