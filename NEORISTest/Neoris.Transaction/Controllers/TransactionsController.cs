using Microsoft.AspNetCore.Mvc;
using Neoris.Common;
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
            EntityResult<TransactionDTO> result = await _transactionLogic.Create(transactionDTO);
            if (result.IsCorrect)
                return Ok(result);
            else
                return Ok(result.Message);
        }

        [Route("editar")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] TransactionDTO transactionDTO, int id)
        {
            EntityResult<TransactionDTO> result = await _transactionLogic.Edit(transactionDTO, id);
            if (result.IsCorrect)
                return Ok(result);
            else
                return Ok(result.Message);
        }

        [Route("eliminar")]
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            EntityResult<TransactionDTO> result = await _transactionLogic.Delete(id);
            if (result.IsCorrect)
                return Ok(result);
            else
                return Ok(result.Message);
        }

        [Route("All")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            EntityResult<TransactionDTO> result = await _transactionLogic.GetAll();
            if (result.IsCorrect)
                return Ok(result);
            else
                return Ok(result.Message);
        }
    }
}
