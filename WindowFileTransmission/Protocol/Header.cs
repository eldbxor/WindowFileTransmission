using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowFileTransmission.Protocol
{
    class Header
    {
        public static Header Parse(byte[] data, int length, int offset = 0)
        {
            var header = new Header();
            header.Deserialize(data, length, offset);
            return header;
        }

        public const int SIZE = (int)ItemOffset.SIZE;

        enum ItemOffset
        {
            CMD_CODE,
            VER = CMD_CODE + 2,
            RFU_1 = VER + 1,
            BODY_SIZE = RFU_1 + 1,
            RFU_2 = BODY_SIZE + 4,

            SIZE = RFU_2 + 8
        }

        public ushort CmdCode { get; set; }
        public byte Ver { get; set; }
        public int BodySize { get; set; }

        public byte[] Serialize()
        {
            byte[] buff = new byte[(int)ItemOffset.SIZE];

            BitConverter.GetBytes(CmdCode).CopyTo(buff, (int)ItemOffset.CMD_CODE);
            buff[(int)ItemOffset.VER] = Ver;
            BitConverter.GetBytes(BodySize).CopyTo(buff, (int)ItemOffset.BODY_SIZE);

            return buff;
        }

        public void Deserialize(byte[] data, int length, int offset = 0)
        {
            if (data == null || data.Length < offset + length || length != (int)ItemOffset.SIZE)
                throw new ArgumentException("Invalid parameters.");

            CmdCode = BitConverter.ToUInt16(data, offset + (int)ItemOffset.CMD_CODE);
            Ver = data[offset + (int)ItemOffset.VER];
            BodySize = BitConverter.ToInt32(data, offset + (int)ItemOffset.BODY_SIZE);
        }
    }
}
