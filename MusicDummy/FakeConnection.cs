using Mirror;
using System;

namespace MusicDummy
{
    public class FakeConnection : NetworkConnectionToClient
    {
        public FakeConnection(int networkConnectionId) : base(networkConnectionId)
        {

        }
        public override string address => "localhost";
        public override void Send(ArraySegment<byte> segment, int channelId = 0)
        {

        }
        public override void Disconnect()
        {
        }
    }
}
