
-- Tabela Infetado
create table infected (
	id_infected 		int 				IDENTITY(1,1) PRIMARY KEY,
    name 				varchar(70) 		not null,
    address				varchar(100)		not null,
    birthday 			varchar(100)		not null,
	pacient_number 		varchar(9)  		not null		unique,
    contact 			varchar(9)   		not null, 		--check( contact like '[0-9]{9}'),
	register_date 		varchar(100)		not null, 
);


-- Tabela Isolado
create table isolated (
	id_isolated 		int 				IDENTITY(1,1) PRIMARY KEY,
    name 				varchar(70) 		not null,
    address 			varchar(100)		not null,
    birthday 			varchar(100)		not null,
	pacient_number 		varchar(9)  		not null 		unique,
    contact 			varchar(9)   		not null, --check( contact like '[0-9]{9}')
	register_date 		varchar(100)		not null,
	cod_infected 		int	 not null		FOREIGN KEY REFERENCES infected(id_infected)
);

-- Tabela Visitas
create table visits (
	id_visit 			int 				IDENTITY(1,1) PRIMARY KEY,
	pacient_number 		varchar(9)  		not null,
	status				int 				CHECK(status = 0 or status = 1),
    visit_date 			varchar(100)		not null,
);

-- Tabela Produto
create table product (
	id			 		int 				IDENTITY(1,1) PRIMARY KEY,
    label 				varchar(60) 		not null,
	unitPrice			float				not null,
);

--Tabela equipas
create table team (
	id			 		int 			IDENTITY(1,1) PRIMARY KEY,
    label 				varchar(50) 	not null,
);

--Tabela Requisicoes
create table orders (
	id			 		int 			IDENTITY(1,1) PRIMARY KEY,
    date 				nchar(10) 		not null,
	total_price			float,
	id_team				int				not null FOREIGN KEY REFERENCES team(id),
);


--Tabela Entregas
create table delivery (
	id			 		int 			IDENTITY(1,1) PRIMARY KEY,
    date 				nchar(10) 		not null,
	id_order			int				not null FOREIGN KEY REFERENCES orders(id) -- 0 por entregar 1 entregue
);

--Tabela Relacao produtos-requisicoes
create table product_order (
	quantity			int				not null,
	id_order			int				not null FOREIGN KEY REFERENCES orders(id),
	id_product			int				not null FOREIGN KEY REFERENCES product(id)
);

-------------------------			Alter tables 			---------------------------
----------------------------------------------------------------------------------------
	
-- Chave estrangeira da tabela Isolado para a tabela Infetado atraves da chave cod_infected -> id_infected
--	alter table ipca.isolated add constraint isolated_infected_fk foreign key( cod_infected  ) references ipca.infected( id_infected );
	
------------ INSERTS -------------------

-- INSERT INTO ipca.infected (id_infected, name, address, birthday, pacient_number, contact, register_date)		
-- VALUES (0, 'joao', 'rua', '02-01-01', '123456789', '925109345', '14-01-21' );
	
	
ALTER TABLE orders
ADD delivered tinyint  DEFAULT 0;