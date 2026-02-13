using System.Data;

public class item
{
    public string Nome {get;private set;}
    public int Valor {get;private set;}

    public int Peso {get;private set;}

    public item (string nome,int valor,int peso)
    {
        Nome = nome;
        Valor = valor;
        Peso = peso;
    }

  
}
public class Arma
{
    public string? Nome {get; set;}
    public int DadoDano {get; set;}

    public int qntDado {get;set;}
    public tipoArma ID;

    public string Atributo {get;set;}
    public Arma(string nome, int dado,int qntdado, tipoArma tipo, string atributo)
     {
        Nome = nome;
        ID = tipo;
        DadoDano = dado;
        qntDado = qntdado;
        Atributo = atributo;

        
     }

}
 public static class ArmaPadrão
{
    public static Arma _punho = new Arma 
    (
        "Punho",
         4,
         1,
        tipoArma.Punho,
        "Corpo-A-Corpo"
    );
}
public enum tipoArma
{
    MachadoGrande,
    EspadaLonga,

    Punho,

    ArcoLongo
};