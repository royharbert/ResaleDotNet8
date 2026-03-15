using System;
using System.Runtime.InteropServices;

public static class ComInteropHelper
{
#if NETFRAMEWORK
    // .NET Framework: Use built-in Marshal.GetActiveObject
    public static object GetActiveObject(string progId)
    {
        if (string.IsNullOrWhiteSpace(progId))
            throw new ArgumentNullException(nameof(progId));

        return Marshal.GetActiveObject(progId);
    }
    [DllImport("ole32.dll")]
private static extern int GetActiveObject(ref Guid rclsid, IntPtr pvReserved, [MarshalAs(UnmanagedType.IUnknown)] out object ppunk);
#else
    // .NET 5+ / .NET Core: Use P/Invoke
    [DllImport("oleaut32.dll", CharSet = CharSet.Unicode)]
    //private static extern int GetActiveObject(ref Guid rclsid, IntPtr reserved, out object ppunk);
    
    
    private static extern int GetActiveObject(ref Guid rclsid, IntPtr pvReserved, [MarshalAs(UnmanagedType.IUnknown)] out object ppunk);

    [DllImport("ole32.dll")]
    private static extern int CLSIDFromProgID([MarshalAs(UnmanagedType.LPWStr)] string progId, out Guid clsid);

    public static object GetActiveObject(string progId)
    {
        if (string.IsNullOrWhiteSpace(progId))
            throw new ArgumentNullException(nameof(progId));

        CLSIDFromProgID(progId, out Guid clsid);
        int hr = GetActiveObject(ref clsid, IntPtr.Zero, out object obj);

        if (hr < 0) // COM error
            obj = null;

        return obj;
    }
#endif
}
