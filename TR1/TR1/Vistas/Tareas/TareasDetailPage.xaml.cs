using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR1.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TR1.Vistas.Tareas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TareasDetailPage : ContentPage
    {
        public TareasDetailPage(MTareas mtareas)
        {
            InitializeComponent();
            LabelTitulo.Text = mtareas.Titulo;
            LabelDescripcion.Text = mtareas.Descripcion;
            LabelEstado.Text = mtareas.Estado;
        }
    }
}