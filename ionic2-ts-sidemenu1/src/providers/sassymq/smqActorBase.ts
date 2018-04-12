import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { StompConfig, StompService } from '@stomp/ng2-stompjs';
import { Message } from '@stomp/stompjs';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs/Subscription';
import { SMQEndpoints } from './smq.endpoints';
import { SMQStompService } from "./smqStompService";

export class SMQActorBase {

  protected config;
  protected stomp: SMQStompService;
  protected messages: Observable<Message>;
  protected subscription: Subscription;
  protected isSubscribed: boolean;
  public stompConnection: BehaviorSubject<any>;
  protected messageHistory: Array<string> = [];
  protected replyHistory: Array<string> = [];
  protected subscriptionID: string;
  public messageReceived: BehaviorSubject<SMQMessage>;
  public replyReceived: BehaviorSubject<SMQMessage>;
  public smqEndpoints: SMQEndpoints = new SMQEndpoints();

  constructor(allExchange: string, waitForOnReady: boolean = false) {
    this.isSubscribed = false;
    this.stompConnection = new BehaviorSubject(false);
    if (!waitForOnReady) {
        this.stomp = new SMQStompService(this.smqEndpoints.stompConfig);
        this.stomp.state.subscribe(this.onState);
    } else this.stomp = null;
    this.messageReceived = new BehaviorSubject(null);
    this.replyReceived = new BehaviorSubject(null);
    this.smqEndpoints = new SMQEndpoints();

    this.stompConnection.subscribe(
        isConnected => {
            if (isConnected) {
                this.subscribeToAllQueue('/exchange/' + allExchange + '/#');
            } else this.unsubscribeFromAllQueue();
        }
    );
  }

  public onReady(stompConfig: StompConfig = null): BehaviorSubject<any> {

      if (!stompConfig) stompConfig = this.smqEndpoints.stompConfig;
      this.stomp = new SMQStompService(stompConfig);
      this.stomp.state.subscribe(this.onState);

      return this.stompConnection;
  }

  public disconnect() {
      
  }

  protected subscribeToAllQueue(actorAllQueue:string) {
    if (this.isSubscribed) {
      return;
    }
    this.messages = this.stomp.subscribe(actorAllQueue, { 'durable': 'false', 'requeue': 'true' });
    this.subscription = this.messages.subscribe(this.onNext);

    this.stomp.client.onreceive = (message: Message) => {
        this.replyHistory.push(JSON.stringify(message || {}));
        this.replyReceived.next(new SMQMessage(message));
    };

    this.isSubscribed = true;
  }

  protected unsubscribeFromAllQueue() {
    if (!this.isSubscribed) {
      return;
    }
    this.subscription.unsubscribe();
    this.subscription = null;
    if (this.stomp.connected()) this.stomp.client.disconnect();
    this.messages = null;
    this.isSubscribed = false;
  }
  
  public onNext = (message: Message) => {
    this.messageHistory.push(message.body + '\n');
    this.messageReceived.next(new SMQMessage(message));
  }

  public onState = (state: any) => {
    this.stompConnection.next(this.stomp.connected());
  }

  public createPayload = () : any => {
    return {};
  }
  
  listenForReply(messageSubject: BehaviorSubject<SMQMessage>, onReply: (smqMessage: SMQMessage) => void, payload: any = null): void {
      if (onReply) {
          var replyToSubscription = messageSubject.subscribe(replyMessage => {
              if (replyToSubscription) {
                  if (replyMessage.body.PayloadId === payload.PayloadId) {
                      console.log('test');
                      onReply(replyMessage);
                  }

                  replyToSubscription.unsubscribe();
                  replyToSubscription = null;
                }
            });
        }
    }
}

export class SMQMessage {
    public message: Message;
    public body: any;

    constructor(message: Message) {
        this.message = message;
        this.body = {};
        if (message && message.body) this.body = JSON.parse(message.body);
    }
  
}


                        