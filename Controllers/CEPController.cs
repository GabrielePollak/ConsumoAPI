using Estudoconsumoapi.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Estudoconsumoapi.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class CEPController : ControllerBase
    {
        private static readonly HttpClient httpClient = new HttpClient();

        [HttpGet]
        public async Task<ActionResult<Cep>> Cep(string cep)
        {


            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
                string responseBody = await response.Content.ReadAsStringAsync();
                Cep endereco = JsonSerializer.Deserialize<Cep>(responseBody);
                return Ok(endereco);

            }
            catch (HttpRequestException e)
            {
                return BadRequest(e.Message);
            }



        }
    }
}
