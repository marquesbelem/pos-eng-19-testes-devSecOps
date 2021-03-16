#language: pt-br

Funcionalidade: Informações restritas
	Como um usario desejo acessar minha pagina de perfil

Cenário: Quando o usuario auntenticado acessar a pagina de perfil, as informações sobre a conta deverá está disponivel 
	Dado que o usuário acessou a pagina inicial
	E deseja ver informações sobre o seu perfil
	E o usuário está na página de login
	E o usuário informar "email" com o valor igual a "camila@teste.com"
	E o usuário informar "pass" com o valor igual a "camila123"
	Quando o usuário clicar no botão de entrar
	Então o usuário deverá vê uma mensagem de sucesso
	E o usuário acessar a página do perfil  
	Então o usuário deverá ver os detalhes do perfil e opção de trocar de senha


Cenário: Quando o usuario não auntenticado acessar a pagina de perfil, as informações sobre a conta deverá está indisponivel 
	Dado que o usuário acessou a pagina inicial
	E deseja ver informações sobre o seu perfil
	E o usuário não está autenticado
	E o usuário acessar a página do perfil   
	Então o usuário deverá ver um aviso de página restrita
