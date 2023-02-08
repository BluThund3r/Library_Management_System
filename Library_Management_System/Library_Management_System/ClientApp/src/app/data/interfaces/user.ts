import { Role } from "../enums/role";

export interface User {
  id: string;
  lastName?: string;
  firstName?: string;
  userName?: string;
  email?: string;
  password?: string;
  age?: number;
  phoneNumber?: string;
  city?: string;
  role: Role;
}
