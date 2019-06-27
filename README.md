# aws_ex6
Exercício 6 - Parte 1; Disciplina: API e Web Services (AWS), Prof: Marco Mendes; Curso: Desenvolvimento Web Full Stack

* Autores: 
    * André Santos  
    * Emerson Duarte
    * Hugo Vinicius
    
#### Implementação de 2 microsserviços:  
1. Microsserviço para gestão de produtos (CRUD) - .NET Core - rodando na porta 6000  
To run the server, run:
    ```
    dotnet run
    ```
2. Microsserviço para gestão de vendas - NODE.JS - rodando na porta 3000  
To run the server, run:
    ```
    npm start
    ```
    
#### Implementação de 1 Gateway:
1. Gateway - .NET Core com Ocelot - rodando na porta 5000  
    To run the server, run:
    ```
    dotnet run
    ```
    
### To access web services in Gateway:      
---- PRODUTOS------------------------------------------------------- 
  * Recupera todos os produtos:  
    ```
    GET http://localhost:5000/produtos
    ```  
  * Recupera um produto específico:  
    ```
    GET http://localhost:5000/produtos/{idProduto}
    ```
  * Operação para adicionar um produto; Deve existir um JSON no body da chamada ex: 
    {
        "id": 77,
        "nome": "Produto77",
        "descricao": "Descrição Produto77",
        "categoria": "N/A",
        "preco": 9.99
    }
    :  
    ```
    POST http://localhost:5000/produtos
    ```
  * Operação para alterar um produto (Deve existir um JSON no body da chamada, como o do exemplo do item anterior):  
    ```
    PUT http://localhost:5000/produtos/{idProduto}
    ```
  * Operação para deletar um produto:  
    ```
    DELETE http://localhost:5000/produtos/{idProduto}
    ```  
---- VENDAS------------------------------------------------------- 
  * Recupera todas as vendas:  
    ```
    GET http://localhost:5000/vendas
    ```  
  * Cancela uma venda:
    ```
    PUT http://localhost:5000/vendas/{idVenda}
    ```    
  * Cria uma nova venda; Deve existir um JSON no body da chamada ex: 
    {
    "id": 88,
    "valor": 9.99,
    "quantidade": 1,
    "data": "27/06/2019",
    "produtos" : 
    	{
    		"id":1, "descricao": "produto 1", "valor": 11
    	}
}
    :  
    ```
    POST http://localhost:5000/vendas
    ```     
