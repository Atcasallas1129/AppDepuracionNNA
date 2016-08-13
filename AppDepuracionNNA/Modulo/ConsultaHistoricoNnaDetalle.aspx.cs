using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;

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
                        if (registro.Count() == 0)
                        {
                            pnEstadoOriginalCaso.Enabled = true;
                            pnEstadoOriginalCaso.Visible = true;
                            pnEstadoDepuradoCaso.Enabled = false;
                            pnEstadoDepuradoCaso.Visible = false;
                            EncargoFiduciario registroOriginal = contexto.EncargoFiduciario.SingleOrDefault(p => p.Id1 == idRegistro);
                            //Informacion general sobre el caso Original
                            txtCodigoUnique.Text = registroOriginal.registro_uniqueidentifier.ToString();
                            txtAnio.Text = registroOriginal.anio.ToString();
                            txtRadicado.Text = registroOriginal.rad.ToString();
                            txtMarcoNormativo.Text = registroOriginal.proceso.ToString();
                            //Informacion sobre la victima original
                            lblIdPersonaVictima.Text = registroOriginal.id_persona.ToString();
                            txtPrimerNombreVictima.Text = registroOriginal.Primer_nombre_victima.ToString();
                            txtSegundoNombreVictima.Text = registroOriginal.Segundo_nombre_victima.ToString();
                            txtPrimerApellidoVictima.Text = registroOriginal.primer_apellido_victima.ToString();
                            txtSegundoApellidoVictima.Text = registroOriginal.Segundo_apellido_victima.ToString();
                            txtTipoDocumentoVictima.Text = registroOriginal.tipo_documento_victima.ToString();
                            txtNumeroDocumentoVictima.Text = registroOriginal.no_documento_victima.ToString();
                            DateTime fechaNacimientoVictima = new DateTime();
                            if (DateTime.TryParse(registroOriginal.fecha_nacimiento_victima.ToString(), out fechaNacimientoVictima)) ;
                            { txtFechaNacimientoVictima.Text = fechaNacimientoVictima.ToString("yyyy-MM-dd"); }
                            ///Informacion sobre el destinatario original
                            lblIdPersonaDestinatario.Text = registroOriginal.id_persona2.ToString();
                            txtPrimerNombreDestinatario.Text = registroOriginal.Primer_nombre_destinatario.ToString();
                            txtSegundoNombreDestinatario.Text = registroOriginal.Segundo_nombre_destinatario.ToString();
                            txtPrimerApellidoDestinatario.Text = registroOriginal.primer_apellido_destinatario.ToString();
                            txtSegundoApellidoDestinatario.Text = registroOriginal.Segundo_apellido_destinatario.ToString();
                            txtTipoDocumentoDestinatario.Text = registroOriginal.tipo_documento_destinatario.ToString();
                            txtNumeroDocumentoDestinatario.Text = registroOriginal.parentesco_destinatario.ToString();
                            DateTime fechaNacimientoDestinatario = new DateTime();
                            if (DateTime.TryParse(registroOriginal.fecha_nacimiento_destinatario.ToString(), out fechaNacimientoDestinatario)) ;
                            { txtFechaNacimientoDestinatario.Text = fechaNacimientoDestinatario.ToString("yyyy-MM-dd"); }
                            ///colocar la info del parentesco
                            //Informacion Financiera
                            try {
                                if(ddlHechoVictimizante.Items.FindByText(registroOriginal.hecho_victimi.ToString())== null)
                                {
                                    ddlHechoVictimizante.SelectedItem.Text = ddlHechoVictimizante.Items.FindByText(registroOriginal.hecho_victimi).ToString();
                                }
                                else
                                {

                                }
                            }
                            catch
                            {

                            }
                            DdlParentescoDestinatario.SelectedItem.Text = DdlParentescoDestinatario.Items.FindByText(registroOriginal.parentesco_destinatario).ToString();
                            txtPorcentaje.Text = registroOriginal.porcentaje_recalculado.ToString();
                            txtValorIndemnizacion.Text = registroOriginal.LIQUIDACION_DEFINITIVA.ToString();
                            txtNumeroResolucion.Text = registroOriginal.no_resolucion.ToString();
                            DateTime fechaResolucionOriginal = new DateTime();
                            if (DateTime.TryParse(registroOriginal.fecha_resolucion.ToString(), out fechaResolucionOriginal)) ;
                            { txtFechaResolucion.Text = fechaResolucionOriginal.ToString("yyyy-MM-dd"); }
                            ///Estado del Giro
                            txtOrdenCompra.Text = registroOriginal.CONTARATO.ToString();
                        }
                        else
                        {
                            pnEstadoOriginalCaso.Enabled = false;
                            pnEstadoOriginalCaso.Visible = false;
                            pnEstadoDepuradoCaso.Enabled = true;
                            pnEstadoDepuradoCaso.Visible = true;
                            EncargoFiduciarioDep registroDepurado = contexto.EncargoFiduciarioDep.SingleOrDefault(p => p.id == idRegistro);
                            //Informacion general sobre el caso depurada
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
                            txtFechaNacimientoVictimaDep.Text = "";///colocar el campo en el modelo
                            ///Informacion del destinatario
                            txtPrimerNombreDestinatarioDep.Text = registroDepurado.Primer_nombre_destinatario.ToString();
                            txtSegundoNombreDestinatarioDep.Text = registroDepurado.Segundo_nombre_destinatario.ToString();
                            txtPrimerApellidoDestinatarioDep.Text = registroDepurado.primer_apellido_destinatario.ToString();
                            txtSegundoApellidoDestinatarioDep.Text = registroDepurado.Segundo_apellido_destinatario.ToString();
                            txtTipoDocumentoDestinatarioDep.Text = registroDepurado.tipo_documento_destinatario.ToString();
                            txtNumeroDocumentoDestinatarioDep.Text = registroDepurado.NO_DOCUMENTO_DESTINATARIO.ToString();
                            txtFechaNacimientoDestinatarioDep.Text = "";///colocar el campo en el modelo
                            ///colocar la informacion del parentesco
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
                    catch (SystemException ex)
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
            if(Convert.ToInt32(DdlParentescoDestinatario.SelectedValue) != 0)
            {
                try
                {
                    EncargoFiduciarioNNAEntities contexto = new EncargoFiduciarioNNAEntities();
                    EncargoFiduciarioDep registro = new EncargoFiduciarioDep();
                    registro.id = Convert.ToInt32(Session["idRegistroDetalle"].ToString());
                    registro.registro_uniqueidentifier = Guid.Parse(transformacioncampo(txtCodigoUnique.Text));
                    registro.anio = transformacioncampo(txtAnio.Text);
                    registro.rad = transformacioncampo(txtRadicado.Text);
                    registro.proceso = transformacioncampo(txtMarcoNormativo.Text);
                    registro.id_persona_victima = string.IsNullOrEmpty(lblIdPersonaVictima.Text) ? Convert.ToInt64(null) : Convert.ToUInt32(lblIdPersonaVictima.Text.ToString());
                    registro.Primer_nombre_victima = transformacioncampo(txtPrimerNombreVictima.Text.ToString());
                    registro.Segundo_nombre_victima = transformacioncampo(txtSegundoNombreVictima.Text.ToString());
                    registro.primer_apellido_victima = transformacioncampo(txtPrimerApellidoVictima.Text.ToString());
                    registro.Segundo_apellido_victima = transformacioncampo(txtPrimerApellidoVictima.Text.ToString());
                    registro.genero_victima = transformacioncampo(ddlGeneroVictima.SelectedValue.ToString());
                    registro.tipo_documento_victima = transformacioncampo(txtTipoDocumentoVictima.ToString());
                    registro.no_documento_victima = Convert.ToInt64(transformacioncampo(txtTipoDocumentoVictima.ToString()));
                    registro.fecha_nacimiento_victima = Convert.ToDateTime(txtFechaNacimientoVictima.Text.ToString());
                }
                catch (SystemException ex)
                {
                    panelMensajes.CssClass = "alert alert-danger";
                    Label textoError = new Label();
                    textoError.Text = "Error: error al procesar la solicitud: Detalle del error: "+ex.ToString();
                    panelMensajes.Controls.Add(textoError);
                }
            }
            else
            {
                panelMensajes.CssClass = "alert alert-warning";
                Label textoError = new Label();
                textoError.Text = "Error: Debe diligenciar el parentesco del destinatario con la víctima.";
                panelMensajes.Controls.Add(textoError);
                DdlParentescoDestinatario.Attributes.Add("style", "background-color:#FF0000");
            }
        }

        protected void DdlParentescoDestinatario_Init(object sender, EventArgs e)
        {
            try
            {
                EncargoFiduciarioNNAEntities contexto = new EncargoFiduciarioNNAEntities();
                var parentesco = from p in contexto.Parentesco
                                 select new
                                 {
                                     id = p.id,
                                     nombre = p.nombre                                     
                                 };
                DdlParentescoDestinatario.DataSource = parentesco.ToArray();
                DdlParentescoDestinatario.DataBind();

                ListItem item = new ListItem("-- Seleccione una opcion --", "-1");
                DdlParentescoDestinatario.Items.Insert(0, item);
            }
            catch
            {

            }
        }

        protected string transformacioncampo (string dato)
        {
            string datoTransformado = Regex.Replace(dato, "[^a-zA-Z0-9_.- ]+", "", RegexOptions.Compiled);
            return datoTransformado;
        }

        protected void ddlHechoVictimizante_Init(object sender, EventArgs e)
        {
            try
            {
                EncargoFiduciarioNNAEntities contexto = new EncargoFiduciarioNNAEntities();
                var hechoVictimi = from p in contexto.HechoVictimizante
                                   select new
                                   {
                                       id = p.id_hecho_victimizante,
                                       hecho = p.nombre
                                   };
                ddlHechoVictimizante.DataSource = hechoVictimi.ToArray();
                ddlHechoVictimizante.DataBind();
                ListItem item = new ListItem("-- Seleccione una opcion --", "-1");
                ddlHechoVictimizante.Items.Insert(0, item);
            }
            catch
            {

            }
        }
    }
}
