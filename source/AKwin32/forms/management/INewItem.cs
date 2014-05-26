namespace AnimeKakkoi.App.Forms.Management
{
    /// <summary>
    /// 
    /// </summary>
    internal interface INewItem
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