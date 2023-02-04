import { Pipe, PipeTransform } from '@angular/core';
import { Genre } from '../../../data/enums/genre';

@Pipe({
  name: 'genreTransform'
})
export class GenreTransformPipe implements PipeTransform {

  transform(value: Genre, ...args: unknown[]): string {
    return Genre[value];
  }

}
