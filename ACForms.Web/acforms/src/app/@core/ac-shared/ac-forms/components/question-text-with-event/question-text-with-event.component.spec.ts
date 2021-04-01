import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionTextWithEventComponent } from './question-text-with-event.component';

describe('QuestionTextWithEventComponent', () => {
  let component: QuestionTextWithEventComponent;
  let fixture: ComponentFixture<QuestionTextWithEventComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuestionTextWithEventComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestionTextWithEventComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
