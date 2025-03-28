using System;

namespace Domain;

public class Endereco
{
    public Endereco(string rua, string numero, string bairro, string cidade, string estado, string cep)
    {

        if (string.IsNullOrWhiteSpace(rua) || rua.Trim().Length == 0)
            throw new ArgumentException("Endereço informado é inválido, Rua não informada");
        if (string.IsNullOrWhiteSpace(numero) || numero.Trim().Length == 0)
            throw new ArgumentException("Endereço informado é inválido, Numero não informada");
        if (string.IsNullOrWhiteSpace(bairro) || bairro.Trim().Length == 0)
            throw new ArgumentException("Endereço informado é inválido, Bairro não informada");
        if (string.IsNullOrWhiteSpace(cidade) || cidade.Trim().Length == 0)
            throw new ArgumentException("Endereço informado é inválido, Cidade não informada");
        if (string.IsNullOrWhiteSpace(estado) || estado.Trim().Length == 0)
            throw new ArgumentException("Endereço informado é inválido, Estado não informada");
        if (string.IsNullOrWhiteSpace(cep) || cep.Trim().Length == 0)
            throw new ArgumentException("Endereço informado é inválido, CEP não informada");

        this.Rua = rua;
        this.Numero = numero;
        this.Bairro = bairro;
        this.Cidade = cidade;
        this.Estado = estado;
        this.CEP = cep;
    }

    public string Rua { get; private set; }
    public string Numero { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
    public string CEP { get; private set; }
}
