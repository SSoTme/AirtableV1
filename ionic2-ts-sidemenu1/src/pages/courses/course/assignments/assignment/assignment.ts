import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';
import { NavParams } from 'ionic-angular';
import { siteMap } from '../../../../../app/app.modules-base';
import { RestAPIService } from '../../../../../providers/rest-api-service';
import { AssignmentBase } from './assignment.base';
import { Storage } from '@ionic/storage';

@Component({
    selector: 'page-assignment',
    templateUrl: 'assignment.html'
})
export class Assignment extends AssignmentBase {

    constructor(public navCtrl: NavController, public navParams: NavParams, public apiSvc: RestAPIService) {
        super(navCtrl, navParams, apiSvc); 
    }
}

