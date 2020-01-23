
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { NavHeaderComponent } from './nav-header/nav-header.component';
import { PageLoaderComponent } from './page-loader/page-loader.component';
import { NavTabsComponent } from './nav-tabs/nav-tabs.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

import { SharedModule } from './shared/shared.module';
import { HomeModule } from './home/home.module';
import { AppRoutingModule } from './app-routing.module';
import { ProjectModule } from './project/project.module';
import { PersonnelModule } from './personnel/personnel.module';
import { FinancialReportComponent } from './financial-report/financial-report.component';
import { FinancialReportModule } from './financial-report/financial-report.module';
import { TaxesModule } from './taxes/taxes.module';
import { PaymentsModule } from './payments/payments.module';
import { BreadcrumbComponent } from './shared/breadcrumbs/breadcrumb.component';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    FetchDataComponent,
    NavHeaderComponent,
    PageLoaderComponent,
    NavTabsComponent,
    PageNotFoundComponent,
    FinancialReportComponent,
    BreadcrumbComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HomeModule,
    SharedModule,
    AppRoutingModule,
    ProjectModule,
    PersonnelModule,
    FinancialReportModule,
    TaxesModule,
    PaymentsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
