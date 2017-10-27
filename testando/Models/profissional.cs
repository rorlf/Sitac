using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace testando.Models
{

    

   

        [Table("tb_profissional", Schema = "public")]
        public class Profissional
    {

        public string cpf { get; set; }
        public string nome { get; set; }
       
        public DateTime? data_nascimento { get; set; }

        public int id { get; set; }
    }
}