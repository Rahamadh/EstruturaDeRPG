


using System.Data;

public enum TipoAtributo
{
    Forca,
    Destreza,
    Constituicao,
    Sabedoria,
    Inteligencia,
    Carisma
}

public class Atributos
{
    public TipoAtributo ID {get; private set;}
    public string Nome {get; private set;}
    public int Valor {get;private set;}

    

    public Atributos (TipoAtributo tipo, string Nome, int valor)
    {
        ID = tipo;
        this.Nome = Nome;
        Valor = valor;
    }

    public int Modificador   //Variavél que guarda o modificador
    {
        get
        {
            return (int)Math.Floor((Valor -10)/2.0);
        }
    }
  public void SomarBonus (int Bonus)
    {
        Valor += Bonus;
    }
    public void SubtrairBonus (int Pena)
    {
        Valor -= Pena;
    }  
 
}


  
    public class GerenciarAtributos
    {
        private Dictionary<TipoAtributo, Atributos> _atributo = new ();
        public  GerenciarAtributos ()
        {
            AtributoBase();
        }

         private void CriarAtributo (TipoAtributo tipo, string nome, int valor)
    {
        _atributo[tipo] = new Atributos (tipo,nome, valor);
    }
     public void AtributoBase ()
    {
       CriarAtributo(TipoAtributo.Forca, "Força",10);
       CriarAtributo(TipoAtributo.Destreza, "Destreza",10);
       CriarAtributo(TipoAtributo.Constituicao, "Constituição",10);
       CriarAtributo(TipoAtributo.Inteligencia, "Inteligência",10);
       CriarAtributo(TipoAtributo.Sabedoria, "Sabedoria",10);
       CriarAtributo(TipoAtributo.Carisma, "Carisma",10);
       
    }

    public int LerAtributo (TipoAtributo tipo)
    {
        return _atributo[tipo].Valor;
    }
    public int LerModificador(TipoAtributo tipo)
    {
        return _atributo[tipo].Modificador;
    }

    public void VertodosValores ()
    {

        foreach(var temp in _atributo)
        {
             Console.WriteLine($"{temp.Value.Nome}  {temp.Value.Valor} {temp.Value.Modificador}" );
        }

        
        
    }
    public void AplicarBonus (TipoAtributo tipo, int bonus)
    {
        _atributo[tipo].SomarBonus(bonus);
    }
        public void AplicarPenalidade (TipoAtributo tipo, int bonus)
    {
        _atributo[tipo].SubtrairBonus(bonus);
    }

    
    }


