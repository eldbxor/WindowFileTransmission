using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowFileTransmission.Protocol
{
    class SendFile
    {
        public const ushort CMD_CODE = 2;

        public class Request : IPacket
        {
            public ushort CmdCode { get { return CMD_CODE; } }
            public int Size { get { return FileName == null ? (int)ItemOffset.MIN_SIZE : (int)ItemOffset.MIN_SIZE + FileName.Length; } }

            enum ItemOffset
            {
                VER,
                RFU_1 = VER + 1,
                FILE_NAME = RFU_1 + 15,
                MIN_SIZE = FILE_NAME
            }

            public byte Ver { get; set; }
            public byte[] FileName { get; set; }

            public byte[] Serialize()
            {
                if (FileName == null)
                {
                    return new byte[(int) ItemOffset.MIN_SIZE]
                    {
                        Ver, // Version
                        
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00  // RFU
                    }
                }
            }

            public void Deserialize(byte[] data, int length, int offset = 0)
            {

            }
        }

        public class Response : IPacket
        {

        }
    }
}
