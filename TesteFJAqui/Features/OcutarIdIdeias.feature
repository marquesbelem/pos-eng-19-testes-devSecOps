#language: pt-br

Funcionalidade: OcutarIdIdeias
	Como um usuario desejo vê as ideias sem saber qual é o ID 

Cenário: Quando um usuario acessar a plataforma e depurar, ele não pode ter acesso ao Id das ideias
	Dado que o usuário acessou a pagina inicial
	E o usuário deseja visualizar alguma ideia
	E o usuário conseguiu ativar o modo inspecto 
	Quando o usuário clicar em inspecionar 
	Então o usuário não deverá vê nenhum Id das ideias

Cenário: Quando um usuario acessar mais detalhes dessa ideia e clicar no botão de voltar, ele não pode ter acesso ao Id das ideias
	Dado que o usuário acessou a pagina inicial
	E o usuário deseja visualizar alguma ideia
	E o usuário selecionar uma ideia clicando no botão de saber mais
	Quando o usuário clicar no botão de voltar da página
	Então o usuário não deverá vê nenhum Id da ideia na url