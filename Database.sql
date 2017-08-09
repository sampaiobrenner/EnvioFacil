/* Create Database db_envioFacil Encoding = 'utf8' Template0; */


Create Table configuracao
(
	id              Serial Unique Not Null
	, ativo         SmallInt Not Null Default 1
	, nome          Varchar(100) Not Null
	, valor         Text Not Null
	, dataCadastro  TimeStamp Not Null Default Now()
	, dataAlteracao TimeStamp
	, Constraint pk_configuracao_id Primary Key(id)
)With Oids;



Create Table pessoa
(
	id                      Serial Unique Not Null
	, ativo                 SmallInt Not Null Default 1
	, idCliente             Int Default Null	
	, nome                  Varchar(100)
	, primeiroNome          Varchar(20) Not Null
	, sobreNome             Varchar(80)
	, razaoSocial           Varchar(100)
	, nomeFantasia          Varchar(100)
	, sexo                  Varchar(1) Default Null
	, email                 Varchar(60) Not Null
	, tipoPessoa            Char(1)	
	, rg                    Varchar(12)
	, inscricaoEstadual     Varchar(16)
	, inscricaoMunicipal    Varchar(16)
	, cpf                   Varchar(11)
	, cnpj                  Varchar(14)
	, dataNascimento        TimeStamp Default Null
	, usuarioSistema        SmallInt Not Null Default 0
	, dataCadastro          TimeStamp Default Now()
	, dataAtualizacao       TimeStamp Default Now()
	, Constraint pk_pessoa_id Primary Key (id)
	, Constraint ck_pessoa_tipoPessoa Check (TipoPessoa IN ('F', 'J'))
) With Oids;
Comment On Column pessoa.usuarioSistema Is 'Flag que indica se trata-se um usuário do sistema. 1=Sim; 2=Não, ou seja é apenas um cliente dos nossos clientes';
Create Index idx_pessoa_nome_login_senha On pessoa(nome, login, senha);



Create Table cliente
(
	id                   Serial Not Null Unique
	, ativo              SmallInt Not Null Default 1
	, idPessoa           Int Not Null Unique	
	, licencaLiberada    SmallInt Not Null Default 1
	, login              Varchar(40)
	, senha              Varchar(20)
	, avisoSistema       Varchar(80) Default Null
	, dataCadastro       TimeStamp Default Now()
	, dataAtualizacao    TimeStamp Default Now()
	, chaveCripto        Varchar(32) Not Null
	, Constraint pk_cliente_id Primary Key (id)
	, Foreign Key (idPessoa) References pessoa(id)
)With Oids;
Comment On Column cliente.avisoSistema Is 'Mensagem que será exibida na tela do aplicativo. Serve para casos em que temos que enviar alguma mensagem aos usuários.';
Alter Table pessoa Add Constraint fk_cliente_idPessoa Foreign key (idCliente) References cliente(id) Match Simple;


Create Table configuracao_cliente
(
	id              Serial Unique Not Null
	, ativo         SmallInt Not Null Default 1
	, idCliente     Int Not Null
	, nome          Varchar(100) Not Null
	, valor         Text Not Null
	, dataCadastro  TimeStamp Not Null Default Now()
	, dataAlteracao TimeStamp
	, Constraint pk_configuracao_cliente_id Primary Key(id)
	, Foreign key (idCliente) References cliente(id)
)With Oids;


Create Table operadora
(
	id             Serial Unique Not NUll
	, ativo        SmallInt Not Null Default 1
	, nome         Varchar(40) Not Null
	, Descricao    Text
	, dataCadastro TimeStamp Not Null Default Now()
	, Constraint pk_operadora_id Primary key (id)
)With Oids;



Create Table tipo_telefone
(
	id              Serial Unique Not Null
	, ativo         SmallInt Default 1
	, descricao     Varchar(40) Not Null
	, dataCadastro  TimeStamp Default Now()
	, Constraint pk_tipo_telefone_id Primary Key(id)
)With Oids;


Create Table pessoa_telefone
(
	id                  Serial Unique Not Null
	, ativo             SmallInt Not Null Default 1
	, idPessoa          Int Not Null
	, idTipoTelefone    Int Not Null
	, idOperadora       Int Default Null
	, ddi               Varchar(3) Not Null
	, ddd               Varchar(3) Not Null
	, numero            Varchar(10) Not Null
	, observacao        Varchar(1024) Default Null
	, Constraint pk_pessoa_telefone_id Primary Key(id)
	, Foreign Key (idPessoa) References pessoa(id)
	, Foreign Key (idTipoTelefone) References tipo_telefone(id)
)With Oids;
Create Index idx_pessoa_telefone_idPessoa On pessoa_telefone(idPessoa);


Create Table forma_pagamento
(
	id                       Serial Unique Not Null
	, ativo                  SmallInt Not Null Default 1
	, descricao              Varchar(40) Not Null
	, numeroMaximoParcelas   Int Default Null
)With Oids;


