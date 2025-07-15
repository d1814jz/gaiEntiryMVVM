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
    class AccidentReportViewModel : MathCore.ViewModels.ViewModel
    {



        public IRepository<AccidentMember> AccidentMemberRepository = App.Services.GetService(typeof(IRepository<AccidentMember>)) as IRepository<AccidentMember>;

        public ObservableCollection<AccidentMember> AccidentMembersView
        {
            get => AccidentMemberRepository.Items.ToObservableCollection();
        }

        private string _Path = @"C:\Users\Fafka\Documents";
        public string Path { get => _Path; set => Set(ref _Path, value); }
        private string _PathWithDocumentName;
        public string PathWithDocumentName { get => _PathWithDocumentName; set => Set(ref _PathWithDocumentName, value); }


        public IRepository<Accident> _AccidentsRepository;
        public IUserDialog _UserDialog;


        private ObservableCollection<Accident> _Accidents;


        public ObservableCollection<Accident> Accidents
        {
            get => _Accidents;
            set
            {
                if (Set(ref _Accidents, value))
                {
                    _Accidents = value;
                    _AccidentsViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _AccidentsViewSource.View.Refresh();
                    //_Accidents = value;

                    OnPropertyChanged(nameof(AccidentsView));
                }
            }
        }

        private CollectionViewSource _AccidentsViewSource;

        public ICollectionView AccidentsView => _AccidentsViewSource?.View;

        #region SelectedAccident : Accident - Выбранный автомобиль

        /// <summary>Выбранный автомобиль</summary>
        private Accident _SelectedAccident;

        /// <summary>Выбранный автомобиль</summary>
        public Accident SelectedAccident { get => _SelectedAccident; set => Set(ref _SelectedAccident, value); }

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
            //_Accidents = _AccidentsRepository.Items.ToObservableCollection(); 
            //Accidents = (await _AccidentsRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Accidents = _AccidentsRepository.Items.ToObservableCollection();
            Accidents = _AccidentsRepository.Items.ToObservableCollection();
            //_Accidents = (await _AccidentsRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewAccidentCommand - Добавление нового автомобиля

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
        public bool openFolderBool = false;
        private void OnReportCommandExecuted()
        {
            var accident = SelectedAccident;
            AccidentMember accidentMember = AccidentMembersView.Where(u => u.idAccident == accident.id).FirstOrDefault();
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
            documentName = $"ДТП {accidentMember.Driver.LastName} {accidentMember.Driver.FirstName} {accidentMember.Driver.Surname}";

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
            queryFull = $"Сотрудник: {accident.Worker.LastName} {accident.Worker.FirstName} {accident.Worker.Surname}\nДокладывает: {accident.Date}, на улице {accident.Street.Street1} в частности {accident.Place} при управлении автомобилем {accidentMember.Auto.Brand} {accidentMember.Auto.Model} {accidentMember.Auto.Year}  \nГражданин: {accidentMember.Driver.LastName} {accidentMember.Driver.FirstName} {accidentMember.Driver.Surname}\nОписание: {accident.Description}\nВиновник:{accidentMember.Criminal}\nРапорт сформирован при помощи автогенерации, дата и время на момент генерации: {DateTime.Now.ToString()}";
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
            openFolderBool = true;

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


        private ICommand _OnOpenFolderCommand;


        public ICommand OnOpenFolderCommand => _OnOpenFolderCommand
            ?? new LambdaCommand(OnOpenFolderCommandExecuted, CanOpenFolderCommandExecute);

        public bool CanOpenFolderCommandExecute() => openFolderBool;


        private void OnOpenFolderCommandExecuted()
        {
            Process PrFolder = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            string file = $"{PathWithDocumentName}";
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Normal;
            psi.FileName = "explorer";
            psi.Arguments = @"/n, /select, " + file;
            PrFolder.StartInfo = psi;
            PrFolder.Start();
        }

        public AccidentReportViewModel(IRepository<Accident> AccidentsRepository, IUserDialog UserDialog)
        {
            _AccidentsRepository = AccidentsRepository;
            _UserDialog = UserDialog;
        }




        /*public ObservableCollection<Accident> Accidents
        {
            get { return _Accidents; }
            set
            {
                _Accidents = value;
                OnPropertyChanged(nameof(Accidents));
            }
        }*/
    }
}
