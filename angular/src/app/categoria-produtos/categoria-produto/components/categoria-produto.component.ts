import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import {
  NgbDateAdapter,
  NgbTimeAdapter,
  NgbCollapseModule,
  NgbDatepickerModule,
  NgbTimepickerModule,
  NgbDropdownModule,
} from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { ListService, CoreModule, ConfigStateService, CurrentUserDto } from '@abp/ng.core';
import { ThemeSharedModule, DateAdapter, TimeAdapter } from '@abp/ng.theme.shared';
import { PageModule } from '@abp/ng.components/page';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';

import { CategoriaProdutoViewService } from '../services/categoria-produto.service';
import { CategoriaProdutoDetailViewService } from '../services/categoria-produto-detail.service';
import { CategoriaProdutoDetailModalComponent } from './categoria-produto-detail.component';
import {
  AbstractCategoriaProdutoComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './categoria-produto.abstract.component';

@Component({
  selector: 'app-categoria-produto',
  changeDetection: ChangeDetectionStrategy.Default,
  standalone: true,
  imports: [
    ...ChildTabDependencies,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbTimepickerModule,
    NgbDropdownModule,

    NgxValidateCoreModule,

    PageModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    CategoriaProdutoDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    CategoriaProdutoViewService,
    CategoriaProdutoDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './categoria-produto.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class CategoriaProdutoComponent extends AbstractCategoriaProdutoComponent {
  private readonly configStateService = inject(ConfigStateService)

  user?: CurrentUserDto

  ngOnInit(): void {
    super.ngOnInit()
    this.user = this.configStateService.getOne('currentUser')
  }
}
