using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using FactoryObject;
using FactoryObject.Utility;

namespace FactoryObject
{
    public class ArtProd
    {
        DB_Access dbTool ;
        public string ART_NO; //布號
        public string Raw_Weight; //胚布碼重
        public string Prod_Weight; //產品碼重
        public string Eqp_Spec; //機上規格
        public string Raw_Spec; //胚布規格
        public string Prod_Spec; //成品規格
        public string YarnCost;
        public List<Warp> WrapList = new List<Warp>();
        public List<Weft> WeftList = new List<Weft>();
        public string Composition;

        public ArtProd()
        {

        }

        public ArtProd(string _ART_NO,string _sMode)
        {
            this.ART_NO = _ART_NO;
            DataTable ART_DATA = new DataTable();
            string ssql = "Select * from ART_BASIC t where t.ART_NO = '"+_ART_NO +"'";
            try
            {
                GlobalVar.SysMode sMode = (GlobalVar.SysMode)Enum.Parse(typeof(GlobalVar.SysMode), _sMode, false);
                dbTool = new DB_Access(sMode);
                ART_DATA = dbTool.QueryData(ssql);
            }
            catch (Exception)
            {

            }

            if (ART_DATA.Rows.Count > 0)
            {
                this.Composition = ART_DATA.Rows[0]["COMPOSITION"].ToString();
            }

        }

        public ArtProd(string _ART_NO, string _Prod_Weight, string _Eqp_Spec, string _Raw_Spec, string _Prod_Spec, string _Yarn_cost, List<Warp> _WrapList, List<Weft> _WeftList)
        {
            this.ART_NO = _ART_NO;


            //this.Raw_Weight = _Raw_Weight;


            this.Prod_Spec = _Prod_Spec ?? string.Empty;

            this.Eqp_Spec = _Eqp_Spec ?? string.Empty;

            this.Raw_Spec = _Raw_Spec ?? string.Empty;

            this.Prod_Spec = _Prod_Spec ?? string.Empty;

            this.YarnCost = _Yarn_cost ?? string.Empty;

            this.WrapList = _WrapList;

            this.WeftList = _WeftList;
        }

        public string GetRawWoof()
        {
            string woof = string.Empty;
            //  u_String.IndexOf("xx", 0)   
            if (!string.IsNullOrEmpty(this.Raw_Spec))
            {
                string[] swoof = this.Raw_Spec.Split('*');
                woof = swoof[1];
            }
            return woof;
        }

        public string GetProdWoof()
        {
            string woof = string.Empty;
            //  u_String.IndexOf("xx", 0)   
            if (!string.IsNullOrEmpty(this.Prod_Spec))
            {
                string[] swoof = this.Prod_Spec.Split('*');
                woof = swoof[1];
            }
            return woof;
        }

        public string GetEqpWoof()
        {
            string woof = string.Empty;
            //  u_String.IndexOf("xx", 0)   
            if (!string.IsNullOrEmpty(this.Eqp_Spec))
            {
                string[] swoof = this.Eqp_Spec.Split('*');
                woof = swoof[1];
            }
            return woof;
        }


    }



    public class Warp
    {
        string Producer; //紗廠
        string Type; //紗種
        string Construction; //成份比
        int den; //實織度
        string Dying_Fab; //染廠
        float qty_raw; //每碼胚布量
        float qty; // 每碼用紗量
    }

    public class Weft
    {
        string Producer;
        string Type;
        string Construction;
        int den;
        string Dying_Fab;
        float qty_raw;
        float qty;
    }
}
