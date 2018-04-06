using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MVCClientesServidorJson.Models
{
    public class Cliente
    {
        [JsonProperty("idcliente")]
        public int IdCliente { get; set; }
        [JsonProperty("nombre")]
        public String Nombre { get; set; }
        [JsonProperty("paginaweb")]
        public String PaginaWeb { get; set; }
        [JsonProperty("imagencliente")]
        public String Imagen { get; set; }

    }
}