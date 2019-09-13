using Senai.OPFlix.WebApi.Domains;
using Senai.OPFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OPFlix.WebApi.Repositories
{
    public class PlataformaRepository : IPlataformaRepository
    {
        public void Atualizar(Plataformas plataformas)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Plataformas PlataformaBuscada = ctx.Plataformas.FirstOrDefault(x => x.IdPlataforma == plataformas.IdPlataforma);
                PlataformaBuscada.Nome = plataformas.Nome;
                ctx.Plataformas.Update(PlataformaBuscada);
                ctx.SaveChanges();
            }
        }

        public Plataformas BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataformas.FirstOrDefault(x => x.IdPlataforma == id);
            }
        }

        public void Cadastrar(Plataformas plataformas)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Plataformas.Add(plataformas);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Plataformas plataformas = ctx.Plataformas.Find(id);
                ctx.Plataformas.Remove(plataformas);
                ctx.SaveChanges();
            }
        }

        public List<Plataformas> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataformas.ToList();
            }
        }
    }

    using Senai.OPFlix.WebApi.Domains;
using Senai.OPFlix.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OPFlix.WebApi.Repositories
    {
        public class UsuarioRepository
        {
            public Usuarios BuscarPorEmailESenha(LoginViewModel login)
            {
                using (OpFlixContext ctx = new OpFlixContext())
                {
                    Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                    if (usuario == null)
                        return null;
                    return usuario;
                }
            }
        }
    }

}
