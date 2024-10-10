using CalculadoraTdd;

namespace TestCalculadora;

public class UnitTest1
{
    private string _data = "10/10/2024";
    public Calculadora construirClasse()
    {
        string data = _data;
        return new Calculadora(data);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 3, 5)]
    [InlineData(3, 5, 8)]
    public void testSomar(int a, int b, int expected)
    {
        Calculadora calc = construirClasse();

        int resultado = calc.somar(a, b);
        
        Assert.Equal(expected, resultado);
    }

    [Theory]
    [InlineData(1, 2, -1)]
    [InlineData(5, 3, 2)]
    [InlineData(3, 3, 0)]
    public void testSubtrair(int a, int b, int expected)
    {
        Calculadora calc = construirClasse();

        int resultado = calc.subtrair(a, b);
        
        Assert.Equal(expected, resultado);
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(5, 3, 15)]
    [InlineData(2, 4, 8)]
    public void testMultiplicar(int a, int b, int expected)
    {
        Calculadora calc = construirClasse();

        int resultado = calc.multiplicar(a, b);
        
        Assert.Equal(expected, resultado);
    }
    
    [Theory]
    [InlineData(6, 2, 3)]
    [InlineData(5, 5, 1)]
    [InlineData(9, 1, 9)]
    public void testDividir(int a, int b, int expected)
    {
        Calculadora calc = construirClasse();

        int resultado = calc.dividir(a, b);
        
        Assert.Equal(expected, resultado);
    }

    [Fact]
    public void testDividirPorZero()
    {
        Calculadora calc = construirClasse();

        Assert.Throws<DivideByZeroException>(() => calc.dividir(1, 0));
    }

    [Fact]
    public void testHistorico()
    {
        Calculadora calc = construirClasse();

        calc.somar(1, 2);
        calc.subtrair(3, 1);
        calc.multiplicar(2, 2);
        calc.dividir(4, 2);

        List<string> listaHistorico = calc.historico();

        Assert.NotEmpty(listaHistorico);
        Assert.Equal(3, listaHistorico.Count);

        Assert.Equal($"4 / 2 = 2 em {_data}", listaHistorico[0]);
        Assert.Equal($"2 * 2 = 4 em {_data}", listaHistorico[1]);
        Assert.Equal($"3 - 1 = 2 em {_data}", listaHistorico[2]);
    }
}