public abstract class Ancestral
{

    public abstract Dictionary<TipoAtributo, int> bonusAtributos {get;}
}
public class Humano : Ancestral
{
    private Dictionary<TipoAtributo, int> _escolha = new ();

public Humano (TipoAtributo escolha1, TipoAtributo escolha2)

    {
        _escolha[escolha1] = 2;
        _escolha[escolha2] = 2;
        
    }
    public override Dictionary<TipoAtributo, int > bonusAtributos => _escolha;
    
}
public class Elfo : Ancestral
{
    private Dictionary<TipoAtributo, int> _escolha = new();

    public Elfo (TipoAtributo escolha)
    {
        _escolha[escolha] = 2;
        _escolha[TipoAtributo.Inteligencia] = 2;
        _escolha[TipoAtributo.Destreza] = 2;
        _escolha[TipoAtributo.Constituicao] = -2;
    }
    public override Dictionary<TipoAtributo, int> bonusAtributos => _escolha;
}