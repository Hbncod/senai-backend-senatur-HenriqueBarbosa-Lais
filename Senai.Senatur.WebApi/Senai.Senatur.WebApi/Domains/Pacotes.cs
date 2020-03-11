using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Domains
{
    // Declara o nome da Entidade
    [Table("Pacotes")]
    public class Pacotes
    {
        // define a chave primária
        [Key]
        // declara a auto incrementação
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id_Pacote { get; set; }

        // define que o dado é obrigatório
        [Required (ErrorMessage = "O nome do pacote é obrigatório")]
        // define o tipo da coluna no banco de dados
        [Column(TypeName = "VARCHAR (100)")]
        // define o máximo de caracteres suportado e devolve uma mensagem de erro
        [StringLength(100, ErrorMessage = "O máximo de caracteres permitido é 100")]
            public string NomePacote { get; set; }

        // define o tipo da coluna no banco de dados
        [Column(TypeName = "NVARCHAR(MAX)")]
        // define o máximo de caracteres suportado e devolve uma mensagem de erro
        [StringLength(1500, ErrorMessage = "O máximo de caracteres permitido é 1500")]
        // define que o dado é obrigatório
        [Required(ErrorMessage = "a Descrição é obrigatória")]
        // Representa o texto que é exibido.
        [DataType(DataType.Text)]
            public string Descricao { get; set; }
        
        // define que é obrigatório
        [Required(ErrorMessage = "a Data de ida é obrigatória")]
        // define o tipo da coluna no banco de dados
        [Column(TypeName = "DATE")]
        // Representa um valor de data
        [DataType(DataType.Date)]
            public DateTime DataIda { get; set; }

        // define que é obrigatório
        [Required(ErrorMessage = "a Data de volta é obrigatória")]
        // define o tipo da coluna no banco de dados
        [Column(TypeName = "DATE")]
        [DataType(DataType.Date)]
            public DateTime DataVolta { get; set; }

        // define que é obrigatório
        [Required(ErrorMessage ="O valor é obrigatório")]
        // define o tipo e nome da coluna no banco de dados
        [Column("Preco", TypeName = "DECIMAL (18,2)")]
        [DataType(DataType.Currency)]
            public decimal Valor { get; set; }

        // define o tipo da coluna no banco de dados
        [Column(TypeName = "BIT")]
            public bool Ativo { get; set; }

        // define que é obrigatório
        [Required(ErrorMessage ="É necessário informar a cidade do pacotes")]
            public int Fk_NomeCidade { get; set; }
        
        // define a chave estrangeira
        [ForeignKey("Fk_NomeCidade")]
        
            public Cidades Cidade { get; set; }

       
    }
}
