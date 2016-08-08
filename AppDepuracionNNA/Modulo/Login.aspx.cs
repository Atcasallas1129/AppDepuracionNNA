using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace AppDepuracionNNA.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn(object sender, EventArgs e)
        {
            try
            {
                if (UsuarioValido(Email.Text, Password.Text))
                {
                    string usuario = Email.Text;
                    string contrasena = EncriptarContrasena(Password.Text);
                    IndemnizaEntities contexto = new IndemnizaEntities();
                    Usuario idusuario = contexto.Usuario.SingleOrDefault(X => X.correo_electronico.Equals(usuario) && X.contrasena.Equals(contrasena));
                    Session["usuarioLogeado"] = idusuario;
                    Response.Redirect("~/Modulo/Home.aspx", true);
                }
                else
                {
                    Session["usuarioLogeado"] = null;
                    panelMensajes.CssClass = "alert alert-danger";
                    Label textoError = new Label();
                    textoError.Text = "Error: Las credenciales de acceso no son correctas.";
                    panelMensajes.Controls.Add(textoError);
                }
            }
            catch
            {
                Session["usuarioLogeado"] = null;
                panelMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error: No se ha podido establecer conexion con la base de datos, intente nuevamente";
                panelMensajes.Controls.Add(textoError);
            }
        }
        public string EncriptarContrasena(string contrasena)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(contrasena);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        private bool UsuarioValido(string usuario, string contrasena)
        {

            try
            {
                IndemnizaEntities contexto = new IndemnizaEntities();

                string contrasenaValida = EncriptarContrasena(contrasena);

                bool valido = false;
                valido = contexto.Usuario.Any(X => X.correo_electronico == usuario && X.contrasena == contrasenaValida && (X.idRol == 5 || X.idRol == 1));
                return valido;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}