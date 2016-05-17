using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Services.Entity;
using WebPages.RunServiceReference;
using System.Data;
//using BLL;

namespace WebPages
{
    public partial class test : System.Web.UI.Page
    {
        public string strmapid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AjaxPro.Utility.RegisterTypeForAjax(typeof(test));
            }       
        }

        //return string
        [AjaxPro.AjaxMethod]
        public String GetAjaxString(string str)
        {
            return "Hello AjaxPro: " + str + Session.Count;
        }

        //return object.
        [AjaxPro.AjaxMethod]
        public Services.Entity.DataClass.BehaviourInfo GetAjaxObject()
        {
            var behaviourInfo = new Services.Entity.DataClass.BehaviourInfo();
            behaviourInfo.Behaviour = "this is test behaviour...";
            return behaviourInfo;
        }

        //return datatable.
        [AjaxPro.AjaxMethod]
        public DataTable GetAjaxDatatable()
        {
            var dt = new DataTable("Table_AX");
            //Method 1
            dt.Columns.Add("column0", System.Type.GetType("System.String"));
            //Method 2
            var dc = new DataColumn("column1", System.Type.GetType("System.Boolean"));
            dt.Columns.Add(dc);

            //Add rows for DataTable
            //Initialize the row
            DataRow dr = dt.NewRow();
            dr["column0"] = "AX";
            dr["column1"] = true;

            dt.Rows.Add(dr);
            return dt;
        }

        //return list<string>
        [AjaxPro.AjaxMethod]
        public List<String> GetAjaxListString()
        {
            var list = new List<String> { "abc", "def" };
            return list;
        }

        //return list<string>
        [AjaxPro.AjaxMethod]
        public void SetAjaxObj(Services.Entity.DataClass.BehaviourInfo behaviourInfo)
        {
            System.Console.WriteLine(behaviourInfo.Behaviour);
        }
    }
}