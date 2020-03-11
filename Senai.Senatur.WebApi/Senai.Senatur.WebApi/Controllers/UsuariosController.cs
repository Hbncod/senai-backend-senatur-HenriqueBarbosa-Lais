using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repository;

namespace Senai.Senatur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository { get; set; }

        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }
        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>uma lista de usuarios</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IEnumerable<Usuarios> ListarUsuarios()
        {
            return _usuariosRepository.ListarUsuarios();
        }
    }
}