# Rodando Aplicação
```shell
dotnet run
```

# Rodando para ambiente de produção
```shell
./run-prod.sh
```

# Link da API utilizada no front-end
# lembrando que fiz esta (api) como minimal se eu quise fazer com
# controladores poderia tambem eu "organizaria mais".
- https://github.com/wotoss/proj-minimal-api-dotnet7

# =====================[ Imformações IMPORTANTE sobre o blazor ]======================
# 
# IMPORTANTISSIMO !
#
#  Eu poderia fazer conexão com (entity-framework ou dapper, SQL-ADO-connection) aqui    no  blazor  ou seja me conectar a (base de dados) daqui mesmo através do blazor.
# Porque o (blazor) tem renderização via (server side e cliente side)
# Com o blazor nos conseguimos (com react não com vuejs não com angular não, com o next tambem não)
# Todos estes não tem integração com o C#
#
# Outros Detalhe não precisei => liberar cross domain
# porque a minha aplicação roda via (server side).
# normalmente quando uso (api) eu preciso (liberar o cross-domain).
# com (Razor) não preciso.
# ====================================================================================
     

