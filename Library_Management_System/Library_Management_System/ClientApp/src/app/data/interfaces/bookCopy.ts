import { CoverType } from "../enums/coverType";

export interface BookCopy {
  id: string;
  bookId: string;
  coverType: CoverType;
  price: number;
}
