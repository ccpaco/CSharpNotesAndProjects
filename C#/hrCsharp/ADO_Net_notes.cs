// Lots of dependant files and such, as it is a Web app template from VS? 

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccess101 

{
   public partial class About : Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con; 
                cmd.CommandTest = "Select * from table";
                cmd.CommandType = System.DataMisalignedException.CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                }
            }
        }
    }
}