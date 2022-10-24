using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR1.Conexion;
using TR1.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TR1.Vistas.Tareas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TareasEditPage : ContentPage
    {
        ConexionBD conexion = new ConexionBD();
        public TareasEditPage(MTareas mtareas)
        {
            InitializeComponent();
            TxtId.Text = mtareas.Id;
            TxtTitulo.Text = mtareas.Titulo;
            TxtDescripcion.Text = mtareas.Descripcion;
            TxtEstado.Text = mtareas.Estado;
        }

        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            string titulo = TxtTitulo.Text;
            string descripcion = TxtDescripcion.Text;
            string estado = TxtEstado.Text;
            if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(estado))
            {
                await DisplayAlert("Warning", "Profavor Complete los campos", "Cerrar");
            }

            MTareas mtareas = new MTareas();
            mtareas.Id = TxtId.Text;
            mtareas.Titulo = titulo;
            mtareas.Descripcion = descripcion;
            mtareas.Estado = estado;

            bool isActualizar = await conexion.Actualizar(mtareas);
            if (isActualizar)
            {
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Error al actualizar tarea", "Cerrar");
            }
        }
    }
}