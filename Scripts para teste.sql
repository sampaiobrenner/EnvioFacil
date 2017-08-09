Insert Into produto (nome, estoque, vlCustoUnitario, vlVendaUnitario, codigovendavel) Values ('Crédito', 0, 0.02, 0.00, 1);

/* Ao executar o script abaixo, trocar o código do produto */
Insert Into produto_plano_venda (idProduto, descricao, quantidade, vlUnitario) Values
(2, '00008 moedas', 8, 0.25)
, (2, '00050 moedas', 50, 0.20)
, (2, '00100 moedas', 100, 0.18)
, (2, '00200 moedas', 200, 0.16)
, (2, '00300 moedas', 300, 0.14)
, (2, '00400 moedas', 400, 0.13)
, (2, '00500 moedas', 500, 0.13)
, (2, '00800 moedas', 800, 0.12)
, (2, '01000 moedas', 1000, 0.11)
, (2, '05000 moedas', 5000, 0.10)
, (2, '10000 moedas', 10000, 0.09)
, (2, '15000 moedas', 15000, 0.08)
, (2, '30000 moedas', 30000, 0.06);

/*
 Num. moedas     Vl unit     Vl tot

00008 moedas  -  R$ 0.25  -  R$ 2.00
00050 moedas  -  R$ 0.20  -  R$ 10.00
00100 moedas  -  R$ 0.18  -  R$ 18.00
00200 moedas  -  R$ 0.16  -  R$ 32.00
00300 moedas  -  R$ 0.14  -  R$ 42.00
00400 moedas  -  R$ 0.13  -  R$ 52.00
00500 moedas  -  R$ 0.13  -  R$ 65.00
00800 moedas  -  R$ 0.12  -  R$ 96.00
01000 moedas  -  R$ 0.11  -  R$ 110.00
05000 moedas  -  R$ 0.10  -  R$ 500.00
10000 moedas  -  R$ 0.09  -  R$ 900.00
15000 moedas  -  R$ 0.08  -  R$ 1200.00
30000 moedas  -  R$ 0.06  -  R$ 1800.00
*/

Insert Into template_sms (global, nome, conteudo) Values (1, '$(nome)', 'pessoa.nome');



Insert Into Pessoa
(               
    nome       
	, sexo                
	, email               
	, login               
	, senha               
	, tipoPessoa          
	, rg                 
	, cpf               
	, dataNascimento      
	, usuarioSistema
	, primeironome
)
Values
(
     'Gabriel Silveira da Rosa'      
	, 'M'                
	, 'gabriel_silveira@hotmail.com'               
	, 'gabriel'               
	, '102030'               
	, 'F'          
	, '9109235858'                 
	, '02879452360'               
	, '1992-10-05'      
	, 1
	, 'Gabriel'
);


Insert Into Cliente
(                  
	idPessoa       
	,licencaLiberada
	,avisoSistema
	,chaveCripto   
)
Values
(        
	(Select Max(id) From pessoa)       
	,1
	,'Nenhum aviso'   
	,MD5(Random()::Text)  
);

Insert Into Pessoa
(               
    nome       
	, sexo                
	, email               
	, login               
	, senha               
	, tipoPessoa          
	, rg                 
	, cpf               
	, dataNascimento      
	, usuarioSistema
	, primeironome
)
Values
(
     'Jessica dos Santos Conceição'      
	, 'F'                
	, 'jessica@bol.com'               
	, 'jessika'               
	, 'abcd'               
	, 'F'          
	, '505050'                 
	, '46489023211'               
	, '1991-08-08'      
	, 1
	, 'Jessica'
);



Insert Into operadora
(
	nome         
	, Descricao    
)
Values
('Claro', '')
, ('OI', '')
, ('Tim', '')
, ('Vivo', '');


Insert Into pessoa_telefone
(
    idPessoa       
	, idTipoTelefone 
	, idOperadora    
	, ddi            
	, ddd            
	, numero         
	, observacao
)
Values
(
	(Select Max(id) From pessoa)
	, 2
	, (Select Max(id) from operadora)
	, '55'
	, '53'
	, '984074070'
	, 'Celular de teste'
),
(
	(Select Max(id) From pessoa)
	, 3
	, (Select Max(id) from operadora)
	, '55'
	, '53'
	, '999235688'
	, 'Outro celular de teste'
);

Insert Into sms_lote_detalhe
(
	, idSmsLote 
	, idPessoaDestinatario 
	, idPessoaTelefone 
	, mensagem 
	, status 
)
Values
(
	(Select Max(id) From sms_lote) 
	, 5 
	, 6 
	, 'Mensagem 1' 
	, 1 
),
(
	(Select Max(id) From sms_lote) 
	, 5 
	, 6 
	, 'Mensagem 2' 
	, 1 
);

