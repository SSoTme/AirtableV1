using System;

using System.Linq;
using System.Collections.Generic;
using System.Collections;
using SassyMQ.Lib.RabbitMQ;

namespace SassyMQ.HP.Lib.RabbitMQ
{
    public class LexiconTerm : LexiconTerm<LexiconTermEnum> { }

    public partial class Lexicon  : IEnumerable<LexiconTerm>
    {
        public static Lexicon Terms = new Lexicon();
        protected static new Dictionary<LexiconTermEnum, LexiconTerm> TermsByKey { get; set; }

        public LexiconTerm this[LexiconTermEnum termKey]
        {
            get { return TermsByKey[termKey]; }
        }

        public LexiconTerm FromRoutingKey(string routingKey)
        {
            return Lexicon.TermsByKey.Values.FirstOrDefault(first => first.RoutingKey == routingKey);
        }


        public IEnumerator<LexiconTerm> GetEnumerator()
        {
            return Lexicon.TermsByKey.Values.GetEnumerator();
        }

        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Lexicon.TermsByKey.Values.GetEnumerator();
        }

        static Lexicon()
        {
            Lexicon.TermsByKey = new Dictionary<LexiconTermEnum, LexiconTerm>();
            
            Lexicon.TermsByKey[LexiconTermEnum.programmer_hello_world] = new LexiconTerm() {
                Term = LexiconTermEnum.programmer_hello_world,
                Sender = "programmer",
                Verb = "hello",
                Receiver = "world",
                Category = "general"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.world_wassup_programmer] = new LexiconTerm() {
                Term = LexiconTermEnum.world_wassup_programmer,
                Sender = "world",
                Verb = "wassup",
                Receiver = "programmer",
                Category = "general"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.programmer_goodbye_world] = new LexiconTerm() {
                Term = LexiconTermEnum.programmer_goodbye_world,
                Sender = "programmer",
                Verb = "goodbye",
                Receiver = "world",
                Category = "general"
            };
            
        }
    }
}