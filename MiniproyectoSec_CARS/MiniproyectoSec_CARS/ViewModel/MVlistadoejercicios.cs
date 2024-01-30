using MiniproyectoSec_CARS.Datos;
using MiniproyectoSec_CARS.Model;
using MiniproyectoSec_CARS.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MiniproyectoSec_CARS.ViewModel
{
    public class MVlistadoejercicios : BaseViewModel
    {
        #region Variables
        string _Texto;
        int _suma;
        ObservableCollection<MListejercicios> _Listaejercicios;
        MListejercicios _Select;
        //MListejercicios _Seleccionado;

        #endregion
        #region Constructores
        public MVlistadoejercicios(INavigation navigation)
        {
            Navigation = navigation;
            Mostrarejercicios();
            //Mostrarprogreso();
        }
        #endregion
        #region Objetos
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value);
                OnpropertyChanged();            
            }
        }

        public MListejercicios Select
        {
            get { return _Select; }
            set { SetValue(ref _Select, value); }
        }
        public ObservableCollection<MListejercicios> ListaEjercicios
        {
            get { return _Listaejercicios; }
            set
            {
                SetValue(ref _Listaejercicios, value);
                OnPropertyChanged();
                //_Listaejercicios = value;
                //OnpropertyChanged(nameof(ListaEjercicios));
            }
        }
        /*
        public MListejercicios Seleccionado
        {
            get { return _Seleccionado; }
            set
            {
                if (_Seleccionado != value)
                {
                    _Seleccionado = value;
                }
            }
        }*/
        #endregion
        #region Procesos
        public async Task Mostrarejercicios()
        {
            var funcion = new Dejercicios();
            ListaEjercicios = await funcion.Mostrarejercicios();
        }
        //public async void Mostrarprogreso()
        //{
        //    var funcion = new Dejercicios();
        //    Texto = await funcion.MostrarSumatoria();
        //    //Texto = _suma.ToString();
        //}
        public async Task Iraregistro()
        {
            await Navigation.PushAsync(new insertarSeguimiento());
        }
        public async Task IraEditar()
        {
            await Navigation.PushAsync(new Editar(Select));
        }
        public async Task Iradelete()
        {
            var funcion = new Dejercicios();
            await funcion.deleteEjercicios(Select);
            await DisplayAlert("Eliminado","se ha eliminado el registro correctamente","exit");
            
            //ya hay obserbable collection, jala con list
            //await Mostrarejercicios();

        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region Comandos
        public ICommand Iraregistrocommand => new Command(async () => await Iraregistro());
        public ICommand IraEditcommand => new Command(async () => await IraEditar());

        public ICommand deletecommand => new Command(async () => await Iradelete());

        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);

        #endregion
    }
}
