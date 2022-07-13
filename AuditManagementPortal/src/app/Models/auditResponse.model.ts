import { Injectable } from "@angular/core";
import { randomInt } from "crypto";

@Injectable()

export class AuditResponse{
    constructor(
        
        public projectName:string,
        public managerName:string,
        public projectStatus:string,
        public remedyAction:string,
        public projectExexutionStatus: string,
        public remedialActionDuration: string
    ){}
}