using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Domains
{
    [Table("Cidades")]
    public class Cidades
    {
        // define a chave primária
        [Key]
        // define a auto incrementação
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Cidade { get; set; }

        // Define o tipo de dado
        [Column(TypeName = "VARCHAR(150)")]
        // define o máximo de caracteres suportado e devolve uma mensagem de erro
        [StringLength(150, ErrorMessage = "O máximo de caracteres permitido é 150")]
        // Define que a propriedade é obrigátória
        [Required(ErrorMessage = "O nome do estado é Obrigatório!")]
        public string Estado { get; set; }

        // Define o tipo de dado
        [Column(TypeName = "VARCHAR(150)")]
        // define o máximo de caracteres suportado e devolve uma mensagem de erro
        [StringLength(150, ErrorMessage = "O máximo de caracteres permitido é 150")]
        // Define que a propriedade é obrigátória
        [Required(ErrorMessage = "O nome da cidade é Obrigatório!")]
        public string NomeCidade { get; set; }

        public List<Pacotes> PacotesnaCidade { get; set; }
    }
}
