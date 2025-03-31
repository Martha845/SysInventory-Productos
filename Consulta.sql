-- Creación de la base de datos
CREATE DATABASE SysInventory;
USE SysInventory;

-- Creación de la tabla Producto
CREATE TABLE Producto (
    IdProducto INT NOT NULL AUTO_INCREMENT,
    Nombre VARCHAR(20) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    CantidadDisponible INT NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    PRIMARY KEY (IdProducto)
);

-- Creación de la tabla Proveedores
CREATE TABLE Proveedores (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL,
    NRC VARCHAR(50) UNIQUE,
    Direccion VARCHAR(80),
    Telefono VARCHAR(20),
    Email VARCHAR(100)
);

-- Creación de la tabla Compras
CREATE TABLE Compras (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FechaCompra DATETIME NOT NULL,
    IdProveedor INT NOT NULL,
    Total DECIMAL (10,2) NOT NULL DEFAULT 0.00,
    Estado TINYINT NOT NULL DEFAULT 1,
    FOREIGN KEY (IdProveedor) REFERENCES Proveedores(Id)
);

-- Creación de la tabla DetalleCompras
CREATE TABLE DetalleCompras (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    IdCompra INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    SubTotal DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (IdCompra) REFERENCES Compras(Id),
    FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
);

-- Insertar múltiples registros en la tabla Producto
INSERT INTO Producto (Nombre, Precio, CantidadDisponible, FechaCreacion)
VALUES
    ('Laptop',       1250.00,  10, 16/07/2005()),
    ('Mouse',         25.50,  150, 02/01/2020()),
    ('Keyboard',      45.30,  120, 09/08/2016()),
    ('Monitor',      300.99,   30, 27/01/2009()),
    ('Printer',      150.75,   15, 30/06/2007()),
    ('Tablet',       200.00,   25, 25/02/2012()),
    ('Smartphone',   850.00,   90, 20/05/2005()),
    ('Headset',       85.90,  130, 15/03/2008()),
    ('Camera',       499.99,   20, 19/04/2014()),
    ('USB Drive',     15.00,  300, 17/07/2007());

-- Insertar datos en la tabla Proveedores
INSERT INTO Proveedores (Nombre, NRC, Direccion, Telefono, Email)
VALUES
    ('Proveedor1', '123456-7', 'Calle 1, Ciudad', '1234-5678', 'proveedor1@email.com'),
    ('Proveedor2', '234567-8', 'Avenida 2, Ciudad', '2345-6789', 'proveedor2@email.com'),
    ('Proveedor3', '345678-9', 'Boulevard 3, Ciudad', '3456-7890', 'proveedor3@email.com');

-- Insertar datos en la tabla Compras
INSERT INTO Compras (FechaCompra, IdProveedor, Total, Estado)
VALUES
    (09/10/2006(), 1, 2500.00, 1),
    (10/12/2025(), 2, 1800.00, 1),
    (15/02/2024(), 3, 1200.00, 1);

-- Insertar datos en la tabla DetalleCompras
INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioUnitario, SubTotal)
VALUES
    (1, 1, 2, 1250.00, 2500.00),
    (2, 3, 10, 45.30, 453.00),
    (3, 5, 8, 150.75, 1206.00);

-- Consulta para verificar los datos insertados
SELECT * FROM Producto;
SELECT * FROM Proveedores;
SELECT * FROM Compras;
SELECT * FROM DetalleCompras;

