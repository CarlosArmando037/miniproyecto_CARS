using MiniproyectoSec_CARS.Datos;
using MiniproyectoSec_CARS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MiniproyectoSec_CARS.ViewModel
{
    public class MVinsertarSeguimiento : BaseViewModel
    {
        #region Variables
        string _Texto;
        string _IdEjercicios;
        string _Distancia;
        string _Kilos;
        string _Calorias;
        #endregion
        #region Constructores
        public MVinsertarSeguimiento(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region Objetos
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public string IdEjercicios
        {
            get { return _IdEjercicios; }
            set { SetValue(ref _IdEjercicios, value); }
        }
        public string Distancia
        {
            get { return _Distancia; }
            set { SetValue(ref _Distancia, value); }
        }
        public string Kilos
        {
            get { return _Kilos; }
            set { SetValue(ref _Kilos, value); }
        }
        public string Calorias
        {
            get { return _Calorias; }
            set { SetValue(ref _Calorias, value); }
        }

        #endregion
        #region Procesos
        public async Task ProcesoAsyncrono()
        {

        }
        public async Task Insertar()
        {
            var funcion = new Dejercicios();
            var parametros = new MListejercicios();
            parametros.Calorias = Calorias;
            parametros.Kilos = Kilos;
            parametros.Distancia = Distancia;

            await funcion.InsertarEjercicios(parametros);
            await Volver();
        }
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion
        #region Comandos
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand InsertarCommand => new Command(async () => await Insertar());
        public ICommand Volvercommand => new Command(async () => await Volver());
        #endregion
    }
}
