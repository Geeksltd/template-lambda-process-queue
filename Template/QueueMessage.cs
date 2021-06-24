using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Olive;

namespace App
{
    class QueueMessage : EventBusCommandMessage
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        // ...

        public override async Task Process()
        {
            throw new NotImplementedException();
        }
    }
}
