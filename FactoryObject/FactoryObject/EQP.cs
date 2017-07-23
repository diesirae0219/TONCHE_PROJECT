using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryObject
{
    public class EQP
    {
        public string EQP_ID { get; set; }
        private ArtProd EQP_PROD { get; set; }
        // public string EQP_PROD_ID { get; set; }
        public DateTime Prod_Start_time { get; set; }
        public string EQP_RPM { get; set; }
        public float TOTAL_PROD_LENGTH { get; set; }
        public List<EQP_PROD_RECORD> EQP_PROD_RECORD_LIST { get; set; }
        public Order order { get; set; }

        // Declare a Name property of type string:
        public string EQP_PROD_ID
        {
            get
            {
                if (EQP_PROD != null)
                    return EQP_PROD.ART_NO;
                else
                    return "";
            }
            set
            {
                EQP_PROD_ID = value;
            }
        }


        public EQP(string ID, string _PROD_NO)
        {
            //Init EQP Status
            //Init EQP Order Info
            //Init EQP Prod
            this.EQP_ID = ID;

            if (String.IsNullOrEmpty(_PROD_NO))
            {
                EQP_PROD = new ArtProd();
            }
            else
            {
                EQP_PROD = null;
            }

        }


        public class EQP_PROD_RECORD //每班紀錄
        {
            public DateTime RECORD_TIME;
            public float PROD_LENGTH;
            public EMPLOYEE FIN_EMP;

        }

        public class WARP_YARN_INFO
        {
            public YARN WARP_YARN;
            public float TOTAL_LENGTH;
            public float USED_LENGTH;

            public WARP_YARN_INFO()
            { }
        }

        public class WEFT_YARN_INFO
        {
            public YARN WARP_YARN;
            public float TOTAL_LENGTH;
            public float USED_LENGTH;

            public WEFT_YARN_INFO()
            { }
        }


    }
}
