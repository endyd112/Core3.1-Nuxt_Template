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


        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct CURRENT_STATUS
        {
            public SAH_STATUS INFO;

            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I8, SizeConst = 2)]
            public long[] UPDATETIME;

            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 2)]
            public int[] VALUE;

            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 2)]
            public uint[] PSTATUS;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string QUALITY;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string TIME_QUALITY;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string MSG;

            [MarshalAs(UnmanagedType.I4)]
            public uint STATUS;

            [MarshalAs(UnmanagedType.I4)]
            public uint ACC_CNT;

            [MarshalAs(UnmanagedType.I1)]
            public bool isALARM;

            [MarshalAs(UnmanagedType.I4)]
            public uint REF_NUM;

            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = 2)]
            public bool[] SIG_ERR;

            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 2)]
            public int[] CONTROL_OPTION;

        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct SAH_STATUS
        {
            [MarshalAs(UnmanagedType.I4)]
            public uint ID;

            /// <summary>
            /// !! 한글처리 !! 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPStr, SizeConst = 256)]
            public byte[] POINT_NAME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string IED_PD_NAME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
            public string IED_IN_SIGNAME1;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
            public string IED_IN_SIGNAME2;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
            public string IED_OUT_SIGNAME1;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
            public string IED_OUT_SIGNAME2;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string IED_IP;

            [MarshalAs(UnmanagedType.I4)]
            public uint CTRLMODE;

            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 8)]
            public int[] BNRINFO_MSG;

            /// <summary>
            /// 8 * 16
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string SYMBOL_COLOR;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DEV_NAME;

            [MarshalAs(UnmanagedType.I4)]
            public uint DEV_TYPE;

            [MarshalAs(UnmanagedType.I4)]
            public uint POINT_TYPE;

            [MarshalAs(UnmanagedType.I4)]
            public uint SUB_TYPE;

            [MarshalAs(UnmanagedType.I4)]
            public uint ALARM_LEVEL;

            [MarshalAs(UnmanagedType.I1)]
            public bool TAG_ALARM;

            [MarshalAs(UnmanagedType.I1)]
            public bool TAG_CTRL;

            [MarshalAs(UnmanagedType.I1)]
            public bool TAG_SOE;

            [MarshalAs(UnmanagedType.I1)]
            public bool TAG_EVT;

            [MarshalAs(UnmanagedType.I4)]
            public uint IND_ONOFF;

            [MarshalAs(UnmanagedType.I1)]
            public bool BNRINFO;

            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = 2)]
            public bool[] B_FLAG;

            [MarshalAs(UnmanagedType.I4)]
            public uint TAG_TRIPCLOSE;

            [MarshalAs(UnmanagedType.I4)]
            public uint CTRL_TIMEOUT;

            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 2)]
            public int[] LOAD_PT;

            [MarshalAs(UnmanagedType.I4)]
            public uint RTU_IN_PT;

            [MarshalAs(UnmanagedType.I4)]
            public uint RTU_OUT_PT;

            [MarshalAs(UnmanagedType.I4)]
            public uint CALC_TYPE;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string CALC_FMLA;

            /// <summary>
            /// 8 * 8
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string CALC_AS_PT;

        }






    }
}
