var curso = new Curso();
curso.EventoAoExederAlunos += AvisarPorEmail;
curso.EventoAoExederAlunos += AvisarPorTelefone;
curso.EventoAoExederAlunos += AvisarCarta;


var cont = 1;
while (curso.Alunos.Count <= curso.MaxAlunos)
{
    curso.AdicionaAluno(($"Rodolfo {cont}", "rodolfo0ti@gmail.com", "1234567899", "rua x de impar - Par Meio"));

    cont++;
    Thread.Sleep(500);
}


void AvisarPorEmail(object sender, List<Aluno> eventArgs)
{
    Console.WriteLine("\n\n");
    eventArgs.ForEach(aluno =>
    {
        Console.WriteLine($"Avisando {aluno.Nome} por email");
        Thread.Sleep(500);
    });
}
void AvisarPorTelefone(object sender, List<Aluno> eventArgs)
{
    Console.WriteLine("\n\n");
    eventArgs.ForEach(aluno =>
    {
        Console.WriteLine($"Avisando {aluno.Nome} por felefone");
        Thread.Sleep(500);
    });
}
void AvisarCarta(object sender, List<Aluno> eventArgs)
{
    Console.WriteLine("\n\n");
    eventArgs.ForEach(aluno =>
    {
        Console.WriteLine($"Avisando {aluno.Nome} por carta");
        Thread.Sleep(500);
    });
}

Console.WriteLine("\n\n---FIM---");




public class Curso
{
    public List<Aluno> Alunos { get; set; } = new();
    public int MaxAlunos { get; set; } = 10;
    public event EventHandler<List<Aluno>> EventoAoExederAlunos;

    public void AdicionaAluno((string nome, string email, string telefone, string endereco) aluno)
    {
        Alunos.Add(new Aluno(aluno.nome, aluno.email, aluno.telefone, aluno.endereco));
        Console.WriteLine($"Aluno {aluno.nome} adicionado ao curso");

        if (Alunos.Count > MaxAlunos)
            AoExecederNumeroDeAlunos(EventArgs.Empty);
    }
    public void AoExecederNumeroDeAlunos(EventArgs e)
    {
        Console.Clear();
        Console.WriteLine("Numero de alunos exedido. Inicio das mensagens..");
        EventoAoExederAlunos?.Invoke(this, Alunos);
    }
}

public class Aluno
{
    public Aluno(string nome, string email, string telefone, string endereco)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
    }

    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
}