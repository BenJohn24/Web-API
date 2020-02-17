using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SubirWebAPI.Models
{
    [Table("OBRAS")]
    public class Obra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("IDLibro")]
        public int IdLibro { get; set; }
        [Column("Titulos")]
        public String Titulo { get; set; }
        [Column("Autores")]
        public String Autor { get; set; }
        [Column("Paginas")]
        public int Pag { get; set; }
    }
}