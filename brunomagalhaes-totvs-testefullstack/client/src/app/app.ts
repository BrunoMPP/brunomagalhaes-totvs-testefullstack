import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { OnInit } from '../../node_modules/@angular/core/index';
import { ListaProdutosComponent } from './components/listaProdutos/listaProdutos.component'
import { FormularioComponent } from './components/formulario/formulario.component'


@Component({
  selector: 'app-root',
  imports: [ListaProdutosComponent, FormularioComponent, FormsModule, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  private http = inject(HttpClient);

  //protected listaDeProdutos: ListaProdutos;

  ngOnInit(): void {

  }
}
