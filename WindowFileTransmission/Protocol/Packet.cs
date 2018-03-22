using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowFileTransmission.Protocol
{
    class Packet
    {
        public static byte[] Make(IPacket packet, byte version = 0)
        {
            if (packet == null)
                throw new ArgumentException("Invalid parameter.");

            var header = new Header
            {
                Ver = version,
                CmdCode = packet.CmdCode,
                BodySize = packet.Size
            };

            byte[] buff = new byte[Header.SIZE + packet.Size];
            header.Serialize().CopyTo(buff, 0);
            packet.Serialize().CopyTo(buff, Header.SIZE);

            return buff;
        }
    }
}
