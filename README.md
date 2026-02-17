# Estrutura de RPG (C#)

Este projeto é um sistema de RPG baseado em turnos desenvolvido em **C#** e **.NET 9.0**, focado na aplicação de princípios de Orientação a Objetos (POO) e arquitetura de software.

O sistema simula mecânicas clássicas de RPG de mesa (como D&D), incluindo criação de personagens, cálculo de atributos e resolução de combate via rolagem de dados.

## 🚀 Funcionalidades Implementadas

### 1. Sistema de Personagens
* **Criação Dinâmica:** Definição de Nome, Raça e Classe.
* **Atributos Base:** Força, Destreza, Constituição, Inteligência, Sabedoria e Carisma.
* **Modificadores Automáticos:** O sistema calcula automaticamente os bônus (modificadores) baseados no valor do atributo (ex: valor 10 = modificador 0).
* **Herança de Raças (Ancestral):**
    * *Humano:* Bônus versátil em dois atributos à escolha.
    * *Elfo:* Bônus fixos em Destreza e Inteligência, com penalidade em Constituição.
* **Sistema de Classes (Profissão):**
    * Definição de dado de vida (Hit Die) e nível.

### 2. Mecânicas de Combate
* **Rolagem de Dados:** Utilitário para simular dados de qualquer face (d6, d8, d20, etc.).
* **Resolução de Ataque:**
    * Comparação de **Rolagem de Ataque + Bônus** vs **Classe de Armadura (CA)**.
    * Diferenciação entre ataque Corpo-a-Corpo (Força) e à Distância (Destreza).
* **Resultados Críticos:**
    * **Acerto Crítico (20 natural):** Dano dobrado.
    * **Falha Crítica (1 natural):** Erro automático.

### 3. Arquitetura e Design
* **Interfaces:** Uso de `IConsole` para abstração de saída de dados (facilitando testes unitários futuros).
* **Encapsulamento:** Proteção de propriedades vitais como Vida e Atributos.

## 🛠️ Tecnologias Utilizadas

* [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/)
* [.NET 9.0](https://dotnet.microsoft.com/download)

## 📦 Como Rodar o Projeto

Pré-requisitos: Ter o [SDK do .NET 9.0](https://dotnet.microsoft.com/download/dotnet/9.0) instalado.

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/Rahamadh/EstruturaDeRPG.git

   cd EstruturaDeRPG

   dotnet run



