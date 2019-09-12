using Senai.OPFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OPFlix.WebApi.Interfaces
{
    public interface ICategoriaRepository
    {
        List<Categoria> Listar();

        Categoria BuscarPorId(int id);

        void Cadastrar(Categoria categoria);

        void Atualizar(Categoria categoria);

        void Deletar(int id);
    }
}