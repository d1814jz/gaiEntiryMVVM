using MathCore.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using MathCore.WPF.ViewModels;
using gaiEntiry.Base.Service;
using MathCore.ViewModels;
using System.Windows;
using gaiEntiry.Base.Repository;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Threading;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;

namespace gaiEntiry.Base.ViewsModel
{
    class DutyReportViewModel : MathCore.ViewModels.ViewModel
    {



        public IRepository<Worker> WorkerRepository = App.Services.GetService(typeof(IRepository<Worker>)) as IRepository<Worker>;
        public ObservableCollection<Worker> WorkersView
        {
            get => WorkerRepository.Items.ToObservableCollection();
        }
        private Worker _SelectedWorker;
        public Worker SelectedWorker { get => _SelectedWorker; set => Set(ref _SelectedWorker, value); }

        public IRepository<ServiceCar> ServiceCarRepository = App.Services.GetService(typeof(IRepository<ServiceCar>)) as IRepository<ServiceCar>;
        public ObservableCollection<ServiceCar> ServiceCarsView
        {
            get => ServiceCarRepository.Items.ToObservableCollection();
        }
        private ServiceCar _SelectedServiceCar;
        public ServiceCar SelectedServiceCar { get => _SelectedServiceCar; set => Set(ref _SelectedServiceCar, value); }

        public IRepository<DutyDots> DutyDotsRepository = App.Services.GetService(typeof(IRepository<DutyDots>)) as IRepository<DutyDots>;
        public ObservableCollection<DutyDots> DutyDotssView
        {
            get => DutyDotsRepository.Items.ToObservableCollection();
        }
        private DutyDots _SelectedDutyDots;
        public DutyDots SelectedDutyDots { get => _SelectedDutyDots; set => Set(ref _SelectedDutyDots, value); }


        private string _Path = @"C:\Users\Fafka\Documents";
        public string Path { get => _Path; set => Set(ref _Path, value); }
        private string _PathWithDocumentName;
        public string PathWithDocumentName { get => _PathWithDocumentName; set => Set(ref _PathWithDocumentName, value); }


        public IRepository<Duty> _DutysRepository;
        public IUserDialog _UserDialog;


        private ObservableCollection<Duty> _Dutys;


        public ObservableCollection<Duty> Dutys
        {
            get => _Dutys;
            set
            {
                if (Set(ref _Dutys, value))
                {
                    _Dutys = value;
                    _DutysViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _DutysViewSource.View.Refresh();
                    //_Dutys = value;

                    OnPropertyChanged(nameof(DutysView));
                }
            }
        }

        private CollectionViewSource _DutysViewSource;

        public ICollectionView DutysView => _DutysViewSource?.View;

        #region SelectedDuty : Duty - Выбранный автомобиль

        /// <summary>Выбранный автомобиль</summary>
        private Duty _SelectedDuty;

        /// <summary>Выбранный автомобиль</summary>
        public Duty SelectedDuty { get => _SelectedDuty; set => Set(ref _SelectedDuty, value); }

        #endregion

        #region Command LoadDataCommand - Команда загрузки данных из репозитория

        /// <summary>Команда загрузки данных из репозитория</summary>
        private ICommand _LoadDataCommand;

