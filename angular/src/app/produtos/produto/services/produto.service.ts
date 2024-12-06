import { Injectable } from '@angular/core';
import { AbstractProdutoViewService } from './produto.abstract.service';
import { ABP } from '@abp/ng.core';

@Injectable()
export class ProdutoViewService extends AbstractProdutoViewService {
  getNovosProdutos() {
    const getData = (query: ABP.PageQueryParams) =>
      this.proxyService.getList({
        ...query,
        maxResultCount: 3,
      });

    return this.list.hookToQuery(getData)
  }
}
