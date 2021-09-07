using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Core.Generic
{
    public class HttpHelper<T>
    {
        public async Task<T> Get(string serviceAddress)
        {
            //Creamos una instancia de HttpClient
            var client = new HttpClient();
            //Asignamos la URL
            client.BaseAddress = new Uri(serviceAddress);
            //Llamada asíncrona al sitio
            var response = await client.GetAsync(client.BaseAddress);
            //Nos aseguramos de recibir una respuesta satisfactoria
            response.EnsureSuccessStatusCode();
            //Convertimos la respuesta a una variable string
            var jsonResult = await response.Content.ReadAsStringAsync();
            //Se deserializa la cadena y se convierte en una instancia de WeatherResult
            var result = JsonConvert.DeserializeObject<T>(jsonResult);

            return result;
        }

        public async Task<T> Post(string serviceAddress, T content)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(serviceAddress, CreateHttpContent(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        public async Task<T> Put(string serviceAddress, T content)
        {
            var client = new HttpClient();
            var response = await client.PutAsync(serviceAddress, CreateHttpContent(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        private static HttpContent CreateHttpContent(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

    }
}
