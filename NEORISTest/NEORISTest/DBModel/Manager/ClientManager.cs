using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Neoris.Common;
using Neoris.User.DBModel.Interface;
using Neoris.User.DBModel.Tables;
using Neoris.User.DTO;
using System.Linq.Expressions;

namespace Neoris.User.DBModel.Manager
{
    public class ClientManager : IClientManager
    {
        private Neoris_Context _context;

        public ClientManager(Neoris_Context context)
        {
            _context = context;
        }

        public async Task<EntityResult<Person>> NewClient(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();
            return new EntityResult<Person>();
        }
        public async Task<EntityResult<ClientDTO>> EditClient(Person person)
        {
            _context.Attach(person.Client);
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new EntityResult<ClientDTO>();
        }

        public async Task<EntityResult<ClientDTO>> DeleteClient(Client client)
        {
            using (var transact = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Client.Remove(client);
                    _context.Person.Remove(client.Person);
                    await _context.SaveChangesAsync();
                    transact.Commit();
                    return new EntityResult<ClientDTO>();
                }
                catch (Exception)
                {
                    transact.Rollback();
                    throw;
                }
            }
        }

        public async Task<EntityResult<Client>> GetClient(Expression<Func<Client, bool>> function)
        {
            return new EntityResult<Client> { SimpleObject = await _context.Client.Include(x => x.Person).Where(function).FirstOrDefaultAsync() };
        }

        public async Task<EntityResult<Client>> GetAll()
        {
            return new EntityResult<Client> { DataList = await _context.Client.Include(x => x.Person).ToListAsync() };
        }

        public async Task<EntityResult<Person>> GetPerson(Expression<Func<Person, bool>> function)
        {
            return new EntityResult<Person> { SimpleObject = await _context.Person.Include(x => x.Client).Where(function).FirstOrDefaultAsync() };
        }
    }
}
