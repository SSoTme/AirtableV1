import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';
import { NavParams } from 'ionic-angular';
import { siteMap } from '../../../app/app.modules-base';
import { IonicBase } from '../../../app/ionic-base';
import { RestAPIService } from '../../../providers/rest-api-service';
import { Observable } from 'rxjs/Observable';
import { Subject } from "rxjs/Subject";
import { Storage } from '@ionic/storage';

export class CourseBase extends IonicBase {

    constructor(public navCtrl: NavController, public navParams: NavParams, public apiSvc: RestAPIService) {
        super()
        this.parent = this.navParams.get("parent");
        this.pages = siteMap;
        
        this.course = this.navParams.get('course') || this.course;
        this.getCourse();
        this.editMode = this.navParams.get("editMode");
    }
    
    public CourseState = siteMap['Course'];

    public pages : any;

    

    public AssignmentsState = siteMap['Assignments'];
    public parent : any;

    
    public course: any = {};
    ;
    public canDelete: any = true;
    public editMode = false;

    pop() {
        this.navCtrl.pop();
    }

    getCourse() {
        return new Promise(resolve => {
            let course = this.navParams.get("course");
            if (!course) course = this.navParams.get("course");

            
            this.apiSvc.getCourse(course)
                .then(data => {
                    this.course = data;
                    this.canDelete = true;

                    // Check if they can actually delete
                    
                    
                    if (this.course.Assignments && this.course.Assignments.length > 0) {
                        this.canDelete = false;
                    }
                    

                    resolve(data);
                });
            
        });
    }
    
    reload() { return this.getCourse(); }

    updateCourse(theCourseToUpdate) {
            

        this.apiSvc.updateCourse(theCourseToUpdate)
            .then(data => {
                 
                this.parent
                    .reload()
                    .then(parentResult => {
                        this.getCourse();
                        this.editMode = false;
                    });
            });
            
    }


    deleteCourse() {
        

        this.apiSvc.deleteCourse(this.course)
            .then(data => {
                this.parent
                    .reload()
                    .then(parentResult => {
                         this.navCtrl.pop();
                    });
            });
            
    }

    
    goToRootState(state, course = {}, editMode = false) : Promise<any> {
        return this.goToState(state, course, editMode, true);
    }

    goToState(state, course = {}, editMode = false, setRoot = false)  : Promise<any> {
        if (setRoot) {
            return this.navCtrl.setRoot(state.component, { course : course, parent: this, editMode: editMode });
        } else {
            return this.navCtrl.push(state.component, { course : course, parent: this, editMode: editMode });
        }
    }

    goToUrl(url) {
        console.log('SIMULATING OPEN OF URL: ' + url);
    }

    
}

