USE GD1C2016;
GO

/* Eliminación de los objetos preexistentes */

IF OBJECT_ID('HARDCOR.Oferta','U') IS NOT NULL
    DROP TABLE HARDCOR.Oferta;

IF OBJECT_ID('HARDCOR.Compra','U') IS NOT NULL
    DROP TABLE HARDCOR.Compra;

IF OBJECT_ID('HARDCOR.Calificacion','U') IS NOT NULL
    DROP TABLE HARDCOR.Calificacion;

IF OBJECT_ID('HARDCOR.Detalle','U') IS NOT NULL
    DROP TABLE HARDCOR.Detalle;

IF OBJECT_ID('HARDCOR.Tipo_fact','U') IS NOT NULL
    DROP TABLE HARDCOR.Tipo_fact;

IF OBJECT_ID('HARDCOR.Factura','U') IS NOT NULL
    DROP TABLE HARDCOR.Factura;

IF OBJECT_ID('HARDCOR.Publicacion','U') IS NOT NULL
    DROP TABLE HARDCOR.Publicacion;

IF OBJECT_ID('HARDCOR.Estado_publ','U') IS NOT NULL
    DROP TABLE HARDCOR.Estado_publ;

IF OBJECT_ID('HARDCOR.Tipo','U') IS NOT NULL
    DROP TABLE HARDCOR.Tipo;

IF OBJECT_ID('HARDCOR.Visibilidad','U') IS NOT NULL
    DROP TABLE HARDCOR.Visibilidad;

IF OBJECT_ID('HARDCOR.Empresa','U') IS NOT NULL
    DROP TABLE HARDCOR.Empresa;

IF OBJECT_ID('HARDCOR.Rubro','U') IS NOT NULL
    DROP TABLE HARDCOR.Rubro;

IF OBJECT_ID('HARDCOR.Cliente','U') IS NOT NULL
    DROP TABLE HARDCOR.Cliente;

IF OBJECT_ID('HARDCOR.Tipo_doc','U') IS NOT NULL
    DROP TABLE HARDCOR.Tipo_doc;

IF OBJECT_ID('HARDCOR.Contacto','U') IS NOT NULL
    DROP TABLE HARDCOR.Contacto;

IF OBJECT_ID('HARDCOR.RolXus','U') IS NOT NULL
    DROP TABLE HARDCOR.RolXus;

IF OBJECT_ID('HARDCOR.Usuario','U') IS NOT NULL
    DROP TABLE HARDCOR.Usuario;

IF OBJECT_ID('HARDCOR.RolXfunc','U') IS NOT NULL
    DROP TABLE HARDCOR.RolXfunc;

IF OBJECT_ID('HARDCOR.Funcionalidad','U') IS NOT NULL
    DROP TABLE HARDCOR.Funcionalidad;

IF OBJECT_ID('HARDCOR.Rol','U') IS NOT NULL
    DROP TABLE HARDCOR.Rol;

IF OBJECT_ID('HARDCOR.Inconsistencias','U') IS NOT NULL
    DROP TABLE HARDCOR.Inconsistencias;

IF OBJECT_ID('HARDCOR.generar_publicacion') IS NOT NULL
    DROP PROCEDURE HARDCOR.generar_publicacion

IF OBJECT_ID('HARDCOR.cambiar_estado_publ') IS NOT NULL
    DROP PROCEDURE HARDCOR.cambiar_estado_publ

IF OBJECT_ID('HARDCOR.modif_publ_borrador') IS NOT NULL
    DROP PROCEDURE HARDCOR.modif_publ_borrador

IF OBJECT_ID ('HARDCOR.tr_finalizar_pub_compra_au') IS NOT NULL
    DROP TRIGGER HARDCOR.tr_finalizar_pub_compra_au

IF OBJECT_ID ('HARDCOR.comprar_ofertar') IS NOT NULL
    DROP PROCEDURE HARDCOR.comprar_ofertar

IF OBJECT_ID ('HARDCOR.alta_vis') IS NOT NULL
    DROP PROCEDURE HARDCOR.alta_vis

IF OBJECT_ID ('HARDCOR.mod_vis') IS NOT NULL
    DROP PROCEDURE HARDCOR.mod_vis

IF OBJECT_ID ('HARDCOR.baja_vis') IS NOT NULL
    DROP PROCEDURE HARDCOR.baja_vis

IF OBJECT_ID ('HARDCOR.baja_rol') IS NOT NULL
    DROP PROCEDURE HARDCOR.baja_rol

IF OBJECT_ID('HARDCOR.calificar_vta') IS NOT NULL
    DROP PROCEDURE HARDCOR.calificar_vta;

IF OBJECT_ID('HARDCOR.consulta_factura') IS NOT NULL
    DROP PROCEDURE HARDCOR.consulta_factura;

IF OBJECT_ID('HARDCOR.lista_sin_calif') IS NOT NULL
    DROP PROCEDURE HARDCOR.lista_sin_calif;

IF OBJECT_ID('HARDCOR.tr_update_calif') IS NOT NULL
    DROP TRIGGER HARDCOR.tr_update_calif;

IF OBJECT_ID('HARDCOR.List_fact') IS NOT NULL
    DROP VIEW HARDCOR.List_fact;

IF OBJECT_ID ('HARDCOR.list_vendedor_mayorCantProdSinVta') IS NOT NULL
    DROP PROCEDURE HARDCOR.list_vendedor_mayorCantProdSinVta

IF OBJECT_ID ('HARDCOR.list_cli_mayorCantProdCompr') IS NOT NULL
    DROP PROCEDURE HARDCOR.list_cli_mayorCantProdCompr

IF OBJECT_ID ('HARDCOR.list_vend_mayorCantFact') IS NOT NULL
    DROP PROCEDURE HARDCOR.list_vend_mayorCantFact

IF OBJECT_ID ('HARDCOR.list_vend_mayorMontoFact') IS NOT NULL
    DROP PROCEDURE HARDCOR.list_vend_mayorMontoFact

IF OBJECT_ID ('HARDCOR.listados') IS NOT NULL
    DROP PROCEDURE HARDCOR.listados

IF OBJECT_ID ('HARDCOR.Emp_Categ') IS NOT NULL
    DROP FUNCTION HARDCOR.Emp_Categ

IF OBJECT_ID ('HARDCOR.finalizar_subastas') IS NOT NULL
    DROP PROCEDURE HARDCOR.finalizar_subastas

IF OBJECT_ID ('HARDCOR.facturar_venta') IS NOT NULL
    DROP PROCEDURE HARDCOR.facturar_venta

IF OBJECT_ID ('HARDCOR.facturar_publicacion') IS NOT NULL
    DROP PROCEDURE HARDCOR.facturar_publicacion

IF (OBJECT_ID ('HARDCOR.login') IS NOT NULL)
    DROP PROCEDURE HARDCOR.login

IF (OBJECT_ID ('HARDCOR.listar_empresas') IS NOT NULL)
    DROP PROCEDURE HARDCOR.listar_empresas

IF (OBJECT_ID ('HARDCOR.listar_clientes') IS NOT NULL)
  DROP PROCEDURE HARDCOR.listar_clientes

IF (OBJECT_ID ('HARDCOR.obtener_roles') IS NOT NULL)
  DROP PROCEDURE HARDCOR.obtener_roles

IF (OBJECT_ID ('HARDCOR.obtener_cliente') IS NOT NULL)
  DROP PROCEDURE HARDCOR.obtener_cliente

IF (OBJECT_ID ('HARDCOR.obtener_empresa') IS NOT NULL)
  DROP PROCEDURE HARDCOR.obtener_empresa

IF (OBJECT_ID ('HARDCOR.crear_usuario') IS NOT NULL)
  DROP PROCEDURE HARDCOR.crear_usuario

IF (OBJECT_ID ('HARDCOR.crear_contacto') IS NOT NULL)
  DROP PROCEDURE HARDCOR.crear_contacto

IF (OBJECT_ID ('HARDCOR.crear_cliente') IS NOT NULL)
  DROP PROCEDURE HARDCOR.crear_cliente

IF (OBJECT_ID ('HARDCOR.crear_empresa') IS NOT NULL)
  DROP PROCEDURE HARDCOR.crear_empresa

IF (OBJECT_ID ('HARDCOR.modificar_cliente') IS NOT NULL)
  DROP PROCEDURE HARDCOR.modificar_cliente

IF (OBJECT_ID ('HARDCOR.modificar_empresa') IS NOT NULL)
  DROP PROCEDURE HARDCOR.modificar_empresa

IF (OBJECT_ID ('HARDCOR.existe_usuario') IS NOT NULL)
  DROP FUNCTION HARDCOR.existe_usuario

IF (OBJECT_ID ('HARDCOR.modificar_rol') IS NOT NULL)
  DROP PROCEDURE HARDCOR.modificar_rol

IF (OBJECT_ID ('HARDCOR.crear_rol') IS NOT NULL)
  DROP PROCEDURE HARDCOR.crear_rol

IF (OBJECT_ID ('HARDCOR.funcionalidades_del_rol') IS NOT NULL)
  DROP PROCEDURE HARDCOR.funcionalidades_del_rol

IF (OBJECT_ID ('HARDCOR.agregar_funcionalidad') IS NOT NULL)
  DROP PROCEDURE HARDCOR.agregar_funcionalidad

IF (OBJECT_ID ('HARDCOR.quitar_funcionalidad') IS NOT NULL)
  DROP PROCEDURE HARDCOR.quitar_funcionalidad

IF (OBJECT_ID ('HARDCOR.obtener_rubros') IS NOT NULL)
  DROP PROCEDURE HARDCOR.obtener_rubros

IF (OBJECT_ID ('HARDCOR.obtener_visibilidades') IS NOT NULL)
  DROP PROCEDURE HARDCOR.obtener_visibilidades

IF (OBJECT_ID ('HARDCOR.obtener_visibilidades_por_usuario') IS NOT NULL)
  DROP PROCEDURE HARDCOR.obtener_visibilidades_por_usuario

IF (OBJECT_ID ('HARDCOR.listar_publicaciones') IS NOT NULL)
  DROP PROCEDURE HARDCOR.listar_publicaciones

IF (OBJECT_ID ('HARDCOR.calcular_peso_visibilidad') IS NOT NULL)
  DROP FUNCTION HARDCOR.calcular_peso_visibilidad

IF (OBJECT_ID ('HARDCOR.cantidad_paginas_publicaciones') IS NOT NULL)
  DROP PROCEDURE HARDCOR.cantidad_paginas_publicaciones

IF (OBJECT_ID ('HARDCOR.cantidad_paginas_facturas') IS NOT NULL)
DROP PROCEDURE HARDCOR.cantidad_paginas_facturas

IF (OBJECT_ID ('HARDCOR.split') IS NOT NULL)
  DROP FUNCTION HARDCOR.split

IF (OBJECT_ID ('HARDCOR.obtener_factura') IS NOT NULL)
  DROP PROCEDURE HARDCOR.obtener_factura

IF (OBJECT_ID ('HARDCOR.obtener_detalles_factura') IS NOT NULL)
  DROP PROCEDURE HARDCOR.obtener_detalles_factura

IF (OBJECT_ID ('HARDCOR.calificaciones_por_estrellas') IS NOT NULL)
  DROP PROCEDURE HARDCOR.calificaciones_por_estrellas