Create Table venda
(
	id                   Serial Unique Not Null
	, idPessoa           Int Not Null
	, idFormaPagamento   Int Not Null
	, vlTotal            Real Not Null
	, vlDesconto         Real Not Null
	, vlRecebido         Real Default Null
	, excluida           SmallInt Not Null Default 0
	, cancelada          SmallInt Not Null Default 0
	, dataCadastro       TimeStamp Not Null Default Now()
	, dataFinalizacao    TimeStamp Default Null
	, dataRetorno        TimeStamp Default Null
	, dataCancelamento   TimeStamp Default Null
	, Constraint pk_venda_id Primary Key (id)
	, Foreign Key (idPessoa) References pessoa(id)
	, Foreign Key (idFormaPagamento) References forma_pagamento(id)
)With Oids;
Comment On Column venda.dataCadastro Is 'Data na qual o registro foi criado no banco de dados (usuário iniciou uma venda)';
Comment On Column venda.dataFinalizacao Is 'Data que o usuário confirmou a venda';
Comment On Column venda.dataRetorno Is 'Data de retorno (para saber se a venda foi aprovada, negada, etc.)';
Comment On Column venda.dataCancelamento Is 'Data de cancelamento da venda';
Create Index idx_venda_dataFinalizacao On venda(dataFinalizacao);


Create Table item_venda
(
	id              Serial Unique Not Null
	, idVenda       Int Not Null
	, idProduto     Int Not Null
	, vlUnitario    Real Not Null
	, quantidade    Real Not Null
	, vlTotal       Real Not Null
	, excluido      SmallInt Default 0
	, dataCadastro  TimeStamp Not Null Default Now()
	, dataExclusao  TimeStamp Default Null
	, Constraint pk_item_venda_id Primary Key (id)
	, Foreign Key (idVenda) References venda(id)
)With Oids;


Create Table tipo_movimento
(
	id              Serial Unique Not Null
	, ativo         SmallInt Not Null Default 1
	, descricao     Varchar(40)
	, Constraint pk_tipo_movimento_id Primary Key (id)
)With Oids;


Create Table produto
(
	id                  Serial Unique Not Null
	, ativo             SmallInt Not Null Default 1
	, nome              Varchar(80) Not Null
	, descricao         Text Default Null
	, codigoVendavel    varchar(32) Not Null
	, estoque           Real Not Null
	, vlCustoUnitario   Real Not Null
	, vlVendaUnitario   Real Not Null	
	, Constraint pk_compra_credito_id Primary Key(id)
)With Oids;


Alter Table item_venda Add Constraint fk_item_venda_idProduto Foreign Key (idProduto) References produto(id);


Create Table produto_movimento
(
	id                 Serial Unique Not Null
	, idProduto        Int Not Null
	, idTipoMovimento  Int Not Null
	, idVenda          Int
	, qtdEntrada       Real Default Null
	, qtdSaida         Real Default Null
	, qtdFinal         Real Not Null
	, qtdAnterior      Real Not Null	
	, Constraint pk_produto_movimento_id Primary Key(id)
	, Foreign Key (idProduto) References produto(id)
	, Foreign Key (idTipoMovimento) References tipo_movimento(id)
)With Oids;

/*
Create Or Replace Function f_trg_produto_calcular_valor_total()
	Returns Trigger As $trg_ai_produto_calcular_vlTotal$
Begin
	If (Coalesce(New.vlTotal, 0) = 0) Then
		New.vlTotal = New.vlUnitario * New.quantidade;
	End If;

	Return Null;
End;
$trg_ai_produto_calcular_vlTotal$ Language plpgsql;


Create Trigger trg_ai_produto_calcular_vlTotal
	After Insert Or Update
	On produto
	For Each Row 
		Execute Procedure f_trg_credito_venda_calcular_valor_total();
*/


Create Table produto_plano_venda
(
	id             Serial Unique Not Null
	, ativo        SmallInt Not Null Default 1
	, idProduto    Int Not Null
	, descricao    Varchar(80) Not Null
	, observacao   Text
	, quantidade   Real Not Null
	, vlUnitario   Real Not Null
    , vlFinal      Real	
	, dataCadastro TimeStamp Not Null Default Now()
	, Constraint pk_produto_plano_venda_id Primary key(id)
	, Foreign key (idProduto) References produto(id)
)With Oids;

Create Or Replace Function func_trig_before_produto_plano_venda_calcular_vlFinal()
	Returns Trigger As $trig_before_produto_plano_venda_calcular_vlFinal$
Begin
	If(Coalesce(New.vlFinal, 0) = 0) Then
		New.vlFinal = New.quantidade * New.vlUnitario;
	End If;

	Return New;
End;
$trig_before_produto_plano_venda_calcular_vlFinal$ Language 'plpgsql';


Create Trigger trig_before_produto_plano_venda_calcular_vlFinal
	Before Insert Or Update
	On produto_plano_venda
	For Each Row
		Execute Procedure func_trig_before_produto_plano_venda_calcular_vlFinal();



