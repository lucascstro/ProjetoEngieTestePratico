using ProjetoEngieTestePratico.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngieTestePratico.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        private readonly Context _context = new Context();

        //retorna todos os fornecedores
        public List<Fornecedor> PegarTodos()
        {
            return _context.Fornecedor.OrderBy(x => x.Nome).ToList();
        }
    }
}