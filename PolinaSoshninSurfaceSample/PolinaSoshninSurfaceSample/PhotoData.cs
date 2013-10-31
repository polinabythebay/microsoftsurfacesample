using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

///this class will store the necessary fields used when displaying photos
///create an observable collection for the scatter view and library container controls

namespace PolinaSoshninSurfaceSample

{
    public class PhotoData
    {
        public string Source { get; private set; }
        public string Caption { get; private set; }
        public PhotoData(string source, string caption)
        {
            this.Source = source;
           this.Caption = caption;
        }
        public PhotoData(string source)
        {
            this.Source = source;
          
        }
    }
}
