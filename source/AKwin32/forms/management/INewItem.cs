using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AKwin32.forms.management
{
    /// <summary>
    /// 
    /// </summary>
    interface INewItem
    {
        /// <summary>
        /// 
        /// </summary>
        void DoVisualChanges();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>true - if item saved successfully.</returns>
        bool ToRegisterItem();
    }
}
