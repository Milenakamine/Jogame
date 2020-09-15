using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jogame.Domains;


namespace Jogame.Contexts
{
    public class JogoContext : DbContext
    {
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Jogador> Jogadors { get; set; }
        public DbSet<JogoJogadores> JogosJogadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=LAB107401\SQLEXPRESS;Initial Catalog=Db_Senai_Jogame;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
