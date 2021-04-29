using ApiClient.Model;
using Client.Domain.Interface;
using Client.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClient.Controllers
{
    [Route("api/[controller]")]
   // [EnableCors("CorsPolicy")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientDomain oIClientDomain;

        public ClientController(IClientDomain oIClientDomain_)
        {
            oIClientDomain = oIClientDomain_;
        }

        private async Task<List<ClientEntity>> GetCliente(List<ClientEntity> list)
        {

            //var list = new List<Client_Entity>()
            //{
            //    new Client_Entity(){ Id=1, Nombres="SIlver", Apellidos="martinez" },
            //     new Client_Entity(){ Id=2, Nombres="SIlve55r", Apellidos="mar222tinez" },
            //      new Client_Entity(){ Id=2, Nombres="SIlv55222er", Apellidos="martinez" },

            //};

            return list;
        }


        [HttpGet]
        public async Task<ActionResult<List<ClientEntity>>> Get()
        {

            var list = await GetCliente(new List<ClientEntity>());

            if(list.Count == 0)
            {
                return NotFound();
            }

            return list;

        }

        [HttpGet]
        [Route("GetLista")]
        public async Task<ActionResult<List<ClientEntity>>> GetLista()
        {

           var list_ = oIClientDomain.GetAll(new ClientEntity());

            var list = await GetCliente(list_);

            if (list_.Count == 0)
            {
                return NotFound();
            }

            return list;

        }

        [HttpPost]
        [Route("SaveClient")]
        public IActionResult SaveClient([FromBody] ClientEntity obj)
        {
            //obj.CreationDate = DateTime.Now;
            //obj.CreationUser = "Admin";
            //obj.CreationIPTerminal = "Admin";
            var result = oIClientDomain.InsertClient(obj);

            return Ok(JsonConvert.SerializeObject(result));
        }

    }
}
