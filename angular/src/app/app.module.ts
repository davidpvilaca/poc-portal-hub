import { CoreModule, provideAbpCore, withOptions } from '@abp/ng.core';
import { provideAbpOAuth } from '@abp/ng.oauth';
import { provideSettingManagementConfig } from '@abp/ng.setting-management/config';
import { provideFeatureManagementConfig } from '@abp/ng.feature-management';
import { ThemeSharedModule, provideAbpThemeShared,withValidationBluePrint,withHttpErrorConfig} from '@abp/ng.theme.shared';
import { provideCommercialUiConfig } from '@volo/abp.commercial.ng.ui/config';
import { AccountAdminConfigModule, provideAccountAdminConfig } from '@volo/abp.ng.account/admin/config';
import { provideAccountPublicConfig } from '@volo/abp.ng.account/public/config';
import { IdentityConfigModule, provideIdentityConfig } from '@volo/abp.ng.identity/config';
import { registerLocale } from '@abp/ng.core/locale';
import { HttpErrorComponent, ThemeLeptonXModule } from '@volosoft/abp.ng.theme.lepton-x';
import { SideMenuLayoutModule } from '@volosoft/abp.ng.theme.lepton-x/layouts';
import { AccountLayoutModule } from '@volosoft/abp.ng.theme.lepton-x/account';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ThemeSharedModule,
    CoreModule,
    IdentityConfigModule,
    AccountAdminConfigModule,
    ThemeLeptonXModule.forRoot(),
    SideMenuLayoutModule.forRoot(),
    AccountLayoutModule.forRoot(),
  ],
  providers: [APP_ROUTE_PROVIDER,
    provideAbpCore(
      withOptions({
        environment,
        registerLocaleFn: registerLocale(),
      }),
    ),
    provideAbpOAuth(),
    provideIdentityConfig(),
    provideSettingManagementConfig(),
    provideFeatureManagementConfig(),
    provideAccountAdminConfig(),
    provideAccountPublicConfig(),
    provideCommercialUiConfig(),
    provideAbpThemeShared(
      withHttpErrorConfig({
        errorScreen: {
          component: HttpErrorComponent,
          forWhichErrors: [401, 403, 404, 500],
          hideCloseIcon: true,
        },
      }),
      withValidationBluePrint({
        wrongPassword: 'Please choose 1q2w3E*',
      }),
    ),
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
