using Microsoft.AspNetCore.Mvc;
using Neoris.Accounts.DBModel.Interface;
using Neoris.Accounts.DTO;
using Neoris.Common;

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
            EntityResult<AccountDTO> result = await _accountLogic.Create(accountDTO);
            if (result.IsCorrect)
                return Ok(result);
            else
                return Ok(result.Message);
        }

        [Route("editar")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] AccountDTO accountDTO, int id)
        {
            EntityResult<AccountDTO> result = await _accountLogic.Edit(accountDTO, id);
            if (result.IsCorrect)
                return Ok(result);
            else
                return Ok(result.Message);
        }

        [Route("eliminar")]
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            EntityResult<AccountDTO> result = await _accountLogic.Delete(id);
            if (result.IsCorrect)
                return Ok(result);
            else
                return Ok(result.Message);
        }

        [Route("All")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            EntityResult<AccountDTO> result = await _accountLogic.GetAll();
            if (result.IsCorrect)
                return Ok(result);
            else
                return Ok(result.Message);
        }

        //[Route("Report")]
        //[HttpGet]
        //public async Task<IActionResult> Report()
        //{
        //    var a = await _accountLogic.Report();
        //    return Ok(a);
        //}
    }
}
