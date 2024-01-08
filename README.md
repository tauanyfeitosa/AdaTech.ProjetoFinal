[![author](https://img.shields.io/badge/author-lauradefaria-blue.svg)](https://github.com/lauradefaria)
[![author](https://img.shields.io/badge/author-murilojcavalcanti-black.svg)](https://github.com/murilojcavalcanti)
[![author](https://img.shields.io/badge/author-tauanyfeitosa-purple.svg)](https://github.com/tauanyfeitosa)
[![author](https://img.shields.io/badge/author-isabelamendesx-pink.svg)](https://github.com/isabelamendesx)
[![author](https://img.shields.io/badge/author-EdOliveiraJr-green.svg)](https://github.com/EdOliveiraJr)
[![author](https://img.shields.io/badge/author-AmandaaBastos-red.svg)](https://github.com/AmandaaBastos)

# Biblioteca Eureka! - Sistema de Biblioteca da Universidade
O projeto tem como objetivo elaborar um sistema de biblioteca para uma universidade, no qual os usuários entram diariamente. Nele, será possível realizar empréstimos e reservas de livros no acervo, 
podendo ser feita por professores e alunos. O projeto tem como intuito aplicar os conceitos de POO e Lógica de Programação em C#, 
no qual foram adquiridos durante os módulos 1 e 2 do curso DiverseDEV organizado pelas instituições: ADA Tech e Mercado Eletrônico. <br/>

---

## Tabela de conteúdos
- [Diagrama de Classes](#diagrama-de-classes)
- [Organização do Sistema](#organizacao-do-sistema)
- [Interface dos Usuários](#interface-dos-usuarios)
- [Dados](#dados)
- [Clonar Respositório](#clonar-repositorio)
- [Autores](#autores)

---

## Diagrama de Classes

Um diagrama de classes é uma ferramenta visual utilizada na modelagem de sistemas orientados a objetos para representar a estrutura estática de um sistema. Ele faz parte da Linguagem de Modelagem Unificada (UML), que é um conjunto de notações gráficas padronizadas para representar modelos de sistemas.
<br/>
A principal finalidade de um diagrama de classes é mostrar as classes que compõem um sistema, juntamente com seus atributos, métodos, relacionamentos e as associações entre as classes.

---

## Organização do Sistema

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
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaLogin.png" width="400"> <br/>
  Figura 1: Tela de Login     <br/>
</p>
Para testes, utilize os seguintes dados de Usuário e Senha: <br/>


 ### Atendente
 
 Na tela principal de atendente há nove botões: Quatro relacionados a visualização de conteúdo (Reservas, Alunos, Professores e Empréstimos), três relacionados ao carregamento de CSV para atualizar no sistema (Comunidade acadêmica, Empréstimos e Reservas), um botão para iniciar um empréstimo e outro para devolução de empréstimos. <br/>

 <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaAtendente.png" width="400"> <br/>
  Figura 2: Tela Principal de Atendente <br/><br/><br/>
  </p>
     
**VISUALIZAR RESERVAS**: Abre uma nova janela para a visualização das reservas de livros existentes no sistema. <br/>
      <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaVisualizarReservas.png" width="400"> <br/>
  Figura 3: Tela Visualização de Reservas em Atendente<br/><br/>
  </p>
  
**VISUALIZAR ALUNOS**: Abre uma nova janela para a visualização dos alunos existentes na comunidade acadêmica. <br/>
 <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaVisualizarAlunos.png" width="400"> <br/>
  Figura 4: Tela Visualização de Alunos em Atendente<br/><br/>
  </p>
     
**VISUALIZAR PROFESSORES**: Abre uma nova janela para a visualização dos professores existentes na comunidade acadêmica. <br/>
 <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaVisualizarProfessores.png" width="400"> <br/>
  Figura 5: Tela Visualização de Professores em Atendente<br/><br/>
  </p>
     
**VISUALIZAR EMPRESTIMOS**: Abre uma nova janela para a visualização dos emprestimos existentes no sistema. <br/>
  <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaVisualizarEmprestimos.png" width="400"> <br/>
  Figura 6: Tela Visualização de Empréstimos em Atendente<br/><br/>
  </p>

  **CARREGAR CSV - COMUNIDADE ACADÊMICA**: Escolhe um arquivo (presente na máquina) relacionado aos usuários da comunidade acadêmica para adicionar no sistema<br/>
  **CARREGAR CSV - EMPRÉSTIMOS**: Escolhe um arquivo (presente na máquina) relacionado aos empréstimos realizadas para adicionar no sistema<br/>
  **CARREGAR CSV - RESERVAS**: Escolhe um arquivo (presente na máquina) relacionado as reservas realizadas para adicionar no sistema<br/><br/>

  **INICIAR EMPRÉSTIMO**: Abre uma janela que mostra todos os empréstimos com aprovações pendentes, contendo um botão para a criação de uma novo empréstimo.<br/>
  <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/AprovarReservaEmprestimo.png" width="400"> <br/>
  Figura 7: Tela Aprovação de Emprestimos em Atendente<br/>
     </p>
     
  Caso o atendete deseje criar um novo empréstimo, ele clica no botão e é direcionado para outra janela. Após isso, ele deve selecionar o usuário, seu tipo (Aluno/Professor) e o livro escolhido. Caso o usuário esteja com um empréstimo ativo de um exemplar daquele livro ou tenha atingido o limite máximo de empréstimos (cinco), o empréstimo não será permitido. <br/>
  <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/CriarEmprestimoAtendente.png" width="400"> <br/>
  Figura 8: Tela Criação de Empréstimo em Atendente <br/><br/>

  **DEVOLUÇÃO**: O atendente digita a matrícula do usuário que está devolvendo o livro e pressiona o botão "Pesquisar". <br/>
<p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/DevolucaoUsuario.png" width="400"> <br/>
  Figura 9: Tela Devolução do Livro em Atendente <br/>
  </p>
    Após isso, seleciona o livro que deseja devolver e marca a opção se o mesmo está em bom estado ou não, por fim pressiona o botão "Devolver". O atendente só pode realizar a devolução de 1 (um) livro por vez.<br/>
    <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/DevolucaoUsuarioEscolhido.png" width="400"> <br/>
  Figura 10: Tela Devolução do Livro Após Busca <br/><br/>
        
### Bibliotecário
 
 Na tela principal de Bibliotecário há 6 botões: Três relacionados a visualização de conteúdo (Livros, Solicitações de lote e Solicitações de Mudança de acervo), um relacionado ao carregamento de CSV para adicionar livro no sistema e dois botões para solicitações (Novos livros e Mudar de acervo). <br/>
 <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaPrincipalBibliotecario.png" width="400"> <br/>
  Figura 11: Tela Principal de Bibliotecário <br/><br/>
  </p>

**VISUALIZAR LIVROS**: Abre uma nova janela para a visualização dos livros existentes nos acervos. <br/><br/>
 <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaVisualizarLivros.png" width="400"> <br/>
  Figura 12: Tela Visualização de Livros por Bibliotecário <br/><br/>
  </p>
  
**CARREGAR CSV - LIVRO**: Escolhe um arquivo (presente na máquina) relacionado aos Livros para adicionar no sistema. <br/>

**SOLICITAR NOVOS LIVROS**: O bibliotecário pode solicitar novos livros, quando o livro não houver mais exemplares disponíveis para utilização. Para solicitar, escolha um livro, o tipo de acervo para qual ele será direcionado e uma descrição do pedido. <br/>
<p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaSolicitarLivros.png" width="400"> <br/>
  Figura 13: Tela de Solicitação de Livros <br/><br/>
  </p>
  
**VISUALIZAR SOLICITAÇÕES DE LOTES**: Abre uma nova janela para a visualização das solicitações de novos livros existentes no sistema. <br/>
<p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaVisualizarSolicitacoes.png" width="400"> <br/>
  Figura 14: Tela Visualização de Solicitações de Livros por Bibliotecário <br/><br/>
  </p>
  
**SOLICITAR MUDAR ACERVO**: O bibliotecário pode solicitar a mudança de acervo de um livro. Para realiza, coloca-se o livro escolhido, o acervo para qual será modificado e uma descrição do motivo dessa mudança. <br/>
<p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaSolicitarMudarAcervo.png" width="400"> <br/>
  Figura 15: Tela de Solicitação para Mudar Acervo de Livro <br/><br/>
  </p>
  
**VISUALIZAR SOLICITAÇÕES DE MUDANÇA DE ACERVO**: Abre uma nova janela para a visualização das solicitações de mudança de acervo existentes no sistema. <br/>
<p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaVisualizarSolicitacoesAcervo.png" width="400"> <br/>
  Figura 16: Tela Visualização de Solicitações de Mudança de acervo por Bibliotecário <br/><br/>
  </p>

### Diretor
 
 Na tela principal de Diretor há 4 botões: Três relacionados a visualização de conteúdo (Reservas, Funcionários e Solicitações) e um relacionado ao cadastramento de funcionários. <br/>
 <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaDiretor.png" width="400"> <br/>
  Figura 17: Tela Principal de Diretor <br/><br/>
  </p>

  **VISUALIZAR RESERVAS**: Abre uma nova janela para a visualização das reservas existentes no sistema. <br/>
  <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaVisualizarReservas.png" width="400"> <br/>
  Figura 18: Tela Visualização de Reservas por Diretor <br/><br/>
  </p>

  **ADICIONAR FUNCIONÁRIOS**: Adiciona um arquivo CSV contendo os novos funcionários. <br/><br/>

  **VISUALIZAR FUNCIONÁRIOS**: Abre uma nova janela para a visualização dos funcionários cadastrados no sistema. <br/>
  <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaVisualizarFuncionarios.png" width="400"> <br/>
  Figura 20: Tela Visualização de Funcionários <br/><br/>
  </p>

  **VISUALIZAR SOLICITAÇÕES**: Abre uma nova janela para a visualização de todas as solicitações existentes no sistema. <br/>
  <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaVisualizarSolicitacoesGerais.png" width="400"> <br/>
  Figura 21: Tela Visualização de Solicitações do Bibliotecário <br/><br/>
  </p>
 
 ### Comunidade Acadêmica
 
 Na tela principal dos membros da comudade acadêmica (Alunos e Professores) há 4 botões: Visualização do acervo de livros, Pagamento de multas, Reserva e Renovação de livros. <br/>
 <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaDiretor.png" width="400"> <br/>
  Figura 22: Tela Principal de Comunidade Acadêmica <br/>
  </p>
 Com relação aos usuários professores, deve-se ressaltar que todo o dia 25 a senha dele é modificada, fornecendo a nova senha para o usuário 10 dias antes, assim que ele entrar no sistema.<br/><br/>

 **VISUALIZAR ACERVO**: Abre uma nova janela para a visualização dos livros existentes no sistema. <br/>
  <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaVisualizarFuncionarios.png" width="400"> <br/>
  Figura 23: Tela Visualização do Acervo por Comunidade Acadêmica <br/><br/>
  </p>

  **RENOVAR**: O usuário pode escolhar qual empréstimo deseja renovar clicando no botão ao lado da descrição do livro, então a data de devolução aumenta em 7 dias. <br/>
  <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaRenovacao.png" width="400"> <br/>
  Figura 24: Tela de Renovação do empréstimo por Comunidade Acadêmica <br/><br/>
  </p>

  **MULTAS**: O usuário pode escolhar qual empréstimo deseja pagar a multa clicando no botão ao lado do empréstimo, a partir disso o sistema irá reconhecer como pago. <br/>
  <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaPagamento.png" width="400"> <br/>
  Figura 25: Tela de Pagamento de Multa por Comunidade Acadêmica <br/><br/>
  </p>

 **RESERVAR**: O usuário escolhe o livro que deseja reservar, recebendo como retorno a data do dia que poderá retirar o livro. <br/><br/>
 **CANCELAR RESERVA**: O usuário escolhe o livro que deseja cancelar a reserva e o exemplar retorna para disponibilidade. <br/>

---

## Dados

Os dados iniciais referentes aos Usuários (Atendentes, Diretores, Bibliotecários e Comunidade Acadêmica), Empréstimos, Livros e Reservas estão presentes em arquivos TXT localizados na pasta "Data", eles podem ser alterados no decorrer do programa, sendo sempre atualizados.<br/>

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
- [X] Estudantes: os estudantes só tem acesso ao acervo aberto e podem entrar na fila de espera (ou lista de reserva de livros) quando quiserem. <br/>
- [X] Funcionários: todos os funcionários tem acesso ao sistema, mas com permissões diferentes.
- [X] Só os atendentes podem atualizar registros de usuários e permitir o empréstimo do livro. <br/>
- [ ] Todo funcionário pode verificar se o livro está no sistema e se está disponível, todo funcionário também pode cadastrar um novo livro ou atualizar o número de exemplares.

---

## Clonar Repositório

- Clone esse repositório na sua máquila local utilizando
    > https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal.git

---
## Autores
|<a href="https://www.linkedin.com/in/lauradefaria/" target="_blank">**Laura de Faria**</a> | <a href="https://www.linkedin.com/in/murilojcavalcanti/" target="_blank">**Murilo Cavalcanti**</a>      |<a href="https://www.linkedin.com/in/isabela-mendes-776858244/" target="_blank">**Isabela Mendes**</a> | <a href="https://www.linkedin.com/in/tauany-feitosa/" target="_blank">**Tauany Feitosa**</a> | <a href="https://www.linkedin.com/in/amanda-bastos-/" target="_blank">**Amanda Bastos**</a> | <a href="https://www.linkedin.com/in/edvaldo-oliveira-14687b101/" target="_blank">**Edvaldo Oliveira**</a> |
|:-----------------------------------------------------------------------------------------:|:---------------------------------------------------------------------------------------:|:-----------------------------------------------------------------------------------------:|:---------------------------------------------------------------------------------------:|:---------------------------------------------------------------------------------------:|:---------------------------------------------------------------------------------------:|
|                   <img src="imgs/laura.png" width="200px"> </img>                            |               <img src="imgs/murilo.png" width="200px"> </img>                          |                   <img src="imgs/isabela.png" width="200px"> </img>                            |               <img src="imgs/tauany.png" width="200px"> </img>                          |               <img src="imgs/amanda.png" width="200px"> </img>                          |               <img src="imgs/edvaldo.png" width="200px"> </img>                          |
|               <a href="http://github.com/lauradefaria" target="_blank">`github.com/lauradefaria`</a>      |  <a href="https://github.com/murilojcavalcanti" target="_blank">`github.com/murilojcavalcanti`</a>  |               <a href="https://github.com/isabelamendesx" target="_blank">`github.com/isabelamendesx`</a>      |  <a href="https://github.com/tauanyfeitosa" target="_blank">`github.com/tauanyfeitosa`</a>  |  <a href="https://github.com/AmandaaBastos" target="_blank">`github.com/AmandaaBastos`</a>  |  <a href="https://github.com/EdOliveiraJr" target="_blank">`github.com/EdOliveiraJr`</a>  |
