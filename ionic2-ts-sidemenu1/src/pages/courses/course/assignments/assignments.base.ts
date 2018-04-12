import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';
import { NavParams } from 'ionic-angular';
import { siteMap } from '../../../../app/app.modules-base';
import { IonicBase } from '../../../../app/ionic-base';
import { RestAPIService } from '../../../../providers/rest-api-service';
import { Observable } from 'rxjs/Observable';
import { Subject } from "rxjs/Subject";
import { Storage } from '@ionic/storage';

export class AssignmentsBase extends IonicBase {

    constructor(public navCtrl: NavController, public navParams: NavParams, public apiSvc: RestAPIService) {
        super()
        this.parent = this.navParams.get("parent");
        this.pages = siteMap;
        this.getAssignments();
        
    }
    
    public AssignmentsState = siteMap['Assignments'];

    public pages : any;

    

    public AssignmentState = siteMap['Assignment'];
    public parent : any;
    public assignments: any = []; 

    

    pop2() { 
        this.navCtrl.pop()
            .then(data => {
                this.navCtrl.pop();
            });
    }

    getAssignments() {
        return new Promise(resolve => {
            
            this.parent.reload()
                .then(result => {
                    this.assignments = result.Assignments;
                    resolve(result);
                })
            
        });
    }

    reload() { return this.getAssignments(); }

    addNewAssignment() { // 
        var newAssignment = {
        
            Course
             : this.parent.course.CourseId,
            "Name" : "New Assignment " + (this.assignments ? this.assignments.length + 1 : 1),
            "Description" : ""
        }
        
        this.apiSvc.addNewAssignment(newAssignment)
            .then(data => {
                
                this.parent.reload();
                this.getAssignments();
                this.goToState(this.AssignmentState, data, true);
            });
            
    }
    

    

    
    goToRootState(state, assignment = {}, editMode = false) : Promise<any> {
        return this.goToState(state, assignment, editMode, true);
    }

    goToState(state, assignment = {}, editMode = false, setRoot = false)  : Promise<any> {
        if (setRoot) {
            return this.navCtrl.setRoot(state.component, { assignment : assignment, parent: this, editMode: editMode });
        } else {
            return this.navCtrl.push(state.component, { assignment : assignment, parent: this, editMode: editMode });
        }
    }

    goToUrl(url) {
        console.log('SIMULATING OPEN OF URL: ' + url);
    }

    
}

