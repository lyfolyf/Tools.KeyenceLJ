using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Lead.Tool.Interface;
using Lead.Tool.Resources;

namespace Lead.CPrim.PrimKeyenceLJ
{
    public class PrimCreator : ICreat
    {
        public ITool GetInstance(string Name, string Path)
        {
            return new KeyenceTool(Name, Path);
        }

        public Image Icon
        {
            get
            {
                return (Image)ImageManager.GetImage("Keyence");
            }
        }

        public string Name
        {
            get
            {
                return "Keyence";
            }
        }
    }
}
