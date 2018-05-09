using PCLStorage;
using System.Threading.Tasks;

namespace BudgetTracker.Helpers
{
    public class Utils
    {
        public async void WriteToFile(string budgetInfo)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("AppContent", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("Budget.txt", CreationCollisionOption.ReplaceExisting);

            await file.WriteAllTextAsync(budgetInfo);

        }

        public async Task<string> ReadFromFile()
        {
            //Todo - check if file exists..if not then create one
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("AppContent", CreationCollisionOption.OpenIfExists);
            ExistenceCheckResult isFileExisting = await folder.CheckExistsAsync("Budget.txt");
            IFile file = await folder.CreateFileAsync("Budget.txt", CreationCollisionOption.OpenIfExists);
            var rtrt = file.ReadAllTextAsync();
            return await file.ReadAllTextAsync();


        }
    }
}

