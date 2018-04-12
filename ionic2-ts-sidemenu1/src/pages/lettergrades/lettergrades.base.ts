import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';
import { NavParams } from 'ionic-angular';
import { siteMap } from '../../app/app.modules-base';
import { IonicBase } from '../../app/ionic-base';
import { RestAPIService } from '../../providers/rest-api-service';
import { Observable } from 'rxjs/Observable';
import { Subject } from "rxjs/Subject";
import { Storage } from '@ionic/storage';

export class LetterGradesBase extends IonicBase {

    constructor(public navCtrl: NavController, public navParams: NavParams, public apiSvc: RestAPIService) {
        super()
        this.parent = this.navParams.get("parent");
        this.pages = siteMap;
        this.getLetterGrades();
        
    }
    
    public LetterGradesState = siteMap['LetterGrades'];

    public pages : any;

    

    public LetterGradeState = siteMap['LetterGrade'];
    public parent : any;
    public letterGrades: any = []; 

    

    pop2() { 
        this.navCtrl.pop()
            .then(data => {
                this.navCtrl.pop();
            });
    }

    getLetterGrades() {
        return new Promise(resolve => {
            
            this.apiSvc.getLetterGrades()
                .then(result => { 
                    this.letterGrades = result;
                    resolve(result);
                });
        });
    }

    reload() { return this.getLetterGrades(); }

    addNewLetterGrade() { // 
        var newLetterGrade = {
            "Name" : "New LetterGrade " + (this.letterGrades ? this.letterGrades.length + 1 : 1),
            "Description" : ""
        }
        
        this.apiSvc.addNewLetterGrade(newLetterGrade)
            .then(data => {
                
                this.getLetterGrades();
                this.goToState(this.LetterGradeState, data, true);
            });
            
    }
    

    

    
    goToRootState(state, letterGrade = {}, editMode = false) : Promise<any> {
        return this.goToState(state, letterGrade, editMode, true);
    }

    goToState(state, letterGrade = {}, editMode = false, setRoot = false)  : Promise<any> {
        if (setRoot) {
            return this.navCtrl.setRoot(state.component, { lettergrade : letterGrade, parent: this, editMode: editMode });
        } else {
            return this.navCtrl.push(state.component, { lettergrade : letterGrade, parent: this, editMode: editMode });
        }
    }

    goToUrl(url) {
        console.log('SIMULATING OPEN OF URL: ' + url);
    }

    
}

