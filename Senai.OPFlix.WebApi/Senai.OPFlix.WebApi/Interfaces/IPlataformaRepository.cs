using Senai.OPFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OPFlix.WebApi.Interfaces
{
    interface IPlataformaRepository
    {
        List<Plataformas> Listar();

        Plataformas BuscarPorId(int id);

        void Cadastrar(Plataformas plataformas);

        void Atualizar(Plataformas plataformas);

        void Deletar(int id);
    }
}