IF (OBJECT_ID ('HARDCOR.operaciones_sin_calificar') IS NOT NULL)
  DROP PROCEDURE HARDCOR.operaciones_sin_calificar

IF (OBJECT_ID ('HARDCOR.ultimas_operaciones_calificadas') IS NOT NULL)
  DROP PROCEDURE HARDCOR.ultimas_operaciones_calificadas

IF (OBJECT_ID ('HARDCOR.obtener_tipos_doc') IS NOT NULL)
  DROP PROCEDURE HARDCOR.obtener_tipos_doc

IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'HARDCOR')
    DROP SCHEMA HARDCOR
GO

/* Creación del esquema */

CREATE SCHEMA HARDCOR AUTHORIZATION gd;
GO

/* Creación de las tablas */

CREATE TABLE HARDCOR.Rol(
    cod_rol TINYINT IDENTITY PRIMARY KEY,
    nombre NVARCHAR(225),
    habilitado BIT);

CREATE TABLE HARDCOR.Funcionalidad(
    cod_fun TINYINT IDENTITY PRIMARY KEY,
    descripcion NVARCHAR(225));

CREATE TABLE HARDCOR.RolXfunc(
    cod_rol TINYINT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Rol(cod_rol),
    cod_fun TINYINT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Funcionalidad(cod_fun),
    PRIMARY KEY (cod_rol, cod_fun));

CREATE TABLE HARDCOR.Usuario(
    cod_us INT IDENTITY PRIMARY KEY,
    username NVARCHAR(225) UNIQUE,
    pass_word VARBINARY(225),
    fecha_creacion DATETIME,
    habilitado BIT,
    intentos TINYINT);

CREATE TABLE HARDCOR.RolXus(
    cod_rol TINYINT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Rol(cod_rol),
    cod_us INT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Usuario(cod_us),
    PRIMARY KEY (cod_rol, cod_us));

CREATE TABLE HARDCOR.Contacto(
    cod_contacto INT IDENTITY PRIMARY KEY,
    mail NVARCHAR(50) UNIQUE,
    cod_postal NVARCHAR(50),
    dom_calle NVARCHAR(100),
    nro_piso NUMERIC(18,0),
    nro_dpto NVARCHAR(50),
    nro_calle NUMERIC(18,0),
    localidad NVARCHAR(225),
    nro_tel CHAR(8));

CREATE TABLE HARDCOR.Tipo_doc(
    cod_doc INT IDENTITY PRIMARY KEY,
	documento NVARCHAR(225),
    descripcion NVARCHAR(225));

CREATE TABLE HARDCOR.Cliente(
    cod_us INT PRIMARY KEY REFERENCES HARDCOR.Usuario(cod_us),
    cod_contacto INT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Contacto(cod_contacto),
    cli_tipo_doc INT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Tipo_doc(cod_doc),
	cli_nombre NVARCHAR(225),
    cli_apellido NVARCHAR(225),
    cli_num_doc NUMERIC(18,0) UNIQUE,
    cli_fecha_Nac DATETIME,
    cli_calificacion NUMERIC(18,2),
    cli_ventas INT);

CREATE TABLE HARDCOR.Rubro(
    cod_rubro INT IDENTITY PRIMARY KEY,
    rubro_desc_corta NVARCHAR(225),
    rubro_desc_larga NVARCHAR(225));

CREATE TABLE HARDCOR.Empresa(
    cod_us INT PRIMARY KEY REFERENCES HARDCOR.Usuario(cod_us),
    cod_contacto INT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Contacto(cod_contacto),
    emp_razon_soc NVARCHAR(225) UNIQUE,
    emp_cuit NVARCHAR(50) UNIQUE,
    emp_ciudad NVARCHAR(225),
    emp_calificacion NUMERIC(18,2),
    emp_ventas INT,
    emp_rubro INT FOREIGN KEY REFERENCES HARDCOR.Rubro(cod_rubro),
    emp_nom_contacto nvarchar(225));

CREATE TABLE HARDCOR.Visibilidad(
    cod_visi NUMERIC(18,0) PRIMARY KEY,
    visi_desc NVARCHAR(225),
    comision_pub NUMERIC(18,2),
    comision_vta NUMERIC(18,2),
    comision_envio NUMERIC(18,2));

CREATE TABLE HARDCOR.Tipo(
    cod_tipo INT IDENTITY(1, 1) PRIMARY KEY,
    descripcion NVARCHAR(225));

CREATE TABLE HARDCOR.Estado_publ(
	cod_estado INT IDENTITY PRIMARY KEY,
	descripcion NVARCHAR(225));

CREATE TABLE HARDCOR.Publicacion(
    cod_pub NUMERIC(18,0) PRIMARY KEY,
    cod_us INT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Usuario(cod_us),
    cod_rubro INT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Rubro(cod_rubro),
    cod_visi NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES HARDCOR.Visibilidad(cod_visi),
    cod_tipo INT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Tipo(cod_tipo),
    estado INT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Estado_publ(cod_estado),
	descripcion NVARCHAR(225),
    stock NUMERIC(18,0),
    fecha_ini DATETIME,
    fecha_fin DATETIME,
    precio NUMERIC(18,2),
    costo NUMERIC(18,2),
    envio BIT);

CREATE TABLE HARDCOR.Factura(
    nro_fact NUMERIC PRIMARY KEY,
    cod_pub NUMERIC(18) NOT NULL FOREIGN KEY REFERENCES HARDCOR.Publicacion(cod_pub),
    cod_us INT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Usuario(cod_us),
    fecha DATETIME,
    total NUMERIC(18,2),
    forma_pago NVARCHAR(225));

CREATE TABLE HARDCOR.Tipo_fact(
    cod_tipo_fact INT IDENTITY PRIMARY KEY,
	descripcion NVARCHAR(225));

CREATE TABLE HARDCOR.Detalle(
    cod_det INT IDENTITY PRIMARY KEY,
    nro_fact NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES HARDCOR.Factura(nro_fact),
    item_desc INT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Tipo_fact(cod_tipo_fact),
    cantidad NUMERIC(18,0),
    importe NUMERIC(18,2));

CREATE TABLE HARDCOR.Calificacion(
    cod_calif NUMERIC(18,0) PRIMARY KEY,
    calif_desc NVARCHAR(225),
    calif_ant_estrellas NUMERIC(18,0) CHECK (calif_ant_estrellas > 0 AND calif_ant_estrellas < 11),
    calif_estrellas NUMERIC(18,0) CHECK (calif_estrellas > 0 AND calif_estrellas < 6));

CREATE TABLE HARDCOR.Compra(
    cod_compra INT IDENTITY PRIMARY KEY,
    cod_pub NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES HARDCOR.Publicacion(cod_pub),
    cod_us INT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Usuario(cod_us),
    cod_calif NUMERIC(18,0) FOREIGN KEY REFERENCES HARDCOR.Calificacion(cod_calif),
    fecha_compra DATETIME,
    cantidad NUMERIC(18,0),
    monto_compra NUMERIC(18,2));

CREATE TABLE HARDCOR.Oferta(
    cod_of INT IDENTITY PRIMARY KEY,
    cod_pub NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES HARDCOR.Publicacion(cod_pub),
    cod_us INT NOT NULL FOREIGN KEY REFERENCES HARDCOR.Usuario(cod_us),
    monto_of NUMERIC(18,2),
    fecha_of DATETIME);

/* Migración de datos desde la tabla maestra */

SELECT * INTO HARDCOR.Inconsistencias FROM gd_esquema.Maestra WHERE 1 = 2

CREATE INDEX HARDCOR ON HARDCOR.Contacto (mail);

CREATE INDEX I_Cliente ON HARDCOR.Cliente (cli_nombre, cli_apellido);

CREATE UNIQUE INDEX I_Empresa ON HARDCOR.Empresa (emp_razon_soc, emp_cuit);

CREATE INDEX I_Publicacion ON HARDCOR.Publicacion (cod_rubro, descripcion);

INSERT INTO HARDCOR.Rol (nombre, habilitado)
VALUES ('Administrador general', 1),
       ('Administrador', 1),
       ('Empresa', 1),
       ('Cliente', 1);
GO

INSERT INTO HARDCOR.Funcionalidad(descripcion)
VALUES ('ABM Rol'),
       ('ABM Usuarios'),
       ('ABM Rubro'),
       ('ABM Visibilidad publicacion'),
       ('Generar publicacion'),
       ('Comprar/Ofertar'),
       ('Historial cliente'),
       ('Calificar vendedor'),
       ('Consulta facturas realizadas al vendedor'),
       ('Listado estadistico');
GO

INSERT INTO HARDCOR.RolXfunc(cod_rol, cod_fun)
SELECT 1, f.cod_fun FROM HARDCOR.Funcionalidad f

INSERT INTO HARDCOR.RolXfunc(cod_rol, cod_fun)
VALUES (2, 1), (2, 2), (2, 3), (2, 4)
GO

INSERT INTO HARDCOR.RolXfunc(cod_rol, cod_fun)
VALUES (3, 5)
GO

INSERT INTO HARDCOR.RolXfunc(cod_rol, cod_fun)
VALUES (4, 5), (4, 6), (4, 7), (4, 8)
GO

INSERT INTO HARDCOR.Contacto(mail, cod_postal, dom_calle, nro_piso, nro_dpto, nro_calle)
SELECT DISTINCT m.Cli_Mail AS mail, m.Cli_Cod_Postal, m.Cli_Dom_Calle, m.Cli_Piso, m.Cli_Depto, m.Cli_Nro_Calle
FROM gd_esquema.Maestra m WHERE m.Cli_Mail IS NOT NULL
UNION ALL
SELECT DISTINCT m.Publ_Empresa_Mail AS mail, m.Publ_Empresa_Cod_Postal, m.Publ_Empresa_Dom_Calle, m.Publ_Empresa_Piso,
m.Publ_Empresa_Depto, m.Publ_Empresa_Nro_Calle FROM gd_esquema.Maestra m WHERE m.Publ_Empresa_Mail IS NOT NULL
ORDER BY mail
GO

DECLARE @hash VARBINARY(225)
SELECT @hash = HASHBYTES('SHA2_256', 'w23e');

/* Inserto el usuario admin */
INSERT INTO HARDCOR.Usuario(username, pass_word, habilitado, intentos)
VALUES ('admin', @hash, 1, 0)

INSERT INTO HARDCOR.Usuario(username, pass_word, habilitado, intentos)
SELECT DISTINCT m.Cli_Dni, @hash, 1, 0 FROM gd_esquema.Maestra m WHERE m.Cli_Dni IS NOT NULL
ORDER BY m.Cli_Dni

INSERT INTO HARDCOR.Usuario(username, pass_word, habilitado, intentos, fecha_creacion)
SELECT DISTINCT m.Publ_Empresa_Cuit, @hash, 1, 0, m.Publ_Empresa_Fecha_Creacion
FROM gd_esquema.Maestra m WHERE m.Publ_Empresa_Razon_Social IS NOT NULL ORDER BY m.Publ_Empresa_Cuit
GO

INSERT INTO HARDCOR.RolXus(cod_rol, cod_us)
VALUES (1, (SELECT cod_us FROM HARDCOR.Usuario WHERE username = 'admin'))

INSERT INTO HARDCOR.Rubro(rubro_desc_corta, rubro_desc_larga)
SELECT DISTINCT m.Publicacion_Rubro_Descripcion, m.Publicacion_Rubro_Descripcion FROM gd_esquema.Maestra m
GO

