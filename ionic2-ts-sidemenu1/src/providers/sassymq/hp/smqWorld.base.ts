import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { SMQActorBase, SMQMessage  } from '../smqActorBase';
import { Message } from "@stomp/stompjs";
import { UUID } from "angular2-uuid";

@Injectable()
export class SMQWorldBase extends SMQActorBase {


    
    public onProgrammerHello: BehaviorSubject<SMQMessage> = new BehaviorSubject(null);
    public onProgrammerGoodbye: BehaviorSubject<SMQMessage> = new BehaviorSubject(null);
    public onWorldWassup: BehaviorSubject<SMQMessage> = new BehaviorSubject(null);

    
    protected onReplyToWorldWassup: BehaviorSubject<SMQMessage> = new BehaviorSubject(null);
    protected onReplyToProgrammerHello: BehaviorSubject<SMQMessage> = new BehaviorSubject(null);
    protected onReplyToProgrammerGoodbye: BehaviorSubject<SMQMessage> = new BehaviorSubject(null);

    constructor() {
        super("world.all");

        this.messageReceived.subscribe(smqMessage => {
            if (!smqMessage) return;
            var message = smqMessage.message;
            var body = smqMessage.body;

            if (message && message.headers && message.headers['destination']) {
                var dest = message.headers['destination'];
                var lexiconTerm = body.LexiconTerm || {'RoutingKey' : body.RoutingKey};
                 if (dest == '/exchange/programmermic/world.general.programmer.hello') { this.onProgrammerHello.next(smqMessage); }
                else if (dest == '/exchange/programmermic/world.general.programmer.goodbye') { this.onProgrammerGoodbye.next(smqMessage); }
                
            // Can also say what 'Programmer' can say.
             if (dest == '/exchange/worldmic/programmer.general.world.wassup') { this.onWorldWassup.next(smqMessage); }
                
            }
        });


       this.replyReceived.subscribe(smqMessage => {
            if (!smqMessage) return;
            var message = smqMessage.message;
            var body = smqMessage.body;

            var lexiconTerm = body.LexiconTerm || { 'RoutingKey': body.RoutingKey };
            
            if (lexiconTerm.RoutingKey === "programmer.general.world.wassup") { this.onReplyToWorldWassup.next(smqMessage); }
            if (lexiconTerm.RoutingKey === "world.general.programmer.hello") { this.onReplyToProgrammerHello.next(smqMessage); }
            if (lexiconTerm.RoutingKey === "world.general.programmer.goodbye") { this.onReplyToProgrammerGoodbye.next(smqMessage); }
       });       
    }

    
        /** 
        */
        Wassup(payload: any, onWassupReply: (smqMessage: SMQMessage) => void): void {
        payload.PayloadId = UUID.UUID();
        this.listenForReply(this.onReplyToWorldWassup, onWassupReply, payload);
        this.stomp.publish('/exchange/worldmic/programmer.general.world.wassup', JSON.stringify(payload || "{}"), { 'reply-to': '/temp-queue/response-queue' });
    }

    
           // Can also say what 'Programmer' can say.
           
        /** 
        */
        ProgrammerHello(payload: any, onHelloReply: (smqMessage: SMQMessage) => void): void {
        payload.PayloadId = UUID.UUID();
        this.listenForReply(this.onReplyToProgrammerHello, onHelloReply, payload);
        this.stomp.publish('/exchange/programmermic/world.general.programmer.hello', JSON.stringify(payload || "{}"), { 'reply-to': '/temp-queue/response-queue' });
    }

    
        /** 
        */
        ProgrammerGoodbye(payload: any, onGoodbyeReply: (smqMessage: SMQMessage) => void): void {
        payload.PayloadId = UUID.UUID();
        this.listenForReply(this.onReplyToProgrammerGoodbye, onGoodbyeReply, payload);
        this.stomp.publish('/exchange/programmermic/world.general.programmer.goodbye', JSON.stringify(payload || "{}"), { 'reply-to': '/temp-queue/response-queue' });
    }

    
}

                        