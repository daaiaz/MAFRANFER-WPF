

namespace MAFRANFER_WPF
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public partial class CursoClie
    {
        public int curso_id { get; set; }
        public string descripcion { get; set; }
        public int duracion { get; set; }
        public System.DateTime fecha_inicio { get; set; }
        public System.DateTime fecha_fin { get; set; }
        public decimal precio { get; set; }
        public int profesor_id { get; set; }
        public string estado { get; set; }

        public static async Task<List<CursoClie>> ObtenerCursos()
        {
            List<CursoClie> lstCursos = new List<CursoClie>();

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:50272/");

                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respuesta = await cliente.GetAsync("api/cursoes");

                if (respuesta.IsSuccessStatusCode)
                {
                    lstCursos = await respuesta.Content.ReadAsAsync<List<CursoClie>>();
                }
            }

            return lstCursos;
        }

        public static async Task<bool> NuevoCurso(CursoClie c)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:50272/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync("api/cursoes", c);
                return respuesta.IsSuccessStatusCode;
            }
        }

        public static async Task<bool> ActualizarCurso(CursoClie c)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:50272/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = await cliente.PutAsJsonAsync("api/cursoes/" + c.curso_id, c);
                return respuesta.IsSuccessStatusCode;
            }
        }

        public static async Task<bool> EliminarCurso(CursoClie c)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:50272/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = await cliente.DeleteAsync("api/cursoes/" + c.curso_id);
                return respuesta.IsSuccessStatusCode;
            }
        }
    }
}
