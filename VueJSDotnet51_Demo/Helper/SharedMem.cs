using System;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using static VueJSDotnet51_Demo.Structure.Struct;

namespace VueJSDotnet51_Demo.Helper
{
    public class SharedMem
    {
        public static IntPtr hMemSts = IntPtr.Zero;
        public static IntPtr hMemProc = IntPtr.Zero;


        static IntPtr GetMappedFileHandle(string hName)
        {
            IntPtr ret = IntPtr.Zero;

            using (var mmf = MemoryMappedFile.OpenExisting(hName))
            {
                using (var accessor = mmf.CreateViewAccessor())
                {

                    if (accessor.CanRead)
                    {

                        unsafe
                        {
                            byte* poke = null;

                            if (accessor.SafeMemoryMappedViewHandle.IsInvalid) throw new Exception("[ ERROR ] " + hName + " - Accessor SafeMemoryMappedViewHandle IsInvalid");
                            accessor.SafeMemoryMappedViewHandle.AcquirePointer(ref poke); // get safe handle
                            ret = (IntPtr)poke;
                        }
                    }
                    else
                    {
                        throw new Exception("[ ERROR ] " + hName + " - Accessor Read Failed");
                    }

                }
            }

            return ret;
        }

        public static void init()
        {
            hMemProc = GetMappedFileHandle("MEM_PROC");
            if (hMemProc == null) throw new Exception("MEM_PROC get handle failed.");

            hMemSts = GetMappedFileHandle("MEM_STS");
            if (hMemSts == null) throw new Exception("MEM_STS get handle failed.");
        }

        public static SHM_PROC GetSHM_PROC()
        {
            return (SHM_PROC)Marshal.PtrToStructure(hMemProc, typeof(SHM_PROC));
        }

    }
}
