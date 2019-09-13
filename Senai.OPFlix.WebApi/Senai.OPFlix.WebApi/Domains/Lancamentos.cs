using System;
using System.Collections.Generic;

namespace Senai.OPFlix.WebApi.Domains
{
    public partial class Lancamentos
    {
        public int IdLancamento { get; set; }
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
