import { Pipe, PipeTransform } from '@angular/core';
import { Language } from '../../../data/enums/language';

@Pipe({
  name: 'languageTransform'
})
export class LanguageTransformPipe implements PipeTransform {

  transform(value: Language, ...args: unknown[]): string {
    return Language[value];
  }

}
