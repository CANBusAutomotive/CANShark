using System.Threading.Tasks;

namespace CANShark.Desktop.Infrastructure.Dialogs
{
    public interface IDialogManager
    {
        Task<string> ShowFolderDialog();

        Task<string[]> ShowOpenFileDialog();

        Task<string> ShowSaveFileDialog();
    }
}