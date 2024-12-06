import { APP_INITIALIZER, inject } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { CATEGORIA_PRODUTO_BASE_ROUTES } from './categoria-produto-base.routes';

export const CATEGORIA_PRODUTOS_CATEGORIA_PRODUTO_ROUTE_PROVIDER = [
  {
    provide: APP_INITIALIZER,
    multi: true,
    useFactory: configureRoutes,
  },
];

function configureRoutes() {
  const routesService = inject(RoutesService);

  return () => {
    const routes: ABP.Route[] = [...CATEGORIA_PRODUTO_BASE_ROUTES];
    routesService.add(routes);
  };
}
