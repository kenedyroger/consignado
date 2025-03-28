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

        _sut = new Proponente(nome, dataNascimento, numeroIdPrevidenciaSocial, enderecoProponente);
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

}

class Proponente
{
    public Proponente(string nome, DateOnly dataNascimento, string numeroIdPrevidenciaSocial, Endereco enderecoResidencial)
    {
        this.Nome = nome;
        this.DataNascimento = dataNascimento;
        this.NumeroIdPrevidenciaSocial = numeroIdPrevidenciaSocial;
        this.EnderecoResidencial = enderecoResidencial;
    }
    public string Nome { get; set; }
    public DateOnly DataNascimento { get; set; }
    public string NumeroIdPrevidenciaSocial { get; private set; }
    public Endereco EnderecoResidencial { get; private set; }
}

public class Endereco
{
    public Endereco(string rua, string numero, string bairro, string cidade, string estado, string cep)
    {
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