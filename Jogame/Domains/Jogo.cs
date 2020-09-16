using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jogame.Domains
{
    public class Jogo : BaseDomain
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime OrderDate { get; set; }


        [NotMapped]
        //não mapeia a propriedade no banco de dados
        [JsonIgnore]
        public IFormFile Imagem { get; set; }

        //url da imagem no salva no servidor
        public string UrlImagem { get; set; }



        public List<JogoJogadores> JogosJogadores { get; set; }

        public Jogo()
        {
            JogosJogadores = new List<JogoJogadores>();
        }

    }
}
