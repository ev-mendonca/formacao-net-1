using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutosViewModel
    {
        public BuscaDeProdutosViewModel(IList<Produto> produtos, string busca = "")
        {
            Produtos = produtos;
            Busca = busca;
        }

        public IList<Produto> Produtos { get; private set; }

        public string Busca { get; private set; }

        public int TotalProdutos 
        { 
            get { return Produtos == null ? 0 : Produtos.Count; } 
        }
    }
}
