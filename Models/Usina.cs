using ProjetoEngieTestePratico.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngieTestePratico.Models
{
    public class Usina
    {
        public int Id { get; set; }
        public string Uc { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int IdFornecedor { get; set; }
        public bool Ativo { get; set; }

        private readonly Context _context = new Context();

        //retorna todos os fornecedores
        public List<Usina> PegarTodos()
        {
            return _context.Usina.OrderBy(x => x.IdFornecedor).ToList();
        }

    }
}