using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace testando.Models
{
    [Table("tb_protocolo", Schema = "public")]
    public class protocolo
    {

        public int ano { get; set; }
        public int id { get; set; }
        public DateTime? data_cadastro { get; set; }
        public DateTime? data_prazo { get; set; }
        public int? protocolo_status_id { get; set; }

       
    }
}