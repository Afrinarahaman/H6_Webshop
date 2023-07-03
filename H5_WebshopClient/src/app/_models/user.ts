import { Role } from "./role";

export interface User {
    id: number;
    email: string;
    password?: string;
    firstName: string;
    lastName: string;
    address: string;
    telephone: string;
    role?: Role;
    token?: string;
  }
  
 
  