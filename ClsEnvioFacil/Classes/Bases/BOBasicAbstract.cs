using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    public abstract class BOBasicAbstract<T>
    {
        public abstract int Salvar(T obj);
        public abstract T Obter(T obj);
        public abstract List<T> ObterLista(T obj);
    }
}
