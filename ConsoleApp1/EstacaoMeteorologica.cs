namespace ConsoleApp1;

public class EstacaoMeteorologica
{
    public EstacaoMeteorologica(int temperaturaInicial)
    {
        Temperatura = temperaturaInicial;
    }

    public int Temperatura { get; private set; }

    public void Atualizar()
    {
        Temperatura = new Random().Next(30);
    }
}