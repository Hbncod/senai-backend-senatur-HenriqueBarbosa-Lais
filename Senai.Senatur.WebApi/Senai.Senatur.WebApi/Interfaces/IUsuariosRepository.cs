using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IUsuariosRepository
    {
        /// <summary>
        /// Cria uma lista com todos os usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        List<Usuarios> ListarUsuarios();

        Usuarios BuscarPorEmailSenha(String Email, String Senha);



    }
}
