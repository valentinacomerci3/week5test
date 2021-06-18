using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5.LibrettoADO.Repositories
{
    public interface IRepository<T>
    {
        public IList<T> GetAll();
        public bool Add(T item); 
       
    }
}
