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
    class AccountingReportViewModel : MathCore.ViewModels.ViewModel
    {

        public IRepository<Worker> WorkerRepository = App.Services.GetService(typeof(IRepository<Worker>)) as IRepository<Worker>;
        public ObservableCollection<Worker> WorkersView
        {
            get => WorkerRepository.Items.ToObservableCollection();
        }

        private Worker _SelectedWorker;
        public Worker SelectedWorker { get => _SelectedWorker; set => Set(ref _SelectedWorker, value); }

        public IRepository<Driver> DriverRepository = App.Services.GetService(typeof(IRepository<Driver>)) as IRepository<Driver>;
        public ObservableCollection<Driver> DriversView
        {
            get => DriverRepository.Items.ToObservableCollection();
        }

        private Driver _SelectedDriver;
        public Driver SelectedDriver { get => _SelectedDriver; set => Set(ref _SelectedDriver, value); }

        public IRepository<Auto> AutoRepository = App.Services.GetService(typeof(IRepository<Auto>)) as IRepository<Auto>;
        public ObservableCollection<Auto> AutosView
        {
            get => AutoRepository.Items.ToObservableCollection();
        }

        private Auto _SelectedAuto;
        public Auto SelectedAuto { get => _SelectedAuto; set => Set(ref _SelectedAuto, value); }


        private string _Path = @"C:\Users\Fafka\Documents";
        public string Path { get => _Path; set => Set(ref _Path, value); }
        private string _PathWithDocumentName;
        public string PathWithDocumentName { get => _PathWithDocumentName; set => Set(ref _PathWithDocumentName, value); }


        public IRepository<Accounting> _AccountingsRepository;
        public IUserDialog _UserDialog;


        private ObservableCollection<Accounting> _Accountings;


        public ObservableCollection<Accounting> Accountings
        {
            get => _Accountings;
            set
            {
                if (Set(ref _Accountings, value))
                {
                    _Accountings = value;
                    _AccountingsViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _AccountingsViewSource.View.Refresh();
                    //_Accountings = value;

                    OnPropertyChanged(nameof(AccountingsView));
                }
            }
        }

        private CollectionViewSource _AccountingsViewSource;

        public ICollectionView AccountingsView => _AccountingsViewSource?.View;

        #region SelectedAccounting : Accounting - Выбранный автомобиль

        /// <summary>Выбранный автомобиль</summary>
        private Accounting _SelectedAccounting;

        /// <summary>Выбранный автомобиль</summary>
        public Accounting SelectedAccounting { get => _SelectedAccounting; set => Set(ref _SelectedAccounting, value); }

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
            //_Accountings = _AccountingsRepository.Items.ToObservableCollection(); 
            //Accountings = (await _AccountingsRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Accountings = _AccountingsRepository.Items.ToObservableCollection();
            Accountings = _AccountingsRepository.Items.ToObservableCollection();
            //_Accountings = (await _AccountingsRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewAccountingCommand - Добавление нового автомобиля

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
            SelectedWorker = WorkersView.Where(u => u.id == SelectedAccounting.idWorker).FirstOrDefault();
            SelectedDriver = DriversView.Where(u => u.id == SelectedAccounting.idDriver).FirstOrDefault();
            SelectedAuto = AutosView.Where(u => u.id == SelectedAccounting.idAuto).FirstOrDefault();
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
            documentName = $"Учет {SelectedAuto.Brand} {SelectedAuto.Model} {SelectedAuto.VinNumber}";

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
            queryFull = $"Автомобиль: {SelectedAuto.Brand} {SelectedAuto.Model} {SelectedAuto.Year} {SelectedAuto.VinNumber}\nДата постановки автомобиля на учет в ГАИ: {SelectedAccounting.FirstDate}\nСотрудник зарегистрировавший автомобиль: {SelectedWorker.LastName} {SelectedWorker.FirstName} {SelectedWorker.Surname}\nВладелец: {SelectedDriver.LastName} {SelectedDriver.FirstName} {SelectedDriver.Surname}\nАвтомобилю был присвоен государственный номер: {SelectedAccounting.Number}, цвет при регистрации {SelectedAccounting.Color}\nРапорт сформирован при помощи автогенерации, дата и время на момент генерации: {DateTime.Now.ToString()}";
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

        public AccountingReportViewModel(IRepository<Accounting> AccountingsRepository, IUserDialog UserDialog)
        {
            _AccountingsRepository = AccountingsRepository;
            _UserDialog = UserDialog;
        }




        /*public ObservableCollection<Accounting> Accountings
        {
            get { return _Accountings; }
            set
            {
                _Accountings = value;
                OnPropertyChanged(nameof(Accountings));
            }
        }*/
    }
}
