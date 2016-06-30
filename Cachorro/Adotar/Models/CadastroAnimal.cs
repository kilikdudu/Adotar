using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adotar.Models
{
    public class CadastroAnimal
    {
        public string Nome { get; set; }
        public long Raca_id { get; set; }
        public long Idade { get; set; }
        public long Sexo_id { get; set; }
        public string Cor { get; set; }
        public string Detalhes { get; set; }
        public HttpPostedFileBase Foto { get; set; }
    }
}