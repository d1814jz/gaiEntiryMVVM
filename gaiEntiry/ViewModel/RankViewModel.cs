using gaiEntiry.Add;
using gaiEntiry.Edit;
using gaiEntiry.Repositories;
using gaiEntiry.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace gaiEntiry.ViewModel
{
    class RankViewModel
    {
        public static int Rankid { get; set; }
        public static string RankRank1 { get; set; }
        public static Rank SelectedRank { get; set; }
        public static Worker RankWorker { get; set; }
        //все звания
        private List<Rank> allRanks = RankRepositories.GetAllRanks();
        public List<Rank> AllRanks
        {
            get { return allRanks; }
            set
            {
                allRanks = value;
                NotifyPropertyChanged("AllRanks");
            }
        }

        private RelayCommand addNewRank;
        public RelayCommand AddNewRank
        {
            get
            {
                return addNewRank ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    if (RankRank1 != null)
                    {
                        resultStr = RankRepositories.CreateRank(RankRank1);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllRanksView();
                    }
                });
            }
        }

        private RelayCommand editRank;
        public RelayCommand EditRank
        {
            get
            {
                return editRank ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Звание не выбрано";
                    if (SelectedRank != null)
                    {
                        resultStr = RankRepositories.EditRank(SelectedRank, RankRank1);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();

                        wnd.Close();
                        UpdateAllRanksView();
                    }
                    else
                        ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand deleteRank;
        public RelayCommand DeleteRank
        {
            get
            {
                return deleteRank ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if (SelectedRank != null)
                    {
                        resultStr = RankRepositories.DeleteRank(SelectedRank);
                        //SetNullValuesToProperties();
                        UpdateAllRanksView();

                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }

        private void UpdateAllRanksView()
        {
            AllRanks = RankRepositories.GetAllRanks();
            RankView.AllRanksView.ItemsSource = null;
            RankView.AllRanksView.Items.Clear();
            RankView.AllRanksView.ItemsSource = allRanks;
            RankView.AllRanksView.Items.Refresh();
        }

        private void OpenAddNewRankViewMethod()
        {
            AddNewRankView obj = new AddNewRankView();
            SetCenterPositionAndOpen(obj);
        }
        private void OpenEditRankViewMethod(Rank rank)
        {
            EditRankView obj = new EditRankView(rank);
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand editRankView;
        public RelayCommand EditRankView
        {
            get
            {
                return editRankView ?? new RelayCommand(obj =>
                {
                    OpenEditRankViewMethod(SelectedRank);
                });
            }
        }

        private RelayCommand openAddNewRankView;
        public RelayCommand OpenAddNewRankView
        {
            get
            {
                return openAddNewRankView ?? new RelayCommand(obj =>
                {
                    OpenAddNewRankViewMethod();
                });
            }
        }

        

        #region Inotify

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void RaisePropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
        protected void NoticePropertyChanged(string propertyName)
        {
            RaisePropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndOpen(messageView);
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion
    }
}
