
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
            var con = _atributo.LerModificador(TipoAtributo.Constituicao);
            
            int Dadoclasse = _profissao.DadoVida;

            return (Dadoclasse * _profissao.Level)+ (con * _profissao.Level);
        }
    }

    public int ClasseArmadura
    {
        get
        {
            var ValorBase = 10 + _atributo.LerModificador(TipoAtributo.Destreza);
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


private Dictionary<string, item> _Item = new ();

private Dictionary<tipoArma, Arma> _arma = new();

   public Profissao _profissao {get; set;}
    public Arma _armaEquipada {get; set;}
    public Ancestral _ancestral {get; set;}

    public GerenciarAtributos _atributo {get;}

     public void CriarArma ()   
    {
        var NovaArma = new List<Arma>
        {
             new ("Machado Grande",12,1,tipoArma.MachadoGrande,"Corpo-A-Corpo"),
             new ("Espada Longa", 10,1, tipoArma.EspadaLonga, "Corpo-A-Corpo"),
             new ("Arco Longo", 8,1,tipoArma.ArcoLongo, "À Distância")
            
        };
        foreach (var temp in NovaArma)
        {
            _arma[temp.ID] = temp;
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
        var valorTotal = _atributo.LerModificador(TipoAtributo.Forca) + Proficiencia;
        return valorTotal; 
    }
    public int BonusADistancia ()
    {
        var valorTotal = _atributo.LerModificador(TipoAtributo.Destreza) + Proficiencia;

        return valorTotal;
    }


public Personagem(string nome, Profissao profissao, IConsole console, Ancestral raca)
    {  
        _console = console ?? new Texto(); // Mensagem de texto no console.
          Nome = nome;
          _profissao = profissao;
          Vida = vidaMaxima;
          _ancestral = raca;
          _armaEquipada = ArmaPadrão._punho; // Arma Default
  
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

    
    public void AdicionarBonus (TipoAtributo tipo)
    {
        foreach(var bonus in _ancestral.bonusAtributos)
        {

            _atributo.AplicarBonus(tipo,bonus.Value);
        }
    }
    public void verAtributos ()
    {
        _atributo.VertodosValores();
        
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