import { Injectable } from '@angular/core';
import { AbstractCategoriaProdutoViewService } from './categoria-produto.abstract.service';
import { ABP } from '@abp/ng.core';

@Injectable()
export class CategoriaProdutoViewService extends AbstractCategoriaProdutoViewService {
  getListaCategorias() {
    const getData = (query: ABP.PageQueryParams) =>
      this.proxyService.getList({
        ...query,
        maxResultCount: 100,
      });

    return this.list.hookToQuery(getData)
  }
}
