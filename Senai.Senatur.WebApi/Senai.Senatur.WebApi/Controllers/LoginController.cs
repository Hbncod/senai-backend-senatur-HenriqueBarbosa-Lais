using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repository;
using Senai.Senatur.WebApi.ViewModel;

namespace Senai.Senatur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository { get; set; }

        public LoginController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        /// <summary>
        /// Faz o login
        /// </summary>
        /// <param name="Login">recebe os dados a serem comparados com nosso banco</param>
        /// <returns>o token do usuario</returns>
        [HttpPost]
        public IActionResult Login(UsuarioViewModel Login)
        {
            Usuarios usuariobuscado = _usuariosRepository.BuscarPorEmailSenha(Login.Email, Login.Senha);

            if (usuariobuscado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email,usuariobuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuariobuscado.Id_Usuario.ToString()),
                new Claim(ClaimTypes.Role, usuariobuscado.Fk_TipoUsuario.ToString())
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Senatur-chave-autenticacao"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // Gera o token
            var token = new JwtSecurityToken(
                issuer: "Senatur.WebApi",                // emissor do token
                audience: "Senatur.WebApi",              // destinatário do token
                claims: claims,                         // dados definidos acima
                expires: DateTime.Now.AddMinutes(30),   // tempo de expiração
                signingCredentials: creds               // credenciais do token
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

    }
}