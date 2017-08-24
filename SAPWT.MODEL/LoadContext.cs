using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWT.MODEL
{
    public class LoadContext
    {
        public MASAC_SEIDOREntities context { get; set; }
        public String currentCulture { get; set; }
    }
}
