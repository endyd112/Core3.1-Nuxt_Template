using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJSDotnet51_Demo.Helper
{
    /// <summary>
    /// 
    ///  표면적으로는 a,b 의 합을 리턴하는 함수이긴하나,
    ///  C++ DLL Import, PyCode, File IO, DB Access 등등..
    ///  어떤 결과값만 가져오면 된다.
    ///  
    /// </summary>
    public class DataProc
    {
        int sum = 0;
        public DataProc(int a, int b)
        {
            sum = a + b;
        }

        public void IncNum()
        {
            sum += 1;
        }

        public int getNum()
        {
            return sum;
        }
    }
}
