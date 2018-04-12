import { StompService } from "@stomp/ng2-stompjs";
import * as Stomp from '@stomp/stompjs';
import { StompConfig } from "@stomp/ng2-stompjs";

export class SMQStompService extends StompService {

    public client: Stomp.Client;

    constructor(config: StompConfig) {
        super(config);
    }

}
                        