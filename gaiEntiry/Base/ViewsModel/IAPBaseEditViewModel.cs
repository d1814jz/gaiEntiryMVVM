using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class IAPBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Worker> WorkerRepository = App.Services.GetService(typeof(IRepository<Worker>)) as IRepository<Worker>;
        public ObservableCollection<Worker> WorkersView
        {
            get => WorkerRepository.Items.ToObservableCollection();
        }
        private Worker _SelectedWorker;
        public Worker SelectedWorker { get => _SelectedWorker; set => Set(ref _SelectedWorker, value); }

        public IRepository<TypesOfIAP> TypesOfIAPRepository = App.Services.GetService(typeof(IRepository<TypesOfIAP>)) as IRepository<TypesOfIAP>;
        public ObservableCollection<TypesOfIAP> TypesOfIAPsView
        {
            get => TypesOfIAPRepository.Items.ToObservableCollection();
        }
        private TypesOfIAP _SelectedTypesOfIAP;
        public TypesOfIAP SelectedTypesOfIAP { get => _SelectedTypesOfIAP; set => Set(ref _SelectedTypesOfIAP, value); }

        private DateTime _Date;
        public DateTime Date { get => _Date; set => Set(ref _Date, value); }
        private string _Description;
        public string Description { get => _Description; set => Set(ref _Description, value); }


        public IAPBaseEditViewModel()
            : this(new IAP { })
        {
        }

        public IAPBaseEditViewModel(IAP IAP)
        {
            SelectedTypesOfIAP = TypesOfIAPsView.Where(u => u.id == IAP.idTypesOfIAP).FirstOrDefault();
            SelectedWorker = WorkersView.Where(u => u.id == IAP.idWorker).FirstOrDefault();
            Date = IAP.Date;
            Description = IAP.Description;

        }


    }
}
