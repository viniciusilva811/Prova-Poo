using System;
using System.Collections.Generic;
using System.Linq;

using Dal;
using System.Linq.Expressions;
using Prova_Poo.Model;

namespace Bll.Pedido
{
    public class episodioBll
    {
        #region Singleton

        private static episodioBll instance = new episodioBll();
        private static IRepositorio<episodio> db = new Repositorio<episodio>();

        private episodioBll()
        {

        }

        public static episodioBll Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        public Prova_Poo.Model.episodio Find(long? id)
        {
            return db.Find(id);
        }

        public IEnumerable<Prova_Poo.Model.episodio> Select(Expression<Func<Prova_Poo.Model.episodio, bool>> predicate)
        {
            return db.Get(predicate);
        }

        public IEnumerable<Prova_Poo.Model.episodio> Select()
        {
            return db.GetTodos();
        }

        public void Add(Prova_Poo.Model.episodio esquema_Servico, string usuario)
        {
            db.Adicionar(esquema_Servico);
            db.Commit();

        }

        public void Update(Prova_Poo.Model.episodio esquema_Servico, string usuario)
        {
            db.Atualizar(esquema_Servico);
            db.Commit();

        }

        public void Remove(long id, string usuario)
        {
            episodio esquema_Servico = Find(id);
            db.Deletar(c => c.Id == id);
            db.Commit();

        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