INSERT INTO HARDCOR.Calificacion(cod_calif, calif_ant_estrellas, calif_desc, calif_estrellas)
SELECT DISTINCT m.Calificacion_Codigo, m.Calificacion_Cant_Estrellas,m.Calificacion_Descripcion,
             case m.Calificacion_Cant_Estrellas
             when 1 then 1 when 2 then 1 when 3 then 2  when 4 then 2  when 5 then 3 when 6 then 3
             when 7 then 4 when 8 then 4 when 9 then 5  when 10 then 5 end as calificacion
FROM gd_esquema.Maestra m WHERE m.Calificacion_Codigo IS NOT NULL
GO

INSERT INTO HARDCOR.Visibilidad(cod_visi, visi_desc, comision_pub, comision_vta, comision_envio)
SELECT DISTINCT m.Publicacion_Visibilidad_Cod, m.Publicacion_Visibilidad_Desc,
                m.Publicacion_Visibilidad_Precio, m.Publicacion_Visibilidad_Porcentaje,
				CASE WHEN m.Publicacion_Visibilidad_Desc = 'Gratis' THEN 0 ELSE 0.05 END
FROM gd_esquema.Maestra m
GO

INSERT INTO HARDCOR.Tipo(descripcion)
SELECT DISTINCT m.Publicacion_Tipo FROM gd_esquema.Maestra m
GO

INSERT INTO HARDCOR.Estado_publ(descripcion)
VALUES ('Activada'),
	   ('Pausada'),
	   ('Borrador'),
	   ('Finalizada');

INSERT INTO HARDCOR.Estado_publ(descripcion)
SELECT DISTINCT M.Publicacion_Estado FROM gd_esquema.Maestra M
GO

INSERT INTO HARDCOR.Publicacion (cod_pub, cod_us, cod_rubro, cod_visi, descripcion, stock, fecha_ini,
                                fecha_fin, precio, estado, cod_tipo, envio)
SELECT DISTINCT m.Publicacion_Cod, u.cod_us, r.cod_rubro, v.cod_visi, m.Publicacion_Descripcion,
                m.Publicacion_Stock, m.Publicacion_Fecha, m.Publicacion_Fecha_Venc, m.Publicacion_Precio,
                CASE WHEN t.cod_tipo = 2 THEN 4 ELSE 5 END, t.cod_tipo, 0
FROM gd_esquema.Maestra m, HARDCOR.Usuario u, HARDCOR.Rubro r, HARDCOR.Visibilidad v, HARDCOR.Tipo t
WHERE (u.username = (SELECT CAST(m.Publ_Cli_Dni AS NVARCHAR(225))) OR u.username = m.Publ_Empresa_Cuit)
      AND r.rubro_desc_corta = m.Publicacion_Rubro_Descripcion AND v.cod_visi = m.Publicacion_Visibilidad_Cod
      AND t.descripcion = m.Publicacion_Tipo

INSERT INTO HARDCOR.Factura(nro_fact, cod_pub, cod_us, fecha, total, forma_pago)
SELECT DISTINCT m.Factura_Nro, p.cod_pub, p.cod_us, m.Factura_Fecha, m.Factura_Total, m.Forma_Pago_Desc
FROM gd_esquema.Maestra m, HARDCOR.Publicacion p WHERE p.cod_pub = m.Publicacion_Cod AND m.Factura_Nro IS NOT NULL
GO

INSERT INTO HARDCOR.Tipo_fact(descripcion)
VALUES('Visibilidad'),
	  ('Compra Inmediata'),
	  ('Subasta'),
	  ('Envio');
GO

INSERT INTO HARDCOR.Detalle(nro_fact, item_desc, cantidad, importe)
SELECT f.nro_fact, (CASE WHEN m.Compra_Fecha IS NOT NULL THEN 2 WHEN m.Oferta_Fecha IS NOT NULL THEN 3 ELSE 1 END), 
m.Item_Factura_Cantidad, m.Item_Factura_Monto
FROM  gd_esquema.Maestra m, HARDCOR.Factura f WHERE m.Factura_Nro = f.nro_fact

INSERT INTO HARDCOR.Oferta(cod_pub, cod_us, monto_of, fecha_of)
SELECT DISTINCT p.cod_pub, p.cod_us, m.Oferta_Monto, m.Oferta_Fecha
FROM gd_esquema.Maestra m, HARDCOR.Publicacion p
WHERE p.cod_pub = m.Publicacion_Cod AND m.Oferta_Monto IS NOT NULL ORDER BY p.cod_pub
GO

INSERT INTO HARDCOR.Tipo_doc(documento, descripcion)
VALUES ('DNI', 'Documento Nacional de Identidad'),
	   ('LE', 'Libreta de Enrolamiento'),
	   ('LC', 'Libreta Cívica');
GO

INSERT INTO HARDCOR.Cliente(cod_us, cod_contacto, cli_nombre, cli_apellido, cli_num_doc, cli_fecha_Nac, cli_tipo_doc)
SELECT DISTINCT u.cod_us, c.cod_contacto, m.Cli_Nombre, m.Cli_Apeliido, m.Cli_Dni, m.Cli_Fecha_Nac, 1
FROM gd_esquema.Maestra m, HARDCOR.Usuario u, HARDCOR.Contacto c
WHERE u.username = (SELECT CAST(m.Cli_Dni AS NVARCHAR(225))) AND c.mail = m.Cli_Mail
GO

INSERT INTO HARDCOR.Empresa(cod_us, cod_contacto, emp_razon_soc, emp_cuit)
SELECT DISTINCT u.cod_us, c.cod_contacto, m.Publ_Empresa_Razon_Social, m.Publ_Empresa_Cuit
FROM gd_esquema.Maestra m, HARDCOR.Usuario u, HARDCOR.Contacto c
WHERE m.Publ_Empresa_Cuit = u.username AND c.mail = m.Publ_Empresa_Mail
GO

INSERT INTO HARDCOR.RolXus(cod_rol, cod_us)
SELECT 3, u.cod_us FROM HARDCOR.Usuario u WHERE u.cod_us IN (SELECT e.cod_us FROM HARDCOR.Empresa e)
UNION ALL
SELECT 4, u.cod_us FROM HARDCOR.Usuario u WHERE u.cod_us IN (SELECT c.cod_us FROM HARDCOR.Cliente c)
GO

CREATE TRIGGER HARDCOR.tr_update_calif
ON HARDCOR.Compra
AFTER UPDATE, INSERT
AS BEGIN

    DECLARE @datos_prom TABLE (cod_us INT, vtas INT, prom NUMERIC(18, 2))
    DECLARE @total INT, @i INT = 0, @cod_us INT, @prom NUMERIC(18, 2), @vtas INT

    INSERT INTO @datos_prom
    SELECT p.cod_us, COUNT(*), AVG(c.calif_estrellas) AS promedio
    FROM  HARDCOR.Publicacion p, HARDCOR.Compra cm, HARDCOR.Calificacion c
    WHERE p.cod_pub= cm.cod_pub AND cm.cod_calif = c.cod_calif
    AND p.cod_us IN (SELECT p.cod_us FROM inserted i, HARDCOR.Publicacion p WHERE p.cod_pub = i.cod_pub)
    GROUP BY p.cod_us ORDER BY p.cod_us

    SELECT @total= COUNT(*) FROM @datos_prom

    WHILE (@i < @total) 
	BEGIN
       SELECT  @cod_us = dt.cod_us, @prom= dt.prom, @vtas = dt.vtas
       FROM @datos_prom dt ORDER BY dt.cod_us offset @i ROWS
       FETCH NEXT 1 ROWS only

       IF EXISTS (SELECT * FROM HARDCOR.Empresa e WHERE e.cod_us= @cod_us)
          UPDATE HARDCOR.Empresa SET emp_calificacion = @prom, emp_ventas = @vtas WHERE cod_us= @cod_us
       ELSE
          UPDATE HARDCOR.Cliente SET cli_calificacion = @prom, cli_ventas = @vtas  WHERE cod_us= @cod_us

       SET @i = @i + 1
    END
END
GO

INSERT INTO HARDCOR.Compra(cod_pub, cod_us, cod_calif, fecha_compra, cantidad, monto_compra)
SELECT m.Publicacion_Cod, cl.cod_us, m.Calificacion_Codigo, m.Compra_Fecha, m.Compra_Cantidad,
       m.Compra_Cantidad * m.Publicacion_Precio
FROM gd_esquema.Maestra m, HARDCOR.Cliente cl
WHERE m.Compra_Cantidad IS NOT NULL AND m.Cli_Dni = cl.cli_num_doc
AND m.Publicacion_Tipo = 'Compra Inmediata' OR (m.Publicacion_Tipo = 'Subasta'
AND m.Oferta_Monto IS NOT NULL)
GO

CREATE FUNCTION HARDCOR.Emp_Categ (@emp_cuit NVARCHAR(225) )
    RETURNS INT
    BEGIN

        DECLARE @categoria NVARCHAR(225), @cod_rubro INT

        SELECT @categoria = d.Publicacion_Rubro_Descripcion
          FROM (SELECT TOP 1 m.Publicacion_Rubro_Descripcion , COUNT(*) AS cant
                FROM gd_esquema.Maestra m
                WHERE @emp_cuit = m.Publ_Empresa_Cuit
                GROUP BY m.Publ_Empresa_Cuit, m.Publicacion_Rubro_Descripcion
                ORDER BY cant DESC ) d

        SELECT @cod_rubro = r.cod_rubro FROM HARDCOR.Rubro r WHERE r.rubro_desc_corta = @categoria

        RETURN @cod_rubro
    END
GO

UPDATE HARDCOR.Empresa SET emp_rubro = HARDCOR.Emp_Categ(e.emp_cuit)
FROM HARDCOR.Empresa e WHERE emp_cuit = e.emp_cuit
GO

/* Creación de funciones y procedures para que trabajen los aplicativos clientes */

CREATE PROCEDURE HARDCOR.calificar_vta (@cod_compra INT, @username NVARCHAR(255), @estrellas INT, @detalle NVARCHAR(225)) AS BEGIN
    BEGIN TRY
        BEGIN TRAN t1
          DECLARE @cod_us INT
          SELECT @cod_us = cod_us FROM HARDCOR.Usuario WHERE username = @username

          DECLARE @cod_calif INT, @errorInCalif INT, @errorUpCompra INT
          SELECT @cod_calif= MAX(c.cod_calif) + 1 FROM HARDCOR.Calificacion c

          INSERT INTO HARDCOR.Calificacion (cod_calif,calif_desc,calif_estrellas)
          VALUES (@cod_calif, @detalle, @estrellas)
          SET @errorInCalif = @@ERROR

          UPDATE HARDCOR.Compra SET cod_calif= @cod_calif WHERE cod_compra = @cod_compra
          SET @errorUpCompra = @@error

        COMMIT TRAN t1
    END TRY

    BEGIN CATCH

       ROLLBACK TRANSACTION t1

       IF @errorInCalif <> 0
           RAISERROR ('No se pudo guardar la calificacion', 16, 1)

       IF @errorUpCompra <> 0
          RAISERROR ('No se pudo calificar la compra ', 16, 1)

    END CATCH

    RETURN 1
END
GO

