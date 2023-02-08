import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoleTransformPipe } from '../core/pipes/roleTransform/role-transform.pipe';
import { CoverTypeTransformPipe } from '../core/pipes/coverTypeTransform/cover-type-transform.pipe';
import { GenreTransformPipe } from '../core/pipes/genreTransform/genre-transform.pipe';
import { LanguageTransformPipe } from '../core/pipes/languageTransform/language-transform.pipe';



@NgModule({
  declarations: [
    RoleTransformPipe,
    CoverTypeTransformPipe,
    GenreTransformPipe,
    LanguageTransformPipe
  ],
  imports: [
    CommonModule
  ],
  exports: [
    RoleTransformPipe,
    CoverTypeTransformPipe,
    GenreTransformPipe,
    LanguageTransformPipe
  ]
})
export class PipesModule { }
