using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWatcher
{
    class UtilTool
    {
        private static CaptureDeviceList devices = null;
        private static string[] hex = new string[] { "0", "1", "2", "3", "4",
        "5","6","7","8","9","A","B","C","D","E","F"};

        public static CaptureDeviceList searchDevice()
        {
            devices = CaptureDeviceList.Instance;
            return devices;
        }

        public static string convertToHexText(byte[] data)
        {
            StringBuilder builder = new StringBuilder();
            int i = 0, end = 0;

            //builder.Append(data.Count().ToString() + "\n");

            for (; i < data.Count(); i += 16)
            {
                int high = (i >> 8) & 0x000000ff;
                int low = i & 0x000000ff;
                builder.Append(hex[0x0f & (high >> 4)]);
                builder.Append(hex[0x0f & high]);
                builder.Append(hex[0x0f & (low >> 4)]);
                builder.Append(hex[0x0f & low]);
                builder.Append(" ");

                //builder.Append(i.ToString("X4"));
                
                if (i + 16 >= data.Count())
                {
                    end = data.Count();
                }
                else
                {
                    end = i + 16;
                }

                for (int j = i; j < end; j++)
                {
                    if (j % 8 == 0)
                    {
                        builder.Append(" ");
                    }
                    builder.Append(hex[0x0f & (data[j] >> 4)]);
                    builder.Append(hex[0x0f & data[j]]);
                    builder.Append(" ");
                }

                if (i + 16 >= data.Count())
                {
                    for (int j = end; j < i + 16; j++)
                    {
                        if (j % 8 == 0)
                        {
                            builder.Append(" ");
                        }
                        builder.Append("  ");
                        builder.Append(" ");
                    }
                }

                builder.Append(" ");

                for (int j = i; j < end; j++)
                {
                    if (j % 8 == 0)
                    {
                        builder.Append(" ");
                    }

                    if (data[j] >= 33 && data[j] <= 126)
                    {
                        builder.Append((char)data[j] + " ");
                    }
                    else
                    {
                        builder.Append(".");
                    }
                }

                builder.Append("\n");
            }

            return builder.ToString();
        }

        public static String HWAddressFormat(String hwaddress)
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (char c in hwaddress)
            {
                if (i % 2 != 0 && i < hwaddress.Count() - 1)
                {
                    builder.Append(c + ":");
                }
                else
                {
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }
    }
}
