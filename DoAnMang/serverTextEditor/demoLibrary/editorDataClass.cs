using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoLibrary
{
    [Serializable]
    public class editorDataClass : editorClass
    {
        public string data = String.Empty;
        public editorDataClass() { }
        public editorDataClass(string data)
        {
            this.type = editorType.DATA;
            this.data = data;

        }
    }
}
