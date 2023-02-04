import { TestBed } from '@angular/core/testing';

import { SubscriptioncardService } from './subscriptioncard.service';

describe('SubscriptioncardService', () => {
  let service: SubscriptioncardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SubscriptioncardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
