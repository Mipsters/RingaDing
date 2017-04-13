using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace RingaDing
{
    class SystemDevices
    {
        [DllImport("winmm.dll", SetLastError = true)]
        static extern uint waveOutGetNumDevs();

        [DllImport("winmm.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern uint waveOutGetDevCaps(uint hwo, ref WAVEOUTCAPS pwoc, uint cbwoc);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct WAVEOUTCAPS
        {
            public ushort wMid;
            public ushort wPid;
            public uint vDriverVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szPname;
            public uint dwFormats;
            public ushort wChannels;
            public ushort wReserved1;
            public uint dwSupport;
        }

        public static string[] GetSoundDevices()
        {
            uint devices = waveOutGetNumDevs();
            string[] result = new string[devices];
            WAVEOUTCAPS caps = new WAVEOUTCAPS();

            for (uint i = 0; i < devices; i++)
            {
                waveOutGetDevCaps(i, ref caps, (uint)Marshal.SizeOf(caps));
                result[i] = caps.szPname;
            }

            return result;
        }
    }
}