import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';
import { NavParams } from 'ionic-angular';
import { siteMap } from '../../../app/app.modules-base';
import { IonicBase } from '../../../app/ionic-base';
import { RestAPIService } from '../../../providers/rest-api-service';
import { Observable } from 'rxjs/Observable';
import { Subject } from "rxjs/Subject";
import { Storage } from '@ionic/storage';

export class EmailBase extends IonicBase {

    constructor(public navCtrl: NavController, public navParams: NavParams, public apiSvc: RestAPIService) {
        super()
        this.parent = this.navParams.get("parent");
        this.pages = siteMap;
        
        
    }
    
    public EmailState = siteMap['Email'];

    public pages : any;

    public parent : any;

    

    
    goToRootState(state) : Promise<any> {
        return this.goToState(state, true);
    }
    goToState(state, setRoot = false) : Promise<any> {
        if (setRoot) {
            return this.navCtrl.setRoot(state.component, { parent : this });
        } else {
            return this.navCtrl.push(state.component, { parent : this });
        }
    }    

    goToUrl(url) {
        console.log('SIMULATING OPEN OF URL: ' + url);
    }

    
}