CREATE PROCEDURE HARDCOR.consulta_factura (@razon_social nvarchar(50), @tipo int, @fechai date, @fechaf date,
                                           @importei numeric(18,2), @importef numeric(18,2), @descripcion nvarchar(225),
                                           @pagina INT, @cantidad_resultados_por_pagina INT)
AS
DECLARE @cod_us int
IF (@tipo = 0 AND @razon_social <> '')
	   SET @cod_us = (SELECT TOP 1 cod_us FROM HARDCOR.CLIENTE WHERE cli_num_doc = CONVERT(numeric(18), @razon_social))
ELSE IF (@tipo = 1 AND @razon_social <> '')
	   SET @cod_us = (SELECT TOP 1 cod_us FROM HARDCOR.Empresa WHERE emp_cuit = @razon_social)
ELSE IF (@razon_social = '')
    SELECT f.nro_fact AS Nro_Factura,
       d.cod_det AS Codigo_Detalle,
       f.cod_us AS Codigo_Vendedor,
       f.cod_pub AS Codigo_Publicacion,
       f.fecha,
       f.total, 
       f.forma_pago,
       d.item_desc AS detalle_factura,
       d.cantidad,
       d.importe AS importe_item
  FROM HARDCOR.Factura f
  LEFT JOIN HARDCOR.Detalle d
  ON f.nro_fact = d.nro_fact
  WHERE ((@fechai IS NULL) OR (@fechai <= f.fecha)) AND ((@fechaf IS NULL) OR (@fechaf >= f.fecha)) AND ((@importei = 0) OR (@importei <= d.importe)) AND ((@importef = 0) OR (@importef >= d.importe))
   ORDER BY f.nro_fact
  OFFSET @pagina * @cantidad_resultados_por_pagina ROWS
   FETCH NEXT @cantidad_resultados_por_pagina ROWS ONLY
ELSE
    SELECT f.nro_fact AS Nro_Factura,
	   d.cod_det AS Codigo_Detalle,
	   f.cod_us AS Codigo_Vendedor,
	   f.cod_pub AS Codigo_Publicacion,
	   f.fecha,
	   f.total, 
	   f.forma_pago,
	   d.item_desc AS detalle_factura,
	   d.cantidad,
	   d.importe AS importe_item
    FROM HARDCOR.Factura f
    LEFT JOIN HARDCOR.Detalle d
    ON f.nro_fact = d.nro_fact
    WHERE f.cod_us = @cod_us AND ((@fechai IS NULL) OR (@fechai <= f.fecha)) AND ((@fechaf IS NULL) OR (@fechaf >= f.fecha)) AND ((@importei = 0) OR (@importei <= d.importe)) AND ((@importef = 0) OR (@importef >= d.importe))
   ORDER BY f.nro_fact
  OFFSET @pagina * @cantidad_resultados_por_pagina ROWS
   FETCH NEXT @cantidad_resultados_por_pagina ROWS ONLY
GO

 CREATE PROCEDURE HARDCOR.list_vendedor_mayorCantProdSinVta (@anio int, @nro_trim int, @cod_visi int, @mes int)
AS BEGIN
    BEGIN TRY
	   BEGIN TRAN t1
		  
		  DECLARE @mes_i int, @mes_f int 
		  
		  DECLARE @datos TABLE (Anio int, Mes int, Codigo_Visibilidad int, Codigo_Vendedor int, Cantidad int)

		  set @mes_f = @nro_trim * 3
		  set @mes_i = @mes_f-2

		  if @mes is not null and @mes_i <= @mes and @mes <= @mes_f 
		  begin
			 set @mes_i = @mes
			 set @mes_f = @mes
		  end

		  if @mes is not null and not(@mes between @mes_i and @mes_f) 
		  begin
			 raiserror('El mes ingresado no pertenece al trimestre seleccionado', 20, -1)
		  end

				insert into @datos
				select top 5 year(p.fecha_ini) as anio,
				       month(p.fecha_ini) as mes,
					  p.cod_visi as visi, 
					  p.cod_us as vendedor, 
					  COUNT(p.stock) as cantidad  
				from HARDCOR.Publicacion p
				where (month(p.fecha_ini)= @mes or month(p.fecha_ini) between @mes_i and @mes_f)
				      and (@cod_visi is null or p.cod_visi = @cod_visi)
					 and year(p.fecha_ini) = @anio
					 and p.estado <> 4
				group by year(p.fecha_ini),month(p.fecha_ini), p.cod_visi, p.cod_us
				order by cantidad desc

		  select d.Anio, d.Mes, v.visi_desc, d.Codigo_Vendedor, d.Cantidad, 
			    e.emp_razon_soc, emp_cuit, emp_calificacion,
			    c.cli_apellido, c.cli_nombre, c.cli_num_doc,c.cli_calificacion
		  from @datos d 
			  left join HARDCOR.Empresa e 
			  on e.cod_us = d.Codigo_Vendedor 
			  left join HARDCOR.Cliente c 
			  on c.cod_us=d.Codigo_Vendedor
			  left join HARDCOR.Visibilidad v
			  on v.cod_visi= d.Codigo_Visibilidad
		  order by Mes asc, Codigo_Visibilidad 
  

	   COMMIT TRAN t1
	END TRY

	BEGIN CATCH

	    ROLLBACK TRANSACTION t1

	    DECLARE @ErrorMessage NVARCHAR(4000);
	    DECLARE @ErrorSeverity INT;
	    DECLARE @ErrorState INT;

	    SELECT 

         @ErrorMessage = ERROR_MESSAGE(),
         @ErrorSeverity = ERROR_SEVERITY(),
         @ErrorState = ERROR_STATE();

	    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);

	END CATCH

	RETURN 1
END
GO

CREATE PROCEDURE HARDCOR.list_cli_mayorCantProdCompr (@anio int, @nro_trim int, @cod_rubro int)
AS BEGIN
    begin try
	  
-- MUY IMPORTANTE!!!!-- >Al momento de facturar una subasta, hacer el insert en compras---> NO BORAR ESTE COMENTARIO!!!
	   
	   DECLARE @datos_cli TABLE (anio int, mes int, rubro nvarchar(225) , codigo_cliente int, cantidad_comprada int)
	   DECLARE @mes_f int, @mes_i int

	   set @mes_f = @nro_trim * 3 
	   set @mes_i = @mes_f-2


	   insert into @datos_cli
	   select top 5
	          year(c.fecha_compra) as anio,
			month(c.fecha_compra) as mes, 
			r.rubro_desc_corta as rubro, 
			c.cod_us as codigo_cliente, 
			COUNT(c.cantidad) as cantidad  
	   from HARDCOR.Compra c, HARDCOR.Publicacion p, HARDCOR.Rubro r
	   where c.cod_pub=p.cod_pub and 
		    p.cod_rubro = r.cod_rubro and 
		    r.cod_rubro = @cod_rubro and
		    year(c.fecha_compra) = @anio and
		    month(c.fecha_compra) between @mes_i and @mes_f
	   group by year(c.fecha_compra),month(c.fecha_compra), r.rubro_desc_corta, c.cod_us
	   order by cantidad desc


	   select dc.*, c.cli_apellido, c.cli_nombre, c.cli_num_doc,c.cli_calificacion
	   from @datos_cli dc 
	        left join 
		   HARDCOR.Cliente c 
		   on dc.codigo_cliente = c.cod_us
	   order by anio desc, mes asc, cantidad_comprada desc


  
    end try
    begin catch

	   DECLARE @ErrorMessage NVARCHAR(4000);
	   DECLARE @ErrorSeverity INT;
	   DECLARE @ErrorState INT;
	   
        SET @ErrorMessage = ERROR_MESSAGE()
        SET @ErrorSeverity = ERROR_SEVERITY()
        SET @ErrorState = ERROR_STATE();

	   RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState);

    end catch
   END
GO

CREATE PROCEDURE HARDCOR.list_vend_mayorCantFact (@anio int, @nro_trim int, @mes int)
AS BEGIN
    begin try

	   DECLARE @datos_vendCantFact TABLE (anio int, mes int, codigo_vendedor int, cantidad_facturas int)
	   DECLARE @mes_f int, @mes_i int

	   set @mes_f = @nro_trim * 3 
	   set @mes_i = @mes_f-2

	   if @mes is not null and @mes_i <= @mes and @mes <= @mes_f 
	   begin
		  set @mes_i = @mes
		  set @mes_f = @mes
	   end

	   if @mes is not null and not(@mes between @mes_i and @mes_f) 
	   begin
		  raiserror('El mes ingresado no pertenece al trimestre seleccionado', 20, -1)
	   end


	   insert into @datos_vendCantFact
	   select top 5
	          year(f.fecha) as anio,
			month(f.fecha) as mes,
			f.cod_us as codigo_vendedor, 
			COUNT(*) as cantidad  
	   from  HARDCOR.Factura f
	   where  year(f.fecha) = @anio and
		    (month(f.fecha)= @mes or month(f.fecha) between @mes_i and @mes_f)
	   group by year(f.fecha),month(f.fecha), f.cod_us
	   order by  cantidad desc


	   select d.Anio, d.Mes, d.codigo_vendedor, d.cantidad_facturas, 
			e.emp_razon_soc, emp_cuit, emp_calificacion,
			c.cli_apellido, c.cli_nombre, c.cli_num_doc,c.cli_calificacion
	   from @datos_vendCantFact d 
		   left join HARDCOR.Empresa e 
		   on e.cod_us = d.Codigo_Vendedor 
		   left join HARDCOR.Cliente c 
		   on c.cod_us=d.Codigo_Vendedor
	   order by anio desc, mes asc, cantidad_facturas desc

  
    end try
    begin catch

	   DECLARE @ErrorMessage NVARCHAR(4000);
	   DECLARE @ErrorSeverity INT;
	   DECLARE @ErrorState INT;
	   
        SET @ErrorMessage = ERROR_MESSAGE()
        SET @ErrorSeverity = ERROR_SEVERITY()
        SET @ErrorState = ERROR_STATE();

	   RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState);

    end catch
   END
GO

CREATE PROCEDURE HARDCOR.list_vend_mayorMontoFact (@anio int, @nro_trim int, @mes int)
AS BEGIN
    begin try

	   DECLARE @datos_vendMontoFact TABLE (anio int, mes int, codigo_vendedor int, monto_facturado int)
	   DECLARE @mes_f int, @mes_i int

	   set @mes_f = @nro_trim * 3
	   set @mes_i = @mes_f-2

	   if @mes is not null and @mes_i <= @mes and @mes <= @mes_f 
	   begin
		  set @mes_i = @mes
		  set @mes_f = @mes
	   end

	   if @mes is not null and not(@mes between @mes_i and @mes_f) 
	   begin
		  raiserror('El mes ingresado no pertenece al trimestre seleccionado', 20, -1)
	   end


	   insert into @datos_vendMontoFact
	   select top 5
	          year(f.fecha) as anio,
			month(f.fecha) as mes,
			f.cod_us as codigo_vendedor, 
			SUM(f.total) as monto  
	   from  HARDCOR.Factura f
	   where  year(f.fecha) = @anio and
		    (month(f.fecha)= @mes or month(f.fecha) between @mes_i and @mes_f)
	   group by year(f.fecha),month(f.fecha), f.cod_us
	   order by  monto desc

	   

	   select d.Anio, d.Mes, d.codigo_vendedor, d.monto_facturado, 
			e.emp_razon_soc, emp_cuit, emp_calificacion,
			c.cli_apellido, c.cli_nombre, c.cli_num_doc,c.cli_calificacion
	   from @datos_vendMontoFact d 
		   left join HARDCOR.Empresa e 
		   on e.cod_us = d.Codigo_Vendedor 
		   left join HARDCOR.Cliente c 
		   on c.cod_us=d.Codigo_Vendedor
        order by anio desc, mes asc, monto_facturado desc
  
    end try
    begin catch

	   DECLARE @ErrorMessage NVARCHAR(4000);
	   DECLARE @ErrorSeverity INT;
	   DECLARE @ErrorState INT;
	   
        SET @ErrorMessage = ERROR_MESSAGE()
        SET @ErrorSeverity = ERROR_SEVERITY()
        SET @ErrorState = ERROR_STATE();

	   RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState);

    end catch
   END
