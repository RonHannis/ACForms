import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionDateboxComponent } from './question-datebox.component';

describe('QuestionDateboxComponent', () => {
  let component: QuestionDateboxComponent;
  let fixture: ComponentFixture<QuestionDateboxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuestionDateboxComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestionDateboxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
