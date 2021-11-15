CREATE SCHEMA IF NOT EXISTS ipca;

-- COLOCAR UM ATRIBUTO STATUS ???? 

-- Tabela Infetado
create table if not exists ipca.infected (
	id_infected 		int 				not null,
    name 				varchar(70) 		not null,
    address				varchar(100)		not null,
    birthday 			varchar(100)		not null,
	pacient_number 		varchar(9)  		not null		unique,
    contact 			varchar(9)   		not null, 		--check( contact like '[0-9]{9}'),
	register_date 		varchar(100)		not null,
	constraint infected_pk primary key( id_infected ) 
);


-- Tabela Isolado
create table if not exists ipca.isolated (
	id_isolated 		serial 				not null,
    name 				varchar(70) 		not null,
    address 			varchar(100)		not null,
    birthday 			varchar(100)		not null,
	pacient_number 		varchar(9)  		not null 		unique,
    contact 			varchar(9)   		not null, --check( contact like '[0-9]{9}')
	register_date 		varchar(100)		not null,
	cod_infected 		int					not null		unique,
	constraint isolated_pk primary key( id_isolated ) 
);

-------------------------			Alter tables 			---------------------------
----------------------------------------------------------------------------------------
	
-- Chave estrangeira da tabela Isolado para a tabela Infetado atraves da chave cod_infected -> id_infected
	alter table ipca.isolated add constraint isolated_infected_fk foreign key( cod_infected  ) references ipca.infected( id_infected );
	
------------ INSERTS -------------------

-- INSERT INTO ipca.infected (id_infected, name, address, birthday, pacient_number, contact, register_date)		
-- VALUES (0, 'joao', 'rua', '02-01-01', '123456789', '925109345', '14-01-21' );
	