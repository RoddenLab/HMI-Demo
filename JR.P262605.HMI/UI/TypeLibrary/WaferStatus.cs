namespace JR.P262605.HMI.UI.TypeLibrary
{
    public enum WaferStatus : int
    {
        Empty = 0,   // Wafer Not Present
        NotScanned = 1,
        Fault = 2,   // Wafer Failed Processing (Destructive)
        Done = 3,   // Wafer Processed
        Ready = 4,   // Wafer Pre-Process
        Processing = 5	// Wafer In-Pocess
    }
}