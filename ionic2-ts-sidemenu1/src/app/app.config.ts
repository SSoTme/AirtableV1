import { Injectable } from '@angular/core';
import { SMQEndpoints } from '../providers/sassymq/smq.endpoints';
import { StompConfig } from '@stomp/ng2-stompjs';

@Injectable()
export class AppConfig {
    config = {
        name: 'SassyMQSeed',
        title: 'SassyMQSeed',
        apiRootUri: 'http://localhost:64110/api/',
        debug: true,
        /**
         * In-app constants
         */
        settings: {
            colors: {
                'white': '#fff',
                'black': '#000',
                'gray-light': '#999',
                'gray-lighter': '#eee',
                'gray': '#666',
                'gray-dark': '#343434',
                'gray-darker': '#222',
                'gray-semi-light': '#777',
                'gray-semi-lighter': '#ddd',
                'brand-primary': '#5d8fc2',
                'brand-success': '#64bd63',
                'brand-warning': '#f0b518',
                'brand-danger': '#dd5826',
                'brand-info': '#5dc4bf'
            },
            screens: {
                'xs-max': 543,
                'sm-min': 544,
                'sm-max': 767,
                'md-min': 768,
                'md-max': 991,
                'lg-min': 992,
                'lg-max': 1199,
                'xl-min': 1200
            }
        },
        state: {
            'nav-static': true,
            'auth': { 'AuthToken': '', 'Username': '', 'IsAuthenticated': false },
        }
    };

    stompConfig: StompConfig = {
        url: (new SMQEndpoints()).rabbitEndpoint,
        headers: {
            // ack: 'none',
            login: 'smqPublic',
            passcode: 'smqPublic',
            host: 'MSSassyMQSeed',
        },
        heartbeat_in: 10000,
        heartbeat_out: 10000,
        reconnect_delay: 5000,
        debug: true
    };
    

    getLocalState(itemName: string): any {
        let stateLocal = JSON.parse(localStorage.getItem('state'));
        return stateLocal[itemName];
    }

    saveStateItem(itemName: string, value: any): void {
        this.config.state[itemName] = value;
        let stateLocal = JSON.parse(localStorage.getItem('state'));
        stateLocal[itemName] = value;
        localStorage.setItem('state', JSON.stringify(stateLocal));
    }

    getConfig(): Object {
        return this.config;
    }
}
