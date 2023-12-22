using System.Collections.Generic;
using Library.database;

namespace Library.Service
{
    public abstract class Service<T1, T2> where T1 : Database<T2> where T2 : Model.Model
    {
        protected readonly T1 Database;

        protected Service(T1 database)
        {
            Database = database;
        }

        public abstract bool Add(T2 model, out string message);

        public abstract List<string> GetAllElementsAsString();

        public abstract T2 GetElementById(int id, out string message);

        public int GetNextId()
        {
            return Database.GetNextId();
        }
    }
}