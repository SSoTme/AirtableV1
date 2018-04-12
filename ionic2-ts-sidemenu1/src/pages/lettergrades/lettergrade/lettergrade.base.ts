import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';
import { NavParams } from 'ionic-angular';
import { siteMap } from '../../../app/app.modules-base';
import { IonicBase } from '../../../app/ionic-base';
import { RestAPIService } from '../../../providers/rest-api-service';
import { Observable } from 'rxjs/Observable';
import { Subject } from "rxjs/Subject";
import { Storage } from '@ionic/storage';

export class LetterGradeBase extends IonicBase {

    constructor(public navCtrl: NavController, public navParams: NavParams, public apiSvc: RestAPIService) {
        super()
        this.parent = this.navParams.get("parent");
        this.pages = siteMap;
        
        this.letterGrade = this.navParams.get('lettergrade') || this.letterGrade;
        this.getLetterGrade();
        this.editMode = this.navParams.get("editMode");
    }
    
    public LetterGradeState = siteMap['LetterGrade'];

    public pages : any;

    public parent : any;

    
    public lettergrade: any = {};
    
    public letterGrade: any = {};
    public canDelete: any = true;
    public editMode = false;

    pop() {
        this.navCtrl.pop();
    }

    getLetterGrade() {
        return new Promise(resolve => {
            let lettergrade = this.navParams.get("lettergrade");
            if (!lettergrade) lettergrade = this.navParams.get("letterGrade");

            
            this.apiSvc.getLetterGrade(lettergrade)
                .then(data => {
                    this.lettergrade = data;
                    this.canDelete = true;

                    // Check if they can actually delete
                    

                    resolve(data);
                });
            
        });
    }
    
    reload() { return this.getLetterGrade(); }

    updateLetterGrade(theLetterGradeToUpdate) {
            

        this.apiSvc.updateLetterGrade(theLetterGradeToUpdate)
            .then(data => {
                 
                this.parent
                    .reload()
                    .then(parentResult => {
                        this.getLetterGrade();
                        this.editMode = false;
                    });
            });
            
    }


    deleteLetterGrade() {
        

        this.apiSvc.deleteLetterGrade(this.lettergrade)
            .then(data => {
                this.parent
                    .reload()
                    .then(parentResult => {
                         this.navCtrl.pop();
                    });
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

