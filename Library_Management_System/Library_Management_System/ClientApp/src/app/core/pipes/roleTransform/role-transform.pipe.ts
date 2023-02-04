import { Pipe, PipeTransform } from '@angular/core';
import { Role } from '../../../data/enums/role';

@Pipe({
  name: 'roleTransform'
})
export class RoleTransformPipe implements PipeTransform {

  transform(value: Role, ...args: unknown[]): string {
    return Role[value];
  }

}
