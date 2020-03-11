using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Context
{
    /// <summary>
    /// Classe responsável pelo contexto do projeto
    /// faz a comunicação entre API e Banco de Dados
    /// </summary>
    public class SenaturContext : DbContext
    {
        // Define as entidades do banco de dados
        public DbSet<TiposUsuario> TiposUsuario { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Cidades> Cidades { get; set; }

        public DbSet<Pacotes> Pacotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Mude seu "Server" para conseguir compilar em seu computador obs: Lembre-se de alterar de uma \ para duas 
            optionsBuilder.UseSqlServer("Server=DEV102\\SQLEXPRESS; Database=SenaTur_CodeFirst; user Id=sa; pwd=sa@132;"); 

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Define o modelo de criação do bnco
        /// </summary>
        /// <param name="modelBuilder">Objeto com modelos que serão criados</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define as entidades já com dados
            modelBuilder.Entity<TiposUsuario>(entity => {
                entity
                .HasIndex(tu => tu.Titulo)
                .IsUnique();

                entity.HasData(
                new TiposUsuario
                {
                    Id_TipoUsuario = 1,
                    Titulo = "Administrador"
                },
                new TiposUsuario
                {
                    Id_TipoUsuario = 2,
                    Titulo = "Cliente"
                });
            });
            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity
                .HasIndex(usu => usu.Email)
                .IsUnique();
                
                entity
                .HasData(
                new Usuarios
                {
                    Id_Usuario = 1,
                    Email = "admin@admin.com",
                    Senha = "admin",
                    Fk_TipoUsuario = 1
                },
                new Usuarios
                {
                    Id_Usuario = 2,
                    Email = "cliente@cliente.com",
                    Senha = "cliente",
                    Fk_TipoUsuario = 2
                });
            });
            modelBuilder.Entity<Cidades>(entity =>
            {
                entity.
                    HasIndex(usu => usu.NomeCidade)
                    .IsUnique();
                entity
                    .HasData
                    (
                    new Cidades
                    {
                        Id_Cidade = 1,
                        NomeCidade = "Salvador",
                        Estado = "Bahia"
                    },
                    new Cidades
                    {
                        Id_Cidade = 2,
                        NomeCidade = "Bonito",
                        Estado = "Mato Grosso do sul"
                    });
            });
            modelBuilder.Entity<Pacotes>(entity =>
            {
                entity.HasData(
                    new Pacotes
                    {
                        Id_Pacote = 1,
                        NomePacote = "SALVADOR - 5 DIAS / 4 DIÁRIAS",
                        Descricao = "O que não falta em Salvador são atrações.Prova disso são as praias, os museus e as construções seculares que dão um charme mais que especial à região.A cidade, sinônimo de alegria, também é conhecida pela efervescência cultural que a credenciou como um dos destinos mais procurados por turistas brasileiros e estrangeiros.O Pelourinho e o Elevador são alguns dos principais pontos de visitação.",
                        DataIda = Convert.ToDateTime("06/08/2020"),
                        DataVolta = Convert.ToDateTime("10/08/2020"),
                        Valor = Convert.ToDecimal("854,00"),
                        Ativo = Convert.ToBoolean(1),
                        Fk_NomeCidade = 1,
                    },
                    new Pacotes
                    {
                        Id_Pacote = 2,
                        NomePacote = "RESORTS NA BAHIA - LITORAL NORTE - 5 DIAS / 4 DIÁRIAS",
                        Descricao = "O Litoral Norte da Bahia conta com inúmeras praias emolduradas por coqueiros, além de piscinas naturais de águas mornas que são protegidas por recifes e habitadas por peixes coloridos. Banhos de mar em águas calmas ou agitadas, mergulho com snorkel, caminhada pela orla e calçadões, passeios de bicicleta, pontos turísticos históricos, interação com animais e até baladas estão entre as atrações da região. Destacam-se as praias de Guarajuba, Imbassaí, Praia do Forte e Costa do Sauipe.",
                        DataIda = Convert.ToDateTime("14/05/2020"),
                        DataVolta = Convert.ToDateTime("18/05/2020"),
                        Valor = Convert.ToDecimal("1826,00"),
                        Ativo = Convert.ToBoolean(1),
                        Fk_NomeCidade = 1
                    },
                    new Pacotes
                    {
                        Id_Pacote =3,
                        NomePacote = "BONITO VIA CAMPO GRANDE - 1 PASSEIO - 5 DIAS / 4 DIÁRIAS",
                        Descricao = "Localizado no estado de Mato Grosso do Sul e ao sul do Pantanal, Bonito possui centenas de cachoeiras, rios e lagos de águas cristalinas, além de cavernas inundadas, paredões rochosos e uma infinidade de peixes. Os aventureiros costumam render-se facilmente a esse destino regado por trilhas ecológicas, passeios de bote e descidas de rapel pelas inúmeras quedas d'água da região",
                        DataIda = Convert.ToDateTime("28/03/2020"),
                        DataVolta = Convert.ToDateTime("01/04/2020"),
                        Valor = Convert.ToDecimal("1004,00"),
                        Fk_NomeCidade = 2
                    });
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
