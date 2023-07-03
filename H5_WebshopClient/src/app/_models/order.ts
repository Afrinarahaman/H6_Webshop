import { CartItem } from "./cartItem";

export interface Order {
    id?: number;
    userId: number;
    orderDetails: CartItem[];
    orderDate?: Date;
}