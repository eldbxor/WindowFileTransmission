using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowFileTransmission.Protocol
{
    class TransmissionMode
    {
        public const ushort CMD_CODE = 0;
        
        public class Request : IPacket
        {
            public ushort CmdCode { get { return CMD_CODE; } }
            public int Size { get { return (int)ItemOffset.SIZE; } }

            enum ItemOffset
            {
                VER,
                MODE = VER + 1,
                RFU_1 = MODE + 1,
                SIZE = RFU_1 + 14
            }

            public byte Ver { get; set; }
            public byte Mode { get; set; }

            public byte[] Serialize()
            {
                byte[] buff = new byte[(int)ItemOffset.SIZE]
                {
                    Mode,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00  // RFU
                };

                return buff;
            }

            public void Deserialize(byte[] data, int length, int offset = 0)
            {
                if (data == null || data.Length < offset || length < 0)
                    throw new ArgumentException("Invalid parameters.");

                Mode = data[offset + (int)ItemOffset.MODE];
            }
        }

        public class Response : IPacket
        {
            public ushort CmdCode { get { return CMD_CODE; } }
            public int Size { get { return (int)ItemOffset.SIZE; } }

            enum ItemOffset
            {
                VER,
                RESULT = VER + 1,
                RFU_1 = RESULT + 1,
                SIZE = RFU_1 + 14
            }

            public byte Ver { get; set; }
            public byte Result { get; set; }

            public byte[] Serialize()
            {
                return new byte[(int)ItemOffset.SIZE]
                {
                    Ver, // Version
                    Result, // Result
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00  // RFU
                };
            }

            public void Deserialize(byte[] data, int length, int offset = 0)
            {
                if (data == null || data.Length < offset + length || length != (int)ItemOffset.SIZE)
                    throw new ArgumentException("Invalid parameters.");

                Ver = data[offset + (int)ItemOffset.VER];
                Result = data[offset + (int)ItemOffset.RESULT];
            }
        }
    }
}
