import { FlexLayoutModule } from '@angular/flex-layout';
import { AngularMaterialModule } from 'src/app/shared/material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgxPrintModule } from 'ngx-print';
import { MenuToggleAnchorDirective, MenuToggleLinkDirective, MenuToggleDirective } from '../core/directives';
import { AddSpacePipe } from '../core/custom-pipes';
import { Ng5BreadcrumbModule } from 'ng5-breadcrumb';
import { ToastrModule } from 'ngx-toastr';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { FileUploadModule } from 'ng2-file-upload';
import { NgxBarcodeModule } from 'ngx-barcode';
import { NgAisModule } from 'angular-instantsearch';

@NgModule({
  declarations: [
    AddSpacePipe,
    MenuToggleAnchorDirective,
    MenuToggleLinkDirective,
    MenuToggleDirective
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    AngularMaterialModule,
    NgxPrintModule,
    FlexLayoutModule,
    Ng5BreadcrumbModule.forRoot(),
    ToastrModule.forRoot(),
    NgAisModule,
    SlickCarouselModule,
    FileUploadModule,
    NgxBarcodeModule
  ],
  exports: [
    AddSpacePipe,
    MenuToggleAnchorDirective,
    MenuToggleLinkDirective,
    MenuToggleDirective,
    ReactiveFormsModule,
    FormsModule,
    AngularMaterialModule,
    NgxPrintModule,
    NgAisModule,
    FlexLayoutModule,
    Ng5BreadcrumbModule,
    ToastrModule,
    SlickCarouselModule,
    FileUploadModule,
    NgxBarcodeModule
  ]
})
export class SharedModule { }
