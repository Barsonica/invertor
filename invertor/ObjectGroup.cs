using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.IO;
using System.Xml.Serialization;

namespace Invertor
{
    public class ObjectGroup
    {
        List<Object> objects = new List<Object>();

        private string name = "";
        
        public ObjectGroup(string name)
        {
            Name = name;
        }

        #region getters  and setters

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }


        #endregion

    }
}
