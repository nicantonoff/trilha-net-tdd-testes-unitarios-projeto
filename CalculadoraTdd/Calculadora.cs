using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraTdd;
public class Calculadora
{
    private List<string> _historico;
    private string _data;

    public Calculadora(string data)
    {
        _historico = new List<string>();
        _data = data;
    }

    public int somar(int a, int b)
    {
        int resultado = a + b;
        _historico.Insert(0, $"{a} + {b} = {resultado} em {_data}");
        return resultado;
    }

    public int subtrair(int a, int b)
    {
        int resultado = a - b;
        _historico.Insert(0, $"{a} - {b} = {resultado} em {_data}");
        return resultado;
    }

    public int multiplicar(int a, int b)
    {
        int resultado = a * b;
        _historico.Insert(0, $"{a} * {b} = {resultado} em {_data}");
        return resultado;
    }

    public int dividir(int a, int b)
    {
        int resultado = a / b;
        _historico.Insert(0, $"{a} / {b} = {resultado} em {_data}");
        return resultado;
    }

    public List<string> historico()
    {
        _historico.RemoveRange(3, _historico.Count - 3);
        return _historico;
    }
}