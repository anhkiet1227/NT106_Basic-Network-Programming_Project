using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoLibrary
{
    [Serializable]
    public class editorMessageClass : editorClass
    {
        public string message = String.Empty;

        public editorMessageClass(string message)
        {
            this.type = editorType.MESSAGE;
            this.message = message;
        }
    }
}
