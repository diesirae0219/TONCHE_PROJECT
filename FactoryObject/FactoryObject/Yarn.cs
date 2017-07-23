using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryObject
{
    public class YARN
    {
        public string YARN_VENDER;
        public enum YARN_TYPE { WARP, WEFT };
        public List<Construction> CONS_LIST;

        public class Construction
        {
            public string CONS_NAME;
            public int CONS_RATIO;

        }

        public YARN()
        {

        }



    }
}
