using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composicao.Entidades {
    internal class Departamento {

        public string Nome { get; set; }

        public Departamento(string nome) {
            this.Nome = nome;
        }
    }
}