        /// <summary>Команда загрузки данных из репозитория</summary>
        /// ??=
        public ICommand LoadDataCommand => _LoadDataCommand
            ?? new LambdaCommandAsync(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        /// <summary>Проверка возможности выполнения - Команда загрузки данных из репозитория</summary>
        private bool CanLoadDataCommandExecute() => true;

        /// <summary>Логика выполнения - Команда загрузки данных из репозитория</summary>
        private async Task OnLoadDataCommandExecuted()
        {
            //_Dutys = _DutysRepository.Items.ToObservableCollection(); 
            //Dutys = (await _DutysRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Dutys = _DutysRepository.Items.ToObservableCollection();
            Dutys = _DutysRepository.Items.ToObservableCollection();
            //_Dutys = (await _DutysRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewDutyCommand - Добавление нового автомобиля

        /// <summary>Добавление автомобиля</summary>
        private ICommand _OnReportCommand;

        /// <summary>Добавление автомобиля</summary>

        public ICommand OnReportCommand => _OnReportCommand
            ?? new LambdaCommand(OnReportCommandExecuted);

        /// <summary>Проверка возможности выполнения - Добавление автомобиля</summary>
        private bool CanReportCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление автомобиля</summary>
        private RelayCommand _SelectPath;
        public RelayCommand SelectPath
        {
            get
            {
                return _SelectPath ?? new RelayCommand(obj =>
                {

                    var ookiiDialog = new VistaFolderBrowserDialog();
                    if (ookiiDialog.ShowDialog() == true)
                    {
                        // do something with the folder path
                        Path = ookiiDialog.SelectedPath;
                        MessageBox.Show(Path);
                    }
                });
            }
        }
        //Process.Start(@"C:\MyCmp\Desktop\TestOfKnowledge\TestOfKnowledge\bin\Debug\TslGame.exe");
        private RelayCommand _OpenFolder;
        public RelayCommand OpenFolder
        {
            get
            {
                return _OpenFolder ?? new RelayCommand(obj =>
                {
                    /*var dialog = new CommonOpenFileDialog(Path);
                    dialog.IsFolderPicker = true;
                    CommonFileDialogResult result = dialog.ShowDialog();*/
                    Process PrFolder = new Process();
                    ProcessStartInfo psi = new ProcessStartInfo();
                    string file = $"{PathWithDocumentName}";
                    psi.CreateNoWindow = true;
                    psi.WindowStyle = ProcessWindowStyle.Normal;
                    psi.FileName = "explorer";
                    psi.Arguments = @"/n, /select, " + file;
                    PrFolder.StartInfo = psi;
                    PrFolder.Start();
                });
            }
        }

        private RelayCommand _OpenFile;
        public RelayCommand OpenFile
        {
            get
            {
                return _OpenFile ?? new RelayCommand(obj =>
                {
                    Process.Start(PathWithDocumentName);
                });
            }
        }
        public bool openBool = false;
        private void OnReportCommandExecuted()
        {
            SelectedWorker = WorkersView.Where(u => u.id == SelectedDuty.idWorker).FirstOrDefault();
            SelectedServiceCar = ServiceCarsView.Where(u => u.id == SelectedDuty.idServiceCar).FirstOrDefault();
            SelectedDutyDots = DutyDotssView.Where(u => u.id ==  SelectedDuty.idDutyDots).FirstOrDefault();
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; //endofdoc is a predefined bookmark
            object oTemplate = "c:\\MyTemplate.dot";
            string pathLocal = string.Empty;
            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            //oWord.Visible = true;
            oWord.Visible = false;
            String documentName = string.Empty;
            string dateToDocument = SelectedDuty.Date.ToString("MM-dd-yyyy");
            documentName = $"Дежурство {dateToDocument}";

            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            Word.Paragraph oPara1;
            object start = oDoc.Content.Start;
            object end = oDoc.Content.End;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);

            oPara1.LeftIndent = oWord.CentimetersToPoints(3);
            oPara1.RightIndent = oWord.CentimetersToPoints(1);
            oPara1.Format.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
            //oPara1.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
            oPara1.Range.Font.Name = "Times New Roman";
            oPara1.Range.Font.Size = 14;

            String queryFull = string.Empty;
            String query = String.Empty;
            String razdel = "===========================================================";
            queryFull = $"Докладываю, что сотрудник {SelectedWorker.LastName} {SelectedWorker.FirstName} {SelectedWorker.Surname} находился на дежурстве. Начальная точка маршрута: {SelectedDutyDots.FirstPlace}, конечная точка маршрута {SelectedDutyDots.LastPlace}, район маршрута: {SelectedDutyDots.District.District1}.\nС использованием служебного автомобиля(Марка, модель, государственный номер автомобиля): {SelectedServiceCar.Brand}, {SelectedServiceCar.Model},{SelectedServiceCar.Number}.\n\nРапорт сформирован при помощи автогенерации, дата и время на момент генерации: {DateTime.Now.ToString()}";
            oPara1.Range.Text = queryFull;
            oPara1.Range.InsertParagraphAfter();
            //oDoc.SaveAs2(ref fileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            //oDoc.SaveAs2(pathTo);
            //from = System.IO.Path.Combine(@"E:\vid\", "(" + i.ToString() + ").PNG")
            //$@"C:\Users\Fafka\Documents\{documentName}.docx"; 
            MessageBox.Show("report");
            oPara1.Range.InsertParagraphAfter();
            PathWithDocumentName = $@"{Path}\{documentName}.docx";
            object fileName = $@"{PathWithDocumentName}";
            oDoc.SaveAs(documentName);
            oDoc.Close();
            oWord.Quit();
            Thread.Sleep(900);
            openBool = true;

        }


        #endregion


        private ICommand _OnOpenFileCommand;


        public ICommand OnOpenFileCommand => _OnOpenFileCommand
            ?? new LambdaCommand(OnOpenFileCommandExecuted, CanOpenFileCommandExecute);

        public bool CanOpenFileCommandExecute() => openBool;


        private void OnOpenFileCommandExecuted()
        {
            Process.Start(PathWithDocumentName);
        }

        public DutyReportViewModel(IRepository<Duty> DutysRepository, IUserDialog UserDialog)
        {
            _DutysRepository = DutysRepository;
            _UserDialog = UserDialog;
        }




        /*public ObservableCollection<Duty> Dutys
        {
            get { return _Dutys; }
            set
            {
                _Dutys = value;
                OnPropertyChanged(nameof(Dutys));
            }
        }*/
    }
}
