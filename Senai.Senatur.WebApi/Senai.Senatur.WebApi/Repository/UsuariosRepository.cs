using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Context;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        SenaturContext ctx = new SenaturContext();

        public Usuarios BuscarPorEmailSenha(string Email, string Senha)
        {
            return ctx.Usuarios.FirstOrDefault(usu => usu.Email == Email && usu.Senha == Senha);

        }

        public List<Usuarios> ListarUsuarios()
        {
            return ctx.Usuarios.Include(usu => usu.TipoUsuario).ToList();
        }
    }
}
