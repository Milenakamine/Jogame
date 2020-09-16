using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jogame.Domains
{
    public class Jogador : BaseDomain
    {
        public  string Nome { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime DataNasc { get; set; }


        [NotMapped]
        //não mapeia a propriedade no banco de dados
        [JsonIgnore]
        public IFormFile Imagem { get; set; }

        //url da imagem no salva no servidor
        public string UrlImagem { get; set; }

        public  List<JogoJogadores> JogosJogadores{ get; set; }




    }
}
