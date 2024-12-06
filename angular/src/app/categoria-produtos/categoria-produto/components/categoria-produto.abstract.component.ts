import { Directive, OnInit, inject } from '@angular/core';

import { ListService, TrackByService } from '@abp/ng.core';

import type { CategoriaProdutoWithNavigationPropertiesDto } from '../../../proxy/categoria-produtos/models';
import { CategoriaProdutoViewService } from '../services/categoria-produto.service';
import { CategoriaProdutoDetailViewService } from '../services/categoria-produto-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive({ standalone: true })
export abstract class AbstractCategoriaProdutoComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(CategoriaProdutoViewService);
  public readonly serviceDetail = inject(CategoriaProdutoDetailViewService);
  protected title = '::CategoriaProdutos';

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

  update(record: CategoriaProdutoWithNavigationPropertiesDto) {
    this.serviceDetail.update(record);
  }

  delete(record: CategoriaProdutoWithNavigationPropertiesDto) {
    this.service.delete(record);
  }
}
