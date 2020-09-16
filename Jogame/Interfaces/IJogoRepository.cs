using Jogame.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jogame.Interfaces
{
    public interface IJogoRepository
    {
        
        List<Jogo> Listar();
        Jogo BuscarPorId(Guid id);

        List<Jogo> BuscarPorNome(string nome);

        Jogo Adicionar(List<JogoJogadores> jogoJogadores);

        void Editar(Jogo jogo);
        void Remover(Guid id);



    }
}
