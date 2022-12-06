using WebAppUncafezin.Models;
using System.Collections.Generic;

namespace WebAppUncafezin.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Bebida> bebidas);
        IList<Produto> GetProdutos();
    }
}