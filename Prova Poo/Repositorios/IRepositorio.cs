using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> GetTodos();
        Task<List<T>> GetTodosAsync();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
        List<T> ExecuteQuery(string query);
        T Find(params object[] key);
        T First(Expression<Func<T, bool>> predicate);
        void Adicionar(T entity);
        void AdicionarTodos(List<T> entity);
        void Atualizar(T entity);
        void Deletar(Func<T, bool> predicate);
        void Commit();
        void Dispose();
    }
}
