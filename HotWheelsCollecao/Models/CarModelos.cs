using SQLite;

namespace HotWheelsCollecao.Models;

public class CarModelos : ContentPage
{
    public bool Obtido { get; internal set; }
    public object Desejado { get; internal set; }
    public object Modelo { get; internal set; }

    public class CarModelos()
    {
       
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public string Modelo { get; set; }

        public string Lote { get; set; }

        public int Ano { get; set; }

        public string FotoPath { get; set; }

        public bool Obtido { get; set; }

        public bool Desejado { get; set; }
    }
}