using System.IO;

namespace Utilities.StaticHelpers
{
    public static class FolderOperations
    {
        public static void DeleteFolder(string floder)
        {
            if (Directory.Exists($"{Directory.GetCurrentDirectory()}/Content/{floder}"))
                Directory.Delete($"{Directory.GetCurrentDirectory()}/Content/{floder}", true);
        }
    }
}
