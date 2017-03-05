namespace DotVVM.Framework.Controls
{
    /// <summary>
    /// Represents a settings for sorting.
    /// </summary>
    public class SortOptions : ISortOptions
    {
        /// <summary>
        /// Gets or sets whether the sort order should be descending.
        /// </summary>
        public bool SortDescending { get; set; }

        /// <summary>
        /// Gets or sets the name of the property that is used for sorting.
        /// </summary>
        public string SortExpression { get; set; }
    }
}