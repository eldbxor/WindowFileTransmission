using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowFileTransmission.Protocol
{
    interface IPacket
    {
        ushort CmdCode { get; }
        int Size { get; }
        byte Ver { get; }

        byte[] Serialize();
        void Deserialize(byte[] data, int length, int offset = 0);
    }
}
