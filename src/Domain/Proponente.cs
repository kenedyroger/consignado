using System;

namespace Domain;

public class Proponente
{
    private decimal _valorRendimento;
    private string _nome;
    private DateOnly _dataNascimento;
    private string _numeroIdPrevidenciaSocial;

    public Proponente(string nome, DateOnly dataNascimento, string numeroIdPrevidenciaSocial, Endereco enderecoResidencial, decimal valorRendimento)
    {
        this._nome = nome;
        this._dataNascimento = dataNascimento;
        this._numeroIdPrevidenciaSocial = numeroIdPrevidenciaSocial;
        this.EnderecoResidencial = enderecoResidencial;

        if (valorRendimento <= 0m)
            throw new ArgumentException("Proponente precisa ter valor de rendimento maior do que Zero");
        this._valorRendimento = valorRendimento;
    }
    public string Nome
    {
        get { return _nome; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Trim().Length == 0)
                throw new ArgumentException("Proponente precisa ter um nome");
            this._nome = value;
        }
    }
    public DateOnly DataNascimento
    {
        get { return _dataNascimento; }
    }
    public string NumeroIdPrevidenciaSocial
    {
        get { return _numeroIdPrevidenciaSocial; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Trim().Length == 0)
                throw new ArgumentException("Proponente precisa ter um número de Previdência Social");
            this._numeroIdPrevidenciaSocial = value;
        }
    }

    public Endereco EnderecoResidencial { get; set; }

    public decimal ValorRendimento
    {
        get { return _valorRendimento; }
        set
        {
            if (value <= 0m)
                throw new ArgumentException("Proponente precisa ter valor de rendimento maior do que Zero");
            this._valorRendimento = value;
        }
    }
}

