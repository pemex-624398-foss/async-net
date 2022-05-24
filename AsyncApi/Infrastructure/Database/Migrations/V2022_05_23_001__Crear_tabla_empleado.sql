create table empleado (
    id_empleado uuid not null primary key,
    nombre varchar(100) not null,
    apellido varchar(100) not null,
    genero varchar(20) not null,
    fecha_nacimiento date not null,
    rfc varchar(13) not null,
    correo varchar(255) not null,
    registro_confirmado boolean not null default false
);
