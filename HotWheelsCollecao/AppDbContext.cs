using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using HotWheelsCollecao.Models;

namespace HotWheelsCollecao.Data
{
    public class AppDbContext
    {
        private readonly SQLiteAsyncConnection _database;

        public AppDbContext()
        {
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "hotwheels.db3");

            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CarModelos>().Wait();
        }

        // Retorna todos os carrinhos
        public Task<List<CarModelos>> GetCarsAsync()
        {
            return _database.Table<CarModelos>().ToListAsync();
        }

        // Retorna um carrinho pelo ID
        public Task<CarModelos> GetCarAsync(int id)
        {
            return _database.Table<CarModelos>()
                            .FirstOrDefaultAsync(c => c.Id == id);
        }

        // Insere ou atualiza um carrinho
        public Task<int> SaveCarAsync(CarModelos car)
        {
            if (car.Id != 0)
                return _database.UpdateAsync(car);
            else
                return _database.InsertAsync(car);
        }

        // Remove um carrinho
        public Task<int> DeleteCarAsync(CarModelos car)
        {
            return _database.DeleteAsync(car);
        }
    }
}
