using AutoMapper;
using Neoris.Common;
using Neoris.Transactions.DBModel.Interface;
using Neoris.Transactions.DTO;
using Neoris.Transactions.DBModel.Tables;
using System.Text.Json;

namespace Neoris.Transactions.Logic
{
    public class TransactionLogic : ITransactionLogic
    {
        private ITransactionManager _transactionManager;

        private readonly IConfiguration _configuration;

        private readonly IMapper _mapper;
        //private readonly IRepository<Client> _client;
        //private readonly IHttpClientFactory _httpClient;

        //private readonly ILogger<BookServices> _logger;
        public TransactionLogic(ITransactionManager transactionManager, IMapper mapper, IConfiguration configuration)
        {
            //_httpClient = httpClient;
            _transactionManager = transactionManager;
            _mapper = mapper;
            _configuration = configuration;
            //_client = clien;
        }

        public async Task<EntityResult<TransactionDTO>> Create(TransactionDTO TransactionDTO)
        {
            Transaction transaction = _mapper.Map<TransactionDTO, Transaction>(TransactionDTO);
            EntityResult<Transaction> result = await _transactionManager.NewTransaction(transaction);
            if (result.IsCorrect)
                return new EntityResult<TransactionDTO>();
            else
                return new EntityResult<TransactionDTO>("El movimiento no fue creado");
        }
        public async Task<EntityResult<TransactionDTO>> Edit(TransactionDTO TransactionDTO, int id)
        {
            EntityResult<Transaction> result = await _transactionManager.GetTransaction(x => x.Id == id);
            Transaction transaction = result.SimpleObject;
            transaction.Date = DateTime.Now;
            transaction.Transaction_Type = TransactionDTO.Transaction_Type;
            transaction.Transaction_value = TransactionDTO.Transaction_value;
            transaction.Balance = TransactionDTO.Balance;

            return await _transactionManager.EditTransaction(transaction);
        }

        public async Task<EntityResult<TransactionDTO>> Delete(int id)
        {
            EntityResult<Transaction> result = await _transactionManager.GetTransaction(x => x.Id == id);
            if (result.IsCorrect && result.SimpleObject != null)
                return await _transactionManager.DeleteTransaction(result.SimpleObject);
            else
                return new EntityResult<TransactionDTO>("No se encontraron datos");
        }

        public async Task<EntityResult<TransactionDTO>> GetAll()
        {
            EntityResult<Transaction> result = await _transactionManager.GetAll();
            if (result.IsCorrect && result.DataList.Any())
                return new EntityResult<TransactionDTO> { DataList = _mapper.Map<List<Transaction>, List<TransactionDTO>>(result.DataList.ToList()) };
            else
                return new EntityResult<TransactionDTO>("No se encontraron datos");
        }

        //public async Task<EntityResult<TransactionDTO>> Report() 
        //{
        //    GetAccounts();

        //    return null;
        //}

        //public async Task<(bool result, AccountDTO Acount, string ErrorMessage)> GetAccounts()
        //{
        //    try
        //    {
        //        var client = this._httpClient.CreateClient("GetAccounts");
        //        var response = await client.GetAsync($"api/cuentas/All");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var content = await response.Content.ReadAsStringAsync();
        //            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        //            var result = JsonSerializer.Deserialize<AccountDTO>(content, options);
        //            return (true, result, null);
        //        }
        //        return (false, null, response.ReasonPhrase);
        //    }
        //    catch (Exception ex)
        //    {
        //        //this._logger.LogError(ex.ToString());
        //        return (false, null, ex.Message);
        //    }
        //}
    }
}
