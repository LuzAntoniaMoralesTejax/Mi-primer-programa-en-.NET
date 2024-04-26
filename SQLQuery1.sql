
/* Creacion de la Base de Datos */
	create database Prueba

	use Prueba  /* Usar la Base de Datos Prueba */

/*XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX*/
					/* CREACION DE TABLAS persona e informacion */

/* Tabla creada de persona */
create table persona(
id int not null primary key Identity,
nombre varchar(50),
apellido varchar(50)
);

/* Tabla creada de informacion */
create table informacion(
id int not null primary key Identity,
telefono varchar(10),
direccion varchar(50),
oficio varchar(50),
);

/*XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX*/
				/*FUNCIONES CRUD DE TABLA persona e informacion*/	

/* CREAR > CREATE >> INSERT */
/* Insercion de datos en la tabla de persona */
insert into persona(nombre, apellido) values ('Lucia', 'Zamora');
insert into persona(nombre, apellido) values ('Zoila', 'Gutierrez');
insert into persona(nombre, apellido) values ('Andrea', 'Zarceño');
insert into persona(nombre, apellido) values ('Cristian', 'Najarro');
insert into persona(nombre, apellido) values ('Daniela', 'Gaitan');

/* Insercion de datos en la tabla de informacion */
insert into informacion(telefono, direccion, oficio) values ('78898925', 'Col. Santa Marta', 'Gerente');
insert into informacion(telefono, direccion, oficio) values ('14785236', 'Col. Estancia', 'RRHH');
insert into informacion(telefono, direccion, oficio) values ('89632541', 'Col. Hunapu', 'IT');
insert into informacion(telefono, direccion, oficio) values ('12365478', 'Col. Zona 3', 'Auxiliar de produccion');
insert into informacion(telefono, direccion, oficio) values ('25896314', 'Col. Madrid', 'Analista de Datos');

/*XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX*/

/* LEER > READ >> SELECT */
/* CONSULTA DE TABLAS persona e informacion */
select * from persona;
select * from informacion;

/*XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX*/

/* ACTUALIZAR > UPDATE >> UPDATE*/
/* TABLA persona*/
update persona set nombre = 'Diego'
where id = 2;

/* TABLA informacion */
update informacion set direccion = 'Santa Fe'
where id =2;

/*XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX*/

/* BORRAR > DELETE >> DELETE */

/* TABLA persona*/
delete from persona where id = 2;

/* TABLA informacion*/
delete from informacion where id = 2;
