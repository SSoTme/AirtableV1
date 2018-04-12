import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { SMQActorBase } from '../smqActorBase';
import { SMQEndpoints } from '../smq.endpoints';
import { SMQWorldBase } from './smqWorld.base';

@Injectable()
export class SMQWorld extends SMQWorldBase {

    constructor() {
        super();        
    }
}

