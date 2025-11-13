using ResaleV8_ClassLibrary.Models;

public class ddEventArgs : EventArgs
{
    public string? newItem { get; set; }
    public string? tableName { get; set; }
    public string? columnName { get; set; }
    public List<GenericModel>? gvList { get; set; }
}
