using System;
using System.Collections.Generic;

namespace RPG
{
    public class Program
    {
        public static void Main (string []args)
        {
            IConsole console = new Texto();
            Profissao guerreiro = new Guerreiro();
            Ancestral humano = new Humano(TipoAtributo.Forca, TipoAtributo.Constituicao);
            Console.WriteLine("Digite o nome do seu heroi");
            string? entrada = Console.ReadLine()?? "heroi";
            Personagem heroi = new Personagem(entrada,guerreiro,console,humano);

            heroi.verAtributos();
           
        

            
            
            
        }
    }
}
