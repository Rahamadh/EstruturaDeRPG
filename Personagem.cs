


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
    public TipoAtributo ID {get;set;}

    public string Nome {get; private set;}
    public int Valor {get;private set;}

    public Atributos (TipoAtributo tipo, string nome, int valor)
    {
        ID = tipo;
        Nome = nome;
        Valor = valor;
        
    }
    public int Modificador
    {
        get
        {
            return (int)Math.Floor((Valor -10)/2.0);
        }
    }
    public void ReceberBonus (int Bonus)
    {
        Valor += Bonus;
    }
    public void ReceberPenalidade (int Pena)
    {
        Valor -= Pena;
    }




    
}
public class Personagem
{
public string Nome {get; private set;}

public int _VidaAtual;

public int Vida
    {
        get
        {
            return _VidaAtual;
        }
        private set
        {
            _VidaAtual = Math.Max(0,value);
        }
    }
    public int vidaMaxima
    {
        get
        {
            var con = _atribudo[TipoAtributo.Constituicao].Modificador;
            
            int Dadoclasse = _profissao.DadoVida;

            return (Dadoclasse * _profissao.Level)+ (con * _profissao.Level);
        }
    }

    public int ClasseArmadura
    {
        get
        {
            var ValorBase = 10 + _atribudo[TipoAtributo.Destreza].Modificador;
            var armadura = 0;
            return ValorBase + armadura;
        }
    }


public int Proficiencia
    {
        get
        {
            int level = _profissao?.Level ?? 1;
            return level switch 
            {
                <= 4 => 2,
                <= 8 => 3,
                <= 12 =>4,
                _ =>5
            };
            
         
           
        }
    }

private Dictionary<TipoAtributo, Atributos> _atribudo = new ();
private Dictionary<string, item> _Item = new ();

private Dictionary<tipoArma, Arma> _arma = new();

   public Profissao _profissao {get; set;}
    public Arma _armaEquipada {get; set;}
    public Ancestral _ancestral {get; set;}

     public void CriarArma ()   
    {
        var NovaArma = new List<Arma>
        {
             new ("Machado Grande",12,1,tipoArma.MachadoGrande,"Corpo-A-Corpo"),
             new ("Espada Longa", 10,1, tipoArma.EspadaLonga, "Corpo-A-Corpo"),
             new ("Arco Longo", 8,1,tipoArma.ArcoLongo, "À Distância")
            
        };
        foreach (var arma in NovaArma)
        {
            _arma[arma.ID] = arma;
        }
    }

  public void CriarItem (string tipo, int valor, int peso)
    {
        if(_Item.ContainsKey(tipo))
        {
            _console.Log("Esse item já existe em seu inventario" );
        }
        else
        {
           item novoitem = new item(tipo, valor,peso);
           _Item.Add(tipo,novoitem);
        }
    }

public IConsole _console;

public int BonusCorpoACorpo ()
    {
        var valorTotal = _atribudo[TipoAtributo.Forca].Modificador + Proficiencia ;
        return valorTotal; 
    }
    public int BonusADistancia ()
    {
        var valorTotal = _atribudo[TipoAtributo.Destreza].Modificador + Proficiencia;

        return valorTotal;
    }


public Personagem(string nome, Profissao profissao, IConsole console, Ancestral raca)
    {
        PegarAtributo();
          Nome = nome;
          _profissao = profissao;
          _console = console ?? new Texto();
          Vida = vidaMaxima;
          _ancestral = raca;
          AdcionarBonus();
  
    }
 

    public bool ArmaEquipada (tipoArma tipo)
    {
        if(_arma.TryGetValue(tipo, out var temp))
        {
            _armaEquipada = temp;

            return true;
        }
        else
        { _console.Log("Arma Inexistente");
            return false;
        }
    }

    public void PegarAtributo ()
    {
        var atributoBase = new List<Atributos>
        {
            new Atributos(TipoAtributo.Forca, "Força",10),
            new Atributos(TipoAtributo.Destreza, "Destreza",10),
            new Atributos(TipoAtributo.Constituicao, "Constituição",10),
            new Atributos(TipoAtributo.Inteligencia, "Inteligência",10),
            new Atributos(TipoAtributo.Sabedoria, "Sabedoria",10),
            new Atributos(TipoAtributo.Carisma, "Carisma",10),
          
        };
        foreach (var temp in atributoBase)
        {
            _atribudo[temp.ID] = temp;
        }

       
    }
    public void AdcionarBonus ()
    {
        foreach(var bonus in _ancestral.bonusAtributos)
        {
            _atribudo[bonus.Key].ReceberBonus(bonus.Value);
        }
    }
    public void verAtributos ()
    {
        Console.WriteLine($"Vida Maxima = {vidaMaxima}");
        foreach (var item in _atribudo)
        {
            
            Console.WriteLine($"{item.Value.Nome}: {item.Value.Valor} {item.Value.Modificador}");
        }

    }
    public int pegarmModificador (TipoAtributo tipo)
    {

        if(_atribudo.TryGetValue(tipo, out var temp))
        {
            return temp.Modificador;

        }
        return 0;
    }

    public void SofrerDano (int dano)
    {
        

        if(Vida <0)
        {
            Vida = 0;
            _console.Log("Morreu");
        }
        else
        {
            Vida -= dano;
        }
    }






}