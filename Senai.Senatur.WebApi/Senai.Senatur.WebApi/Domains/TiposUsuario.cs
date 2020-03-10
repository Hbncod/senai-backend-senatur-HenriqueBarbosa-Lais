using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Tiposusuario
    /// </summary>
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        // define q é a chave primária
        [Key]
        // Define o auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_TipoUsuario { get; set; }


        // Define o tipo de dado
        [Column(TypeName = "VARCHAR (100)")]
        // define o máximo de caracteres suportado e devolve uma mensagem de erro
        [StringLength(100,ErrorMessage = "O máximo de caracteres permitido é 100")]
        // Define que é uma propriedade obrigatória
        [Required(ErrorMessage = "O Titulo de um Tipo de Usuario é obrigatório")]
        public string Titulo { get; set; }
    }
}
