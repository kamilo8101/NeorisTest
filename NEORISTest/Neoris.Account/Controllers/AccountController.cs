using Microsoft.AspNetCore.Mvc;
using Neoris.Accounts.DBModel.Interface;
using Neoris.Accounts.DTO;

namespace Neoris.Accounts.Controllers
{
    [ApiController]
    [Route("cuentas")]
    public class AccountController : ControllerBase
    {
        private IAccountLogic _accountLogic;
        public AccountController(IAccountLogic clientLogic) { _accountLogic = clientLogic; }

        [Route("crear")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AccountDTO accountDTO)
        {
            var a = await _accountLogic.Create(accountDTO);
            return Ok(a.Message);
        }

        [Route("editar")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] AccountDTO accountDTO, int id)
        {
            var a = await _accountLogic.Edit(accountDTO, id);
            return Ok();
        }

        [Route("eliminar")]
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var a = await _accountLogic.Delete(id);
            return Ok();
        }

        [Route("All")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var a = await _accountLogic.GetAll();
            return Ok(a);
        }

        [Route("Report")]
        [HttpGet]
        public async Task<IActionResult> Report()
        {
            var a = await _accountLogic.Report();
            return Ok(a);
        }
    }
}
