#language: pt-br

Funcionalidade: EnvioDeComentario
	Como um usario desejo escrever comentarios em ideias na plataforma


Cenário: Quando o usuario auntenticado enviar um comentario, deverá ser adicionado na lista
	Dado que o usuário acessou a paginal inicial 
	E deseja compartilhar um comentario na plataforma
	E o usuário está na página de login
	E o usuário informar "email" com o valor igual a "camila@teste.com"
	E o usuário informar "pass" com o valor igual a "camila123"
	Quando o usuário clicar no botão de entrar
	Então o usuário deverá vê uma mensagem de sucesso
	E o usuário acessar a página de ideias 
	E o usuário selecionar uma ideia clicando no botão de saber mais
	E o usuário informar "comentario" com o valor igual "essa ideia parece ficar legal em 3D" 
	E clicar no botão de comentar
	Então o usuário deverá vê uma mensagem de sucesso

	
Cenário: Quando o usuario não auntenticado enviar um comentario, deverá ser adicionado na lista
	Dado que o usuário acessou a paginal inicial 
	E deseja compartilhar um comentario na plataforma
	E o usuário acessar a página de ideias 
	E o usuário selecionar uma ideia clicando no botão de saber mais
	E o usuário informar "comentario" com o valor igual "sem autenticação: essa ideia parece ficar legal em 3D" 
	E clicar no botão de comentar
	Então o usuário deverá vê uma mensagem de erro