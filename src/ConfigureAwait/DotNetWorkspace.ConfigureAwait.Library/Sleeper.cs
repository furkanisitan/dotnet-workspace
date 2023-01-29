using System.Diagnostics;

namespace DotNetWorkspace.ConfigureAwait.Library;

public static class Sleeper
{
    public static async Task SleepAsync()
    {
        // Main thread
        Debug.WriteLine("Before Delay");

        // Worker thread
        await Task.Delay(1000).ConfigureAwait(false);
        //await Task.Delay(1000).ConfigureAwait(true);

        // Continuation task (Which thread?)
        Debug.WriteLine("After Delay");
    }
}