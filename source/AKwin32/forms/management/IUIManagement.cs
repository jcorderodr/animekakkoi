using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AKwin32.forms.management
{
    /// <summary>
    /// 
    /// </summary>
    interface IUIManagement
    {
        /// <summary>
        /// Implements the convert mechanism from the source to the Entity.
        /// </summary>
        void ConvertItemsToDefaultType();

        /// <summary>
        /// Loads content and data to the option's controls.
        /// </summary>
        void DoVisualChanges();

        /// <summary>
        /// Fill the mainly UI components (dynamic data).
        /// </summary>
        void LoadDataToControls();

        /// <summary>
        /// Fills the DataSources, Resources and objects from the repository.
        /// </summary>
        void PrepareDataFromRepo();

        /// <summary>
        /// Implements mechanism for filtering the showed (in-time) data.
        /// </summary>
        /// <param name="list"></param>
        void FilterData(List<object> list);

        /// <summary>
        /// Implements mechanism to apply the ReadOnly mode.
        /// </summary>
        void setReadOnlyMode();

        /// <summary>
        /// 
        /// </summary>
        void SaveItemsToRepository();

    }
}
