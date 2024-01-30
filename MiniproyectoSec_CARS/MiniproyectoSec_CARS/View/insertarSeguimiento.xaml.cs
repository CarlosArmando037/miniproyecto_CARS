using MiniproyectoSec_CARS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiniproyectoSec_CARS.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class insertarSeguimiento : ContentPage
    {
        public insertarSeguimiento()
        {
            InitializeComponent();
            BindingContext = new MVinsertarSeguimiento(Navigation);
        }
    }
}