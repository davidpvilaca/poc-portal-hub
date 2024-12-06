import { APP_INITIALIZER, inject } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { PRODUTO_BASE_ROUTES } from './produto-base.routes';

export const PRODUTOS_PRODUTO_ROUTE_PROVIDER = [
  {
    provide: APP_INITIALIZER,
    multi: true,
    useFactory: configureRoutes,
  },
];

function configureRoutes() {
  const routesService = inject(RoutesService);

  return () => {
    const routes: ABP.Route[] = [...PRODUTO_BASE_ROUTES];
    routesService.add(routes);
  };
}
