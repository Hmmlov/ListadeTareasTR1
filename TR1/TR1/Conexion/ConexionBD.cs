using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR1.Modelo;

namespace TR1.Conexion
{
    public class ConexionBD
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://listatareas-7bfb7-default-rtdb.firebaseio.com/");

        public async Task<bool> Agregar(MTareas mtareas)
        {
            var data = await firebaseClient.Child(nameof(MTareas)).PostAsync(JsonConvert.SerializeObject(mtareas));
            if(!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<MTareas>> Listar()
        {
            return (await firebaseClient.Child(nameof(MTareas)).OnceAsync<MTareas>()).Select(item => new MTareas
            {
                Titulo = item.Object.Titulo,
                Descripcion = item.Object.Descripcion,
                Estado = item.Object.Estado,
                Id = item.Key
            }).ToList();
        }
        public async Task<MTareas> Editar(string id)
        {
            return (await firebaseClient.Child(nameof(MTareas) + "/" + id).OnceSingleAsync<MTareas>());
        }

        public async Task<bool> Actualizar(MTareas mtareas)
        {
            await firebaseClient.Child(nameof(MTareas) + "/" + mtareas.Id).PutAsync(JsonConvert.SerializeObject(mtareas));
            return true;
        }

        public async Task<bool> Eliminar(string id)
        {
            await firebaseClient.Child(nameof(MTareas) + "/" + id).DeleteAsync();
            return true;
        }
    }
}
