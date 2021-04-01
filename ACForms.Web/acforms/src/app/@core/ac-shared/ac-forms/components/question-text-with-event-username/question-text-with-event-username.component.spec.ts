import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionTextWithEventUsernameComponent } from './question-text-with-event-username.component';

describe('QuestionTextWithEventUsernameComponent', () => {
  let component: QuestionTextWithEventUsernameComponent;
  let fixture: ComponentFixture<QuestionTextWithEventUsernameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuestionTextWithEventUsernameComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestionTextWithEventUsernameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
