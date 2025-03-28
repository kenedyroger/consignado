namespace Unit.Domain;

[TestClass]
public class ProponenteTests
{
    private Proponente _sut;

    [TestInitialize]
    public void Setup()
    {
        string nome = "fulano de tal";
        DateOnly dataNascimento = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        string numeroIdPrevidenciaSocial = "1234";
        _sut = new Proponente(nome, dataNascimento, numeroIdPrevidenciaSocial);
    }

    [TestMethod]
    public void Nao_deve_criar_proponente_sem_nome()
    {
        var proponente = _sut;
        Assert.IsNotNull(proponente.Nome);
        Assert.IsFalse(string.IsNullOrEmpty(proponente.Nome));
    }

    [TestMethod]
    public void Nao_deve_criar_proponente_sem_data_nascimento()
    {
        var proponente = _sut;
        Assert.IsNotNull(proponente.DataNascimento);
    }

    [TestMethod]
    public void Nao_deve_criar_proponente_sem_numero_previdencia_social()
    {
        var proponente = _sut;
        Assert.IsNotNull(proponente.NumeroIdPrevidenciaSocial);
        Assert.IsFalse(string.IsNullOrEmpty(_sut.NumeroIdPrevidenciaSocial));
    }
}

class Proponente
{
    public Proponente(string nome, DateOnly dataNascimento, string numeroIdPrevidenciaSocial)
    {
        this.Nome = nome;
        this.DataNascimento = dataNascimento;
        this.NumeroIdPrevidenciaSocial = numeroIdPrevidenciaSocial;
    }
    public string Nome { get; set; }
    public DateOnly DataNascimento { get; set; }
    public string NumeroIdPrevidenciaSocial { get; private set; }

}