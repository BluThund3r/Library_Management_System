import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorDetailsComponentComponent } from './author-details-component.component';

describe('AuthorDetailsComponentComponent', () => {
  let component: AuthorDetailsComponentComponent;
  let fixture: ComponentFixture<AuthorDetailsComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthorDetailsComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuthorDetailsComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
