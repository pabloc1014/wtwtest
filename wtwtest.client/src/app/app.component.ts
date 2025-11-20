import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SistemaFacturacion } from './interfaces/factura.interface';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  

  clientes: SistemaFacturacion.Cliente[] = [];
  productos: SistemaFacturacion.ProductoViewModel[] = [];

  subtotal: number = 0;
  impuestos: number = 0;
  total: number = 0;

  factura: SistemaFacturacion.FacturaCreateModel;

  constructor(private http: HttpClient) {
    this.factura = {
    fechaEmisionFactura: new Date().toISOString(),
    idCliente: 0,
    numeroFactura: 0,
    detalles: []
  };

  this.subtotal = 0;
  this.impuestos = 0;
  this.total = 0;
  }

  ngOnInit(): void {
    this.cargarClientes();
    this.cargarProductos();
  }

  cargarClientes() {
    this.http.get<SistemaFacturacion.Cliente[]>("https://localhost:7020/api/clientes").subscribe({
      next: (data) => {
        this.clientes = data;
      },
      error: (err) => {
        console.error('Error al llamar el endpoint:', err);
      }
    });
  }

  cargarProductos() {
    this.http.get<SistemaFacturacion.ProductoViewModel[]>("https://localhost:7020/api/productos").subscribe({
      next: (data) => {
        this.productos = data;
      },
      error: (err) => {
        console.error('Error al llamar el endpoint:', err);
      }
    });
  }

  guardarFacturaEnBD(factura: any) {
    this.http.post("https://localhost:7020/api/factura", factura)
    .subscribe({
      next: (response) => {
        alert("Factura guardada exitosamente");
        this.nuevo(); 
      },
      error: (error) => {
        alert("Error al guardar la factura");
      }
    });
  }


  nuevo() {
  this.factura = {
    fechaEmisionFactura: new Date().toISOString(),
    idCliente: 0,
    numeroFactura: 0,
    detalles: []
  };

  this.subtotal = 0;
  this.impuestos = 0;
  this.total = 0;
}

agregarProducto() {
  const nuevoDetalle: SistemaFacturacion.DetalleFacturaCreateModel = {
    idProducto: 0,
    cantidadDeProducto: 1,
    precioUnitarioProducto: 0,
    subtotalProducto: 0,
    notas: null
  };

  this.factura?.detalles.push(nuevoDetalle);
}

productoSeleccionado(productoId: number) {
  const prod = this.productos.find(p => p.id == productoId);
  if (!prod) return;

  const index = this.factura.detalles.findIndex(d => d.idProducto === productoId);
  if (index < 0) return;

  const detalle = this.factura.detalles[index];

  detalle.idProducto = prod.id;
  detalle.precioUnitarioProducto = prod.precioUnitario;
  detalle.subtotalProducto = detalle.precioUnitarioProducto * detalle.cantidadDeProducto;

  this.calcularTotales();
}

calcularTotales() {
  let suma = 0;
  if(!this.factura?.detalles) return;

  for (let d of this.factura.detalles) {
    d.subtotalProducto = d.precioUnitarioProducto * d.cantidadDeProducto;
    suma += d.subtotalProducto;
  }

  this.subtotal = suma;
  this.impuestos = this.subtotal * 0.19;
  this.total = this.subtotal + this.impuestos;
}

guardar() {
  if(!this.factura) return;

  const payload: SistemaFacturacion.FacturaCreateModel = {
    fechaEmisionFactura: this.factura.fechaEmisionFactura,
    idCliente: this.factura.idCliente,
    numeroFactura: this.factura.numeroFactura,
    detalles: this.factura.detalles
  };

  this.guardarFacturaEnBD(payload);
}
}