GO

CREATE PROCEDURE HARDCOR.listados (@anio int, @nro_trim int, @tipoListado int, @cod_visi int, @mes int, @cod_rubro int)
AS BEGIN

if @tipoListado = 0
    exec HARDCOR.list_vendedor_mayorCantProdSinVta @anio, @nro_trim, @cod_visi, @mes 
if @tipoListado = 1
    exec HARDCOR.list_cli_mayorCantProdCompr @anio, @nro_trim, @cod_rubro 
if @tipoListado = 2
    exec HARDCOR.list_vend_mayorCantFact @anio, @nro_trim, @mes 
if @tipoListado = 3
    exec HARDCOR.list_vend_mayorMontoFact @anio, @nro_trim, @mes 

END
GO

CREATE PROCEDURE HARDCOR.facturar_venta(@codigo_publicacion INT, @fecha DATETIME, @cantidad INT) AS BEGIN
/* Factura una venta, teniendo en cuenta si tiene o no envio
   Devuelve el numero de factura o -1 si ocurre un error */
  BEGIN TRY
    BEGIN TRANSACTION
		DECLARE @ret INT
		DECLARE @nuevo_numero_factura NUMERIC(18, 0)
		DECLARE @comision_venta NUMERIC(18, 2)
		DECLARE @comision_envio NUMERIC(18, 2)
		
		SET @comision_envio = 0  -- Por defecto, no se le cobra el envio
		SET @ret = -1  -- Cuando se haga realmente todo, seteo esta variable al numero de factura
		
		SELECT @nuevo_numero_factura = MAX(F.nro_fact) + 1 FROM HARDCOR.Factura F
			
		/* Calculo la comision de venta */
		SELECT @comision_venta = V.comision_vta * P.precio * @cantidad
		FROM HARDCOR.Publicacion P, HARDCOR.Visibilidad V
		WHERE P.cod_pub = @codigo_publicacion AND P.cod_visi = V.cod_visi
	
		/* Calculo la comision por envio, si la publicaion la tuviera */ 
		SELECT @comision_envio = V.comision_envio * P.precio * @cantidad
		FROM HARDCOR.Publicacion P, HARDCOR.Visibilidad V
		WHERE P.cod_pub = @codigo_publicacion AND P.envio = 1

		/* Creo una nueva factura asociada */
		INSERT HARDCOR.Factura(nro_fact, cod_pub, fecha, forma_pago, total, cod_us)
		VALUES(@nuevo_numero_factura, @codigo_publicacion, @fecha,
		'Efectivo', @comision_envio + @comision_venta, 
		(SELECT P.cod_us FROM HARDCOR.Publicacion P WHERE P.cod_pub = @codigo_publicacion))

		/* Inserto los detalles de la factura */
		INSERT HARDCOR.Detalle(nro_fact, item_desc, cantidad, importe)
		VALUES(@nuevo_numero_factura, 
		(SELECT CASE WHEN P.cod_tipo = 1 THEN 2 ELSE 3 END FROM HARDCOR.Publicacion P WHERE P.cod_pub = @codigo_publicacion), 
		@cantidad, 
		@comision_venta)

		IF 2 = (SELECT P.cod_tipo FROM HARDCOR.Publicacion P WHERE P.cod_pub = @codigo_publicacion)  
		BEGIN
			DECLARE @cod_us INT
			DECLARE @monto INT

			SELECT @cod_us = O.cod_us, @monto = O.monto_of FROM HARDCOR.Oferta O WHERE O.cod_pub = @codigo_publicacion AND 
			O.monto_of = (SELECT MAX(O.monto_of) FROM HARDCOR.Oferta O WHERE O.cod_pub = @codigo_publicacion)
			
			INSERT INTO HARDCOR.Compra(cod_pub, cod_us, fecha_compra, cantidad, monto_compra)
			VALUES (@codigo_publicacion, @cod_us, @fecha, @cantidad, @monto)
		END

		IF @comision_envio > 0
			INSERT HARDCOR.Detalle(nro_fact, item_desc, cantidad, importe)
			VALUES(@nuevo_numero_factura, 4, @cantidad, @comision_envio)

    COMMIT TRANSACTION
    SET @ret = @nuevo_numero_factura
  END TRY

  BEGIN CATCH
    ROLLBACK TRANSACTION
  END CATCH

  SELECT @ret
END
GO

CREATE PROCEDURE HARDCOR.finalizar_subastas(@fecha DATETIME) AS BEGIN
/* Finaliza las subastas que tienen como fecha de final una anterior a la
   fecha pasada como parametro */
  DECLARE @codigo INT
  DECLARE subastas_finalizadas CURSOR FOR (SELECT P.cod_pub FROM HARDCOR.Publicacion P
                                           WHERE CONVERT(DATE, P.fecha_fin) < CONVERT(DATE, @fecha)
                                           AND P.cod_tipo = 2 AND P.estado <> 4)
  OPEN subastas_finalizadas
  FETCH NEXT FROM subastas_finalizadas INTO @codigo

  /* Facturo la venta de cada subasta que paso a finalizada */
  WHILE @@FETCH_STATUS = 0 BEGIN
    BEGIN TRY
      /* Para que el cambio de estado y la facturacion se hagan de manera atomica */
      BEGIN TRANSACTION
        /* Facturacion */
        EXEC HARDCOR.facturar_venta @codigo, @fecha, 1

        /* Cambio de estado */
        UPDATE HARDCOR.Publicacion SET estado = 4 WHERE cod_pub=@codigo

        FETCH NEXT FROM subastas_finalizadas INTO @codigo
      COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
    END CATCH
  END

  CLOSE subastas_finalizadas
  DEALLOCATE subastas_finalizadas
END
GO

CREATE PROCEDURE HARDCOR.facturar_publicacion(@codigo_publicacion INT, @fecha DATETIME) AS BEGIN
/* Factura la comision por publicar de una publicacion. Devuelve el numero de factura o -1 */
  BEGIN TRY
    BEGIN TRANSACTION
    DECLARE @ret INT
    DECLARE @codigo_usuario INT
    DECLARE @nuevo_numero_factura NUMERIC(18, 0) = (SELECT MAX(F.nro_fact) + 1 FROM HARDCOR.Factura F)
    DECLARE @comision NUMERIC(18, 2)
    SET @ret = -1

    /* Busco el codigo de usuario */
    SELECT @codigo_usuario = cod_us FROM HARDCOR.Publicacion
    WHERE cod_pub = @codigo_publicacion

    /* Calculo la comision de publicacion */
    SELECT @comision = V.comision_pub
    FROM HARDCOR.Publicacion P, HARDCOR.Visibilidad V 
	WHERE P.cod_pub = @codigo_publicacion AND P.cod_visi = V.cod_visi

    /* Creo una nueva factura asociada */
    INSERT HARDCOR.Factura(nro_fact, cod_pub, fecha, forma_pago, total, cod_us)
    VALUES(@nuevo_numero_factura, @codigo_publicacion, @fecha,
           'Efectivo', @comision, (SELECT P.cod_us
                                   FROM HARDCOR.Publicacion P
                                   WHERE P.cod_pub = @codigo_publicacion))

    /* Inserto los detalles de la factura */
    INSERT HARDCOR.Detalle(nro_fact, item_desc, cantidad, importe)
    VALUES(@nuevo_numero_factura, 1, 1, @comision)

    COMMIT TRANSACTION
    SET @ret = @nuevo_numero_factura
  END TRY

  BEGIN CATCH
    ROLLBACK TRANSACTION
  END CATCH

  SELECT @ret
END
GO

CREATE PROCEDURE HARDCOR.alta_vis(@descripcion NVARCHAR(225), @comision_pub NUMERIC(18, 2),
                                  @comision_vta NUMERIC(18, 2), @comision_envio NUMERIC(18, 2))
AS BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            DECLARE @cod_visi NUMERIC(18, 0)

            IF NOT EXISTS (SELECT * FROM HARDCOR.Visibilidad v WHERE v.visi_desc = @descripcion)
            BEGIN
                SELECT @cod_visi = MAX(v.cod_visi) + 1 FROM HARDCOR.Visibilidad v

                INSERT INTO HARDCOR.Visibilidad(cod_visi, visi_desc, comision_pub, comision_vta, comision_envio)
                VALUES (@cod_visi, @descripcion, @comision_pub, @comision_vta, @comision_envio)
            END
            ELSE
                RAISERROR('', 16, 1)
        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION

        IF EXISTS (SELECT * FROM HARDCOR.Visibilidad v WHERE v.visi_desc = @descripcion)
        BEGIN
            PRINT 'La visibilidad ya existe.'
            RETURN -1
        END
    END CATCH

    RETURN 1
END
GO

CREATE PROCEDURE HARDCOR.mod_vis(@cod_visi NUMERIC(18, 0), @descripcion NVARCHAR(225), @comision_pub NUMERIC(18, 2),
                                 @comision_vta NUMERIC(18, 2), @comision_envio NUMERIC(18, 2))
AS BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            IF EXISTS (SELECT * FROM HARDCOR.Visibilidad v WHERE v.cod_visi = @cod_visi)
            BEGIN
                IF NOT EXISTS (SELECT * FROM HARDCOR.Visibilidad v WHERE v.visi_desc = @descripcion)
                BEGIN
                    UPDATE HARDCOR.Visibilidad SET visi_desc = @descripcion, comision_pub = @comision_pub,
                    comision_vta = @comision_vta, comision_envio = @comision_envio WHERE cod_visi = @cod_visi
                END
                ELSE
                    RAISERROR('', 16, 1)
            END
            ELSE
                RAISERROR('', 16, 1)
        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION

        IF NOT EXISTS (SELECT * FROM HARDCOR.Visibilidad v WHERE v.cod_visi = @cod_visi)
        BEGIN
            PRINT 'La visibilidad a modificar no existe.'
            RETURN -1
        END

        IF EXISTS (SELECT * FROM HARDCOR.Visibilidad v WHERE v.visi_desc = @descripcion)
        BEGIN
            PRINT 'Hay otra visibilidad con la misma descripcion.'
            RETURN -2
        END
    END CATCH

    RETURN 1
END
GO

CREATE PROCEDURE HARDCOR.baja_vis(@cod_visi NUMERIC(18, 0))
AS BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            IF EXISTS (SELECT * FROM HARDCOR.Visibilidad v WHERE v.cod_visi = @cod_visi)
            BEGIN
                DELETE FROM HARDCOR.Publicacion WHERE cod_visi = @cod_visi
            END
            ELSE
                RAISERROR('', 16, 1)
        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION

        IF NOT EXISTS (SELECT * FROM HARDCOR.Visibilidad v WHERE v.cod_visi = @cod_visi)
        BEGIN
            PRINT 'La visibilidad no existe.'
            RETURN -1
        END
    END CATCH

    RETURN 1
