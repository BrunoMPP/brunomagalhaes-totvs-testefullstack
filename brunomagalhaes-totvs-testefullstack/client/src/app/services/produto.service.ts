import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { ProdutoModel } from '../models/produto.model';



@Injectable({
  providedIn: 'root'
})
export class ProdutoService {
  private produtosSubject = new BehaviorSubject<ProdutoModel[]>([]);
  produtos$: Observable<ProdutoModel[]> = this.produtosSubject.asObservable();

  constructor(private http: HttpClient) { }

  buscarProdutosCadastrados(): any {
    this.http.get<ProdutoModel[]>('https://localhost:44362/buscarProdutosCadastrados').subscribe({
      next: produtos => this.produtosSubject.next(produtos),
      error: erro => console.error('Erro ao carregar produtos', erro)
    });
  }


  novoProduto(produto: ProdutoModel): any {
    this.http.post<ProdutoModel>('https://localhost:44362/novoProduto', produto).subscribe({
      next: novoProduto => {
        const lista = this.produtosSubject.value;
        this.produtosSubject.next([...lista, novoProduto]);
        this.buscarProdutosCadastrados();
      },
      error: erro => console.error('Erro ao adicionar produto', erro)
    });
  }

  removerProduto(id: number): any {
    return this.http.delete<void>(`https://localhost:44362/${id}/removerProduto`).subscribe({
      next: () => {
        const lista = this.produtosSubject.value.filter(p => p.id !== id);
        this.produtosSubject.next(lista);
        this.buscarProdutosCadastrados();
      }
    });
  }

  atualizarProduto(product: ProdutoModel): any {
    this.http.put<ProdutoModel>('https://localhost:44362/atualizarProduto', product).subscribe({
      next: response => {
        this.buscarProdutosCadastrados();
      },
      error: erro =>
        console.error('Erro ao adicionar produto', erro),
      complete: () => {
      }
    });
  }
}
