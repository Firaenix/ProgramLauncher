using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLauncher.CustomClasses
{
    /*
     * The OtherExeContainer class is a class that is used for containing all the information about
     * Other Executables stored in the XML as <OtherExe Params="">...</OtherExe>
     * 
     */
    public class OtherExeContainer
    {
        private string otherExeLocation = "";
        private string otherExeParams = "";

        public string getExe()
        {
            return otherExeLocation;
        }

        public void setExe(string newLoc)
        {
            otherExeLocation = newLoc;
        }

        public string getParam()
        {
            return otherExeParams;
        }

        public void setParam(string newParam)
        {
            otherExeParams = newParam;
        }
    }
}
