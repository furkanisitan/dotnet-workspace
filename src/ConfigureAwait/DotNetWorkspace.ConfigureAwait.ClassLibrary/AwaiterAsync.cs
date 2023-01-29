using System.Diagnostics;

namespace DotNetWorkspace.ConfigureAwait.ClassLibrary
{
    public static class AwaiterAsync
    {
        public static async Task WaitAsync()
        {
            Debug.WriteLine("Before Delay");

            await Task.Delay(1000);

            Debug.WriteLine("After Delay");
        }
    }
}