using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    public abstract class DAOBasicAbstract<T>
    {
        public abstract int Inserir(T obj);
        public abstract bool Inserir(List<T> obj);
        public abstract int Count(T obj);
        public abstract int Count(int p_Id);
        public abstract bool Atualizar(T obj);
        public abstract List<T> ObterListagem(T obj);
    }
}
