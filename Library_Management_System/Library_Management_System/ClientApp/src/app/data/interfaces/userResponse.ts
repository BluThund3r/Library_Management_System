import { Role } from "../enums/role";

export interface UserResponse {
  id: string;
  userName: string;
  email: string;
  firstName: string;
  lastName: string;
  token: string;
  role: Role;
}
