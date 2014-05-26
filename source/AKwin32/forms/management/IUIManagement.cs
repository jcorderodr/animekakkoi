#region

using System.Collections.Generic;

#endregion

namespace AnimeKakkoi.App.Forms.Management
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IUIManagement
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
        /// Properties treatments for uniques and specifics propertie's entity.
        /// </summary>
        /// <param name="ctrl">System.Windows.Forms.Control to set his value</param>
        /// <param name="pName">Property's name</param>
        /// <param name="entity">the entity to get or set value</param>
        void InheritControlSelection(System.Windows.Forms.Control ctrl, string pName, object entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="p"></param>
        /// <param name="entity"></param>
        void InheritControlValidation(System.Windows.Forms.Control ctrl, System.Reflection.PropertyInfo p, object entity);

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


        void SaveItemsToRepository(bool newItems);
    }
}