using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ClipboardManager
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> clipboardHistory = new ObservableCollection<string>();
        private DispatcherTimer clipboardWatcher;
        private bool isClearingOrDeleting = false;

        public MainWindow()
        {
            InitializeComponent();
            ClipboardListBox.ItemsSource = clipboardHistory;

            InitializeClipboardWatcher();
        }

        private void InitializeClipboardWatcher()
        {
            clipboardWatcher = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            clipboardWatcher.Tick += ClipboardWatcher_Tick;
            clipboardWatcher.Start();
        }

        private void ClipboardWatcher_Tick(object sender, EventArgs e)
        {
            if (isClearingOrDeleting)
                return;

            if (Clipboard.ContainsText())
            {
                string currentText = Clipboard.GetText();
                if (!clipboardHistory.Contains(currentText))
                {
                    clipboardHistory.Add(currentText);
                    Debug.WriteLine($"Added to history: {currentText}");
                }
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            isClearingOrDeleting = false;
            string searchText = SearchTextBox.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ClipboardListBox.ItemsSource = clipboardHistory;
            }
            else
            {
                var filteredHistory = clipboardHistory.Where(item => item.ToLower().Contains(searchText)).ToList();
                ClipboardListBox.ItemsSource = new ObservableCollection<string>(filteredHistory);
            }
        }

        private void ClearHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            isClearingOrDeleting = true;
            clipboardHistory.Clear();
            ClipboardListBox.ItemsSource = clipboardHistory;
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            isClearingOrDeleting = false;
            if (ClipboardListBox.SelectedItem != null)
            {
                Clipboard.SetText(ClipboardListBox.SelectedItem.ToString());
                MessageBox.Show("Text copied to clipboard.");
            }
            else
            {
                MessageBox.Show("Please select an item from the list.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClipboardListBox.SelectedItem != null)
            {
                isClearingOrDeleting = true;
                string selectedItem = ClipboardListBox.SelectedItem.ToString();

                if (clipboardHistory.Contains(selectedItem))
                {
                    clipboardHistory.Remove(selectedItem);
                    ClipboardListBox.ItemsSource = clipboardHistory; // Ensure UI update
                }
                else
                {
                    MessageBox.Show("The selected item could not be found.");
                }
            }
            else
            {
                MessageBox.Show("Please select an item from the list.");
            }
        }

        private void ClipboardListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            isClearingOrDeleting = false;
            if (ClipboardListBox.SelectedItem != null)
            {
                Clipboard.SetText(ClipboardListBox.SelectedItem.ToString());
                MessageBox.Show("Text copied to clipboard.");
            }
        }
    }
}
