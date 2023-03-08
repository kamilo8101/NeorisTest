using Microsoft.AspNetCore.Mvc;
using Neoris.Common;
using Neoris.User.DBModel.Interface;
using Neoris.User.DTO;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Neoris.User.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClientController : ControllerBase
    {
        private IClientLogic _clientLogic;
        public ClientController(IClientLogic clientLogic) { _clientLogic = clientLogic; }  

        [Route("crear")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientDTO clientDTO) 
        {
            EntityResult<ClientDTO> result = await _clientLogic.Create(clientDTO);
            if(result.IsCorrect)
                return Ok(result.SimpleObject);
            else
                return Ok(result.Message);
        }       

        [Route("editar")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] ClientDTO clientDTO, int id)
        {
            EntityResult<ClientDTO> result =  await _clientLogic.Edit(clientDTO, id);
            if (result.IsCorrect)
                return Ok(result.SimpleObject);
            else
                return Ok(result.Message);
        }

        [Route("eliminar")]
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var a = await _clientLogic.Delete(id);
            return Ok();
        }

        [Route("All")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var a = await _clientLogic.GetAll();
            return Ok(a);
        }
    }
}
