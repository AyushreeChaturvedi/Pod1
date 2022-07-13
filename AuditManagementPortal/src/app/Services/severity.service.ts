import { map } from "rxjs/operators";
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Injectable, Inject} from "@angular/core";
import { Router } from '@angular/router';
import { SeverityURL } from '../Models/tokens';
import { GetQuestionsList } from './getQuestionList.service';
import { Security } from './security.service';
import {data} from '../Models/data.model'

@Injectable({providedIn: 'root'})

export class Severity{
    private token=localStorage.getItem('auditToken');

    // headers={
    //   headers: new HttpHeaders({
    //       'Content-Type': 'application/json',
    //       'Authorization':`Bearer ${this.token}`
    //   })
    // }

    headers = new HttpHeaders({
      'Content-Type': 'application/json'

    });

    constructor(private http:HttpClient,
      private route:Router,
      private qList:GetQuestionsList,
      private security:Security,
      public requestData1:data,
      @Inject(SeverityURL) private severityUrl:string
      ){

    }
    
    setDetails(){
      this.requestData1.projectName=this.qList.getProjectName(),
   this.requestData1.projectManagerName=this.security.getUserName(),
  this.requestData1.applicationOwnerName= "Sreedhar";
  if(this.qList.getAuditType() == 0){
    this.requestData1.type="Internal";
  }else{
    this.requestData1.type="SOX";
  }
  
  this.requestData1.date=new Date().toISOString();
  var res: 
    {questionId:number, answer:string}[] = this.qList.sendResponse();
    const ans = res.map((obj)=>obj.answer);
    const ques = res.map((obj1)=>obj1.questionId);
  for(let i=0;i<ans.length;i++){
     if(ans[i]==="YES")
        if(ques[i] == 1){
             this.requestData1.question1 = true;
        }
          else  
           if(ques[i] == 2){
            this.requestData1.question2 = true;
          }
          else  
           if(ques[i] == 3){
            this.requestData1.question3 = true;
          }
          else  
           if(ques[i] == 4){
            this.requestData1.question4 = true;
          }
          if(ques[i] == 5){
            this.requestData1.question5 = true;
          }

     else
     if(ans[i] =="NO"){
          if(ques[i] == 1){
            this.requestData1.question1 = false;
      }
        else  
          if(ques[i] == 2){
          this.requestData1.question2 = false;
        }
        else  
          if(ques[i] == 3){
          this.requestData1.question3 = false;
        }
        else  
          if(ques[i] == 4){
          this.requestData1.question4 = false;
        }
        if(ques[i] == 5){
          this.requestData1.question5 = false;
        }

      }
  }
    
  }
    getTokFromlocal(){
      return this.token;
    }


    public executionStatus(){
      this.setDetails();
      //return this.requestData1;
      const body=JSON.stringify(this.requestData1);
      console.log(body);
      return this.http.post<any>(this.severityUrl,body,{headers:this.headers})   
      .pipe(
        map((user:any) => {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem("currentUser", JSON.stringify(user));

          return user;
        })
      );;
      }

}
