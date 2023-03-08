using Microsoft.AspNetCore.Mvc;
using Neoris.Transactions.DBModel.Interface;
using Neoris.Transactions.DTO;

namespace Neoris.Transactions.Controllers
{
    [ApiController]
    [Route("movimientos")]
    public class TransactionsController : ControllerBase
    {
        private ITransactionLogic _transactionLogic;
        public TransactionsController(ITransactionLogic clientLogic) { _transactionLogic = clientLogic; }

        [Route("crear")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionDTO transactionDTO)
        {
            var a = await _transactionLogic.Create(transactionDTO);
            return Ok(a.Message);
        }

        [Route("editar")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] TransactionDTO transactionDTO, int id)
        {
            var a = await _transactionLogic.Edit(transactionDTO, id);
            return Ok();
        }

        [Route("eliminar")]
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var a = await _transactionLogic.Delete(id);
            return Ok();
        }

        [Route("All")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var a = await _transactionLogic.GetAll();
            return Ok(a);
        }
    }
}
