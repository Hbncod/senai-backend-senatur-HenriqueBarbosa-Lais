using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Domains
{
    // Define o nome da tabela   
    [Table("Usuarios")]
    public class Usuarios
    {
        //Define q é a chave primária
        [Key]
        //Define a auto incrementação
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Usuario { get; set; }

        // Define o tipo da coluna
        [Column("VARCHAR(150)")]
        // define o máximo de caracteres suportado e devolve uma mensagem de erro
        [StringLength(150, ErrorMessage = "O máximo de caracteres permitido é 150")]
        // Define o tipo do dado
        [DataType(DataType.EmailAddress)]
        // define que o email é obrigatório
        [Required(ErrorMessage ="O E-mail do usuario é obrigatório")]
        public string Email { get; set; }

        // define o tipo da coluna
        [Column("VARCHAR(30)")]
        // define o tipo do dado
        [DataType(DataType.Password)]
        //Define o mínimo e o máximo de caracteres que a senha recebe
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A senha deve conter entre 5 e 30 caracteres.")]
        // Define que a senha é obrigatória
        [Required(ErrorMessage ="A Senha do usuario é obrigatória")]
        public string Senha { get; set; }


        public int Fk_TipoUsuario { get; set; }

        // Define a chave estrangeira
        [ForeignKey("Fk_TipoUsuario")]
        public TiposUsuario TipoUsuario { get; set; }
    }
}
