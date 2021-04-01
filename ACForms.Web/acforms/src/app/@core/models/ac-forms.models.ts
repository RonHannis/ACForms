export enum ACQuestionnaireQuestionTypes {
  Text = 'Text',
  TextArea = 'TextArea',
  Date = 'Date',
  SelectOne = 'SelectOne',
  Checkbox = 'Checkbox',
  CheckWithText = 'CheckWithText',
  CustomCollection = 'CustomCollection',
  TextboxWithEvent = 'TextboxWithEvent'
}

export enum ACCustomCollectionTypes {
  Text = 'Text',
  Diagnosis = 'Diagnosis',
  Medication = 'Medication',
  Surgery = 'Surgery',
  RelationshipDiagnosisAge = 'RelationshipDiagnosisAge',
  Children = 'Children'
}

export enum ACTextboxWithEventTypes {
  None = 'None',
 Username = 'Username'
}

export interface ACQuestionnaire {
  key: string;
  title: string;
  status: string;
  notes?: string[];
  allowAttachments: boolean;
  requireAttachments: boolean;
  requireCAPTCHA: boolean;
  attachments: ACQuestionnaireAttachment[];
  sections: ACQuestionnaireSection[];
}

export interface ACQuestionnaireAttachment {
  id: number;
  entryId: string;
  filename: string;
}


export interface ACQuestionnaireSection {
  key: string;
  label: string;
  subLabel?: string;
  markdownText?: string;
  sections?: ACQuestionnaireSection[];
  questions: ACQuestionnaireQuestion<ACQuestionnaireQuestionTypes>[];
}

export interface ACQuestionnaireQuestion<T extends ACQuestionnaireQuestionTypes> {
  key: string;
  formKey: string;
  label: string;
  subLabel?: string;
  readonly type: T;
  collectionType?: ACCustomCollectionTypes;
  textboxEventType?: ACTextboxWithEventTypes;
  value?: any;
  readOnly?: boolean;
  required?: boolean;
  customValidator?: string;
  mask?: string;
  hint?: string;
  visible?: string;

  // when there might be a dropdown, radio buttons, or checkboxes
  options?: any[];

  // used where there might be sub-question fields
  questions?: ACQuestionnaireQuestion<ACQuestionnaireQuestionTypes>[];
}


export enum InputMasks {
  phone = '(000) 000-0000',
  npi = '0000000000',
  cpt = '00000',
  icd10 = 'SAA.AAAA',
  date = '0000-M0-d0',
  initial = 'S'
}


