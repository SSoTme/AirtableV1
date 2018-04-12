import { Component } from '@angular/core';
import { Storage } from '@ionic/storage';
import { Subject } from "rxjs/Subject";
import { NavController } from "ionic-angular";

export class IonicBase {
    protected defaultAuthToken = {
        Email: "",
        UserName: "Guest",
        IsAuthenticated: false
    }

    protected authtoken: any = this.defaultAuthToken;

    protected onAuthtoken: Subject<any> = new Subject();

    constructor() {
        this.onAuthtoken.next(this.authtoken);

    }

    makeCurrentRoot(navCtrl: NavController) {
        var currentIndex = navCtrl.getActive().index + 1;
        if (currentIndex > 0) {
            navCtrl.remove(0, currentIndex);
        }
    }
}