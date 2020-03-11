using Senai.Senatur.WebApi.Context;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repository
{
    public class PacotesRepository : IPacotesRepository
    {

        SenaturContext ctx = new SenaturContext();

        public void Alterar(int id,Pacotes AlteracoesPacote)
        {
            // busca um pacote através do id
            Pacotes PacoteBuscado = ctx.Pacotes.Find(id);

            if (AlteracoesPacote.Cidade != null)
            {
                PacoteBuscado.Cidade = AlteracoesPacote.Cidade;
            }
            if (AlteracoesPacote.DataIda != null)
            {
                PacoteBuscado.DataIda = AlteracoesPacote.DataIda;
            }
            if (AlteracoesPacote.DataVolta != null)
            {
                PacoteBuscado.DataVolta = AlteracoesPacote.DataVolta;
            }
            if (AlteracoesPacote.Descricao != null)
            {
                PacoteBuscado.Descricao = AlteracoesPacote.Descricao;
            }
            if (AlteracoesPacote.NomePacote != null)
            {
                PacoteBuscado.NomePacote = AlteracoesPacote.NomePacote;
            }
            if (AlteracoesPacote.Valor != null)
            {
                PacoteBuscado.Valor = AlteracoesPacote.Valor;
            }
            if (AlteracoesPacote.Fk_NomeCidade != null)
            {
                PacoteBuscado.Fk_NomeCidade = AlteracoesPacote.Fk_NomeCidade;
            }

            ctx.Pacotes.Update(PacoteBuscado);



        }

        public Pacotes BuscarPorId(int id)
        {
            

            Pacotes PacoteEncontrado = ctx.Pacotes.Find(id);

            return PacoteEncontrado;
        }


        public void Cadastrar(Pacotes NovoPacote)
        {
            NovoPacote.Id_Pacote = 0; // Declaro q o id é 0 para q se o usuario me enviar um id não acorra um erro;
            ctx.Pacotes.Add(NovoPacote);

            ctx.SaveChanges();
        }


        public List<Pacotes> ListarPacotes()
        {
            return ctx.Pacotes.ToList();
        }
    }
}
