import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { ACQuestionnaireSection } from "../../../../models/ac-forms.models";
import { MAT_DATE_LOCALE } from '@angular/material/core';

@Component({
  selector: 'app-custom-collection-template-children',
  templateUrl: './custom-collection-template-children.component.html',
  styleUrls: ['./custom-collection-template-children.component.scss']
})


export class CustomCollectionTemplateChildrenComponent implements OnInit {

  @Input() value: any;
  @Input() key: string;
  @Output() changed = new EventEmitter<any>();

  relationshipOptions = [
    'Natural child of enrollee and spouse',
    'Natural child of spouse -> Part 4',
    'Natural child of enrollee -> Part 4',
    'Other -> Part 4A'
  ];

  yesno = [
    'Yes',
    'No'
  ];

 
  isSelectedSection4 = false;
  isSelectedSection4A = false;


  constructor() { }

  ngOnInit(): void {
    if (!this.value) { this.initValue(); }
  }

    get childFirstname(): string {
      return this.getValueProp('childFirstname');
    }

    set childFirstname(childFirstname: string) {
      this.value.childFirstname = childFirstname;
      this.onChanged();
    }

    get childLastname(): string {
      return this.getValueProp('childLastname');
    }

    set childLastname(childLastname: string) {
      this.value.childLastname = childLastname;
      this.onChanged();
    }

    get childRelationship(): string {
      return this.getValueProp('childRelationship');
    }

  set childRelationship(childRelationship: string) {
      if (childRelationship === 'Natural child of enrollee and spouse') {
        this.isSelectedSection4 = false;
        this.isSelectedSection4A = false;
    } else if (childRelationship === 'Natural child of spouse -> Part 4') {
        this.isSelectedSection4 = true;
        this.isSelectedSection4A = false;
    } else if (childRelationship === 'Natural child of enrollee -> Part 4') {
        this.isSelectedSection4 = true;
        this.isSelectedSection4A = false;
    } else if (childRelationship === 'Other -> Part 4A') {
        this.isSelectedSection4 = false;
        this.isSelectedSection4A = true;
      }
      this.initValue();
      this.value.childRelationship = childRelationship;
      this.onChanged();
    }

  get otherchildcoverage(): string {
    return this.getValueProp('otherchildcoverage');
  }

  set otherchildcoverage(otherchildcoverage: string) {
    this.value.otherchildcoverage = otherchildcoverage;
    this.onChanged();
  }

  get part4Childfirstname(): string {
    return this.getValueProp('part4Childfirstname');
  }

  set part4Childfirstname(part4Childfirstname: string) {
    this.value.part4Childfirstname = part4Childfirstname;
    this.onChanged();
  }

  get part4Childlastname(): string {
    return this.getValueProp('part4Childlastname');
  }

  set part4Childlastname(part4Childlastname: string) {
    this.value.part4Childlastname = part4Childlastname;
    this.onChanged();
  }

  get childAddressenrollee(): string {
    return this.getValueProp('childAddressenrollee');
  }

  set childAddressenrollee(childAddressenrollee: string) {
    this.value.childAddressenrollee = childAddressenrollee;
    this.onChanged();
  }

  get childAddress(): string {
    return this.getValueProp('childAddress');
  }

  set childAddress(childAddress: string) {
    this.value.childAddress = childAddress;
    this.onChanged();
  }

  get graduationDate(): string {
    return this.getValueProp('graduationDate');
  }
  set graduationDate(graduationDate: string) {
    this.value.graduationDate = graduationDate;
    this.onChanged();
  }

  get otherparent(): string {
    return this.getValueProp('otherparent');
  }
  set otherparent(otherparent: string) {
    this.value.otherparent = otherparent;
    this.onChanged();
  }

  get otherParentdateofbirth(): string {
    return this.getValueProp('otherParentdateofbirth');
  }
  set otherParentdateofbirth(otherParentdateofbirth: string) {
    this.value.otherParentdateofbirth = otherParentdateofbirth;
    this.onChanged();
  }


  get otherParentaddress(): string {
    return this.getValueProp('otherParentaddress');
  }
  set otherParentaddress(otherParentaddress: string) {
    this.value.otherParentaddress = otherParentaddress;
    this.onChanged();
  }

  get childInsurance(): string {
    return this.getValueProp('childInsurance');
  }
  set childInsurance(childInsurance: string) {
    this.value.childInsurance = childInsurance;
    this.onChanged();
  }

  get sameasSpouse(): string {
    return this.getValueProp('sameasSpouse');
  }
  set sameasSpouse(sameasSpouse: string) {
    this.value.sameasSpouse = sameasSpouse;
    this.onChanged();
  }

