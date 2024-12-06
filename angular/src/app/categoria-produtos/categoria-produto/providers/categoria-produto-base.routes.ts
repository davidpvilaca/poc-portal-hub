import { ABP, eLayoutType } from '@abp/ng.core';

export const CATEGORIA_PRODUTO_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/categoria-produtos',
    iconClass: 'fas fa-tags',
    name: '::Menu:CategoriaProdutos',
    layout: eLayoutType.application,
    requiredPolicy: 'PortalHub.CategoriaProdutos',
    breadcrumbText: '::CategoriaProdutos',
  },
];
