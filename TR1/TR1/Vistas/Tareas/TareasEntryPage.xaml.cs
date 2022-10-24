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
    public partial class TareasEntryPage : ContentPage
    {
        ConexionBD conexion = new ConexionBD();
        public TareasEntryPage()
        {
            InitializeComponent();
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            string titulo = TxtTitulo.Text;
            string descripcion = TxtDescripcion.Text;
            string estado = TxtEstado.Text;
            if(string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(estado))
            {
                await DisplayAlert("Warning", "Profavor Complete los campos", "Cerrar");
            }
            MTareas mtareas = new MTareas();
            mtareas.Titulo = titulo;
            mtareas.Descripcion = descripcion;
            mtareas.Estado = "Pendiente";

            var isAgregar = await conexion.Agregar(mtareas);

            if(isAgregar)
            {
                await DisplayAlert("Informacion", "Tarea agregada con exito", "Ok");
                Limpiar();
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Error al agregar tarea", "Cerrar");
            }
        }
        public void Limpiar()
        {
            TxtTitulo.Text = string.Empty;
            TxtDescripcion.Text = string.Empty;
            TxtEstado.Text = string.Empty;
        }
    }
}