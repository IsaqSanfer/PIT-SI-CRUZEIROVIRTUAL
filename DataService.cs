using WebAppUncafezin.Models;
using WebAppUncafezin.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppUncafezin
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext contexto,
                    IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            contexto.Database.Migrate();

            List<Bebida> bebidas = Getbebidas();

            produtoRepository.SaveProdutos(bebidas);
        }

        private static List<Bebida> Getbebidas()
        {
            var json = File.ReadAllText("bebidas.json");
            var bebidas = JsonConvert.DeserializeObject<List<Bebida>>(json);
            return bebidas;
        }
    }
}