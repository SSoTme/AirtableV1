using System;
using System.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;
using SassyMQ.Lib.RabbitMQ;
using SassyMQ.HP.Lib.RabbitMQ;
using SassyMQ.Lib.RabbitMQ.Payload;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SassyMQ.HP.Lib;
using CoreLibrary.SassyMQ;

namespace SassyMQ.HP.Lib.RMQActors
{
    public partial class SMQWorld : HPActorBase
    {
     
        public SMQWorld(bool isAutoConnect = true)
            : base("world.all", isAutoConnect)
        {
        }
        // HomeworkPlus - HP
        public virtual bool Connect(string virtualHost, string username, string password)
        {
            return base.Connect(virtualHost, username, password);
        }   

        protected override void CheckRouting(HPPayload payload) 
        {
            this.CheckRouting(payload, false);
        }

        partial void CheckPayload(HPPayload payload);

        private void Reply(HPPayload payload)
        {
            if (!System.String.IsNullOrEmpty(payload.ReplyTo))
            {
                payload.DirectMessageQueue = this.QueueName;
                this.CheckPayload(payload);
                this.RMQChannel.BasicPublish("", payload.ReplyTo, body: Encoding.UTF8.GetBytes(payload.ToJSonString()));
            }
        }

        protected override void CheckRouting(HPPayload payload, bool isDirectMessage) 
        {
            // if (payload.IsDirectMessage && !isDirectMessage) return;

            try {
                
             if (payload.IsLexiconTerm(LexiconTermEnum.programmer_hello_world)) 
            {
                this.OnProgrammerHelloReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.programmer_goodbye_world)) 
            {
                this.OnProgrammerGoodbyeReceived(payload);
            }
        
            // And can also hear everything which : Programmer hears.
            
             if (payload.IsLexiconTerm(LexiconTermEnum.world_wassup_programmer)) 
            {
                this.OnWorldWassupReceived(payload);
            }
        
            } catch (Exception ex) {
                payload.Exception = ex;
            }
            this.Reply(payload);
        }

        
        /// <summary>
        /// Responds to: Hello - 
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<HPPayload>> ProgrammerHelloReceived;
        protected virtual void OnProgrammerHelloReceived(HPPayload payload)
        {
            this.LogMessage(payload, "Hello - ");
            var plea = new PayloadEventArgs<HPPayload>(payload);
            this.Invoke(this.ProgrammerHelloReceived, plea);
        }
        
        /// <summary>
        /// Responds to: Goodbye - 
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<HPPayload>> ProgrammerGoodbyeReceived;
        protected virtual void OnProgrammerGoodbyeReceived(HPPayload payload)
        {
            this.LogMessage(payload, "Goodbye - ");
            var plea = new PayloadEventArgs<HPPayload>(payload);
            this.Invoke(this.ProgrammerGoodbyeReceived, plea);
        }
        
        /// <summary>
        /// Wassup - 
        /// </summary>
        public void WorldWassup() 
        {
            this.WorldWassup(this.CreatePayload());
        }

        /// <summary>
        /// Wassup - 
        /// </summary>
        public void WorldWassup(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.WorldWassup(payload);
        }

        /// <summary>
        /// Wassup - 
        /// </summary>
        public void WorldWassup(HPPayload payload)
        {
            
            this.SendMessage(payload, "Wassup - ",
            "worldmic", "programmer.general.world.wassup");
        }


        
            // And can also say/hear everything which : Programmer hears.
            
        /// <summary>
        /// Responds to: Wassup - 
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<HPPayload>> WorldWassupReceived;
        protected virtual void OnWorldWassupReceived(HPPayload payload)
        {
            this.LogMessage(payload, "Wassup - ");
            var plea = new PayloadEventArgs<HPPayload>(payload);
            this.Invoke(this.WorldWassupReceived, plea);
        }
        
        /// <summary>
        /// Hello - 
        /// </summary>
        public void ProgrammerHello() 
        {
            this.ProgrammerHello(this.CreatePayload());
        }

        /// <summary>
        /// Hello - 
        /// </summary>
        public void ProgrammerHello(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.ProgrammerHello(payload);
        }

        /// <summary>
        /// Hello - 
        /// </summary>
        public void ProgrammerHello(HPPayload payload)
        {
            
            this.SendMessage(payload, "Hello - ",
            "programmermic", "world.general.programmer.hello");
        }


        
        /// <summary>
        /// Goodbye - 
        /// </summary>
        public void ProgrammerGoodbye() 
        {
            this.ProgrammerGoodbye(this.CreatePayload());
        }

        /// <summary>
        /// Goodbye - 
        /// </summary>
        public void ProgrammerGoodbye(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.ProgrammerGoodbye(payload);
        }

        /// <summary>
        /// Goodbye - 
        /// </summary>
        public void ProgrammerGoodbye(HPPayload payload)
        {
            
            this.SendMessage(payload, "Goodbye - ",
            "programmermic", "world.general.programmer.goodbye");
        }


        

        
        public void LogMessage(HPPayload payload, System.String msg)
        {
            if (IsDebugMode)
            {
                System.Diagnostics.Debug.WriteLine(msg);
                System.Diagnostics.Debug.WriteLine("payload: " + payload.SafeToString());
            }
        }
        
    }
}

                    