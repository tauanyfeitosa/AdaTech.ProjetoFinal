[![author](https://img.shields.io/badge/author-lauradefaria-blue.svg)](https://github.com/lauradefaria)
[![author](https://img.shields.io/badge/author-murilojcavalcanti-black.svg)](https://github.com/murilojcavalcanti)
[![author](https://img.shields.io/badge/author-tauanyfeitosa-purple.svg)](https://github.com/tauanyfeitosa)
[![author](https://img.shields.io/badge/author-isabelamendesx-pink.svg)](https://github.com/isabelamendesx)
[![author](https://img.shields.io/badge/author-EdOliveiraJr-green.svg)](https://github.com/EdOliveiraJr)
[![author](https://img.shields.io/badge/author-AmandaaBastos-red.svg)](https://github.com/AmandaaBastos)

# Biblioteca Eureka! - Sistema de Biblioteca da Universidade
O projeto tem como objetivo elaborar um sistema de biblioteca para uma universidade. Nela, será possível realizar empréstimos de livros no acervo, 
podendo ser feita por professores e alunos. O projeto tem como intuito aplicar os conceitos de POO e Lógica de Programação em C#, 
no qual foram adquiridos durante os módulos 1 e 2 do curso DiverseDEV organizado pelas instituições: ADA Tech e Mercado Eletrônico. <br/>

---

## Tabela de conteúdos
- [Diagrama de Classes](#diagrama-de-classes)
- [Organização do Sistema](#organização-do-sistema)
- [Interface dos Usuários](#interfaces-do-usuarios)
- [Dados](#dados)
- [Clonar Respositório](#clonar-repositorio)
- [Autores](#autores)

---

## Diagrama de Classes

Um diagrama de classes é uma ferramenta visual utilizada na modelagem de sistemas orientados a objetos para representar a estrutura estática de um sistema. Ele faz parte da Linguagem de Modelagem Unificada (UML), que é um conjunto de notações gráficas padronizadas para representar modelos de sistemas.
<br/>
A principal finalidade de um diagrama de classes é mostrar as classes que compõem um sistema, juntamente com seus atributos, métodos, relacionamentos e as associações entre as classes.

---

## Organização do sistema do Sistema

### Usuários

Como usuários do sistemas temos a Comunidade Acadêmica (composta por estudantes e professores) e os funcionários (divididos em atendente, bibliotecário e Diretor).<br/>
<pre>
  Descrição:<br/>
  - Estudante: Discente da universidade, ele pode reservar e realizar 5 empréstimos simultâneos, sendo eles exemplares de livros diferentes (apenas pode pegar emprestado um exemplar do livro), além de permitir 1 renovação para cada livro.<br/>
  - Professor: Docente da universidade, pode realizar a mesma quantidade de empréstimos e renovações do estudante, tendo prioridade na fila de empréstimos e acesso a qualquer livro da biblioteca, mesmo de acervos restritos .<br/>
  - Atendente: Responsável pelo atendimento e empréstimos direcionados a comunidade acadêmica.<br/>
  - Bibliotecário: Responsável pela organização do acervo da biblioteca.<br/>
  - Diretor: Responsável pela gestão de funcionários e autorização de solicitações relacionadas a mudanças no acerto ou livros novos.<br/>
</pre>

### Acervos

Os livros estão classificados em: Acervo Público, Acervo Restrito ou Fora de estoque.<br/>
<pre>
  Descrição:<br/>
  - Acervo públicos: são aqueles com pelo menos 2 exemplares na biblioteca em bom estado.<br/>
  - Acervo restrito: livros com apenas um exemplar ou que todos os exemplares estão em mau estado.<br/>
  - Fora de estoque: livros que foram perdidos, totalmente danificados ou que estão todos emprestados. <br/>
</pre>

---

## Interface dos Usuários

### Geral

O sistema inicia com a tela de login, na qual sera digitado o usuário (Funcionários: login - Comunidade acadêmica: Matrícula) e a senha, além de escolher entre o tipo de usuário, podendo ser: Funcionário (Atendente, Bibliotecário e Diretor), Aluno ou Professor. <br/>

<p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/main/imgs/TelaLogin.png" width="400"> <br/>
  Figura 1: Tela de Login     
</p>

 ### Atendente
 
 Na tela principal de atendente há nove botões: Quatro relacionados a visualização de conteúdo (Reservas, Alunos, Professores e Empréstimos), três relacionado ao carregamento de CSV para atualizar no sistema (Comunidade acadêmica, Empréstimos e Reservas), um botão para iniciar um empréstimo e outro para devolução de empréstimos. <br/>

 <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/main/imgs/TelaPrincipalAtendente.png" width="400"> <br/>
  Figura 2: Tela Principal de Atendente <br/><br/><br/>
  </p>
     
**VISUALIZAR RESERVAS**: Abre uma nova janela para a visualização das reservas de livros existentes no sistema. <br/>
      <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/main/imgs/TelaVisualizarReservas.png" width="400"> <br/>
  Figura 3: Tela Visualização de Reservas em Atendente<br/><br/>
  </p>
  
**VISUALIZAR ALUNOS**: Abre uma nova janela para a visualização das dos alunos existentes na comunidade acadêmica. <br/>
 <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/main/imgs/TelaTelaVisualizarAlunos.png" width="400"> <br/>
  Figura 4: Tela Visualização de Alunos em Atendente<br/><br/>
  </p>
     
**VISUALIZAR PROFESSORES**: Abre uma nova janela para a visualização das dos professores existentes na comunidade acadêmica. <br/>
 <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/main/imgs/TelaVisualizarProfessores.png" width="400"> <br/>
  Figura 5: Tela Visualização de Professores em Atendente<br/><br/>
  </p>
     
**VISUALIZAR EMPRESTIMOS**: Abre uma nova janela para a visualização das dos emprestimos existentes no sistema. <br/>
 Escolhe um arquivo (presente na máquina) relacionado as reservas realizadas para adicionar no sistema
  <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/main/imgs/TelaVisualizarEmprestimos.png" width="400"> <br/>
  Figura 6: Tela Visualização de Empréstimos em Atendente<br/><br/>
  </p>

  **CARREGAR CSV - COMUNIDADE ACADÊMICA**: Escolhe um arquivo (presente na máquina) relacionado aos usuários da comunidade acadêmica para adicionar no sistema<br/>
  **CARREGAR CSV - EMPRÉSTIMOS**: Escolhe um arquivo (presente na máquina) relacionado aos empréstimos realizadas para adicionar no sistema<br/>
  **CARREGAR CSV - RESERVAS**: Escolhe um arquivo (presente na máquina) relacionado as reservas realizadas para adicionar no sistema<br/><br/>

  **INICIAR EMPRÉSTIMO**: Abre uma janela que mostra todos os empréstimos com aprovações pendentes, contendo um botão para a criação de uma novo empréstimo.<br/>
  Escolhe um arquivo (presente na máquina) relacionado as reservas realizadas para adicionar no sistema
  <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/main/imgs/AprovarReservaEmprestimo.png" width="400"> <br/>
  Figura 7: Tela Aprovação de Emprestimos em Atendente<br/>
     </p>
     
  Caso o atendete deseje criar um novo empréstimo, ele clica no botão e é direcionado para outra janela. Após isso, ele deve selecionar o usuário, seu tipo (Aluno/Professor) e o livro escolhido. Caso o usuário esteja com um empréstimo ativo de um exemplar daquele livro ou tenha atingido o limite máximo de empréstimos (cinco), o empréstimo não será permitido. <br/>
  <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/main/imgs/CriarEmprestimoAtendente.png" width="400"> <br/>
  Figura 8: Tela Criação de Empréstimo em Atendente <br/><br/>

  **DEVOLUÇÃO**: O atendente digita a matrícula do usuário que está devolvendo o livro e pressiona o botão "Pesquisar". <br/>
<p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/main/imgs/DevolucaoUsuario.png" width="400"> <br/>
  Figura 9: Tela Devolução do Livro em Atendente <br/>
  </p>
    Após isso, seleciona o livro que deseja devolver e pressiona o botão "Devolver". O atendente só pode realizar a devolução de 1 (um) livro por vez.<br/>
    <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/main/imgs/DevolucaoUsuarioEscolhido.png" width="400"> <br/>
  Figura 10: Tela Devolução do Livro Após Busca <br/><br/>
        
### Bibliotecário
 
 Na tela principal de X há X botões: . <br/>

### Diretor
 
 Na tela principal de X há X botões: . <br/>
 
 ### Aluno
 
 Na tela principal de X há X botões: . <br/>
 
 ### Professor
 
 Na tela principal de X há X botões: . <br/>

---

## Dados

ELABORAR TEXTO EXPLICANDO CSV E TXT<br/>

---

## Itens Obrigatórios

- [X] Três indivíduos aptos a entrar no sistema. <br/>
- [X] Professores podem ter acesso a qualquer livro da biblioteca. <br/>
- [X] Para entrar no sistema da biblioteca, os funcionários precisam de login e senha, novos funcionários são cadastrados pelo diretor da biblioteca. <br/>
- [X] Para que os alunos solicitem os livros, devem informar um código de acesso (n° de matrícula). Todos os alunos já estão registrados no sistema através do número de matrícula, precisam apenas informar e aguardar a liberação pela biblioteca. <br/>
- [X] Os professores necessitam mostrar apenas o código de cadastro no sistema e uma senha padrão que é alterada a cada mês. <br/>
- [X] Os livros são divididos em 3 setores: fora de estoque, acervo restrito e acervo publico. <br/>
- [X] Acervo públicos: são aqueles com pelo menos 2 exemplares na biblioteca em bom estado. <br/>
- [X] Acervo restrito: livros com apenas um exemplar ou que todos os exemplares estão em mau estado. <br/>
- [X] Fora de estoque: livros que foram perdidos, totalmente danificados ou que estão todos emprestados. <br/>
- [X] Os números de matricula são lidos através de um csv e os livros são cadastrados na classe Livros através de um Json com todas as informações. <br/>
- [X] O arquivo csv ou json pode ser atualizado a qualquer momento pelos atendentes ou diretor. <br/>
- [ ] Estudantes: os estudantes só tem acesso ao acervo aberto e podem entrar na fila de espera (ou lista de reserva de livros) quando quiserem. <br/>
- [ ] Funcionários: todos os funcionários tem acesso ao sistema, mas com permissões diferentes. Todo funcionário pode verificar se o livro está no sistema e se está disponível, todo funcionário também pode cadastrar um novo livro ou atualizar o número de exemplares. Mas, só os atendentes podem atualizar registros de usuários e permitir o empréstimo do livro. <br/>


---

## Clonar Repositório

- Clone esse repositório na sua máquila local utilizando
    > https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal.git

---
## Autores
|<a href="https://www.linkedin.com/in/lauradefaria/" target="_blank">**Laura de Faria**</a> | <a href="https://www.linkedin.com/in/murilojcavalcanti/" target="_blank">**Murilo Cavalcanti**</a>      |<a href="https://www.linkedin.com/in/isabela-mendes-776858244/" target="_blank">**Isabela Mendes**</a> | <a href="https://www.linkedin.com/in/tauany-feitosa/" target="_blank">**Tauany Feitosa**</a> | <a href="https://www.linkedin.com/in/amanda-bastos-/" target="_blank">**Amanda Bastos**</a> | <a href="https://www.linkedin.com/in/edvaldo-oliveira-14687b101/" target="_blank">**Edvaldo Oliveira**</a> |
|:-----------------------------------------------------------------------------------------:|:---------------------------------------------------------------------------------------:|:-----------------------------------------------------------------------------------------:|:---------------------------------------------------------------------------------------:|:---------------------------------------------------------------------------------------:|:---------------------------------------------------------------------------------------:|
|                   <img src="imgs/laura.jpeg" width="200px"> </img>                            |               <img src="imgs/murilo.png" width="200px"> </img>                          |                   <img src="imgs/isabela.png" width="200px"> </img>                            |               <img src="imgs/tauany.png" width="200px"> </img>                          |               <img src="imgs/amanda.png" width="200px"> </img>                          |               <img src="imgs/edvaldo.png" width="200px"> </img>                          |
|               <a href="http://github.com/lauradefaria" target="_blank">`github.com/lauradefaria`</a>      |  <a href="https://github.com/murilojcavalcanti" target="_blank">`github.com/murilojcavalcanti`</a>  |               <a href="https://github.com/isabelamendesx" target="_blank">`github.com/isabelamendesx`</a>      |  <a href="https://github.com/tauanyfeitosa" target="_blank">`github.com/tauanyfeitosa`</a>  |  <a href="https://github.com/AmandaaBastos" target="_blank">`github.com/AmandaaBastos`</a>  |  <a href="https://github.com/EdOliveiraJr" target="_blank">`github.com/EdOliveiraJr`</a>  |
