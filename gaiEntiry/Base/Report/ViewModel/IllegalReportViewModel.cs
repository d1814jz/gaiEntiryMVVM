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
    class IllegalReportViewModel : MathCore.ViewModels.ViewModel
    {



        public IRepository<IllegalType> IllegalTypeRepository = App.Services.GetService(typeof(IRepository<IllegalType>)) as IRepository<IllegalType>;
        public ObservableCollection<IllegalType> IllegalTypesView
        {
            get => IllegalTypeRepository.Items.ToObservableCollection();
        }
        private IllegalType _SelectedIllegalType;
        public IllegalType SelectedIllegalType { get => _SelectedIllegalType; set => Set(ref _SelectedIllegalType, value); }

        public IRepository<Duty> DutyRepository = App.Services.GetService(typeof(IRepository<Duty>)) as IRepository<Duty>;
        public ObservableCollection<Duty> DutysView
        {
            get => DutyRepository.Items.ToObservableCollection();
        }
        private Duty _SelectedDuty;
        public Duty SelectedDuty { get => _SelectedDuty; set => Set(ref _SelectedDuty, value); }

        public IRepository<Auto> AutoRepository = App.Services.GetService(typeof(IRepository<Auto>)) as IRepository<Auto>;
        public ObservableCollection<Auto> AutosView
        {
            get => AutoRepository.Items.ToObservableCollection();
        }
        private Auto _SelectedAuto;
        public Auto SelectedAuto { get => _SelectedAuto; set => Set(ref _SelectedAuto, value); }

        public IRepository<Driver> DriverRepository = App.Services.GetService(typeof(IRepository<Driver>)) as IRepository<Driver>;
        public ObservableCollection<Driver> DriversView
        {
            get => DriverRepository.Items.ToObservableCollection();
        }
        private Driver _SelectedDriver;
        public Driver SelectedDriver { get => _SelectedDriver; set => Set(ref _SelectedDriver, value); }

        public IRepository<Accounting> AccountingRepository = App.Services.GetService(typeof(IRepository<Accounting>)) as IRepository<Accounting>;
        public ObservableCollection<Accounting> AccountingsView
        {
            get => AccountingRepository.Items.ToObservableCollection();
        }
        private Accounting _SelectedAccounting;
        public Accounting SelectedAccounting { get => _SelectedAccounting; set => Set(ref _SelectedAccounting, value); }

        private string _Path = @"C:\Users\Fafka\Documents";
        public string Path { get => _Path; set => Set(ref _Path, value); }
        private string _PathWithDocumentName;
        public string PathWithDocumentName { get => _PathWithDocumentName; set => Set(ref _PathWithDocumentName, value); }


        public IRepository<Illegal> _IllegalsRepository;
        public IUserDialog _UserDialog;


        private ObservableCollection<Illegal> _Illegals;


        public ObservableCollection<Illegal> Illegals
        {
            get => _Illegals;
            set
            {
                if (Set(ref _Illegals, value))
                {
                    _Illegals = value;
                    _IllegalsViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _IllegalsViewSource.View.Refresh();
                    //_Illegals = value;

                    OnPropertyChanged(nameof(IllegalsView));
                }
            }
        }

        private CollectionViewSource _IllegalsViewSource;

        public ICollectionView IllegalsView => _IllegalsViewSource?.View;

        #region SelectedIllegal : Illegal - Выбранный автомобиль

        /// <summary>Выбранный автомобиль</summary>
        private Illegal _SelectedIllegal;

        /// <summary>Выбранный автомобиль</summary>
        public Illegal SelectedIllegal { get => _SelectedIllegal; set => Set(ref _SelectedIllegal, value); }

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
            //_Illegals = _IllegalsRepository.Items.ToObservableCollection(); 
            //Illegals = (await _IllegalsRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Illegals = _IllegalsRepository.Items.ToObservableCollection();
            Illegals = _IllegalsRepository.Items.ToObservableCollection();
            //_Illegals = (await _IllegalsRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewIllegalCommand - Добавление нового автомобиля

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
            SelectedAuto = AutosView.Where(u => u.id == SelectedIllegal.idAuto).FirstOrDefault();
            SelectedDuty = DutysView.Where(u => u.id == SelectedIllegal.idDuty).FirstOrDefault();
            SelectedDriver = DriversView.Where(u => u.id == SelectedIllegal.idDriver).FirstOrDefault();
            SelectedIllegalType = IllegalTypesView.Where(u => u.id == SelectedIllegal.idIllegalType).FirstOrDefault();
            SelectedAccounting = AccountingsView.Where(u => u.id == SelectedIllegal.idAuto).FirstOrDefault();
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
            documentName = $"Нурешение {SelectedIllegal.Driver.LastName} {SelectedIllegal.Driver.FirstName} {SelectedIllegal.Driver.Surname}";

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
            queryFull = $"Дата: {SelectedDuty.Date}\nСотрудник: {SelectedDuty.Worker.LastName} {SelectedDuty.Worker.FirstName} {SelectedDuty.Worker.Surname}\nДокладывает, что при управлении автомобилем {SelectedAuto.Brand}, {SelectedAuto.Model}, {SelectedAuto.Year}, государственный номер автомобиля {SelectedAccounting.Number} был задержан гражданин {SelectedDriver.LastName} {SelectedDriver.FirstName} {SelectedDriver.Surname}\nОписание нарушения: {SelectedIllegal.Description}\nИсходя из вида нарушения: {SelectedIllegalType.IllegalType1} был наложен штраф в размере {SelectedIllegalType.Fine} бв.\nРапорт сформирован при помощи автогенерации, дата и время на момент генерации: {DateTime.Now.ToString()}";
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

        public IllegalReportViewModel(IRepository<Illegal> IllegalsRepository, IUserDialog UserDialog)
        {
            _IllegalsRepository = IllegalsRepository;
            _UserDialog = UserDialog;
        }




        /*public ObservableCollection<Illegal> Illegals
        {
            get { return _Illegals; }
            set
            {
                _Illegals = value;
                OnPropertyChanged(nameof(Illegals));
            }
        }*/
    }
}
