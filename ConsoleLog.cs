public interface IConsole
{
    void Log (string mensagem);
}
public class Texto : IConsole
{
    public void Log (string mensagem) => Console.WriteLine($"{mensagem}");
    
}
