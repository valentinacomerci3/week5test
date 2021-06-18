using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5.LibrettoADO.Entities
{
    public class Esame 
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int CFU { get; set; }
        public DateTime DataEsame { get; set; }
        public int Voto { get; set; }
        public string Esito { get; set; }
        public int Studente { get; set; }

    }
}
