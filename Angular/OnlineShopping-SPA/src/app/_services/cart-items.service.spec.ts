/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CartItemsService } from './cart-items.service';

describe('Service: CartItems', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CartItemsService]
    });
  });

  it('should ...', inject([CartItemsService], (service: CartItemsService) => {
    expect(service).toBeTruthy();
  }));
});
