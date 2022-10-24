using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class TareasListaPage : ContentPage
    {
        ConexionBD conexion = new ConexionBD(); 
        public TareasListaPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var tareas =  await conexion.Listar();
            TareasListView.ItemsSource = null;
            TareasListView.ItemsSource = tareas;
        }

        private void AgregarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TareasEntryPage());
        }

        private void TareasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item == null)
            {
                return;
            }
            var mtareas = e.Item as MTareas;
            Navigation.PushAsync(new TareasDetailPage(mtareas));
            ((ListView)sender).SelectedItem = null;
        }

        private async void EliminarTap_Tapped(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Eliminar", "Estas seguro que desea eliminar","Si","No");
            if (response)
            {
                String id = ((TappedEventArgs)e).Parameter.ToString();
                bool isEliminado =  await conexion.Eliminar(id);
                if(isEliminado)
                {
                    await DisplayAlert("Informacion", "Tarea eliminada con exito", "Ok");
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Error", "Error al eliminar tarea", "Ok");

                }
            }
        }

        private async void EditarTap_Tapped(object sender, EventArgs e)
        {
            String id = ((TappedEventArgs)e).Parameter.ToString();
            var mtareas = await conexion.Editar(id);
            if(mtareas == null)
            {
                await DisplayAlert("Warning", "Dato no encontrado", "Ok");
            }
            mtareas.Id = id;
            await Navigation.PushAsync(new TareasEditPage(mtareas));
        }
    }
}