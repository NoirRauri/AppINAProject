export interface DetalleFactura {
    idDetalleFactura: number,
    idFactura: number,
    idProducto: string,
    cant: number,
    precio: number,
    estado: boolean
}