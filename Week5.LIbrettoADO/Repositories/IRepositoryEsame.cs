using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.LibrettoADO.Entities;

namespace Week5.LibrettoADO.Repositories
{
    public interface IRepositoryEsame : IRepository<Esame>
    {
        public IList<Esame> EsamiOrdinatiPerVotoData();
        
    }
}
