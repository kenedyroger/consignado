using Domain;

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

        string rua = "rua prof. ciclano de tal";
        string numeroResidencial = "s/n";
        string bairro = "parque das flores";
        string cidade = "algum lugar";
        string estado = "MG";
        string cep = "00000-000";

        Endereco enderecoProponente = new Endereco(rua, numeroResidencial, bairro, cidade, estado, cep);

        decimal valorRendimento = 0.1m;

        _sut = new Proponente(nome, dataNascimento, numeroIdPrevidenciaSocial, enderecoProponente, valorRendimento);
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

    [TestMethod]
    public void Nao_deve_criar_proponente_sem_endereco_residencial_completo()
    {
        var proponente = _sut;
        Assert.IsNotNull(proponente.EnderecoResidencial);
        Assert.IsNotNull(proponente.EnderecoResidencial.Rua);
        Assert.IsNotNull(proponente.EnderecoResidencial.Numero);
        Assert.IsNotNull(proponente.EnderecoResidencial.Bairro);
        Assert.IsNotNull(proponente.EnderecoResidencial.Cidade);
        Assert.IsNotNull(proponente.EnderecoResidencial.Estado);
        Assert.IsNotNull(proponente.EnderecoResidencial.CEP);
        Assert.IsFalse(string.IsNullOrEmpty(proponente.EnderecoResidencial.Rua));
        Assert.IsFalse(string.IsNullOrEmpty(proponente.EnderecoResidencial.Numero));
        Assert.IsFalse(string.IsNullOrEmpty(proponente.EnderecoResidencial.Bairro));
        Assert.IsFalse(string.IsNullOrEmpty(proponente.EnderecoResidencial.Cidade));
        Assert.IsFalse(string.IsNullOrEmpty(proponente.EnderecoResidencial.Estado));
        Assert.IsFalse(string.IsNullOrEmpty(proponente.EnderecoResidencial.CEP));
    }

    [TestMethod]
    public void Nao_deve_criar_proponente_sem_informar_os_rendimentos()
    {
        var proponente = _sut;
        Assert.IsNotNull(proponente.ValorRendimento);
        Assert.IsTrue(proponente.ValorRendimento > 0m);

        decimal rendimentoInvalido = 0m;
        Assert.ThrowsException<ArgumentException>(() => proponente.ValorRendimento = rendimentoInvalido);
    }
}