using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_Veiculos.Infra.Arquivos.Serializador
{
    public interface ISerializador
    {
        Contexto CarregarDadosDoArquivo();

        void GravarDadosEmArquivo(Contexto dados);
    }
}
