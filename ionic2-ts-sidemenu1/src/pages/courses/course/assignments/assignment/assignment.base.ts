import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';
import { NavParams } from 'ionic-angular';
import { siteMap } from '../../../../../app/app.modules-base';
import { IonicBase } from '../../../../../app/ionic-base';
import { RestAPIService } from '../../../../../providers/rest-api-service';
import { Observable } from 'rxjs/Observable';
import { Subject } from "rxjs/Subject";
import { Storage } from '@ionic/storage';

export class AssignmentBase extends IonicBase {

    constructor(public navCtrl: NavController, public navParams: NavParams, public apiSvc: RestAPIService) {
        super()
        this.parent = this.navParams.get("parent");
        this.pages = siteMap;
        
        this.assignment = this.navParams.get('assignment') || this.assignment;
        this.getAssignment();
        this.editMode = this.navParams.get("editMode");
    }
    
    public AssignmentState = siteMap['Assignment'];

    public pages : any;

    public parent : any;

    
    public assignment: any = {};
    ;
    public canDelete: any = true;
    public editMode = false;

    pop() {
        this.navCtrl.pop();
    }

    getAssignment() {
        return new Promise(resolve => {
            let assignment = this.navParams.get("assignment");
            if (!assignment) assignment = this.navParams.get("assignment");

            
            this.apiSvc.getAssignment(assignment)
                .then(data => {
                    this.assignment = data;
                    this.canDelete = true;

                    // Check if they can actually delete
                    

                    resolve(data);
                });
            
        });
    }
    
    reload() { return this.getAssignment(); }

    updateAssignment(theAssignmentToUpdate) {
            

        this.apiSvc.updateAssignment(theAssignmentToUpdate)
            .then(data => {
                 
                this.parent
                    .reload()
                    .then(parentResult => {
                        this.getAssignment();
                        this.editMode = false;
                    });
            });
            
    }


    deleteAssignment() {
        

        this.apiSvc.deleteAssignment(this.assignment)
            .then(data => {
                this.parent
                    .reload()
                    .then(parentResult => {
                         this.navCtrl.pop();
                    });
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