END
GO 

CREATE PROCEDURE HARDCOR.generar_publicacion(@descripcion NVARCHAR(225), @stock NUMERIC(18, 0),
                                             @precio NUMERIC(18, 2), @rubro NVARCHAR(225),
                                             @usuario NVARCHAR(225), @visi NVARCHAR(225), @estado NVARCHAR(225),
                                             @tipo NVARCHAR(225), @fecha_venc DATETIME, @envio BIT, @fecha DATETIME)
AS BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            DECLARE @cod_pub INT
            DECLARE @cod_us INT
            DECLARE @cod_visi INT
            DECLARE @h BIT

            SELECT @cod_us = u.cod_us, @h = u.habilitado FROM HARDCOR.Usuario u WHERE u.username = @usuario

            IF @h = 1
            BEGIN
                SELECT @cod_pub = MAX(p.cod_pub) + 1 FROM HARDCOR.Publicacion p

                IF NOT EXISTS (SELECT p.cod_us FROM HARDCOR.Publicacion p WHERE p.cod_us = @cod_us) AND @cod_us > 95
                BEGIN
                    SELECT @cod_visi = v.cod_visi FROM HARDCOR.Visibilidad v WHERE v.visi_desc = 'Gratis'
                END
                ELSE
                    SELECT @cod_visi = v.cod_visi FROM HARDCOR.Visibilidad v WHERE v.visi_desc = @visi

                INSERT INTO HARDCOR.Publicacion (cod_pub, cod_us, cod_rubro, cod_visi, descripcion, stock,
                                                fecha_ini, fecha_fin, precio, estado, cod_tipo, envio)
                SELECT @cod_pub, @cod_us, r.cod_rubro, @cod_visi, @descripcion, @stock, @fecha,
                CASE WHEN @tipo = 'Subasta' THEN @fecha_venc WHEN @tipo = 'Compra Inmediata' THEN NULL END,
                @precio, e.cod_estado, t.cod_tipo, @envio
                FROM HARDCOR.Rubro r, HARDCOR.Tipo t, HARDCOR.Estado_publ e 
				WHERE r.rubro_desc_corta = @rubro AND t.descripcion = @tipo AND e.descripcion = @estado
            END
            ELSE
                RAISERROR('', 16, 1)
        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION

        IF @h <> 1
        BEGIN
            PRINT 'El usuario esta inhabilitado.'
            SELECT -1
        END
    END CATCH

    SELECT @cod_pub
END
GO

CREATE PROCEDURE HARDCOR.cambiar_estado_publ(@usuario NVARCHAR(225), @cod_pub NUMERIC(18, 0), @nuevo_estado NVARCHAR(225), @fecha DATETIME)
AS BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            DECLARE @estado NVARCHAR(225)
            DECLARE @tipo NVARCHAR(225)
            DECLARE @cod_us NVARCHAR(225)
            DECLARE @h BIT

			DECLARE @cod_estado INT = (SELECT E.cod_estado FROM HARDCOR.Estado_publ E WHERE @nuevo_estado = E.descripcion)

            SELECT @estado = p.estado, @tipo = t.descripcion, @cod_us = u.username, @h = u.habilitado
            FROM HARDCOR.Publicacion p, HARDCOR.Usuario u, HARDCOR.Tipo t
            WHERE p.cod_pub = @cod_pub AND p.cod_us = u.cod_us AND p.cod_tipo = t.cod_tipo

            IF @usuario = @cod_us AND @h = 1
            BEGIN
                IF (@nuevo_estado <> 'Finalizado' AND @tipo = 'Subasta') OR @tipo = 'Compra Inmediata'
                BEGIN
                    IF @estado <> 4
                    BEGIN
                        IF @estado <> @cod_estado
                        BEGIN
                            UPDATE HARDCOR.Publicacion SET estado = @cod_estado WHERE cod_pub = @cod_pub
                            IF @nuevo_estado = 'Activo'
                              EXEC HARDCOR.facturar_publicacion @cod_pub, @fecha 
                        END
                        ELSE
                            RAISERROR('', 16, 1)
                    END
                    ELSE
                        RAISERROR('', 16, 1)
                END
                ELSE
                    RAISERROR('', 16, 1)
            END
            ELSE
                RAISERROR('', 16, 1)

        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION

        IF @usuario <> @cod_us OR @h <> 1
        BEGIN
            PRINT 'La publicacion que se quiere modificar no le corresponde al usuario ingresado o esta inhabilitado.'
            RETURN -1
        END

        IF @nuevo_estado = 'Finalizado' AND @tipo = 'Subasta'
        BEGIN
            PRINT 'Las subastas no pueden cambiarse a finalizadas, el sistema lo hace automaticamente.'
            RETURN -2
        END

        IF @estado = @cod_estado
        BEGIN
            PRINT 'La publicacion ya tiene el estado por el que se desea cambiar.'
            RETURN -3
        END

        IF @estado = 4
        BEGIN
            PRINT 'No se puede cambiar el estado de una publicacion finalizada.'
            RETURN -4
        END

    END CATCH

    RETURN 1
END
GO

CREATE PROCEDURE HARDCOR.modif_publ_borrador(@cod_pub NUMERIC(18, 0), @descripcion NVARCHAR(225),
                                             @stock NUMERIC(18, 0), @precio NUMERIC(18, 2),
                                             @costo NUMERIC(18, 2), @rubro NVARCHAR(225),
                                             @usuario NVARCHAR(225), @visi NVARCHAR(225),
                                             @tipo NVARCHAR(225), @fecha_venc DATETIME)
AS BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            DECLARE @r INT
            DECLARE @v INT
            DECLARE @t INT
            DECLARE @estado NVARCHAR(225)
            DECLARE @cod_us NVARCHAR(225)
            DECLARE @h BIT

            SELECT @cod_us = u.username, @estado = p.estado, @h = u.habilitado
            FROM HARDCOR.Publicacion p, HARDCOR.Usuario u
            WHERE p.cod_pub = @cod_pub AND p.cod_us = u.cod_us
			
            IF @usuario = @cod_us AND @h = 1
            BEGIN
                IF @estado = 3
                BEGIN
					SELECT @v = v.cod_visi FROM HARDCOR.Visibilidad v WHERE v.visi_desc = @visi
                    SELECT @r = r.cod_rubro FROM HARDCOR.Rubro r WHERE r.rubro_desc_corta = @rubro
                    SELECT @t = t.cod_tipo FROM HARDCOR.Tipo t WHERE t.descripcion = @tipo

                    UPDATE HARDCOR.Publicacion SET descripcion = @descripcion, stock = @stock,
                    precio = @precio, costo = @costo, cod_rubro = @r, cod_visi = @v, cod_tipo = @t,
                    fecha_fin = @fecha_venc WHERE cod_pub = @cod_pub
                END
                ELSE
                    RAISERROR('', 16, 1)
            END
            ELSE
                RAISERROR('', 16, 1)
        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION

        IF @usuario <> @cod_us OR @h <> 1
        BEGIN
            PRINT 'La publicacion que se quiere modificar no le corresponde al usuario ingresado o esta inhabilitado.'
            RETURN -1
        END

        IF @estado <> 3
        BEGIN
            PRINT 'Solo se pueden modificar los datos de las publicaciones en estado pausado.'
            RETURN -2
        END

    END CATCH

    RETURN 1
END
GO

CREATE PROCEDURE HARDCOR.comprar_ofertar(@cod_pub NUMERIC(18, 0), @usuario NVARCHAR(225),
                                         @cantidad NUMERIC(18, 0), @mont_of NUMERIC(18, 2), @fecha DATETIME)
AS BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            DECLARE @usuario2 NVARCHAR(225)
            DECLARE @cod_us INT
            DECLARE @monto_actual NUMERIC(18, 2)
            DECLARE @tipo NVARCHAR(225)
            DECLARE @h BIT
            DECLARE @ret INT

            IF EXISTS (SELECT p.cod_pub FROM HARDCOR.Publicacion p WHERE p.cod_pub = @cod_pub AND p.estado <> 4)
            BEGIN
                IF @cantidad > 0 AND @cantidad <= (SELECT p.stock FROM HARDCOR.Publicacion p WHERE p.cod_pub = @cod_pub)
                BEGIN
                    SELECT @usuario2 = u.username, @h = u.habilitado FROM HARDCOR.Publicacion p, HARDCOR.Usuario u
                    WHERE p.cod_pub = @cod_pub AND p.cod_us = u.cod_us

                    IF @usuario <> @usuario2 AND @h = 1
                    BEGIN
                        SELECT @cod_us = u.cod_us FROM HARDCOR.Usuario u WHERE u.username = @usuario
                        SELECT @tipo = t.descripcion FROM HARDCOR.Publicacion p, HARDCOR.Tipo t
                        WHERE p.cod_pub = @cod_pub AND p.cod_tipo = t.cod_tipo

                        IF 'Compra Inmediata' = @tipo
                        BEGIN

                            INSERT INTO HARDCOR.Compra(cod_pub, cod_us, fecha_compra, cantidad, monto_compra)
                            VALUES (@cod_pub, @cod_us, @fecha, @cantidad, @mont_of)

                            UPDATE HARDCOR.Publicacion SET stock = stock - @cantidad WHERE cod_pub = @cod_pub
                            EXEC @ret = HARDCOR.facturar_venta @cod_pub, @fecha, @cantidad
                        END
                        ELSE BEGIN
                            SELECT @monto_actual = (CASE WHEN MAX(o.monto_of) IS NOT NULL THEN MAX(o.monto_of)
                                                         WHEN MAX(o.monto_of) IS NULL THEN 0 END)
                            FROM HARDCOR.Oferta o WHERE o.cod_pub = @cod_pub

                            IF @monto_actual < FLOOR(@mont_of)
                            BEGIN
                                INSERT INTO HARDCOR.Oferta(cod_pub, cod_us, fecha_of, monto_of)
                                VALUES (@cod_pub, @cod_us, @fecha, @mont_of)

                                SET @ret = 0
                            END ELSE RAISERROR('', 16, 1)
                        END
                    END
                    ELSE RAISERROR('', 16, 1)

                END
                ELSE RAISERROR('', 16, 1)

            END
            ELSE RAISERROR('', 16, 1)

        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION

        IF NOT EXISTS (SELECT p.cod_pub FROM HARDCOR.Publicacion p WHERE p.cod_pub = @cod_pub AND p.estado <> 4)
        BEGIN
            PRINT 'La publicacion no existe o ha finalizado .'
            RETURN -1
        END

        IF @cantidad <= 0 OR @cantidad > (SELECT p.stock FROM HARDCOR.Publicacion p WHERE p.cod_pub = @cod_pub)
        BEGIN
            PRINT 'La cantidad ingresada es invalida o el stock es insuficiente.'
            RETURN -2
        END

        IF @usuario = @usuario2 OR @h <> 1
        BEGIN
            PRINT 'Un vendedor no puede auto-comprarse o auto-ofrecerse. O esta inhabilitado el usuario.'
            SELECT -3
        END

        IF @monto_actual >= @mont_of
        BEGIN
            PRINT 'El monto ofrecido es insuficiente.'
            RETURN -4
        END
    END CATCH

    SELECT @ret
