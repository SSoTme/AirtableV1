import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { SMQActorBase, SMQMessage  } from '../smqActorBase';
import { Message } from "@stomp/stompjs";
import { UUID } from "angular2-uuid";

@Injectable()
export class SMQProgrammerBase extends SMQActorBase {


    
    public onWorldWassup: BehaviorSubject<SMQMessage> = new BehaviorSubject(null);

    
    protected onReplyToProgrammerHello: BehaviorSubject<SMQMessage> = new BehaviorSubject(null);
    protected onReplyToProgrammerGoodbye: BehaviorSubject<SMQMessage> = new BehaviorSubject(null);

    constructor() {
        super("programmer.all");

        this.messageReceived.subscribe(smqMessage => {
            if (!smqMessage) return;
            var message = smqMessage.message;
            var body = smqMessage.body;

            if (message && message.headers && message.headers['destination']) {
                var dest = message.headers['destination'];
                var lexiconTerm = body.LexiconTerm || {'RoutingKey' : body.RoutingKey};
                 if (dest == '/exchange/worldmic/programmer.general.world.wassup') { this.onWorldWassup.next(smqMessage); }
                
            }
        });


       this.replyReceived.subscribe(smqMessage => {
            if (!smqMessage) return;
            var message = smqMessage.message;
            var body = smqMessage.body;

            var lexiconTerm = body.LexiconTerm || { 'RoutingKey': body.RoutingKey };
            
            if (lexiconTerm.RoutingKey === "world.general.programmer.hello") { this.onReplyToProgrammerHello.next(smqMessage); }
            if (lexiconTerm.RoutingKey === "world.general.programmer.goodbye") { this.onReplyToProgrammerGoodbye.next(smqMessage); }
       });       
    }

    
        /** 
        */
        Hello(payload: any, onHelloReply: (smqMessage: SMQMessage) => void): void {
        payload.PayloadId = UUID.UUID();
        this.listenForReply(this.onReplyToProgrammerHello, onHelloReply, payload);
        this.stomp.publish('/exchange/programmermic/world.general.programmer.hello', JSON.stringify(payload || "{}"), { 'reply-to': '/temp-queue/response-queue' });
    }

    
        /** 
        */
        Goodbye(payload: any, onGoodbyeReply: (smqMessage: SMQMessage) => void): void {
        payload.PayloadId = UUID.UUID();
        this.listenForReply(this.onReplyToProgrammerGoodbye, onGoodbyeReply, payload);
        this.stomp.publish('/exchange/programmermic/world.general.programmer.goodbye', JSON.stringify(payload || "{}"), { 'reply-to': '/temp-queue/response-queue' });
    }

    
}

                        