import { Directive, OnInit, inject } from '@angular/core';

import { ListService, TrackByService } from '@abp/ng.core';

import type { ProdutoDto } from '../../../proxy/produtos/models';
import { ProdutoViewService } from '../services/produto.service';
import { ProdutoDetailViewService } from '../services/produto-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive({ standalone: true })
export abstract class AbstractProdutoComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(ProdutoViewService);
  public readonly serviceDetail = inject(ProdutoDetailViewService);
  protected title = '::Produtos';

  ngOnInit() {
    this.service.hookToQuery();
  }

  clearFilters() {
    this.service.clearFilters();
  }

  showForm() {
    this.serviceDetail.showForm();
  }

  create() {
    this.serviceDetail.selected = undefined;
    this.serviceDetail.showForm();
  }

  update(record: ProdutoDto) {
    this.serviceDetail.update(record);
  }

  delete(record: ProdutoDto) {
    this.service.delete(record);
  }
}
