using Boris_Client.Helpers;
using Boris_Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace Boris_Client.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public RelayCommandAsync<string> SendMessageCommand { get; set; }

        public ObservableCollection<ChatMessage> ChatHistory { get; set; } = new ObservableCollection<ChatMessage>();

        BotClientSdk.DirectLineWrapper _wrapper = null;

        private string _messageText;
        public string MessageText
        {
            get { return _messageText; }
            set
            {
                _messageText = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            SendMessageCommand = new RelayCommandAsync<string>(SendMessage);

            _wrapper = new BotClientSdk.DirectLineWrapper(PopulateHistory);
        }

        internal async Task Initialise()
        {
            await _wrapper.StartConversation();            
        }

        private async Task SendMessage(string message)
        {
            await _wrapper.SendMessage(message);
            MessageText = string.Empty;

        }

        private void PopulateHistory(List<KeyValuePair<string, string>> response)
        {            
            var ignored = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                foreach (var historyItem in response)
                {
                    ChatHistory.Add(new ChatMessage(historyItem.Key, historyItem.Value));
                }
            });
        }

        private CoreDispatcher Dispatcher =>
            (Window.Current == null) ?
                CoreApplication.MainView.CoreWindow.Dispatcher :
                CoreApplication.GetCurrentView().CoreWindow.Dispatcher;

        protected void RaisePropertyChanged([CallerMemberName]string name = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
