import { DetalleFactura } from "./detalleFactura";

export interface Factura {
    idFactura: number,
    Fecha: Date,
    IdCliente: string,
    TipoVenta: string,
    TipoPago: string,
    estado: boolean,
    TbDetalleFacturas: DetalleFactura[]
}