using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



namespace AppDepuracionNNA.Modulo
{
    public partial class consultaHistoricoNNA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linqDataSourceDatos_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            try
            {
                EncargoFiduciarioNNAEntities contexto = new EncargoFiduciarioNNAEntities();
                string rad = string.IsNullOrWhiteSpace(txtRadicado.Text) ? null : txtRadicado.Text;
                string numDocVictima = string.IsNullOrWhiteSpace(txtDocumentoVictima.Text) ? null : txtDocumentoVictima.Text;
                string numDocDestinatario = string.IsNullOrWhiteSpace(txtDocumentoDestinatario.Text) ? null : txtDocumentoDestinatario.Text;
                if (rad == null && numDocVictima == null && numDocDestinatario == null)
                {
                    var resultado = from p in contexto.vw_consultaHistoricoNNAS.AsNoTracking()
                                    where p.IdRegistro == 0
                                    orderby p.Radicado, p.Proceso
                                    select new
                                    {
                                        IdRegistro = p.IdRegistro,
                                        Radicado = p.Radicado,
                                        Proceso = p.Proceso,
                                        NombreVictima = p.NombreVictima,
                                        DocumentoVictima = p.DocumentoVictima,
                                        HechoVictimizante = p.HechoVictimizante,
                                        NombreDestinatario = p.NombreDestinatario,
                                        DocumentoDestinatario = p.DocumentoDestinatario
                                    };
                    e.Result = resultado.ToArray();
                }
                else if (!string.IsNullOrWhiteSpace(rad) && string.IsNullOrWhiteSpace(numDocVictima) && string.IsNullOrWhiteSpace(numDocDestinatario))
                {
                    var resultado = from p in contexto.vw_consultaHistoricoNNAS.AsNoTracking()
                                    where p.Radicado == rad
                                    orderby p.Radicado, p.Proceso
                                    select new
                                    {
                                        IdRegistro = p.IdRegistro,
                                        Radicado = p.Radicado,
                                        Proceso = p.Proceso,
                                        NombreVictima = p.NombreVictima,
                                        DocumentoVictima = p.DocumentoVictima,
                                        HechoVictimizante = p.HechoVictimizante,
                                        NombreDestinatario = p.NombreDestinatario,
                                        DocumentoDestinatario = p.DocumentoDestinatario
                                    };
                    e.Result = resultado.ToArray();
                }
                else if (!string.IsNullOrWhiteSpace(rad) && !string.IsNullOrWhiteSpace(numDocVictima) && string.IsNullOrWhiteSpace(numDocDestinatario))
                {
                    var resultado = from p in contexto.vw_consultaHistoricoNNAS.AsNoTracking()
                                    where p.Radicado == rad && p.DocumentoVictima == numDocVictima
                                    orderby p.Radicado, p.Proceso
                                    select new
                                    {
                                        IdRegistro = p.IdRegistro,
                                        Radicado = p.Radicado,
                                        Proceso = p.Proceso,
                                        NombreVictima = p.NombreVictima,
                                        DocumentoVictima = p.DocumentoVictima,
                                        HechoVictimizante = p.HechoVictimizante,
                                        NombreDestinatario = p.NombreDestinatario,
                                        DocumentoDestinatario = p.DocumentoDestinatario
                                    };
                    e.Result = resultado.ToArray();
                }
                else if (!string.IsNullOrWhiteSpace(rad) && !string.IsNullOrWhiteSpace(numDocVictima) && !string.IsNullOrWhiteSpace(numDocDestinatario))
                {
                    var resultado = from p in contexto.vw_consultaHistoricoNNAS.AsNoTracking()
                                    where p.Radicado == rad && p.DocumentoVictima == numDocVictima && p.DocumentoDestinatario == numDocDestinatario
                                    orderby p.Radicado, p.Proceso
                                    select new
                                    {
                                        IdRegistro = p.IdRegistro,
                                        Radicado = p.Radicado,
                                        Proceso = p.Proceso,
                                        NombreVictima = p.NombreVictima,
                                        DocumentoVictima = p.DocumentoVictima,
                                        HechoVictimizante = p.HechoVictimizante,
                                        NombreDestinatario = p.NombreDestinatario,
                                        DocumentoDestinatario = p.DocumentoDestinatario
                                    };
                    e.Result = resultado.ToArray();
                }
                else if (string.IsNullOrWhiteSpace(rad) && !string.IsNullOrWhiteSpace(numDocVictima) && string.IsNullOrWhiteSpace(numDocDestinatario))
                {
                    var resultado = from p in contexto.vw_consultaHistoricoNNAS.AsNoTracking()
                                    where p.DocumentoVictima == numDocVictima
                                    orderby p.Radicado, p.Proceso
                                    select new
                                    {
                                        IdRegistro = p.IdRegistro,
                                        Radicado = p.Radicado,
                                        Proceso = p.Proceso,
                                        NombreVictima = p.NombreVictima,
                                        DocumentoVictima = p.DocumentoVictima,
                                        HechoVictimizante = p.HechoVictimizante,
                                        NombreDestinatario = p.NombreDestinatario,
                                        DocumentoDestinatario = p.DocumentoDestinatario
                                    };
                    e.Result = resultado.ToArray();
                }
                else if (string.IsNullOrWhiteSpace(rad) && !string.IsNullOrWhiteSpace(numDocVictima) && !string.IsNullOrWhiteSpace(numDocDestinatario))
                {
                    var resultado = from p in contexto.vw_consultaHistoricoNNAS.AsNoTracking()
                                    where p.DocumentoVictima == numDocVictima && p.DocumentoDestinatario == numDocDestinatario
                                    orderby p.Radicado, p.Proceso
                                    select new
                                    {
                                        IdRegistro = p.IdRegistro,
                                        Radicado = p.Radicado,
                                        Proceso = p.Proceso,
                                        NombreVictima = p.NombreVictima,
                                        DocumentoVictima = p.DocumentoVictima,
                                        HechoVictimizante = p.HechoVictimizante,
                                        NombreDestinatario = p.NombreDestinatario,
                                        DocumentoDestinatario = p.DocumentoDestinatario
                                    };
                    e.Result = resultado.ToArray();
                }
                else if (!string.IsNullOrWhiteSpace(rad) && !string.IsNullOrWhiteSpace(numDocVictima) && string.IsNullOrWhiteSpace(numDocDestinatario))
                {
                    var resultado = from p in contexto.vw_consultaHistoricoNNAS.AsNoTracking()
                                    where p.DocumentoDestinatario == numDocDestinatario
                                    orderby p.Radicado, p.Proceso
                                    select new
                                    {
                                        IdRegistro = p.IdRegistro,
                                        Radicado = p.Radicado,
                                        Proceso = p.Proceso,
                                        NombreVictima = p.NombreVictima,
                                        DocumentoVictima = p.DocumentoVictima,
                                        HechoVictimizante = p.HechoVictimizante,
                                        NombreDestinatario = p.NombreDestinatario,
                                        DocumentoDestinatario = p.DocumentoDestinatario
                                    };
                    e.Result = resultado.ToArray();
                }
            }
            catch
            {
                panelMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error: No es posible establecer conexion con el sistema, por favor intente mas tarde.";
                panelMensajes.Controls.Add(textoError);
            }

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvHistoricoNna.DataBind();
            }
            catch
            {
                panelMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error: No es posible establecer conexion con el sistema, por favor intente mas tarde.";
                panelMensajes.Controls.Add(textoError);
            }
        }

        protected void dgvHistoricoNna_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dgvHistoricoNna.SelectedRow;
                int idSeleccionado = Convert.ToInt32(dgvHistoricoNna.DataKeys[row.RowIndex].Value.ToString());
                Session["idRegistroDetalle"] = idSeleccionado;
                Response.Redirect("~/Modulo/ConsultaHistoricoNnaDetalle.aspx", true);
            }
            catch
            {
                panelMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error: No es posible establecer conexion con el sistema, por favor intente mas tarde.";
                panelMensajes.Controls.Add(textoError);
            }
        }
    }
}