﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jogame.Domains
{
    public class Jogador : BaseDomain
    {

        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime DataNasc { get; set; }

        public  List<JogoJogadores> JogosJogadores{ get; set; }




    }
}
