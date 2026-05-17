using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using OpennLayer.Application.Services;
using OpennLayer.Infrastructure.Versioning;
using OpennLayer.UI.Commands;

namespace OpennLayer.UI.ViewModels
{
    public class MainViewModel : MvvmBaseModel
    {
        private readonly TiaPortalService _service;

        public ObservableCollection<string> Versions { get; } = new();

        private string? _selectedVersion;
        public string? SelectedVersion
        {
            get => _selectedVersion;
            set
            {
                _selectedVersion = value;
                OnPropertyChanged(nameof(SelectedVersion));
            }
        }

        private string _status = string.Empty;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public ICommand LoadVersionsCommand { get; }
        public ICommand AttachCommand { get; }

        public MainViewModel(TiaPortalService service)
        {
            _service = service;

            LoadVersionsCommand = new RelayCommand(_ => Load());
            AttachCommand = new RelayCommand(async _ => await Attach());
        }

        private void Load()
        {
            Versions.Clear();

            foreach (var v in TiaVersionDetector.GetInstalledVersions())
                Versions.Add(v);

            SelectedVersion = Versions.FirstOrDefault();
        }

        private async Task Attach()
        {
            if (SelectedVersion == null)
                return;

            Status = "Connecting...";

            await _service.AttachAsync(SelectedVersion);

            Status = $"Connected to TIA V{SelectedVersion}";
        }
    }
}