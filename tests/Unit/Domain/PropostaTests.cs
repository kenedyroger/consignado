using System;
using Domain;

namespace Unit.Domain;

[TestClass]
public class PropostaTests
{

    [TestMethod]
    public void Deve_validar_se_proposta_invalida_proponente_com_80_anos_ou_mais()
    {
        Agente agente = new Agente();

        DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);
        DateOnly dataNaoPermitida = dataAtual.AddYears(-80).AddDays(-1);
        DateOnly dataNascimento = dataNaoPermitida;

        string nome = "fulano de tal";
        string numeroIdPrevidenciaSocial = "1234";

        string rua = "rua prof. ciclano de tal";
        string numeroResidencial = "s/n";
        string bairro = "parque das flores";
        string cidade = "algum lugar";
        string estado = "MG";
        string cep = "00000-000";

        Endereco enderecoProponente = new Endereco(rua, numeroResidencial, bairro, cidade, estado, cep);

        decimal valorRendimento = 0.1m;

        Proponente proponente = new Proponente(nome, dataNascimento, numeroIdPrevidenciaSocial, enderecoProponente, valorRendimento);
        Proposta _sut = new Proposta(agente, proponente);

        Assert.IsFalse(_sut.Validar());
    }

    [TestMethod]
    public void Deve_validar_se_proposta_valida_proponente_com_menos_80_anos()
    {
        Agente agente = new Agente();

        DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);
        DateOnly dataNaoPermitida = dataAtual.AddYears(-80).AddDays(1);
        DateOnly dataNascimento = dataNaoPermitida;

        string nome = "fulano de tal";
        string numeroIdPrevidenciaSocial = "1234";

        string rua = "rua prof. ciclano de tal";
        string numeroResidencial = "s/n";
        string bairro = "parque das flores";
        string cidade = "algum lugar";
        string estado = "MG";
        string cep = "00000-000";

        Endereco enderecoProponente = new Endereco(rua, numeroResidencial, bairro, cidade, estado, cep);

        decimal valorRendimento = 0.1m;

        Proponente proponente = new Proponente(nome, dataNascimento, numeroIdPrevidenciaSocial, enderecoProponente, valorRendimento);
        Proposta _sut = new Proposta(agente, proponente);

        Assert.IsTrue(_sut.Validar());
    }
}


public class Proposta
{
    private readonly int IDADE_MAXIMA = 80;
    private Agente _agente;
    private Proponente _proponente;
    public Proposta(Agente agente, Proponente proponente)
    {
        this._agente = agente;
        this._proponente = proponente;
    }

    private bool IdadeProponenteInvalidaProposta()
    {
        DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);
        DateOnly dataNaoPermitida = dataAtual.AddYears(-80);
        return this._proponente.DataNascimento <= dataNaoPermitida;
    }
    public bool Validar()
    {
        if (this.IdadeProponenteInvalidaProposta())
            return false;

        return true;
    }
}