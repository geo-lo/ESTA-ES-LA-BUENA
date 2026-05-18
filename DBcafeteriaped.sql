--Creamos la base de datos

CREATE DATABASE CafeteriaDB;
GO

--Seleccionamos la database a utilizar
USE CafeteriaDB;
GO

--Creamos las tablas necesarias para guardar los datos

CREATE TABLE Inventario(
IdProducto INT PRIMARY KEY IDENTITY(1,1),
NombreProducto VARCHAR(100) NOT NULL,
CantidadActual INT NOT NULL DEFAULT 0,
StockMinimo INT NOT NULL DEFAULT 5,
PrecioUnitario DECIMAL(10,2) NOT NULL,
UltimaActualizacion DATETIME DEFAULT GETDATE()
);

--HISTORIAL DE VENTAS
CREATE TABLE HistoriaVentas(
IdRegistro INT PRIMARY KEY IDENTITY (1,1),
IdProducto INT,
NombreProducto VARCHAR(100),
CantidadVendida INT NOT NULL,
PrecioVenta DECIMAL(10,2) NOT NULL,
TotalVenta AS (CantidadVendida * PrecioVenta),
FechaVenta DATETIME DEFAULT GETDATE(),

CONSTRAINT FK_Inventario_Ventas FOREIGN KEY (IdProducto)REFERENCES Inventario(IdProducto)


GO

--TRIGGERS
CREATE TRIGGER                   --Obtiene la fecha actual cada vez que se actualice el stock
trg_ActualizarFechaStock         --Sirve para mantener un registro de cuándo se actualizó por última vez el stock de un producto
ON Inventario
AFTER UPDATE
AS
BEGIN
    UPDATE Inventario
    SET UltimaActualizacion = GETDATE()
    FROM Inventario
    INNER JOIN inserted ON Inventario.IdProducto = inserted.IdProducto;
    END;
GO
USE CafeteriaDB;
GO

ALTER TABLE Inventario ADD Categoria VARCHAR(50) NULL;
ALTER TABLE Inventario ADD Descripcion VARCHAR(255) NULL;