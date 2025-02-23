import { NgModule } from '@angular/core';
import { PageModule } from '@abp/ng.components/page';
import { SharedModule } from '../shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { ListService } from '@abp/ng.core';
import { ProdutoViewService } from '../produtos/produto/services/produto.service';
import { CategoriaProdutoViewService } from '../categoria-produtos/categoria-produto/services/categoria-produto.service';
import { AccordionComponent, AccordionPanelComponent } from 'ngx-bootstrap/accordion';

@NgModule({
  declarations: [HomeComponent],
  imports: [SharedModule, HomeRoutingModule, PageModule, AccordionComponent, AccordionPanelComponent],
  providers: [
    ListService,
    ProdutoViewService,
    CategoriaProdutoViewService,
  ]
})
export class HomeModule {}
