# 🕹️ Blade of Valor – Prova de Conceito

---

## 📘 Descrição

Este projeto é a **Prova de Conceito** para o jogo **Blade of Valor**, desenvolvida para demonstrar a base funcional do gameplay principal.  
O objetivo é validar os elementos essenciais do jogo antes da expansão para fases completas.

---

## 🎯 Objetivos da Prova de Conceito

A prova de conceito proposta inclui:

- Uma fase curta (primeira fase);
- Movimentação básica (andar, pular, bloqueio);
- Combate funcional com espada;
- Um tipo de inimigo simples;
- HUD com vida e moedas;
- Mecânica roguelite: ao morrer, retornar ao início mantendo moedas para comprar melhorias simples.

---

## 🛠️ Progresso das Funcionalidades

| Funcionalidade                         | Status | Descrição                                                 |
| -------------------------------------- | ------ | --------------------------------------------------------- |
| Movimentação básica (andar/pular)      | ✅     | Implementada com animações e física ajustada.             |
| Combate com espada                     | ⚙️     | Ataques com animação, colisão e dano funcional.           |
| Primeira fase curta                    | ⚙️     | Fase inicial jogável com obstáculos, inimigos e cenário.  |
| Inimigo simples                        | ⚙️     | Inimigo com patrulha e comportamento básico de ataque.    |
| HUD de vida e moedas                   | ✅     | Exibe informações em tempo real do jogador.               |
| Sistema de morte e reinício            | ❌     | Jogador retorna ao início mantendo as moedas acumuladas.  |
| Loja / Melhoria simples                | ❌     | Permite gastar moedas adquiridas para melhorar atributos. |


❌ - Indica que ainda não foi desenvolvido;

⚙️ - Indica que está em desenvolvimento;

⚠️ - Indica que está sendo atualizado ou corrigido;

✅ - Indica que a funcionalidade já foi desenvolvida;

---

## 🧩 Tecnologias Utilizadas

- **Unity Engine**
- **C#**
- **Visual Studio Code**
- **Animator / Mecanim**
- **Tilemap** (para a construção da fase)
- **Cinemachine** (para o controle da câmera)

---

## 💾 Como Rodar o Projeto

1. Clone este repositório:

   ```bash
   git clone https://github.com/SeuUsuario/BladeOfValor.git

   ```

2. Abra o projeto no Unity 2022.3 LTS (2022.3.62f2)

3. Execute a cena principal

4. Teste os controles:

- [A / D] → Andar

- [ Espaço ] → Pular

- [ Botão esquerdo do mouse ] → Ataque

- [ Botão direito do mouse ] → Bloqueio

- [ Q ] → Corte Aéreo
