using System;
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
            int? idRegistro = Convert.ToInt32(Session["idRegistroDetalle"]);
            EncargoFiduciarioNNAEntities contexto = new EncargoFiduciarioNNAEntities();
            EncargoFiduciario registroBase = contexto.EncargoFiduciario.SingleOrDefault(p => p.Id1 == idRegistro);
        }

        protected void buttonGuardar_Click(object sender, EventArgs e)
        {
            divEstadoOriginalCaso.Enabled = false;
        }
    }
}