using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace CANShark.Desktop.Infrastructure.Dialogs
{
    public class NativeDialogManager : IDialogManager
    {
        public Task<string[]> ShowOpenFileDialog()
        {
            var fileDialog = new OpenFileDialog();
            return fileDialog.ShowAsync(GetMainWindow());
        }

        public Task<string> ShowSaveFileDialog()
        {
            var fileDialog = new SaveFileDialog();
            return fileDialog.ShowAsync(GetMainWindow());
        }

        public Task<string> ShowFolderDialog()
        {
            var folderDialog = new OpenFolderDialog();
            return folderDialog.ShowAsync(GetMainWindow());
        }

        private Window GetMainWindow()
        {
            // TODO rewrite. This must be MainWindow insted of Windows[0]
            return ((ClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).Windows[0];
        }
    }
}
