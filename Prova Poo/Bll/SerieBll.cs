using System;
using System.Collections.Generic;
using System.Linq;

using Dal;
using System.Linq.Expressions;
using Prova_Poo.Model;

namespace Bll.Pedido
{
    public class serieBll
    {
        #region Singleton

        private static serieBll instance = new serieBll();
        private static IRepositorio<serie> db = new Repositorio<serie>();

        private serieBll()
        {

        }

        public static serieBll Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        public Prova_Poo.Model.serie Find(long? id)
        {
            return db.Find(id);
        }

        public IEnumerable<Prova_Poo.Model.serie> Select(Expression<Func<Prova_Poo.Model.serie, bool>> predicate)
        {
            return db.Get(predicate);
        }

        public IEnumerable<Prova_Poo.Model.serie> Select()
        {
            return db.GetTodos();
        }

        public void Add(Prova_Poo.Model.serie esquema_Servico,string usuario)
        {
            db.Adicionar(esquema_Servico);
            db.Commit();
         
        }

        public void Update(Prova_Poo.Model.serie esquema_Servico,string usuario)
        {
            db.Atualizar(esquema_Servico);
            db.Commit();
          
        }

        public void Remove(long id,string usuario)
        {
            serie esquema_Servico = Find(id);
            db.Deletar(c => c.Id == id);
            db.Commit();
          
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
