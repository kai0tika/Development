using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace StockTickerExample
{
    public partial class _Default : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Request.MapPath("stock.xml"));
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                ViewState["dt"] = ds.Tables[0];
            }
        }

       

        /// <summary>
        /// Update the specific row in the DataTable with the data from GridView,
        /// re-write the data into the xml file and re-databind again.
        /// </summary>
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["dt"];

            for (int i = 1; i < GridView1.Rows[e.RowIndex].Cells.Count; i++)
            {
                dt.Rows[e.RowIndex][i-1] = (GridView1.Rows[e.RowIndex].Cells[i].Controls[0] as TextBox).Text;
            }
            dt.AcceptChanges();
            GridView1.EditIndex = -1;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            dt.WriteXml(Request.MapPath("stock.xml"));
        }

        
        /// <summary>
        /// Cancel edit and set the mode of the GridView to normal viewing mode.
        /// </summary>
       

        /// <summary>
        /// Insert the data into the DataTable, re-write into the xml file and
        /// re-databind to the GridView.
        /// </summary>
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            ctltimer.Enabled = true;
            DataTable dt = (DataTable)ViewState["dt"];
            tbId.Text = dt.Rows.Count.ToString();
            dt.Rows.Add(tbSym.Text, tbId.Text);
            dt.AcceptChanges();
            dt.WriteXml(Request.MapPath("stock.xml"));
            GridView1.DataSource = dt;
            GridView1.DataBind();
            tbSym.Text = string.Empty;
        }

        public string GetPrice(object StockId, object Symbol)
        {
            //function to return price of stock. 
            //Stock Id used to generate random price
            BusinessObjects.StockItem stockitem = new BusinessObjects.StockItem();
            return stockitem.Pricevalue(StockId.ToString(),Symbol.ToString());
        }

        protected void OnTimerIntervalElaspse(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Request.MapPath("stock.xml"));
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            ViewState["dt"] = ds.Tables[0];
        }
    
    }
}
