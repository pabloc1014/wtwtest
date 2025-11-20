

CREATE PROCEDURE sp_GetClientes
AS
BEGIN
    SELECT Id, RazonSocial
    FROM TblClientes
    ORDER BY RazonSocial;
END
GO


CREATE PROCEDURE sp_GetProductos
AS
BEGIN
    SELECT Id, NombreProducto, PrecioUnitario
    FROM CatProductos
    ORDER BY NombreProducto;
END
GO

CREATE PROCEDURE sp_GetProductoById
    @IdProducto INT
AS
BEGIN
    SELECT 
        Id,
        NombreProducto,
        PrecioUnitario,
        ImagenProducto,
        ext
    FROM CatProductos
    WHERE Id = @IdProducto;
END
GO


CREATE PROCEDURE sp_InsertFactura
    @FechaEmisionFactura DATETIME,
    @IdCliente INT,
    @NumeroFactura INT,
    @NumeroTotalArticulos INT,
    @SubTotalFacturas DECIMAL(18,2),
    @TotalImpuestos DECIMAL(18,2),
    @TotalFactura DECIMAL(18,2),
    @IdFactura INT OUTPUT
AS
BEGIN
    INSERT INTO TblFacturas
    (
        FechaEmisionFactura,
        IdCliente,
        NumeroFactura,
        NumeroTotalArticulos,
        SubTotalFacturas,
        TotalImpuestos,
        TotalFactura
    )
    VALUES
    (
        @FechaEmisionFactura,
        @IdCliente,
        @NumeroFactura,
        @NumeroTotalArticulos,
        @SubTotalFacturas,
        @TotalImpuestos,
        @TotalFactura
    );

    SET @IdFactura = SCOPE_IDENTITY();
END
GO


CREATE PROCEDURE sp_InsertDetalleFactura
    @IdFactura INT,
    @IdProducto INT,
    @CantidadDeProducto INT,
    @PrecioUnitarioProducto DECIMAL(18,2),
    @SubtotalProducto DECIMAL(18,2),
    @Notas VARCHAR(200)
AS
BEGIN
    INSERT INTO TblDetallesFactura
    (
        IdFactura,
        IdProducto,
        CantidadDeProducto,
        PrecioUnitarioProducto,
        SubtotalProducto,
        Notas
    )
    VALUES
    (
        @IdFactura,
        @IdProducto,
        @CantidadDeProducto,
        @PrecioUnitarioProducto,
        @SubtotalProducto,
        @Notas
    );
END
GO


CREATE PROCEDURE sp_SearchFacturasByCliente
    @IdCliente INT
AS
BEGIN
    SELECT 
        f.Id,
        f.NumeroFactura,
        f.FechaEmisionFactura,
        f.SubTotalFacturas,
        f.TotalImpuestos,
        f.TotalFactura,
        c.RazonSocial AS Cliente
    FROM TblFacturas f
    INNER JOIN TblClientes c ON c.Id = f.IdCliente
    WHERE f.IdCliente = @IdCliente
    ORDER BY f.FechaEmisionFactura DESC;
END
GO


CREATE PROCEDURE sp_SearchFacturasByNumero
    @NumeroFactura INT
AS
BEGIN
    SELECT 
        f.Id,
        f.NumeroFactura,
        f.FechaEmisionFactura,
        f.SubTotalFacturas,
        f.TotalImpuestos,
        f.TotalFactura,
        c.RazonSocial AS Cliente
    FROM TblFacturas f
    INNER JOIN TblClientes c ON c.Id = f.IdCliente
    WHERE f.NumeroFactura = @NumeroFactura;
END
GO


CREATE PROCEDURE sp_GetAllClientes
AS
BEGIN
    SELECT *
    FROM TblClientes;
END
GO


USE DevLab;
GO


INSERT INTO CatTipoCliente (TipoCliente)
VALUES 
    ('Persona Natural'),
    ('Persona Juridica');
GO


INSERT INTO TblClientes (RazonSocial, IdTipoCliente, FechaCreacion, RFC)
VALUES
    ('Pablo', 1, GETDATE(), '123456789'),
    ('SuperMercado B', 2, GETDATE(), 'FTF987654321'),
    ('SuperMercado C', 2, GETDATE(), 'PEG654987321');
GO


INSERT INTO CatProductos (NombreProducto, ImagenProducto, PrecioUnitario, ext)
VALUES
    ('Laptop Lenovo ThinkPad L14', NULL, 350000.00, NULL),
    ('Mouse inalámbrico Logitech M185', NULL, 45000.00, NULL);
GO


