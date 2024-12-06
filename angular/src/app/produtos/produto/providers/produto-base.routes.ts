import { ABP, eLayoutType } from '@abp/ng.core';

export const PRODUTO_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/produtos',
    iconClass: 'fas fa-box',
    name: '::Menu:Produtos',
    layout: eLayoutType.application,
    requiredPolicy: 'PortalHub.Produtos',
    breadcrumbText: '::Produtos',
  },
];
