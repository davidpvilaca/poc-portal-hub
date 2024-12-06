import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriaProdutoComponent } from './components/categoria-produto.component';

export const routes: Routes = [
  {
    path: '',
    component: CategoriaProdutoComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CategoriaProdutoRoutingModule {}