END
GO

CREATE TRIGGER HARDCOR.tr_finalizar_pub_compra_au
ON HARDCOR.Publicacion
AFTER UPDATE
AS BEGIN
    IF UPDATE (stock)
    BEGIN
        UPDATE HARDCOR.Publicacion SET estado = 4 WHERE stock = 0
    END
END
GO

CREATE PROCEDURE HARDCOR.login (@userName NVARCHAR(255), @password VARCHAR(255)) AS BEGIN
  /* Devuelve una fila por cada rol que el usuario posea con:
    - Si el login fue exitoso o no (BIT)
    - Código de rol (INT)
    - Nombre de rol (NVARCHAR)
    - Cantidad de intentos fallidos (INT)
    - Si el usuario está habilitado o no (BIT)
  */
  DECLARE @ret BIT
  DECLARE @cantidad_intentos_fallidos INT

  SELECT @ret=COUNT(*), @cantidad_intentos_fallidos=MAX(intentos)
    FROM HARDCOR.Usuario
   WHERE username = @userName
     AND pass_word = HASHBYTES('SHA2_256', @password)
     AND habilitado = 1

  IF @ret = 0 BEGIN
    --Agrego un login fallido
    UPDATE HARDCOR.Usuario
       SET intentos = intentos + 1
     WHERE username = @userName
    --Deshabilito al usuario si ya tiene 3 logins fallidos
    UPDATE HARDCOR.Usuario
       SET habilitado = 0
     WHERE username = @userName
       AND intentos = 3
  END
  ELSE
    UPDATE HARDCOR.Usuario
       SET intentos = 0
     WHERE username = @userName

  --Devuelvo los roles asignados al usuario intentando loguearse
  -- o nada, si el login no fue exitoso
  SELECT @ret AS login_valido,
         RxU.cod_rol, R.nombre,
         U.habilitado, U.intentos
    FROM HARDCOR.RolXus RxU, HARDCOR.ROl R, HARDCOR.Usuario U
   WHERE RxU.cod_rol = R.cod_rol
     AND U.username = @userName
     AND U.cod_us = RxU.cod_us
END
GO

CREATE PROCEDURE HARDCOR.listar_empresas (@razon_social NVARCHAR(255), @cuit NVARCHAR(50), @mail NVARCHAR(50)) AS BEGIN
  SELECT *
    FROM HARDCOR.Empresa E, HARDCOR.Contacto C
   WHERE E.cod_contacto = C.cod_contacto
     AND ((E.emp_cuit = @cuit) OR (@cuit LIKE ''))
     AND ((E.emp_razon_soc = @razon_social) OR (@razon_social LIKE ''))
     AND ((C.mail = @mail) OR (@mail LIKE ''))
END
GO

CREATE PROCEDURE HARDCOR.listar_clientes (@nombre NVARCHAR(255), @apellido NVARCHAR(255),
                                          @dni NUMERIC(18, 0), @email NVARCHAR(50), @tipo_doc INT) AS BEGIN
  SELECT *
    FROM HARDCOR.Cliente Cl, HARDCOR.Contacto Co
   WHERE Cl.cod_contacto = Co.cod_contacto
     AND ((@nombre LIKE '') OR (Cl.cli_nombre LIKE '%' + @nombre + '%'))
     AND ((@apellido LIKE '') OR (Cl.cli_apellido LIKE '%' +  @apellido + '%'))
     AND ((@email LIKE '') OR (Co.mail LIKE '%' +  @email + '%'))
     AND ((@dni = 0) OR (Cl.cli_num_doc = @dni)) AND (Cl.cli_tipo_doc = @tipo_doc)
END
GO

CREATE PROCEDURE HARDCOR.obtener_roles AS BEGIN
  SELECT *
    FROM HARDCOR.Rol
   WHERE habilitado = 1
END
GO

CREATE PROCEDURE HARDCOR.obtener_cliente (@codigo  INT) AS BEGIN
  SELECT Cl.*, Co.*, U.habilitado
    FROM HARDCOR.Cliente Cl, HARDCOR.Contacto Co, HARDCOR.Usuario U
   WHERE  Cl.cod_contacto = Co.cod_contacto
     AND  Cl.cod_us = @codigo
     AND  U.cod_us = @codigo
END
GO

CREATE PROCEDURE HARDCOR.obtener_empresa (@codigo  INT) AS BEGIN
  SELECT E.*, C.*, U.habilitado
    FROM HARDCOR.Empresa E, HARDCOR.Contacto C, HARDCOR.Usuario U
   WHERE  E.cod_contacto = C.cod_contacto
     AND  E.cod_us = @codigo
     AND  U.cod_us = @codigo
END
GO

CREATE PROCEDURE HARDCOR.crear_usuario (@username NVARCHAR(255), @password VARCHAR(255), @codigo_rol TINYINT, @habilitado BIT, @fecha_creacion DATETIME) 
AS BEGIN
  /* Intenta crear un usuario con los datos especificados
     Para eso debe crear una entrada en la tabla Usuario y una en la table RolXus
     Si alguna de las dos inserciones falla, todo se vuelve para atras
     Devuelve el codigo del nuevo usuario o -1 en caso de error */
  BEGIN TRY
	BEGIN TRANSACTION
			
		INSERT INTO HARDCOR.Usuario (username, pass_word, habilitado, intentos, fecha_creacion)
		VALUES (@username, HASHBYTES('SHA2_256', @password), @habilitado, 0, @fecha_creacion)

		DECLARE @nuevo_codigo_usuario INT = (SELECT cod_us FROM HARDCOR.Usuario WHERE username = @username)

		INSERT INTO HARDCOR.RolXus (cod_rol, cod_us)
		VALUES (@codigo_rol, @nuevo_codigo_usuario)

	COMMIT TRANSACTION
    RETURN @nuevo_codigo_usuario
  END TRY
  
  BEGIN CATCH
    ROLLBACK TRANSACTION
    -- No hago nada si hubo un error (el username está duplicado)
    RETURN -1
  END CATCH

END
GO

CREATE PROCEDURE HARDCOR.crear_contacto (@telefono NVARCHAR(255),
                                         @mail NVARCHAR(50),
                                         @direccion_calle NVARCHAR(100),
                                         @direccion_numero NUMERIC(18, 0),
                                         @direccion_piso NUMERIC(18, 0),
                                         @numero_departamento NVARCHAR(50),
                                         @localidad NVARCHAR(255),
                                         @codigo_postal NVARCHAR(50)) AS BEGIN

  /* Crea un nuevo contacto y devuelve su codigo */
   
	INSERT INTO HARDCOR.Contacto (mail, nro_tel, dom_calle, nro_calle, nro_piso, nro_dpto, localidad, cod_postal)
	VALUES (@mail, @telefono, @direccion_calle, @direccion_numero, @direccion_piso, @numero_departamento, @localidad, @codigo_postal)
	RETURN SCOPE_IDENTITY()

END
GO

CREATE PROCEDURE HARDCOR.crear_cliente (@username NVARCHAR(255),
                                        @password VARCHAR(255),
										@fecha_creacion DATETIME,
                                        @codigo_rol TINYINT,
                                        @nombre NVARCHAR(255),
                                        @apellido NVARCHAR(255),
                                        @dni NUMERIC(18, 0),
                                        @telefono NVARCHAR(255),
                                        @mail NVARCHAR(50),
                                        @fecha_nacimiento DATETIME,
                                        @direccion_calle NVARCHAR(100),
                                        @direccion_numero NUMERIC(18, 0),
                                        @direccion_piso NUMERIC(18, 0),
                                        @numero_departamento NVARCHAR(50),
                                        @localidad NVARCHAR(255),
                                        @codigo_postal NVARCHAR(50),
                                        @habilitado BIT,
										@tipo_doc NVARCHAR(225)) AS BEGIN

  /* Crea un nuevo usuario, un nuevo cliente y un nuevo contacto y los llena con los datos recibidos */
  BEGIN TRY
    BEGIN TRANSACTION
    DECLARE @codigo_usuario INT
    EXEC @codigo_usuario = HARDCOR.crear_usuario @username, @password, @codigo_rol, @habilitado, @fecha_creacion

    IF @codigo_usuario = -1
      RAISERROR('El usuario ya existe', 16, 1)  -- Que salte directamente al CATCH

    DECLARE @codigo_contacto INT
    EXEC @codigo_contacto = HARDCOR.crear_contacto @telefono, @mail, @direccion_calle, @direccion_numero, @direccion_piso,
                                                             @numero_departamento, @localidad, @codigo_postal

	DECLARE @cod_tipo_doc INT = (SELECT t.cod_doc FROM HARDCOR.Tipo_doc t WHERE t.documento = @tipo_doc)
    INSERT INTO HARDCOR.Cliente (cod_us, cod_contacto, cli_nombre, cli_apellido, cli_num_doc, cli_fecha_Nac, cli_tipo_doc)
    VALUES (@codigo_usuario, @codigo_contacto, @nombre, @apellido, @dni, @fecha_nacimiento, @cod_tipo_doc)

    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION
  END CATCH
END
GO

CREATE PROCEDURE HARDCOR.crear_empresa (@username NVARCHAR(255),
                                        @password VARCHAR(255),
                                        @fecha_creacion DATETIME,
										@codigo_rol TINYINT,
                                        @razon_social NVARCHAR(255),
                                        @cuit NVARCHAR(50),
                                        @ciudad NVARCHAR(255),
                                        @telefono NVARCHAR(255),
                                        @mail NVARCHAR(50),
                                        @direccion_calle NVARCHAR(100),
                                        @direccion_numero NUMERIC(18, 0),
                                        @direccion_piso NUMERIC(18, 0),
                                        @numero_departamento NVARCHAR(50),
                                        @localidad NVARCHAR(255),
                                        @codigo_postal NVARCHAR(50),
                                        @habilitado BIT) AS BEGIN

  /* Crea un nuevo usuario, una nueva empresa y un nuevo contacto y los llena con los datos recibidos */
  BEGIN TRY
    BEGIN TRANSACTION
      DECLARE @codigo_usuario INT
      EXEC @codigo_usuario = HARDCOR.crear_usuario @username, @password, @codigo_rol, @habilitado, @fecha_creacion

      IF @codigo_usuario = -1
        RAISERROR('El usuario ya existe', 16, 1)  -- Que salte directamente al CATCH

      DECLARE @codigo_contacto INT
      EXEC @codigo_contacto = HARDCOR.crear_contacto @telefono, @mail, @direccion_calle, @direccion_numero, @direccion_piso,
                                                     @numero_departamento, @localidad, @codigo_postal

      INSERT INTO HARDCOR.Empresa (cod_us, cod_contacto, emp_razon_soc, emp_cuit, emp_ciudad)
      VALUES (@codigo_usuario, @codigo_contacto, @razon_social, @cuit, @ciudad)

      COMMIT TRANSACTION
  END TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION
  END CATCH
END
GO

