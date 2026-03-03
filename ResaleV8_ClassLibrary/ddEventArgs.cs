using ResaleV8_ClassLibrary.Models;

public class DropDownEventArgs : EventArgs
{
    public bool FirstPass { get; set; } = true;
    public int CaretPos { get; set; } = 0;
    public string? originalItem { get; set; }
    public string? StringToProcess { get; set; }
    public string? escapedItem { get; set; }
    public string? unescapedItem { get; set; }

    public void Reset()
    {
        FirstPass = true;
        CaretPos = 0;
        originalItem = null;
        StringToProcess = null;
        escapedItem = null;
        unescapedItem = null;
    }

}

