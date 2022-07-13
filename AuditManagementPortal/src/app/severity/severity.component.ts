import { Component, Inject, OnInit, Input } from '@angular/core';
import { Severity } from '../Services/severity.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuditResponse } from '../Models/auditResponse.model';
import { Router } from '@angular/router';
import { Security } from '../Services/security.service';
import { GetQuestionsList } from '../Services/getQuestionList.service';
import { analyzeFileForInjectables } from '@angular/compiler';
import { BehaviorSubject, Observable } from "rxjs";
import { randomInt } from 'crypto';
//import {item} from '../Models/item'


@Component({
  selector: 'app-severity',
  templateUrl: './severity.component.html',
  styleUrls: ['./severity.component.css']
})


export class SeverityComponent implements OnInit {
  
  public finalRes:any;
  public resStatus:string="";
  //public currentUserSubject:item;
  constructor ( 
  private sev:Severity,
    
    private router:Router,    
    private security:Security,
    //public currentUserSubject: item= new item(0 ,"",""),
    private qList:GetQuestionsList) { }
    auditResponse =new AuditResponse(" "," "," "," "," "," ");
    

  ngOnInit(): void {
    if(!this.security.checkLogin())
    this.router.navigate(['unauthorisedError']);
    this.getexecutionStatus();
  }

  getexecutionStatus(){
    var temp:any;
    var x = this.sev.executionStatus()  //returns an observable
    .subscribe(response=>{
      
      temp = response;
      console.log(temp);
      this.setResults(temp);
      
    },error=>{
      console.log(error.message);
    });
  }

  setResults(finalRes:any){
    // var item = JSON.parse(localStorage.getItem("currentUser"));
    //console.log(finalRes);
    //this.currentUserSubject = JSON.parse(localStorage.getItem("currentUser") || '{}');
    
    this.finalRes.auditId = randomInt(100);
   // this.auditResponse.projectStatus =finalRes.ProjectExecutionStatus;
   //console.log(finalRes);
     if(finalRes.remedialActionDuration =="No Action Needed"){
   
        this.auditResponse.projectExexutionStatus="Green";
        }
        else{
          this.auditResponse.projectExexutionStatus="Red";
        } 
    //this.auditResponse.projectStatus="Red";
    this.auditResponse.remedyAction=finalRes.remedialActionDuration;
    this.auditResponse.projectName=this.qList.getProjectName();
    this.auditResponse.managerName=this.security.getUserName();

    this.resStatus=finalRes.remedialActionDuration;
  }

}
