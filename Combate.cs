public enum TipoAcerto
{
    acertoCritico,
    ErroCritico,
    Acerto,
    Errou
}
public class AcoesDeCombate
{
 


    public IConsole _console;

    public AcoesDeCombate (IConsole console)
    {
        _console = console;
    }
    public TipoAcerto Golpear (Personagem Atacante, Personagem alvo)
    {
       
        int d20 = Dado.RolarDado(1,20);
        int bonus = Atacante._armaEquipada.Atributo == "Corpo-A-Corpo"?
        Atacante.BonusCorpoACorpo() : Atacante.BonusADistancia();
        int rolagem = d20 + bonus;
        
        int CA = alvo.ClasseArmadura;

        if(d20 == 1)
        {
            return TipoAcerto.ErroCritico;
            
        }

        if( d20 == 20)
        {
            return TipoAcerto.acertoCritico;
        }
        
       if(rolagem >= CA)
        {
        return TipoAcerto.Acerto;
        }
        else
        {
        return TipoAcerto.Errou;
        }     
  

      
    }
    public int CausarDano (Personagem Atacante, Personagem alvo)
    {
        int DadoArma = Dado.RolarDado(Atacante._armaEquipada.qntDado, Atacante._armaEquipada.DadoDano);
        int BonusDano = Atacante._armaEquipada.Atributo == "Corpo-A-Corpo" ? Atacante._atributo.LerAtributo(TipoAtributo.Forca) 
        : Atacante._atributo.LerAtributo(TipoAtributo.Destreza);
        int danoTotal = DadoArma + BonusDano;
       return  danoTotal;
   
    }
    public void ControlarCombate (Personagem atacante, Personagem alvo)
    {
        var resultado = Golpear(atacante,alvo);
        var dano = CausarDano (atacante,alvo);
        var danoCritico = CausarDano (atacante,alvo) *2;

        switch (resultado)
        {
            case TipoAcerto.acertoCritico:
            alvo.SofrerDano(danoCritico);
            _console.Log($"{alvo.Nome} sofreu {danoCritico} dano critico");
            break;
            
             case TipoAcerto.ErroCritico:
             _console.Log($"{atacante.Nome} Teve uma falha critica");
             break;
             case TipoAcerto.Acerto:
             _console.Log($"{alvo.Nome} Sofreu {dano} de dano");
            break;
             case TipoAcerto.Errou:
             _console.Log("O ataque falhou");

            break;
        }
      
    }


}