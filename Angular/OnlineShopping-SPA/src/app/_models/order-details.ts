import { Order } from './order';
import { OrderedProducts } from './ordered-products';
import { ReceiverDetails } from './receiver-details';

export interface OrderDetails {
    order: Order;
    orderedProducts: OrderedProducts;
    receiverDetails: ReceiverDetails;

}
