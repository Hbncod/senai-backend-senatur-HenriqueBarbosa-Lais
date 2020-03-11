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
    public class PacotesController : ControllerBase
    {
        private IPacotesRepository _pacotesRepository { get; set; }

        public PacotesController()
        {
            _pacotesRepository = new PacotesRepository();
        }
        /// <summary>
        /// Lista todos os pacotes
        /// </summary>
        /// <returns>Uma lista de pacotes</returns>
        [Authorize]
        [HttpGet]
        public IEnumerable<Pacotes> ListarPacotes()
        {
            return _pacotesRepository.ListarPacotes();
        }

        /// <summary>
        /// Busca um Pacote por id
        /// </summary>
        /// <param name="id">id buscado</param>
        /// <returns>Retorna o pacote referente ao id enviado</returns>
        [Authorize(Roles = "1")]
        [HttpGet("buscar/{id}")]
        public Pacotes BuscarPorId(int id)
        {
            return _pacotesRepository.BuscarPorId(id);
        }

        /// <summary>
        /// Cadastra novos pacotes
        /// </summary>
        /// <param name="Novopacote">Os dados do novo usuario</param>
        /// <returns>como este pacote ficou</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Pacotes Novopacote)
        {
            _pacotesRepository.Cadastrar(Novopacote);
            return Created("O Usuario foi criado com sucesso", Novopacote);
        }

        /// <summary>
        /// Atualiza um pacote
        /// </summary>
        /// <param name="id">id do pacote a ser atualizado</param>
        /// <param name="pacoteatualizado">dados a serem atualizado</param>
        /// <returns>Ok</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Pacotes pacoteatualizado)
        {
            _pacotesRepository.Alterar(id, pacoteatualizado);
            return Ok("O pacote foi atualizado com sucesso");
        }
    }
}