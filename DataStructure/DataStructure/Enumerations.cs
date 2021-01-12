using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public enum MessageType
    {
        Incoming,
        Outgoing,
        Service
    }

    public enum MessageTopic
    {
        Subscribe,
        Error,
        Update
    }
}