Create Table cliente_saldo
(
	id                        Serial Unique Not Null
	, idCliente               Int Not Null
	, saldo                   Real Not Null
	, dataUltimaMovimentacao  TimeStamp Not Null
	, Constraint pk_pessoa_saldo_id Primary Key(id)
	, Foreign Key (idCliente) References cliente(id)
)With Oids;


Create Table cliente_movimentacao_saldo
(
	id                Serial Unique Not Null
	, idClienteSaldo  Int Not Null
	, idItemVenda     Int Default Null
	, idTipoMovimento Int Not Null
	, saldoCreditado  Real Default 0
	, saldoDebitado   Real Default 0
	, saldoFinal      Real Not Null
	, saldoAnterior   Real Not Null
	, data            TimeStamp Not Null Default Now()
	, Constraint pk_cliente_movimentacao_saldo_id Primary Key (id)
	, Foreign Key (idClienteSaldo) References cliente_saldo(id)
	, Foreign key (idItemVenda) References item_venda(id)
	, Foreign key (idTipoMovimento) References tipo_movimento(id)
)With Oids;


Create Table sms_lote
(
	id                    Serial Unique Not Null
	, ativo               SmallInt Not Null Default 1
	, processado          SmallInt Not Null Default 0
	, idClienteRemetente  Int Not Null
	, qtdSms              Int Not Null
	, qtdEnviado          Int Default Null
	, qtdErro             Int Default Null
	, status              SmallInt Not Null
	, envioAgendado       SmallInt Not Null Default 0
	, dataCadastro        TimeStamp Not Null Default Now ()
	, dataAgendada        TimeStamp Default Null
	, dataProcessamento   TimeStamp Default Null
	, Constraint pk_sms_lote_id Primary key (id)
	, Foreign key (idClienteRemetente) References cliente(id)
	, Constraint ck_sms_lote_status Check (status In (1, 2, 3))
)With Oids;
Comment On Column sms_lote.status Is 'Status: 1-Não processado; 2-Processamento iniciado; 3-Processado';
Comment On Column sms_lote.dataAgendada Is 'Refere-se à data no qual o envio deverá ser executado';
Create Index idx_sms_lote_dataAgendada On sms_lote(dataAgendada);


Create Table sms_lote_detalhe
(
	id                         Serial Unique Not Null
	, ativo                    SmallInt Not Null Default 1
	, idSmsLote                Int Not Null
	, idPessoaDestinatario     Int Not Null
	, idPessoaTelefone         Int Not Null
	, mensagem                 Varchar(160) Not Null
	, status                   SmallInt Not Null
	, retorno                  Text
	, dataCadastro             TimeStamp Not Null Default Now()
	, dataRetorno              TimeStamp Default Null
	, Constraint pk_sms_lote_detalhe_id Primary key(id)
	, Foreign key (idSmsLote) References sms_lote(id)
	, Foreign key (idPessoaDestinatario) References pessoa(id)
	, Foreign key (idPessoaTelefone) References pessoa_telefone(id)
	, Constraint ck_sms_lote_detalhe_status Check (status In (1, 2, 3))
)With Oids;
Comment On Column sms_lote_detalhe.status Is 'Status: 1-Não processado; 2-Processamento iniciado; 3-Processado';
Create Index idx_sms_lote_detalhe On sms_lote_detalhe(idSmsLote);


Create Table tag_template
(
	id                  Serial Unique Not Null
	, nome              Varchar(20) Not Null
	, campoReferencia   Varchar(40) Not Null
	, Constraint pk_tag_template_id Primary key (id)
)With Oids;
Comment on table tag_template Is 'Guarda as tags que podem ser utilizadas para substituir campos padrões. Por exemplo: $(nome), $(telefone), $(celular';


Create Table template_sms
(
	id              Serial Unique Not Null
	, ativo         SmallInt Not Null Default 1
	, global        SmallInt Not Null Default 0
	, idCliente     Int Default Null
	, nome          Varchar(100) Not Null
	, conteudo      Varchar(160) Not Null
	, dataCadastro  TimeStamp Not Null Default Now()
	, Constraint pk_template_sms_id Primary Key (id)
	, Foreign key (idCliente) References cliente(id)
)With Oids;


Create Table serv_servidor_sms
(
	id                Serial Unique Not Null
	, ativo           SmallInt Not Null Default 1
	, nome            Varchar(40) Not Null
	, site            Varchar(80)
	, urlWebService   Varchar(80)
	, usuario         Varchar(80) Not Null
	, senha           Varchar(80) Not Null
	, dataCadastro    TimeStamp Not Null Default Now()
	, dataDesativacao TimeStamp Default Null
	, Constraint pk_serv_servidor_sms_id Primary Key(id)
)With Oids;

Create Table serv_servidor_sms_saldo
(
	id                Serial Unique Not Null
	, idServidorSMS   Int Not Null
	, saldo           Real Not Null
	, Constraint pk_serv_servidor_sms_saldo Primary key(id)
	, Foreign key (idServidorSMS) References serv_servidor_sms(id)
)With Oids;