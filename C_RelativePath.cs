using System;

namespace Book_Kepping
{
    public class C_Relative_Path
    {
        public static string GetRelativePath(bool method)
        {
            string rawPath = AppContext.BaseDirectory;
            string exclusion = "bin\\Debug\\net5.0-windows\\";
            /*
             * Method = true --------------> Cash Method
             * Method = false -------------> Acrual Method
            */
            if(method)
            {
                return rawPath.Replace(exclusion, "") + "User Files\\Cash Method\\";
            }
            else
            {
                return rawPath.Replace(exclusion, "") + "User Files\\Acrual Method\\";
            }
        }
    }
}

