#Rodando(subindo) para ambiente de aplicação
#1º eu faço um publish 
#2º dou um ./run-prod.sh - que seria este arquivo com o release
#3º desta forma vai criar o arquivo (release)
#4º ao compilar este arquivo (./run-prod.sh) e cria o meu (codigo buildado do blazor)
#5º este (código buildado do balzor) é o codigo que eu vou precisar rodar no servidor de produção
#6º vou precisar rodar o arquivo (dll) que vai levantar o servidor (vps - Servidor-Virtual-Privado) em modo de produção 
#7º esta pasta (Release) eu coloco no (.gitignore) eu não versiono no (github)
dotnet publish -o Release

# então quando eu for (rodar em produção)
# dou um (dotnet Release/blazor-view-dotnet7.dll) que esta dentro da pasta release
#dotnet Release/