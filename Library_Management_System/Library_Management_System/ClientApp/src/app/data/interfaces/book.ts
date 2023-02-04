import { Genre } from '../enums/genre';
import { Language } from '../enums/language';

export interface Book {
  title: string;
  id: string;
  publisherId: string;
  releaseDate: Date;
  genre: Genre;
  language: Language;
  noPages: number;
}
