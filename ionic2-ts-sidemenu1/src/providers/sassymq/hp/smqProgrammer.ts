import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { SMQActorBase } from '../smqActorBase';
import { SMQEndpoints } from '../smq.endpoints';
import { SMQProgrammerBase } from './smqProgrammer.base';

@Injectable()
export class SMQProgrammer extends SMQProgrammerBase {

    constructor() {
        super();        
    }
}

