import { Pipe, PipeTransform } from '@angular/core';
import { CoverType } from '../../../data/enums/coverType';

@Pipe({
  name: 'coverTypeTransform'
})
export class CoverTypeTransformPipe implements PipeTransform {

  transform(value: CoverType, ...args: unknown[]): string {
    return CoverType[value];
  }

}
