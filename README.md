<h1 align="center">FoccoEmFrente.Kanban</h1>

<h2 align="center">  Plataforma Kanban desenvolvida em parceria com a empresa Focco - Soluções de Gestão afim de desenvolver habilidades em C# e React.</h2>
<h4 align="center"> 
	🚧  Primerira versão 🚀 Finalizada...  🚧
</h4>

### Features

- [ x ] Cadastro de usuário
- [ x ] Login
- [ x ] Cadastro de atividades
- [ x ] Exclusão de atividades
- [ x ] Atualização de atividades
- [ x ] Atualização de status

#### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
</br> [.NET Core SDK]( https://download.visualstudio.microsoft.com/download/pr/56131147-65ea-47d6-a945-b0296c86e510/44b43b7cb27d55081e650b9a4188a419/dotnet-sdk-3.1.201-win-x64.exe) & [ASP .NET Runtime]( https://cdn.discordapp.com/attachments/617117168424845356/866815026346459156/aspnetcore-runtime-3.1.16-win-x64.exe)
</br>[Node e Yarn](https://nodejs.org/download/release/v12.8.1/node-v12.8.1-x64.msi). 
</br>Além disto usaremos um editor para trabalhar com o código back-end: [Visual Studio Community 2019](https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&rel=16), e outro para o código front-end [Visual Studio Code](https://code.visualstudio.com/).
</br> O código front-end se encontra dentro de: -> <b>FoccoEmFrente.Kanban.Web</b> -> <b>ClientApp</b> -> <b>src</b>.
</br> Para testarmos nossas <b>API's</b> e rotas usaremos o [Postman] (https://dl.pstmn.io/download/latest/win64) <b>OBS</b>: Se você estiver testando em hambiente local, deverá desabilitar a comunicação SSL dentro do Postman.

### 🎲 Rodando o Back End e o Front End

```bash
# Clone este repositório
$ git clone <https://github.com/boottD/FoccoEmFrente.Kanban.git>

#instale o visual studio community
	1. A instalação deve ser realizada com no mínimo as seguintes opções:
		1. ASP.NET e desenvolvimento Web
		2. Desenvolvimento entre plataformas .NET
		3. Idioma padrão inglês
		
#Instale a última versão do SDK do .NET Core 3.1.2
	1. .NET Core SDk 
	2 ASP .NET Runtime
	
#Instale Node e Yarn
	1. Instalar a instalação do Node.JS
	1. Instalar com as configurações padrão
	2. No final do processo, executar o comando "node -v" no terminal
	3. Deve ser exibido a versão do node, caso não funcione, tente realizar a instalação novamente e verifique se o path do node está nas variáveis de ambiente
	2. Com o node instalado, instalar o yarn com o comando abaixo:
	1. npm install -g yarn
	2. executar o comando `yarn -v` para verificar a versão e se está instalado corretamente

#Instale o Visual Studio Code
	1. Realize a instalação do visual studio code.
	2. No final da instalação, recomendamos que os checks para ação de "Abrir o Code" pelo Windows Explorer sejam selecionados.
	3. Instale as extensões recomendadas: 
	1. Abra o Visual Studio Code
	2. Abra as Extensões (Ctrl + Shift + X)
	3. Instale as extensões abaixo:
	1. Prettier - Code formatter
	2. vscode-icons

#Instale o Postman
	1. Realizar a instalação padrão do postman

# Acesse a pasta do Projeto Base e acesse o arquivo FoccoEmFrente.Kanban.sln

# Ou abra este projeto/solução de dentro do Visual Studio Community 2019

# O servidor inciará na porta:5000 (HTTP) ou na porta:5001 (HTTPS) - acesse <http://localhost:porta>

```
