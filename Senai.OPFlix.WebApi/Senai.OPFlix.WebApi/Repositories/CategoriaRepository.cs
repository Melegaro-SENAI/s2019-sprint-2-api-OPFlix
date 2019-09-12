using Senai.OPFlix.WebApi.Domains;
using Senai.OPFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OPFlix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public void Atualizar(Categoria categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Categoria CategoriaBuscada = ctx.Categoria.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
            }
        }

        public Categoria BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categoria.FirstOrDefault(x => x.IdCategoria == id);
            }
        }

        public void Cadastrar(Categoria categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Categoria.Add(categoria);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Categoria categoria = ctx.Categoria.Find(id);
                ctx.Categoria.Remove(categoria);
                ctx.SaveChanges();
            }
        }

        public List<Categoria> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categoria.ToList();
            }
        }
    }
}