using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jogame.Domains
{
    public class JogoJogadores : BaseDomain
    {
        public Guid IdJogador { get; set; }
        [ForeignKey("IdJogador")]
        public Jogador Jogador { get; set; }

        public Guid IdJogo { get; set; }
        [ForeignKey("IdJogo")]
        public Jogo Jogo { get; set; }
    }
}
