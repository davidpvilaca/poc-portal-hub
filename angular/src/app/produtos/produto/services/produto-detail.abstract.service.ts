import { inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';

import { finalize, tap } from 'rxjs/operators';

import type { ProdutoDto } from '../../../proxy/produtos/models';
import { ProdutoService } from '../../../proxy/produtos/produto.service';

export abstract class AbstractProdutoDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);

  public readonly proxyService = inject(ProdutoService);
  public readonly list = inject(ListService);

  isBusy = false;
  isVisible = false;
  selected = {} as any;
  form: FormGroup | undefined;

  protected createRequest() {
    const formValues = {
      ...this.form.value,
    };

    if (this.selected) {
      return this.proxyService.update(this.selected.id, {
        ...formValues,
        concurrencyStamp: this.selected.concurrencyStamp,
      });
    }

    return this.proxyService.create(formValues);
  }

  buildForm() {
    const {
      nome,
      descricao,
      cicloDeVida,
      dataPublicacao,
      linkDocumentacao,
      plataforma,
      tecnologias,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      nome: [nome ?? null, [Validators.required]],
      descricao: [descricao ?? null, []],
      cicloDeVida: [cicloDeVida ?? null, [Validators.required]],
      dataPublicacao: [dataPublicacao ?? null, [Validators.required]],
      linkDocumentacao: [linkDocumentacao ?? null, []],
      plataforma: [plataforma ?? null, []],
      tecnologias: [tecnologias ?? null, []],
      status: [status ?? null, []],
    });
  }

  showForm() {
    this.buildForm();
    this.isVisible = true;
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: ProdutoDto) {
    this.selected = record;
    this.showForm();
  }

  hideForm() {
    this.isVisible = false;
  }

  submitForm() {
    if (this.form.invalid) return;

    this.isBusy = true;

    const request = this.createRequest().pipe(
      finalize(() => (this.isBusy = false)),
      tap(() => this.hideForm()),
    );

    request.subscribe(this.list.get);
  }

  changeVisible($event: boolean) {
    this.isVisible = $event;
  }
}
