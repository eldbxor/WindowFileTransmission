using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowFileTransmission.Protocol
{
    class FileInfo
    {
        public const ushort CMD_CODE = 1;

        public class Request : IPacket
        {
            public ushort CmdCode { get { return CMD_CODE; } }
            public int Size { get { return FileName == null ? (int)ItemOffset.MIN_SIZE : (int)ItemOffset.MIN_SIZE + FileName.Length; } }
            enum ItemOffset
            {
                VER,
                FILE_SIZE = VER + 1,
                RFU_1 = FILE_SIZE + 4,
                FILE_NAME = RFU_1 + 11,
                MIN_SIZE = FILE_NAME
            }

            public byte Ver { get; set; }
            public int FileSize { get; set; }
            public byte[] FileName { get; set; }
            

            public byte[] Serialize()
            {
                byte[] buff;
                if (FileName == null)
                {
                    buff = new byte[(int)ItemOffset.MIN_SIZE];
                    buff[(int)ItemOffset.VER] = Ver;
                    Buffer.BlockCopy(BitConverter.GetBytes(FileSize), 0, buff, (int)ItemOffset.FILE_SIZE, FileSize);

                    return buff;
                }

                buff = new byte[(int)ItemOffset.MIN_SIZE + FileName.Length];
                Buffer.BlockCopy(BitConverter.GetBytes(FileSize), 0, buff, (int)ItemOffset.FILE_SIZE, FileSize);
                Buffer.BlockCopy(FileName, 0, buff, (int)ItemOffset.FILE_NAME, FileName.Length);

                return buff;
            }

            public void Deserialize(byte[] data, int length, int offset = 0)
            {
                if (data == null || data.Length < offset || length < 0)
                    throw new ArgumentException("Invalid parameters.");

                Ver = data[offset + (int)ItemOffset.VER];
                this.FileName = new byte[length - (int)ItemOffset.FILE_NAME];
                Buffer.BlockCopy(data, offset + (int)ItemOffset.FILE_NAME, this.FileName, 0, this.FileName.Length);
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