  get childOtherpolicyholder(): string {
    return this.getValueProp('childOtherpolicyholder');
  }
  set childOtherpolicyholder(childOtherpolicyholder: string) {
    this.value.childOtherpolicyholder = childOtherpolicyholder;
    this.onChanged();
  }

  get relationshipTochild(): string {
    return this.getValueProp('relationshipTochild');
  }
  set relationshipTochild(relationshipTochild: string) {
    this.value.relationshipTochild = relationshipTochild;
    this.onChanged();
  }

  get childOtherinsurance(): string {
    return this.getValueProp('childOtherinsurance');
  }
  set childOtherinsurance(childOtherinsurance: string) {
    this.value.childOtherinsurance = childOtherinsurance;
    this.onChanged();
  }

  get childOthereffectivedate(): string {
    return this.getValueProp('childOthereffectivedate');
  }
  set childOthereffectivedate(childOthereffectivedate: string) {
    this.value.childOthereffectivedate = childOthereffectivedate;
    this.onChanged();
  }


  get childOthertermedate(): string {
    return this.getValueProp('childOthertermedate');
  }
  set childOthertermedate(childOthertermedate: string) {
    this.value.childOthertermedate = childOthertermedate;
    this.onChanged();
  }

  get childOthercoveragemedical(): boolean {
    return this.getValueProp('childOthercoveragemedical') === 'Yes' ? true : false;
  }

  set childOthercoveragemedical(childOthercoveragemedical: boolean) {
    this.value.childOthercoveragemedical = childOthercoveragemedical === true ? 'Yes' : 'No';
    this.onChanged();
  }

  get childOthercoveragedental(): boolean {
    return this.getValueProp('childOthercoveragedental') === 'Yes' ? true : false;
  }

  set childOthercoveragedental(childOthercoveragedental: boolean) {
    this.value.childOthercoveragedental = childOthercoveragedental === true ? 'Yes' : 'No';
    this.onChanged();
  }

  get childOthercoveragevision(): boolean {
    return this.getValueProp('childOthercoveragevision') === 'Yes' ? true : false;
  }

  set childOthercoveragevision(childOthercoveragevision: boolean) {
    this.value.childOthercoveragevision = childOthercoveragevision === true ? 'Yes' : 'No';
    this.onChanged();
  }

  get childOthercoverageprescription(): boolean {
    return this.getValueProp('childOthercoverageprescription') === 'Yes' ? true : false;
  }

  set childOthercoverageprescription(childOthercoverageprescription: boolean) {
    this.value.childOthercoverageprescription = childOthercoverageprescription === true ? 'Yes' : 'No';
    this.onChanged();
  }

  get childOthercoveragesupplemental(): boolean {
    return this.getValueProp('childOthercoveragesupplemental') === 'Yes' ? true : false;
  }

  set childOthercoveragesupplemental(childOthercoveragesupplemental: boolean) {
    this.value.childOthercoveragesupplemental = childOthercoveragesupplemental === true ? 'Yes' : 'No';
    this.onChanged();
  }

  get childOtherthanparentFName(): string {
    return this.getValueProp('childOtherthanparentFName');
  }
  set childOtherthanparentFName(childOtherthanparentFName: string) {
    this.value.childOtherthanparentFName = childOtherthanparentFName;
    this.onChanged();
  }

  get childOtherthanparentLName(): string {
    return this.getValueProp('childOtherthanparentLName');
  }
  set childOtherthanparentLName(childOtherthanparentLName: string) {
    this.value.childOtherthanparentLName = childOtherthanparentLName;
    this.onChanged();
  }

  get childOthercoverageavailable(): string {
    return this.getValueProp('childOthercoverageavailable');
  }
  set childOthercoverageavailable(childOthercoverageavailable: string) {
    this.value.childOthercoverageavailable = childOthercoverageavailable;
    this.onChanged();
  }
  get childOtherthanparentpolicyname(): string {
    return this.getValueProp('childOtherthanparentpolicyname');
  }
  set childOtherthanparentpolicyname(childOtherthanparentpolicyname: string) {
    this.value.childOtherthanparentpolicyname = childOtherthanparentpolicyname;
    this.onChanged();
  }
  get childOtherthanparentrelation(): string {
    return this.getValueProp('childOtherthanparentrelation');
  }
  set childOtherthanparentrelation(childOtherthanparentrelation: string) {
    this.value.childOtherthanparentrelation = childOtherthanparentrelation;
    this.onChanged();
  }
  get childOtherthanparentinsurance(): string {
    return this.getValueProp('childOtherthanparentinsurance');
  }
  set childOtherthanparentinsurance(childOtherthanparentinsurance: string) {
    this.value.childOtherthanparentinsurance = childOtherthanparentinsurance;
    this.onChanged();
  }
  get childOtherthanparenteffectivedate(): string {
    return this.getValueProp('childOtherthanparenteffectivedate');
  }
  set childOtherthanparenteffectivedate(childOtherthanparenteffectivedate: string) {
    this.value.childOtherthanparenteffectivedate = childOtherthanparenteffectivedate;
    this.onChanged();
  }
  get childOtherthanparenttermedate(): string {
    return this.getValueProp('childOtherthanparenttermedate');
  }
  set childOtherthanparenttermedate(childOtherthanparenttermedate: string) {
    this.value.childOtherthanparenttermedate = childOtherthanparenttermedate;
    this.onChanged();
  }
  get childOtherthanparentcoveragemedical(): boolean {
    return this.getValueProp('childOtherthanparentcoveragemedical') === 'Yes' ? true : false;
  }

