using System;
using System.Collections.Generic;

namespace Senai.OPFlix.WebApi.Domains
{
    public partial class Lançamentos
    {
        public int IdLançamento { get; set; }
        public string Nome { get; set; }
        public DateTime DataLançamento { get; set; }
    }
}
