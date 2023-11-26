using System.Collections.ObjectModel;
using System.Linq;
using ISFATAAIOWATE.Entities;
using ReactiveUI;

namespace ISFATAAIOWATE.ViewModels;

public class ClothesIssuanceLogsVM : ViewModelBase
{
    private ObservableCollection<ClothingHistory> _clothingHistory;

    public ObservableCollection<ClothingHistory> ClothingHistory
    {
        get => _clothingHistory;
        set => this.RaiseAndSetIfChanged(ref _clothingHistory, value);
    }

    public ClothesIssuanceLogsVM()
    {
        ClothingHistory = new ObservableCollection<ClothingHistory>(Helper.GetContext().ClothingHistories.ToList());
    }
}