using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace VueJSDotnet51_Demo.Structure
{
    public class Struct
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct _PROC_MNG
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string NAME;

            [MarshalAs(UnmanagedType.I4)]
            public int HEARTBEAT;

            [MarshalAs(UnmanagedType.I4)]
            public int SIZE;

            [MarshalAs(UnmanagedType.I4)]
            public int FLAG;

            [MarshalAs(UnmanagedType.I4)]
            public int HFLAG;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string STATUS;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct SHM_PROC
        {

            public byte UFLAG;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public _PROC_MNG[] PROC_MNG;
        }
    }
}
