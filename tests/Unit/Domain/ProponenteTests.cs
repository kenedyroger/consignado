namespace Unit.Domain;

[TestClass]
public class ProponenteTests
{
    private Proponente _sut;

    [TestInitialize]
    public void Setup()
    {
        _sut = new Proponente("fulano de tal", new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day));
    }

    [TestMethod]
    public void Nao_deve_criar_proponente_sem_nome()
    {
        var proponente = _sut;
        Assert.IsNotNull(proponente.Nome);
        Assert.IsFalse(string.IsNullOrEmpty(proponente.Nome));
    }

    [TestMethod]
    public void Nao_deve_criar_proponente_data_nascimento()
    {
        var proponente = _sut;
        Assert.IsNotNull(proponente.DataNascimento);
    }

}

class Proponente
{
    public Proponente(string nome, DateOnly dataNascimento)
    {
        this.Nome = nome;
        this.DataNascimento = dataNascimento;
    }
    public string Nome { get; set; }
    public DateOnly DataNascimento { get; set; }
}