using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personel.Entities
{
    public class Departmans
    {
        public int DepartmanID { get; set; }
        public string Departman { get; set; }
        public string Aciklama { get; set; }

        public override string ToString()
        {
            return Departman;
        }
        //public override string ToString()
        //{
        //    return Aciklama;
        //}

    }
}
