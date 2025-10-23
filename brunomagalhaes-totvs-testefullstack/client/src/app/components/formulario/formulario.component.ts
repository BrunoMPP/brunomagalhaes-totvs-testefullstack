import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProdutoService } from '../../services/produto.service';
import { ProdutoModel } from '../../models/produto.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-formulario',
  imports: [CommonModule, FormsModule],
  templateUrl: './formulario.component.html',
  styleUrl: './formulario.component.css'
})
export class FormularioComponent {
  produtoAtual: ProdutoModel = { nome: '', preco: 0, descricao: '', estoque: 0 };

  constructor(private produtoService: ProdutoService) { }


  saveProduct(): void {
    if (this.produtoAtual.id) {
      this.produtoService.atualizarProduto(this.produtoAtual);
      this.produtoAtual = { nome: '', preco: 0, descricao: '', estoque: 0 }
    } else {
      this.produtoService.novoProduto(this.produtoAtual);
      this.produtoAtual = { nome: '', preco: 0, descricao: '', estoque: 0 };
    }
  }

}
