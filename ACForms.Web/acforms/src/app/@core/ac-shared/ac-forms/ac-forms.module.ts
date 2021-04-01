import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionnaireComponent } from './questionnaire/questionnaire.component';
import { QuestionnaireNavigationComponent } from './components/questionnaire-navigation/questionnaire-navigation.component';
import { QuestionnaireProgressComponent } from './components/questionnaire-progress/questionnaire-progress.component';
import { QuestionnaireSectionComponent } from './components/questionnaire-section/questionnaire-section.component';
import { QuestionDateboxComponent } from './components/question-datebox/question-datebox.component';
import { QuestionTextboxComponent } from './components/question-textbox/question-textbox.component';
import { QuestionRadioComponent } from './components/question-radio/question-radio.component';
import { QuestionCheckWithTextComponent } from './components/question-check-with-text/question-check-with-text.component';
import { QuestionCustomCollectionComponent } from './components/question-custom-collection/question-custom-collection.component';
import { CustomCollectionTemplateDiagnosisComponent } from './components/custom-collection-template-diagnosis/custom-collection-template-diagnosis.component';
import { CustomCollectionTemplateMedicationComponent } from './components/custom-collection-template-medication/custom-collection-template-medication.component';
import { CustomCollectionTemplateSurgeryComponent } from './components/custom-collection-template-surgery/custom-collection-template-surgery.component';
import { CustomCollectionTemplateTextboxComponent } from './components/custom-collection-template-textbox/custom-collection-template-textbox.component';
import { FileAttachmentsComponent } from './components/file-attachments/file-attachments.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomQuestionnaireSectionComponent } from './components/custom-questionnaire-section/custom-questionnaire-section.component';
import { CustomQuestionRadioComponent } from './components/custom-question-radio/custom-question-radio.component';
import { CustomQuestionTextboxComponent } from './components/custom-question-textbox/custom-question-textbox.component';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatStepperModule } from '@angular/material/stepper';
import { MatTabsModule } from '@angular/material/tabs';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatChipsModule } from '@angular/material/chips';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatNativeDateModule, MAT_DATE_FORMATS } from '@angular/material/core';
import { NgxMaskModule, IConfig } from 'ngx-mask';
import { MarkdownModule } from 'ngx-markdown';
import { CustomCollectionTemplateRelationshipDiagnosisAgeComponent } from './components/custom-collection-template-relationship-diagnosis-age/custom-collection-template-relationship-diagnosis-age.component';
import { QuestionTextareaComponent } from './components/question-textarea/question-textarea.component';
import { QuestionTextWithEventUsernameComponent } from './components/question-text-with-event-username/question-text-with-event-username.component';
import { QuestionTextWithEventComponent } from './components/question-text-with-event/question-text-with-event.component';
import { CustomCollectionTemplateChildrenComponent } from './components/custom-collection-template-children/custom-collection-template-children.component';
@NgModule({
  declarations: [
    QuestionnaireComponent,
    QuestionnaireNavigationComponent,
    QuestionnaireProgressComponent,
    QuestionnaireSectionComponent,
    QuestionTextboxComponent,
    QuestionRadioComponent,
    QuestionCheckWithTextComponent,
    QuestionCustomCollectionComponent,
    CustomCollectionTemplateDiagnosisComponent,
    CustomCollectionTemplateMedicationComponent,
    CustomCollectionTemplateSurgeryComponent,
    QuestionDateboxComponent,
    FileAttachmentsComponent,
    CustomCollectionTemplateTextboxComponent,
    CustomCollectionTemplateRelationshipDiagnosisAgeComponent,
    QuestionTextareaComponent,
    CustomQuestionnaireSectionComponent,
    CustomQuestionRadioComponent,
    CustomQuestionTextboxComponent,
    CustomCollectionTemplateChildrenComponent,
    QuestionTextareaComponent,
    QuestionTextWithEventUsernameComponent,
    QuestionTextWithEventComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MatCheckboxModule,
    MatButtonModule,
    MatInputModule,
    MatAutocompleteModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatRadioModule,
    MatSelectModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatMenuModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatStepperModule,
    MatTabsModule,
    MatExpansionModule,
    MatButtonToggleModule,
    MatChipsModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
    MatDialogModule,
    MatTooltipModule,
    MatSnackBarModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatNativeDateModule,
    NgxMaskModule.forRoot(),
    MarkdownModule.forRoot(),
  ],
  exports: [
    QuestionnaireComponent
  ],
  providers: []
})
export class AcFormsModule { }
