using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Firebase.Database;
using MiniproyectoSec_CARS.Conexion;
using MiniproyectoSec_CARS.Model;
 
namespace MiniproyectoSec_CARS.Datos
{
    public class Dejercicios
    {

        public async Task InsertarEjercicios(MListejercicios parametros)
        {
            await Cconexion.firebase
                .Child("Ejercicios")
                .PostAsync(new MListejercicios()
                {
                    IdEjercicios = Guid.NewGuid(),
                    Calorias = parametros.Calorias,
                    Distancia = parametros.Distancia,
                    Kilos = parametros.Kilos,

                    //Idpokemon = Guid.NewGuid(),
                });


            //var datosTotales = await Cconexion.firebase.Child("Ejercicios").OnceAsync<MListejercicios>();
            //int sumatoriaCalorias = 0;
            //foreach (var dato in datosTotales) { sumatoriaCalorias += int.Parse(dato.Object.Calorias); }

            ////var consulta = (await Cconexion.firebase
            ////    .Child("Progreso").OnceAsync<Mprogreso>()).FirstOrDefault();

            ////int colsultaCal = Convert.ToInt32(consulta.Object.Sumatoria);

            //await Cconexion.firebase
            //    .Child("Progreso")
            //    .PutAsync(new Mprogreso()
            //    {
            //        Sumatoria = sumatoriaCalorias

            //    });
        }
        //public async Task<Mprogreso> MostrarSumatoria()
        //{
        //    var datosTotales = await Cconexion.firebase.Child("Progreso").OnceAsync<Mprogreso>();
        //    Mprogreso total = new Mprogreso() { Sumatoria = datosTotales.};

        //    total = datosTotales;
        //}
        public async Task editarEjercicios(MListejercicios parametros)
        {
            var consulta = (await Cconexion.firebase
                .Child("Ejercicios").OnceAsync<MListejercicios>()).Where(a => a.Object.IdEjercicios == parametros.IdEjercicios)
                .FirstOrDefault();

            await Cconexion.firebase
                .Child("Ejercicios").Child(consulta.Key).PutAsync(new MListejercicios()
                {
                    Calorias = parametros.Calorias,
                    Distancia = parametros.Distancia,
                    Kilos = parametros.Kilos,
                    IdEjercicios = parametros.IdEjercicios
                });
        }
        public async Task deleteEjercicios(MListejercicios parametros)
        {
            var consulta = (await Cconexion.firebase
                .Child("Ejercicios").OnceAsync<MListejercicios>()).Where(a => a.Object.IdEjercicios == parametros.IdEjercicios)
                .FirstOrDefault();

            await Cconexion.firebase
                .Child("Ejercicios").Child(consulta.Key).DeleteAsync();
        }
        public async Task<ObservableCollection<MListejercicios>> Mostrarejercicios()
        {
            //forma de lista

            //return (await Cconexion.firebase
            //.Child("Ejercicios")
            //.OnceAsync<MListejercicios>())
            //.Select(item => new MListejercicios
            //{
            //    Calorias = item.Object.Calorias,
            //    Distancia = item.Object.Distancia,
            //    IdEjercicios = item.Object.IdEjercicios,
            //    Kilos = item.Object.Kilos,
            //}).ToList();

            //forma de observable collection
            
            var data = await Task.Run(() => Cconexion.firebase
                .Child("Ejercicios")
                .AsObservable<MListejercicios>()
                .AsObservableCollection());
            return data;
        }

    }
}
