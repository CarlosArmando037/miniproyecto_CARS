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
    public class MVEditarSeguimiento : BaseViewModel
    {

        #region Variables
        string _Texto;
        Guid _IdEjercicios;
        string _Distancia;
        string _Kilos;
        string _Calorias;
        #endregion
        #region Constructores
        public MVEditarSeguimiento(INavigation navigation, MListejercicios modelo)
        {
            Navigation = navigation;
            _Distancia = modelo.Distancia;
            _IdEjercicios = modelo.IdEjercicios;
            _Kilos = modelo.Kilos;
            _Calorias = modelo.Calorias;
        }
        #endregion
        #region Objetos
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public Guid IdEjercicios
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
        public async Task Editarejercicios()
        {
            var funcion = new Dejercicios();
            var parametros = new MListejercicios();
            parametros.Calorias = Calorias;
            parametros.Kilos = Kilos;
            parametros.Distancia = Distancia;
            parametros.IdEjercicios = IdEjercicios;

            await funcion.editarEjercicios(parametros);
            await Volver();
        }
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion
        #region Comandos
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand EditCommand => new Command(async () => await Editarejercicios());
        public ICommand Volvercommand => new Command(async () => await Volver());
        #endregion
    }
}
