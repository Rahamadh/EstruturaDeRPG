using System.Security.Cryptography.X509Certificates;

public abstract class Profissao
{
  public abstract int DadoVida {get;}
  public abstract int Level {get;}
}
public class Guerreiro : Profissao
{

    public override int DadoVida => 8;
    public override int Level => 1;
   
}