import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';
import { NavParams } from 'ionic-angular';
import { siteMap } from '../../app/app.modules-base';
import { IonicBase } from '../../app/ionic-base';
import { RestAPIService } from '../../providers/rest-api-service';
import { Observable } from 'rxjs/Observable';
import { Subject } from "rxjs/Subject";
import { Storage } from '@ionic/storage';

export class CoursesBase extends IonicBase {

    constructor(public navCtrl: NavController, public navParams: NavParams, public apiSvc: RestAPIService) {
        super()
        this.parent = this.navParams.get("parent");
        this.pages = siteMap;
        this.getCourses();
        
    }
    
    public CoursesState = siteMap['Courses'];

    public pages : any;

    

    public CourseState = siteMap['Course'];
    public parent : any;
    public courses: any = []; 

    

    pop2() { 
        this.navCtrl.pop()
            .then(data => {
                this.navCtrl.pop();
            });
    }

    getCourses() {
        return new Promise(resolve => {
            
            this.apiSvc.getCourses()
                .then(result => { 
                    this.courses = result;
                    resolve(result);
                });
        });
    }

    reload() { return this.getCourses(); }

    addNewCourse() { // 
        var newCourse = {
            "Name" : "New Course " + (this.courses ? this.courses.length + 1 : 1),
            "Description" : ""
        }
        
        this.apiSvc.addNewCourse(newCourse)
            .then(data => {
                
                this.getCourses();
                this.goToState(this.CourseState, data, true);
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

