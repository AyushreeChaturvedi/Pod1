import { Injectable } from "@angular/core";

@Injectable({ providedIn: "root" })
export class data{
    projectName: string;
    projectManagerName: string;
    applicationOwnerName: string;
    type: string;
    date: string;
    question1: Boolean;
    question2: Boolean;
    question3: Boolean;
    question4: Boolean;
    question5: Boolean;
}