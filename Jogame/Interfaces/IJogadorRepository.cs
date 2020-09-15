using Jogame.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jogame.Interfaces
{
    public interface IJogadorRepository
    {
        
        List<Jogador> Listar();
        Jogador BuscarPorId(Guid id);
        List<Jogador> BuscarPorNome(string nome);
        void Adicionar(Jogador jogador);
        void Editar(Jogador jogador);
        void Remover(Guid id);

    }
}
