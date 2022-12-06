using WebAppUncafezin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppUncafezin.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto) { }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }

        public void SaveProdutos(List<Bebida> bebidas)
        {
            foreach (var Bebida in bebidas)
            {
                if (!dbSet.Where(p => p.Codigo == Bebida.Codigo).Any())
                {
                    dbSet.Add(new Produto(Bebida.Codigo, Bebida.Categoria, Bebida.Nome, Bebida.Descricao, Bebida.Preco));
                }
            }
            contexto.SaveChanges();
        }
    }

    public class Bebida
    {
        public string Codigo { get; set; }
        public string Categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}