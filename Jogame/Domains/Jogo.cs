using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jogame.Domains
{
    public class Jogo : BaseDomain
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime OrderDate { get; set; }

        public List<JogoJogadores> JogosJogadores { get; set; }

        public Jogo()
        {
            JogosJogadores = new List<JogoJogadores>();
        }

    }
}
