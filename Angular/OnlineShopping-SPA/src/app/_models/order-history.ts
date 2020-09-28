export interface OrderHistory {
    ReceiverFirstName: string;
    ReceiverLastName: string;
    ReceiverEmail: string;
    ReceiverAddress: string;
    ReceiverAddress2: string;
    ReceiverCountry: string;
    ReceiverState: string;
    ReceiverZip: number;

    OrderId: number;
    OrderDate: Date;

    OrderProducts: string;
    ProductId: number;
    ProductName: string;
    ProductQty: number;
    ProductPrice: number;
}
