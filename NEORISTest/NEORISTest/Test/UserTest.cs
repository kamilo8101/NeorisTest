using AutoMapper;
using Moq;
using Neoris.User.DBModel.Tables;
using Neoris.User.DTO;
using Xunit;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Neoris.User.DBModel.Interface;
using Neoris.User.Logic;

namespace Neoris.User.Test
{
    //public class UserTest
    //{

    //    readonly Mock<IRepository<Client>> mockContext = new Mock<IRepository<Client>>();
    //    readonly Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
    //    /// <summary>
    //    /// Método encargado de probar la excepción del Create
    //    /// </summary>
    //    [Fact]
    //    public void CreateUserReturnBusinessException()
    //    {
    //        //Arrange
    //        Client client = new Client { IdChatbot = 0, Cellphone = "12345", CanCode = "abc123", InvoiceCode = "abcd321" };

    //        var data = new List<entityDB.Client>
    //        {
    //            new entityDB.Client {
    //                ClientName = client.CanCode +"_"+ client.InvoiceCode,
    //                }
    //        }.AsQueryable();

    //        mockContext.Setup(x => x.GetByFilter(x => x.Claims.Any(cla => cla.Type == "CanCode" && cla.Value == client.CanCode))).Returns(data);
    //        AccountService service = new AccountService(mockContext.Object, mockConfig.Object);

    //        Assert.ThrowsAsync<BusinessException>(() => service.Create(client));
    //    }

    //    /// <summary>
    //    /// Método encargado de probar el Create
    //    /// </summary>
    //    /// <returns></returns>
    //    [Fact]
    //    public async Task CreateUserReturnResponseUserDTO()
    //    {
    //        //Arrange
    //        IsUserDTO client = new IsUserDTO { IdChatbot = 0, Cellphone = "12345", CanCode = "abc123", InvoiceCode = "abcd321" };
    //        int expectedId = 1;

    //        IQueryable<entityDB.Client>? data = new List<entityDB.Client>
    //        {
    //        }.AsQueryable();

    //        mockContext.Setup(x => x.GetByFilter(x => x.Claims.Any(cla => cla.Type == "CanCode" && cla.Value == client.CanCode))).Returns(data);
    //        mockContext.Setup(x => x.Add(It.IsAny<entityDB.Client>()))
    //            .Callback((entityDB.Client entity) => {
    //                entity.Id = expectedId;
    //            })
    //            .Returns(Task.FromResult<object?>(null));
    //        mockContext.Setup(x => x.SaveChanges()).Returns(Task.FromResult<object?>(null));

    //        AccountService service = new AccountService(mockContext.Object, mockConfig.Object);

    //        //Act
    //        ResponseUserDTO response = await service.Create(client);

    //        //Assert
    //        Assert.Equal(expectedId, response.UserId);
    //    }
    //}
}
