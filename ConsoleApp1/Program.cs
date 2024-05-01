using System.Reactive.Linq;

namespace ConsoleApp1;

public class Program
{
    private static EstacaoMeteorologica _estacaoMeteorologica = new(30);
    private static EstacaoReativa _estacaoReativa = new();

    static void Main(string[] args)
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    _estacaoMeteorologica.Atualizar();
        //    Console.WriteLine($"Temperatura Atual: {_estacaoMeteorologica.TemperaturaAtual}º");
        //}

        //_estacaoReativa.Temperatura
        //    .Subscribe(x =>
        //    {
        //        Console.WriteLine($"Temperatura: {x}º");
        //    });

        //_estacaoReativa.Pressao
        //    .Subscribe(x =>
        //    {
        //        Console.WriteLine($"Pressao: {x}%");
        //    });

        var combinedObservable = _estacaoReativa.Temperatura.CombineLatest(_estacaoReativa.Pressao, (temp, press) =>
            {
                return $"Temperatura: {temp}º - Pressão: {press} atm";
            });

        combinedObservable.Subscribe(x =>
        {
            Console.WriteLine(x);
        });

        Console.ReadKey();
    }
}