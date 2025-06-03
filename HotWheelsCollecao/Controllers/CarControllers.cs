using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotWheelsCollecao.Models;
using HotWheelsCollecao.Data;

namespace HotWheelsCollecao.Controllers
{
    public class CarController
    {
        private readonly AppDbContext _context;

        public CarController()
        {
            _context = new AppDbContext();
        }

        public Task<List<CarModelos>> ObterTodosAsync()
        {
            return _context.GetCarsAsync();
        }

        public Task<CarModelos> ObterPorIdAsync(int id)
        {
            return _context.GetCarAsync(id);
        }

        public Task<int> SalvarAsync(CarModelos car)
        {
            return _context.SaveCarAsync(car);
        }

        public Task<int> RemoverAsync(CarModelos car)
        {
            return _context.DeleteCarAsync(car);
        }

        public async Task<List<CarModelos>> FiltrarAsync(string modelo, bool? obtido, bool? desejado)
        {
            var lista = await _context.GetCarsAsync();

            if (!string.IsNullOrWhiteSpace(modelo))
                lista = lista.Where(c => c.Modelo.ToLower().Contains(modelo.ToLower())).ToList();

            if (obtido.HasValue)
                lista = lista.Where(c => c.Obtido == obtido.Value).ToList();

            if (desejado.HasValue)
                lista = lista.Where(c =>
                {
                    return (bool)(c.Desejado = desejado.Value);
                }).ToList();

            return lista;
        }

        public async Task AlternarObtidoAsync(CarModelos car)
        {
            car.Obtido = !car.Obtido;
            await _context.SaveCarAsync(car);
        }

        public async Task AlternarDesejadoAsync(CarModelos car)
        {
            car.Desejado = car.Desejado;
            await _context.SaveCarAsync(car);
        }
    }
}
