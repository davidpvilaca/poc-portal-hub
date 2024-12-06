import { inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';

import { finalize, tap } from 'rxjs/operators';

import type { CategoriaProdutoWithNavigationPropertiesDto } from '../../../proxy/categoria-produtos/models';
import { CategoriaProdutoService } from '../../../proxy/categoria-produtos/categoria-produto.service';

export abstract class AbstractCategoriaProdutoDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);

  public readonly proxyService = inject(CategoriaProdutoService);
  public readonly list = inject(ListService);

  public readonly getProdutoLookup = this.proxyService.getProdutoLookup;

  isBusy = false;
  isVisible = false;
  selected = {} as any;
  form: FormGroup | undefined;

  protected createRequest() {
    const formValues = {
      ...this.form.value,
      produtoIds: this.form.value.produtoIds.map(({ id }) => id),
    };

    if (this.selected) {
      return this.proxyService.update(this.selected.categoriaProduto.id, {
        ...formValues,
        concurrencyStamp: this.selected.categoriaProduto.concurrencyStamp,
      });
    }

    return this.proxyService.create(formValues);
  }

  buildForm() {
    const { nome, descricao } = this.selected?.categoriaProduto || {};

    const { produtos = [] } = this.selected || {};

    this.form = this.fb.group({
      nome: [nome ?? null, [Validators.required]],
      descricao: [descricao ?? null, []],
      produtoIds: [produtos, []],
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

  update(record: CategoriaProdutoWithNavigationPropertiesDto) {
    this.proxyService.getWithNavigationProperties(record.categoriaProduto.id).subscribe(data => {
      this.selected = data;
      this.showForm();
    });
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
