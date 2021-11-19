
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
	cod_infected 		int	 not null		unique 			FOREIGN KEY REFERENCES infected(id_infected)
);

-- Tabela Visitas
create table visits (
	id_visit 			int 				IDENTITY(1,1) PRIMARY KEY,
	pacient_number 		varchar(9)  		not null,
	status				int 				CHECK(status = 0 or status = 1),
    visit_date 			varchar(100)		not null,
);

-------------------------			Alter tables 			---------------------------
----------------------------------------------------------------------------------------
	
-- Chave estrangeira da tabela Isolado para a tabela Infetado atraves da chave cod_infected -> id_infected
--	alter table ipca.isolated add constraint isolated_infected_fk foreign key( cod_infected  ) references ipca.infected( id_infected );
	
------------ INSERTS -------------------

-- INSERT INTO ipca.infected (id_infected, name, address, birthday, pacient_number, contact, register_date)		
-- VALUES (0, 'joao', 'rua', '02-01-01', '123456789', '925109345', '14-01-21' );
	