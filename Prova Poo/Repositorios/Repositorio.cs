using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.BulkInsert.Extensions;
using Prova_Poo.Model;

namespace Dal
{
    public class Repositorio<T> : IRepositorio<T>, IDisposable where T : class
    {
        private provapooEntities Context;

        public Repositorio()
        {
            Context = new provapooEntities();

        }

        public IEnumerable<T> GetTodos()
        {
            return Context.Set<T>().ToList() ;
        }

        public async Task<List<T>> GetTodosAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return  Context.Set<T>().Where(predicate).ToList();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public List<T> ExecuteQuery(string query)
        {
            return Context.Set<T>().SqlQuery(query).ToList();
        }

        public T Find(params object[] key)
        {
            return Context.Set<T>().Find(key);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public void Adicionar(T entity)
        {
            Context.Set<T>().Add(entity);
            
        }

        public void AdicionarTodos(List<T> entity)
        {
            Context.BulkInsert<T>(entity);
        }

        public void Atualizar(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Deletar(Func<T, bool> predicate)
        {
            Context.Set<T>()
           .Where(predicate).ToList()
           .ForEach(del => Context.Set<T>().Remove(del));
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = new provapooEntities();
            }
            GC.SuppressFinalize(this);
        }
    }
}
