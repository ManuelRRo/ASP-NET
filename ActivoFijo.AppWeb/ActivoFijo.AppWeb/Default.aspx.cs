using ActivoFijo.Core.Dto.CAT;
using ActivoFijo.Core.Dto.Generico;
using ActivoFijo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ActivoFijo.AppWeb
{
    public partial class _Default : Page
    {
        public IOperacion<EspecificoGastoDto> repository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected async void BtnGuardarActualizar_Click(object sender, EventArgs e)
        {
            EspecificoGastoDto data;
            try
            {
                data = new EspecificoGastoDto()
                {
                    IdEspecifico = Convert.ToInt32(Hdn_IdEspecifico.Value),
                    CodigoEspecifico = TxTCodigo.Text,
                    NombreEspecifico = TxtNombre.Text,
                };
            }
            catch(Exception)
            {
                Hdn_IdEspecifico.Value = "0";
                data = new EspecificoGastoDto()
                {
                    CodigoEspecifico = TxTCodigo.Text,
                    NombreEspecifico = TxtNombre.Text,
                };
            }
            
            GenericResponse<EspecificoGastoDto> respuesta;
            if (Hdn_IdEspecifico.Value == "0")
                respuesta = await repository.Guardar(data);
            else
                respuesta = await repository.Actualizar(data);
            if (respuesta.Status.HttpCode == System.Net.HttpStatusCode.OK)
            {
                Gv_EspecificoGastos.DataBind();
            }
            
        }

        protected async void Lnk_Editar_Command(object sender, CommandEventArgs e)
        {
            int IdEspecifico = Convert.ToInt32(e.CommandArgument);
            var usr = await repository.ObtenerPorId(IdEspecifico);
            if (usr.Status.HttpCode == System.Net.HttpStatusCode.OK)
            {
                LnkBtn_Nuevo.Text = "Actualizar";
                Hdn_IdEspecifico.Value = IdEspecifico.ToString();
                TxTCodigo.Text = usr.Item.CodigoEspecifico;
                TxtNombre.Text = usr.Item.NombreEspecifico;
            }
        }

        protected async void Lnk_Eliminar_Command(object sender, CommandEventArgs e)
        {
            object id = e.CommandArgument;
            var response = await repository.Eliminar(id);
            if (response.Status.HttpCode == System.Net.HttpStatusCode.OK)
            {
                Gv_EspecificoGastos.DataBind();   
            }
           
        }

    }
}