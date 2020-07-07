using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Categoria GetCategoria(int id);
        Task<Categoria> SaveCategoria(string nome); 
    }

    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        
        public CategoriaRepository(ApplicationContext contexto,
            IHttpContextAccessor contextAccessor) : base(contexto)
        {
            this.contextAccessor = contextAccessor;
        }
        public Categoria GetCategoria(int id)
        {
            return dbSet
                .Include(c => c.Produtos)
                .Where(c => c.Id == id)
                .SingleOrDefault();
        }

        public async Task<Categoria> SaveCategoria(string nome)
        {
            Categoria categoria = GetCategoria(nome);
            if(categoria == null)
            {
                categoria = new Categoria(nome);
                dbSet.Add(categoria);
                await contexto.SaveChangesAsync();
                
            }
            return categoria;
        }

        private Categoria GetCategoria(string nome)
        {
            return dbSet.Where(c => c.Nome == nome).SingleOrDefault();
        }
    }
}
