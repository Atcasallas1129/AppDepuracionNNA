using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppDepuracionNNA.Modulo
{
    public partial class ConsultaHistoricoNnaDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ///if(Session["idRegistroDetalle"] != null && Session["usuarioLogeado"] != null)
            if (Session["idRegistroDetalle"] != null || Session["usuarioLogeado"] != null)
            {
                try
                {
                    try
                    {
                        int? idRegistro = Convert.ToInt32(Session["idRegistroDetalle"]);
                        EncargoFiduciarioNNAEntities contexto = new EncargoFiduciarioNNAEntities();
                        var registro = from p in contexto.EncargoFiduciarioDep
                                       where p.id == idRegistro
                                       select p;
                        if (registro.Count() > 0)
                        {
                            pnEstadoOriginalCaso.Enabled = true;
                            pnEstadoDepuradoCaso.Enabled = true;
                            pnEstadoDepuradoCaso.Visible = true;
                            EncargoFiduciarioDep registroDepurado = contexto.EncargoFiduciarioDep.SingleOrDefault(p => p.id == idRegistro);
                            txtCodUniqueDep.Text = registroDepurado.registro_uniqueidentifier.ToString();
                            txtAnioDep.Text = registroDepurado.anio.ToString();
                            txtRadicadoDep.Text = registroDepurado.rad.ToString();
                            txtMarcoNormativoDep.Text = registroDepurado.proceso.ToString();
                            ///Informacion de la Victima Depurada
                            txtPrimerNombreVictimaDep.Text = registroDepurado.Primer_nombre_victima.ToString();
                            txtSegundoNombreVictimaDep.Text = registroDepurado.Segundo_nombre_victima.ToString();
                            txtPrimerApellidoVictimaDep.Text = registroDepurado.primer_apellido_victima.ToString();
                            txtSegundoApellidoVictimaDep.Text = registroDepurado.Segundo_apellido_victima.ToString();
                            txtTipoDocumentoVictimaDep.Text = registroDepurado.tipo_documento_victima.ToString();
                            txtNumeroDocumentoVictimaDep.Text = registroDepurado.no_documento_victima.ToString();
                            ///Informacion del destinatario
                            txtPrimerNombreDestinatarioDep.Text = registroDepurado.Primer_nombre_destinatario.ToString();
                            txtSegundoNombreDestinatarioDep.Text = registroDepurado.Segundo_nombre_destinatario.ToString();
                            txtPrimerApellidoDestinatarioDep.Text = registroDepurado.primer_apellido_destinatario.ToString();
                            txtSegundoApellidoDestinatarioDep.Text = registroDepurado.Segundo_apellido_destinatario.ToString();
                            txtTipoDocumentoDestinatarioDep.Text = registroDepurado.tipo_documento_destinatario.ToString();
                            txtNumeroDocumentoDestinatarioDep.Text = registroDepurado.NO_DOCUMENTO_DESTINATARIO.ToString();
                            ///informacion financiera
                            txtPorcentajeDep.Text = registroDepurado.porcentaje_recalculado.ToString();
                            txtValorIndemnizacionDep.Text = registroDepurado.valor_total_pagar_indemnizacion.ToString();
                            DateTime fechaResolucion = new DateTime();
                            if (DateTime.TryParse(registroDepurado.fecha_resolucion.ToString(), out fechaResolucion)) ;
                            { txtFechaResolucionDep.Text = fechaResolucion.ToString("yyyy-MM-dd"); }
                            ///Estado del Giro
                            txtEstadoBancarioDep.Text = registroDepurado.estadoPago.ToString();
                            txtOrdenCompra.Text = registroDepurado.CONTARATO.ToString();
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
                catch
                {
                    Response.Redirect("~/Modulo/Login.aspx", true);
                }
            }
        }

        protected void buttonGuardar_Click(object sender, EventArgs e)
        {
            pnEstadoOriginalCaso.Enabled = false;
        }
    }
}