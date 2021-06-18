using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5.LibrettoADO.Entities
{
    public class Studente
    {
        public int ID { get; set; }
        public String Nome { get; set; }
        public String Cognome { get; set; }
        public int AnnoNascita { get; set; }
    }
}
