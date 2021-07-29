using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngieTestePratico.Models
{
    public class Usina
    {
        public int Id { get; set; }
        public int Uc { get; set; }
        public string Fornecedor { get; set; }
        public bool Ativo { get; set; }
    }
}