import { Injectable } from '@angular/core';
import { StompConfig } from '@stomp/ng2-stompjs';


@Injectable()
export class SMQEndpoints {
    public baseSmqPath: string = '/exchange/';
    public rabbitEndpoint = 'ws://localhost:15674/ws';

    constructor() {
    }

    stompConfig: StompConfig = {
        url: this.rabbitEndpoint,
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


}
