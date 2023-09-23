using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SISTEMA_EQUIVALENCIAS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-V9EB1JU\SQLEXPRESS01;initial catalog=EQUIVALENCIA;
Integrated Security=True;"))


            {


                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM USUARIO WHERE nombre=@username AND clave=@password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@username", txtuss.Text.Trim());
                string clav = EnCryptDecrypt.CryptorEngine.Encrypt(txtpass.Text, true);

                sqlCmd.Parameters.AddWithValue("@password", clav);
                // string clav = EnCryptDecrypt.CryptorEngine.Decrypt(txtPassword.Text, true);


                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["username"] = txtuss.Text.Trim();
                    //Response.Redirect("~/ Index.html");
                    Response.Redirect("~/Home/Index");


                }
                else { lblerr.Visible = true; }
            }


        }
    }
}