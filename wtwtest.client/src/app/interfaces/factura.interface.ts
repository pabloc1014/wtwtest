export namespace SistemaFacturacion
{
    export interface Cliente{
        clienteId: number;
        razonSocial: string;
    }

    export interface ProductoViewModel {
        id: number;
        nombreProducto: string;
        precioUnitario: number;
        imagenProducto: string | null;
    }
    
    export interface FacturaCreateModel {
        fechaEmisionFactura: string;
        idCliente: number;
        numeroFactura: number;
        detalles: DetalleFacturaCreateModel[];
    }

    export interface DetalleFacturaCreateModel {
        idProducto: number;
        cantidadDeProducto: number;
        precioUnitarioProducto: number;
        subtotalProducto: number;
        notas: string | null;
    }
}