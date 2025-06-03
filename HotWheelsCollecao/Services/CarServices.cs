using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HotWheelsCollecao.Models;

namespace HotWheelsCollecao.Services
{
    public class CarService
    {
        private readonly SQLiteAsyncConnection _database;

        public CarService()
        {
            var dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "hotwheels.db3"
            );

            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CarModelos>().Wait();
        }

        // Obter todos os carrinhos
        public Task<List<CarModelos>> GetAllAsync()
        {
            return _database.Table<CarModelos>().ToListAsync();
        }

        // Obter um carrinho específico
        public Task<CarModelos> GetByIdAsync(int id)
        {
            return _database.Table<CarModelos>()
                            .FirstOrDefaultAsync(c => c.Id == id);
        }

        // Salvar (inserir ou atualizar)
        public Task<int> SaveAsync(CarModelos car)
        {
            if (car.Id != 0)
                return _database.UpdateAsync(car);
            else
                return _database.InsertAsync(car);
        }

        // Deletar carrinho
        public Task<int> DeleteAsync(CarModelos car)
        {
            return _database.DeleteAsync(car);
        }
    }
}
