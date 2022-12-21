import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidenavextComponent } from './sidenavext.component';

describe('SidenavextComponent', () => {
  let component: SidenavextComponent;
  let fixture: ComponentFixture<SidenavextComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SidenavextComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SidenavextComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
