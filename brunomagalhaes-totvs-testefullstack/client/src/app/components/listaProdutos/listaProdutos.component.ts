import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProdutoService } from '../../services/produto.service';
import { ProdutoModel } from '../../models/produto.model';
import { BehaviorSubject, Observable } from 'rxjs';

@Component({
  selector: 'app-listaProdutos',
  imports: [CommonModule, FormsModule],
  templateUrl: './listaProdutos.component.html',
  styleUrl: './listaProdutos.component.css'
})
export class ListaProdutosComponent implements OnInit {
  produtos$: Observable<ProdutoModel[]>;
  produtoAtual: ProdutoModel = { nome: '', preco: 0, descricao: '', estoque: 0 };
  produtos: ProdutoModel[] = [];

  produtoEmEdicao: ProdutoModel | null = null;


  constructor(private produtoService: ProdutoService) {
    this.produtoService.buscarProdutosCadastrados();
    this.produtos$ = this.produtoService.produtos$;
  }


  ngOnInit(): void {

  }


  editar(produto: ProdutoModel) {
    this.produtoEmEdicao = { ...produto };
  }

  cancelarEdicao() {
    this.produtoEmEdicao = null;
  }

  salvarEdicao() {
    if (this.produtoEmEdicao) {
      this.produtoService.atualizarProduto(this.produtoEmEdicao);
      this.produtoEmEdicao = null;
    }
  }


  remover(id: number) {
    this.produtoService.removerProduto(id);
  }
}
