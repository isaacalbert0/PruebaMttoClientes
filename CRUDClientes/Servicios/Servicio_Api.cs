using CRUDClientes.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Text;
using static System.Net.WebRequestMethods;

namespace CRUDClientes.Servicios
{
    public class Servicio_Api : IServicio_Api
    {
        private static string _baseurl = "http://localhost:5252";

        public Servicio_Api()
        {
            var builderd = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            //_baseurl = builderd.GetSection("");
        }

        public async Task<List<Clientes>> Lista()
        {
            List<Clientes> lista = new List<Clientes>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("api/Clientes/");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                json_respuesta = json_respuesta.Replace("[", "");
                json_respuesta = json_respuesta.Replace("]", "");

                var resultado = JsonConvert.DeserializeObject<Clientes>(json_respuesta);

                lista = resultado.ListaClientes;
            }
            return lista;

        }

        public async Task<Clientes> Obtener(string Identificacion)
        {
            Clientes objCliente = new Clientes();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Clientes/{Identificacion}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Clientes>(json_respuesta);
                json_respuesta = json_respuesta.Replace("[", "");
                json_respuesta = json_respuesta.Replace("]", "");
                objCliente = resultado.ObjetoClientes;
                
            }
            return objCliente;
        }

        public async Task<bool> Guardar(Clientes objeto)
        {
            bool respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync($"api/Clientes/", content);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> Editar(Clientes objeto)
        {
            bool respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync($"api/Clientes/", content);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
        public async Task<bool> Eliminar(string Identificacion)
        {
            bool respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"api/Clientes/{Identificacion}");
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}