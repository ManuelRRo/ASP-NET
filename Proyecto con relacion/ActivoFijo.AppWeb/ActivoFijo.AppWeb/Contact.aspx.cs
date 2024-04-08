using ActivoFijo.Core.Dto.CAT;
using ActivoFijo.Core.Dto.Generico;
using ActivoFijo.Core.Interfaces;
using ActivoFijo.Data.Repository.CAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ActivoFijo.AppWeb
{
    public partial class Contact : Page
    {
        public IOperacion<ClasificacionActivoFijoDto> repository { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void BtnGuardarActualizar_Click(Object sender, EventArgs e)
        {
            ClasificacionActivoFijoDto data;
            try
            {
                data = new ClasificacionActivoFijoDto()
                {
                    IdClasificacionActivoFijo = Convert.ToInt32(Hdn_IdClasificacion.Value),
                    IdEspecifico = Convert.ToInt32(Ddl_EspecificoGasto.SelectedValue),
                    Codigo = TxTCodigo.Text.ToString(),
                    Descripcion = TxtDescripcion.Text.ToString()
                };
            }
            catch (Exception)
            {
                Hdn_IdClasificacion.Value = "0";
                data = new ClasificacionActivoFijoDto()
                {
                    IdEspecifico = Convert.ToInt32(Ddl_EspecificoGasto.SelectedValue),
                    Codigo = TxTCodigo.Text.ToString(),
                    Descripcion = TxtDescripcion.Text.ToString()
                };
            }
            GenericResponse<ClasificacionActivoFijoDto> respuesta;
            if (Hdn_IdClasificacion.Value == "0")
                respuesta = await repository.Guardar(data);
            else
                respuesta = await repository.Actualizar(data);
            if (respuesta.Status.HttpCode == System.Net.HttpStatusCode.OK)
            {
                Gv_Clasificacion.DataBind();
               
            }
        }

        protected async void Lnk_Editar_Command(object sender, CommandEventArgs e)
        {
            int IdClasificacion = Convert.ToInt32(e.CommandArgument);
            var usr = await repository.ObtenerPorId(IdClasificacion);
            if (usr.Status.HttpCode == System.Net.HttpStatusCode.OK)
            {
                LnkBtn_Nuevo.Text = "Actualizar";
                Hdn_IdClasificacion.Value = IdClasificacion.ToString();
                TxTCodigo.Text = usr.Item.Codigo.ToString();
                TxtDescripcion.Text = usr.Item.Descripcion;
            }
        }

        protected async void Lnk_Eliminar_Command(object sender, CommandEventArgs e)
        {
            object id = e.CommandArgument;
            var response = await repository.Eliminar(id);
            if (response.Status.HttpCode == System.Net.HttpStatusCode.OK)
            {
                Gv_Clasificacion.DataBind();
            }

        }
    }
}