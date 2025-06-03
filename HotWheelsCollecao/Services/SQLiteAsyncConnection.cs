
namespace HotWheelsCollecao.Services
{
    internal class SQLiteAsyncConnection
    {
        private string dbPath;

        public SQLiteAsyncConnection(string dbPath)
        {
            this.dbPath = dbPath;
        }

        internal object CreateTableAsync<T>()
        {
            throw new NotImplementedException();
        }

        internal object Table<T>()
        {
            throw new NotImplementedException();
        }
    }
}