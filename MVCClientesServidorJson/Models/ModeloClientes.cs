using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MVCClientesServidorJson.Models
{
    public class ModeloClientes
    {
        //necesitamos la url de acceso a nuestro api
        Uri urlapi;
        //necesitamos el tipo de contenido que vamos a consumir
        MediaTypeWithQualityHeaderValue media;
        public ModeloClientes()
        {
            this.urlapi = new Uri("http://localhost:63386/");
            media =
                new MediaTypeWithQualityHeaderValue("application/json");
        }
        //task para tareas asincronas
        public async Task<List<Cliente>> GetCliente()
        {
            //using para que cree el objeto lo instancie y luego libere la memoria..
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/Clientes";
                cliente.BaseAddress = this.urlapi;
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(media);
                HttpResponseMessage respuesta = await cliente.GetAsync(peticion);
                if (respuesta.IsSuccessStatusCode) //si la respuesta es correcta vendrá el contenido
                {
                    List<Cliente> clientes =
                        await respuesta.Content.ReadAsAsync<List<Cliente>>();
                    return clientes;
                }
                else
                {
                    return null;
                }

            } 
        }

        public async Task<Cliente> BuscarCliente(int idcliente)
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/Clientes/" + idcliente;
                cliente.BaseAddress = this.urlapi;
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(media);
                HttpResponseMessage respuesta =
                    await cliente.GetAsync(peticion);
                if(respuesta.IsSuccessStatusCode)
                {
                    Cliente cli = await respuesta.Content.ReadAsAsync<Cliente>();
                    return cli;                    
                }
                else { return null; }
            }
        }
        public async Task InsertarCliente(int idcliente,String nombre,String paginaweb,String imagen)
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/Clientes";
                cliente.BaseAddress = this.urlapi;
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(media);
                Cliente cli = new Cliente
                {
                    IdCliente = idcliente,
                    Nombre = nombre,
                    PaginaWeb = paginaweb,
                    Imagen = imagen
                };
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(peticion, cli);
               
            }
        }

        public async Task ModificarCliente(int idcliente, String nombre, String paginaweb, String imagen)
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/Clientes/" + idcliente;
                cliente.BaseAddress = this.urlapi;
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(media);
                Cliente cli = new Cliente
                {
                    IdCliente = idcliente,
                    Nombre = nombre,
                    PaginaWeb = paginaweb,
                    Imagen = imagen
                };

                await cliente.PutAsJsonAsync(peticion, cli);

            }

        }

        public async Task EliminarCliente(int idcliente)
        {
            using (HttpClient cliente = new HttpClient()) {
                String peticion = "api/Clientes/" + idcliente;
                cliente.BaseAddress = this.urlapi;
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));               
                HttpResponseMessage response =
                    await cliente.DeleteAsync(peticion);

            }

        }
    }
}