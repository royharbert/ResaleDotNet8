using ResaleV8_ClassLibrary.Models;

//public class ddEventArgs : EventArgs
//{
//    public string? newItem { get; set; }
//    public string? tableName { get; set; }
//    public string? columnName { get; set; }
//    public int MyProperty { get; set; }
//    public List<GenericModel>? gvList { get; set; }
//}
public class DropDownEventArgs : EventArgs
{
    public bool FirstPass { get; set; } = true;
    public int CaretPos { get; set; } = 0;
    public string? originalItem { get; set; }
    public string? StringToProcess { get; set; }
    public string? escapedItem { get; set; }
    public string? unescapedItem { get; set; }

}

