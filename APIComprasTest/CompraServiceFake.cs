using APICompras.Models;
using APICompras.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIComprasTest
{
    public class CompraServiceFake : ICompraService
    {
        private readonly List<CompraItem> _compra;

        public CompraServiceFake()
        {
            _compra = new List<CompraItem>()
            {
                new CompraItem(){Id = 1, Nome = "Notbook Acer", Fabricante = "Acer", Preco = 3000.00M},
                new CompraItem(){Id = 2, Nome = "Notbook Samsumg", Fabricante = "Samsumg", Preco = 2500.00M},
                new CompraItem(){Id = 3, Nome = "Guitarra Fender", Fabricante = "Fender", Preco = 30000.00M}
            };
        }

        public IEnumerable<CompraItem> GetAllItems()
        {
            return _compra;
        }

        public CompraItem Add(CompraItem novoItem)
        {
            novoItem.Id = GeraId();
            _compra.Add(novoItem);
            return novoItem;
        }

        public CompraItem GetById(int id)
        {
            return _compra.Where(a => a.Id == id)
               .FirstOrDefault();
        }

        public void Remove(int id)
        {
            var item = _compra.First(a => a.Id == id);
            _compra.Remove(item);
        }

        static int GeraId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}