CREATE PROCEDURE HARDCOR.modificar_cliente (@codigo INT,
                                            @nombre NVARCHAR(255),
                                            @apellido NVARCHAR(255),
                                            @num_doc NUMERIC(18, 0),
											@tipo_doc NVARCHAR(225),
                                            @telefono NVARCHAR(255),
                                            @mail NVARCHAR(50),
                                            @fecha_nacimiento DATETIME,
                                            @direccion_calle NVARCHAR(100),
                                            @direccion_numero NUMERIC(18, 0),
                                            @direccion_piso NUMERIC(18, 0),
                                            @numero_departamento NVARCHAR(50),
                                            @ciudad NVARCHAR(255),
                                            @codigo_postal NVARCHAR(50),
                                            @habilitado BIT) AS BEGIN
  BEGIN TRY
    BEGIN TRANSACTION

	DECLARE @tipo_doc2 INT = (SELECT t.cod_doc FROM HARDCOR.Tipo_doc t WHERE t.documento = @tipo_doc)

    UPDATE HARDCOR.Cliente
    SET cli_fecha_Nac = @fecha_nacimiento,
    cli_apellido = @apellido,
    cli_nombre = @nombre,
    cli_num_doc = @num_doc,
	cli_tipo_doc = @tipo_doc2
    WHERE cod_us = @codigo

    UPDATE HARDCOR.Usuario
       SET habilitado = @habilitado
     WHERE cod_us = @codigo

    UPDATE HARDCOR.Contacto
       SET cod_postal = @codigo_postal,
              dom_calle = @direccion_calle,
            nro_calle = @direccion_numero,
              localidad = @ciudad,
             nro_piso = @direccion_piso,
             nro_dpto = @numero_departamento,
              nro_tel = @telefono,
                 mail = @mail
     WHERE cod_contacto = (SELECT cod_contacto
                             FROM HARDCOR.Cliente
                            WHERE cod_us = @codigo)
    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION
  END CATCH
END
GO

CREATE PROCEDURE HARDCOR.modificar_empresa (@codigo INT,
                                            @razon_social NVARCHAR(255),
                                            @cuit NVARCHAR(50),
                                            @ciudad NVARCHAR(255),
                                            @telefono NVARCHAR(255),
                                            @mail NVARCHAR(50),
                                            @direccion_calle NVARCHAR(100),
                                            @direccion_numero NUMERIC(18, 0),
                                            @direccion_piso NUMERIC(18, 0),
                                            @numero_departamento NVARCHAR(50),
                                            @localidad NVARCHAR(255),
                                            @codigo_postal NVARCHAR(50),
                                            @habilitado BIT) AS BEGIN
  BEGIN TRY
    BEGIN TRANSACTION
    UPDATE HARDCOR.Empresa
       SET emp_razon_soc = @razon_social,
                emp_cuit = @cuit,
              emp_ciudad = @ciudad
     WHERE cod_us = @codigo

    UPDATE HARDCOR.Usuario
       SET habilitado = @habilitado
     WHERE cod_us = @codigo

    UPDATE HARDCOR.Contacto
       SET cod_postal = @codigo_postal,
            localidad = @localidad,
            dom_calle = @direccion_calle,
            nro_calle = @direccion_numero,
             nro_dpto = @numero_departamento,
             nro_piso = @direccion_piso,
              nro_tel = @telefono,
                 mail = @mail
     WHERE cod_contacto = (SELECT cod_contacto
                             FROM HARDCOR.Empresa
                            WHERE emp_cuit = @cuit)

    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION
  END CATCH
END
GO

CREATE FUNCTION HARDCOR.existe_usuario (@username NVARCHAR(255)) RETURNS BIT AS BEGIN
  IF EXISTS(SELECT 1
             FROM HARDCOR.Usuario
            WHERE username = @username)
    RETURN 1
  RETURN 0
END
GO

CREATE PROCEDURE HARDCOR.modificar_rol (@cod_rol TINYINT, @nombre NVARCHAR(255), @habilitado BIT) AS BEGIN
  UPDATE HARDCOR.Rol
     SET nombre = @nombre,
         habilitado = @habilitado
   WHERE cod_rol = @cod_rol
END
GO

CREATE PROCEDURE HARDCOR.crear_rol (@nombre NVARCHAR(255), @habilitado BIT) AS BEGIN
  INSERT INTO HARDCOR.Rol (nombre, habilitado)
  VALUES (@nombre, @habilitado)

  SELECT SCOPE_IDENTITY() AS nuevo_pk
    FROM HARDCOR.Rol
END
GO

CREATE PROCEDURE HARDCOR.funcionalidades_del_rol (@cod_rol TINYINT) AS BEGIN
  /* Lista las funcionalidades que tiene asignado un rol */
  SELECT F.cod_fun, F.descripcion
    FROM HARDCOR.Funcionalidad F, HARDCOR.RolXfunc R
   WHERE R.cod_rol = @cod_rol
     AND F.cod_fun = R.cod_fun
END
GO

CREATE PROCEDURE HARDCOR.agregar_funcionalidad (@cod_rol TINYINT, @cod_fun TINYINT) AS BEGIN
  /* Agrega la funcionalidad descrita por el codigo al rol,
     si es que no lo tenia asignado previamente */
  IF(NOT EXISTS(SELECT 1 FROM HARDCOR.RolXfunc WHERE cod_rol = @cod_rol AND cod_fun = @cod_fun)) BEGIN
    INSERT INTO HARDCOR.RolXfunc (cod_rol, cod_fun)
    VALUES (@cod_rol, @cod_fun)
  END
END
GO

CREATE PROCEDURE HARDCOR.quitar_funcionalidad (@cod_rol TINYINT, @cod_fun TINYINT) AS BEGIN
  DELETE FROM HARDCOR.RolXfunc
   WHERE cod_rol = @cod_rol
     AND cod_fun = @cod_fun
END
GO

CREATE PROCEDURE HARDCOR.obtener_rubros AS BEGIN
  SELECT *
    FROM HARDCOR.Rubro
END
GO

CREATE PROCEDURE HARDCOR.obtener_visibilidades_por_usuario AS BEGIN
  /* Deberia recibir el usuario
     Si ese usuario no tiene publicacion, deberia devolver solo gratis
     Si tiene publicaciones, deberia devolver todos menos gratis
   */
  SELECT *
    FROM HARDCOR.Visibilidad
END
GO

CREATE PROCEDURE HARDCOR.obtener_visibilidades AS BEGIN
  SELECT *
    FROM HARDCOR.Visibilidad
END
GO

CREATE PROCEDURE HARDCOR.listar_publicaciones(@pagina INT, @cantidad_resultados_por_pagina INT,
                                              @descripcion NVARCHAR(255), @rubros NVARCHAR(255), @username NVARCHAR(255)) AS BEGIN
  SELECT *
    FROM HARDCOR.Publicacion P
   WHERE P.estado = 1
     AND ((@descripcion LIKE '') OR ( P.descripcion LIKE '%' + @descripcion + '%'))
     AND ((@rubros LIKE '') OR ( P.cod_rubro IN (SELECT *
                                                   FROM HARDCOR.split(@rubros))))
     AND @username <> (SELECT username
                         FROM HARDCOR.Usuario U
                        WHERE U.cod_us = P.cod_us)
   ORDER BY HARDCOR.calcular_peso_visibilidad(cod_visi)
  OFFSET @pagina * @cantidad_resultados_por_pagina ROWS
   FETCH NEXT @cantidad_resultados_por_pagina ROWS ONLY
END
GO

CREATE FUNCTION HARDCOR.calcular_peso_visibilidad(@cod_visi INT) RETURNS INT AS BEGIN
  RETURN (SELECT comision_pub + 2 * comision_vta + comision_envio
            FROM HARDCOR.Visibilidad
           WHERE cod_visi = @cod_visi)
END
GO

CREATE PROCEDURE HARDCOR.cantidad_paginas_publicaciones(@tamanio_pagina INT) AS BEGIN
   SELECT COUNT(cod_pub) / @tamanio_pagina
     FROM HARDCOR.Publicacion
END
GO

CREATE PROCEDURE HARDCOR.cantidad_paginas_facturas(@tamanio_pagina INT) AS BEGIN
   SELECT COUNT(nro_fact) / @tamanio_pagina
     FROM HARDCOR.Factura
END
GO

CREATE FUNCTION HARDCOR.split (@commaSeparatedList NVARCHAR(MAX)) RETURNS @t TABLE (val NVARCHAR(MAX)) AS BEGIN
  /* Hack horrible para que dado un string de enteros separados por coma me los devuelva listados */
  DECLARE @xml xml
  SET @xml = N'<root><r>' + REPLACE(@commaSeparatedList, ',', '</r><r>') + '</r></root>'

  INSERT INTO @t(val)
  SELECT r.value('.', 'VARCHAR(MAX)') AS item
    FROM @xml.nodes('//root/r') AS RECORDS(r)

  RETURN
END
GO

CREATE PROCEDURE HARDCOR.obtener_factura (@numero NUMERIC) AS BEGIN
  SELECT *
    FROM HARDCOR.Factura
   WHERE nro_fact = @numero
END
GO

CREATE PROCEDURE HARDCOR.obtener_detalles_factura (@numero NUMERIC) AS BEGIN
  SELECT *
    FROM HARDCOR.Detalle
   WHERE nro_fact = @numero
END
GO

CREATE PROCEDURE HARDCOR.calificaciones_por_estrellas (@usuario NVARCHAR(255)) AS BEGIN
  /* Devuelve una fila por cada calificacion (1-5) y tipo (1-Compra inmediata, 2-subasta)
     con la cantidad de calificaciones hechas por el usuario a ese tipo de publicacion con esa
     cantidad de estrellas */
    SELECT COUNT(*) AS Cantidad, Ca.calif_estrellas AS Calificacion,  P.cod_tipo AS Tipo
      FROM HARDCOR.Compra Co, HARDCOR.Calificacion Ca, HARDCOR.Publicacion P
     WHERE Co.cod_us = (SELECT cod_us
                          FROM HARDCOR.Usuario
                         WHERE username = @usuario)
       AND Ca.cod_calif = Co.cod_calif
       AND P.cod_pub = Co.cod_pub
  GROUP BY Ca.calif_estrellas, P.cod_tipo
END
GO

CREATE PROCEDURE HARDCOR.operaciones_sin_calificar (@usuario NVARCHAR(255)) AS BEGIN
  SELECT *  -- TODO: Ver que campos mostramos
    FROM HARDCOR.Compra Co, HARDCOR.Publicacion P
   WHERE Co.cod_us = (SELECT cod_us
                        FROM HARDCOR.Usuario
                       WHERE username = @usuario)
     AND P.cod_pub = Co.cod_pub
     AND NOT EXISTS (SELECT cod_calif
                       FROM HARDCOR.Calificacion Ca
                      WHERE Ca.cod_calif = Co.cod_calif)
END
GO

CREATE PROCEDURE HARDCOR.ultimas_operaciones_calificadas (@usuario NVARCHAR(255)) AS BEGIN
  SELECT TOP 10 *  --TODO: Ver que campos mostramos
    FROM HARDCOR.Compra Co, HARDCOR.Calificacion Ca, HARDCOR.Publicacion P
   WHERE Co.cod_us = (SELECT cod_us
                        FROM HARDCOR.Usuario
                       WHERE username = @usuario)
     AND Ca.cod_calif = Co.cod_calif
     AND P.cod_pub = Co.cod_pub
  ORDER BY Co.fecha_compra DESC
END
GO

CREATE PROCEDURE HARDCOR.obtener_tipos_doc AS BEGIN
SELECT * FROM HARDCOR.Tipo_doc
END
GO