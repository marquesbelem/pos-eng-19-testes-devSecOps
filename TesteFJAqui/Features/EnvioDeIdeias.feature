#language: pt-br

Funcionalidade: EnvioDeIdeias
	Como um usario desejo escrever minhas ideias na plataforma

Cenário: Quando o usuario auntenticado enviar uma ideia, a ideia deverá ser adicionada na lista
	Dado que o usuário acessou a paginal inicial
	E deseja compartilhar uma ideia na plataforma
	E o usuário está na página de login
	E o usuário informar "email" com o valor igual a "camila@teste.com"
	E o usuário informar "pass" com o valor igual a "camila123"
	Quando o usuário clicar no botão de entrar
	Então o usuário deverá vê uma mensagem de sucesso
	E o usuário acessar a página de ideias  
	E clicar no botão de escrever ideia
	E o usuário informar "title" com o valor igual a "Quebra cabeça espacial"
	E o usuário informar "content" com o valor igual a "Esse jogo você deve procurar as peças no Espaço sideral"
	E o usuário selecionar "category" com o valor igual a "2"
	Quando o usuário clicar no botão de enviar
	Então o usuário deverá vê uma mensagem de sucesso

Cenário: Quando o usuario não auntenticado enviar uma ideia, a ideia não pode ser adicionada na lista
	Dado que o usuário acessou a paginal inicial
	E deseja compartilhar uma ideia na plataforma
	E o usuário acessar a página de ideias  
	E clicar no botão de escrever ideias
	E o usuário informar "title" com o valor "Quebra cabeça espacial usuario não autentificado"
	E o usuário informar "content" com o valor "Esse jogo você deve procurar as peças no Espaço sideral"
	E o usuário selecionar "category" com o valor igual a "2"
	Quando o usuário clicar no botão de enviar
	Então o usuário deverá vê uma mensagem de erro
