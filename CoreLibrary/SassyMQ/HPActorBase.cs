

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;
using SassyMQ.Lib.RabbitMQ;
using SassyMQ.HP.Lib.RabbitMQ;
using SassyMQ.Lib.RabbitMQ.Payload;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SassyMQ.HP.Lib.RMQActors;

namespace SassyMQ.HP.Lib
{
    public abstract class HPActorBase : SMQActorBase<HPPayload> 
    {
        public HPActorBase(string allExchange, bool isAutoConnect) : base(allExchange, isAutoConnect)
        {
        }
    }
}