  set childOtherthanparentcoveragemedical(childOtherthanparentcoveragemedical: boolean) {
    this.value.childOtherthanparentcoveragemedical = childOtherthanparentcoveragemedical === true ? 'Yes' : 'No';
    this.onChanged();
  }

  get childOtherthanparentcoveragedental(): boolean {
    return this.getValueProp('childOtherthanparentcoveragedental') === 'Yes' ? true : false;
  }

  set childOtherthanparentcoveragedental(childOtherthanparentcoveragedental: boolean) {
    this.value.childOtherthanparentcoveragedental = childOtherthanparentcoveragedental === true ? 'Yes' : 'No';
    this.onChanged();
  }

  get childOtherthanparentcoveragevision(): boolean {
    return this.getValueProp('childOtherthanparentcoveragevision') === 'Yes' ? true : false;
  }

  set childOtherthanparentcoveragevision(childOtherthanparentcoveragevision: boolean) {
    this.value.childOtherthanparentcoveragevision = childOtherthanparentcoveragevision === true ? 'Yes' : 'No';
    this.onChanged();
  }

  get childOtherthanparentcoverageprescription(): boolean {
    return this.getValueProp('childOtherthanparentcoverageprescription') === 'Yes' ? true : false;
  }

  set childOtherthanparentcoverageprescription(childOtherthanparentcoverageprescription: boolean) {
    this.value.childOtherthanparentcoverageprescription = childOtherthanparentcoverageprescription === true ? 'Yes' : 'No';
    this.onChanged();
  }

  get childOtherthanparentcoveragesupplemental(): boolean {
    return this.getValueProp('childOtherthanparentcoveragesupplemental') === 'Yes' ? true : false;
  }

  set childOtherthanparentcoveragesupplemental(childOtherthanparentcoveragesupplemental: boolean) {
    this.value.childOtherthanparentcoveragesupplemental = childOtherthanparentcoveragesupplemental === true ? 'Yes' : 'No';
    this.onChanged();
  }





  getValueProp(property: string): any {
    if (this.value) {
      if (!this.value[property]) {
        this.value[property] = null;
      }
    } else {
      this.initValue();
    }
    return this.value[property];
  }

  initValue(): void {
    this.value = {
      childFirstname: null,
      childLastname: null,
      childRelationship: 'Natural child of enrollee and spouse'
    };

    if (this.isSelectedSection4) {
      this.value = {
        childFirstname: null,
        childLastname: null,
        childRelationship: 'Natural child of enrollee or spouse',
        otherchildcoverage: null,
        part4Childfirstname: null,
        part4Childlastname: null,
        childAddressenrollee: null,
        childAddress: null,
        graduationDate: null,
        otherparent: null,
        otherParentdateofbirth: null,
        otherParentaddress: null,
        childInsurance: null,
        sameasSpouse: null,
        childOtherpolicyholder: null,
        relationshipTochild: null,
        childOtherinsurance: null,
        childOthereffectivedate: null,
        childOthertermedate: null,
        childOthercoveragemedical: 'No',
        childOthercoveragedental: 'No',
        childOthercoveragevision: 'No',
        childOthercoverageprescription: 'No',
        childOthercoveragesupplemental: 'No'
      }
    }

    if (this.isSelectedSection4A) {
      this.value = {
        childOtherthanparentFName: null,
        childOtherthanparentLName: null,
        childRelationship: 'Other Child',
        childotherinformation: null,
        childOtherthanparent: null,
        childOthercoverageavailable: null,
        childOtherthanparentpolicyname: null,
        childOtherthanparentrelation: null,
        childOtherthanparentinsurance: null,
        childOtherthanparenteffectivedate: null,
        childOtherthanparenttermedate: null,
        childOtherthanparentcoveragemedical: 'No',
        childOtherthanparentcoveragedental: 'No',
        childOtherthanparentcoveragevision: 'No',
        childOtherthanparentcoverageprescription: 'No',
        childOtherthanparentcoveragesupplemental: 'No'
      };
    }
  }

  onChanged(): void {
    this.changed.emit(this.value);
  }
  changeDate($event): void {
   // console.log($event);
  }
 
}
