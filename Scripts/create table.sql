create table Categoria(
	IdCategoria		integer			identity(1,1),
	Nome			nvarchar(50)	not null,
	primary key(IdCategoria)
)
go

create table Fornecedor(
	IdFornecedor	integer			identity(1,1),
	Nome			nvarchar(50)	not null,
	Email			nvarchar(50)	not null,
	Telefone		nvarchar(13)	not null,
	Cnpj			nvarchar(14)	not null unique,
	primary key(IdFornecedor)
)
go

create table Produto(
	IdProduto		integer			identity(1,1),
	Nome			nvarchar(50)	not null,
	Descricao		nvarchar(250)	not null,
	DataValidade	datetime		not null,
	DataFabricacao	datetime		not null,
	Preco			decimal(18,2)	not null,
	IdCategoria		integer			not null,
	IdFornecedor	integer			not null,
	primary key(IdProduto),
	foreign key(IdCategoria) references Categoria(IdCategoria),
	foreign key(IdFornecedor) references Fornecedor(IdFornecedor)
)
go