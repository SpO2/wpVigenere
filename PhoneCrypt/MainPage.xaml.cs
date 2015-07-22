using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PhoneCrypt;
using PhoneCrypt.Entities;
using PhoneCrypt.Repositories;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using PhoneCrypt.Views;

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=391641

namespace PhoneCrypt
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<History> histories;
        private HistoryRepository historyRepository;
        private const String CONFIRM_DELETE_HISTORY = "Confirm History suppression ?";
        private const String UICOMMAND_YES = "Yes";
        private const String UICOMMAND_NO = "No";

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.historyRepository = new HistoryRepository();
        }

        /// <summary>
        /// Invoqué lorsque cette page est sur le point d'être affichée dans un frame.
        /// </summary>
        /// <param name="e">Données d’événement décrivant la manière dont l’utilisateur a accédé à cette page.
        /// Ce paramètre est généralement utilisé pour configurer la page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: préparer la page pour affichage ici.

            // TODO: si votre application comporte plusieurs pages, assurez-vous que vous
            // gérez le bouton Retour physique en vous inscrivant à l’événement
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Si vous utilisez le NavigationHelper fourni par certains modèles,
            // cet événement est géré automatiquement.
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Encryption encryption = new Encryption(this.tbWord.Text, this.tbPassPhrase.Text);
            History history;
            
            this.tbResult.Text = encryption.encrypt();
            if (this.tbResult.Text != "")
            {
                history = new History();
                history.value = this.tbWord.Text;
                history.password = this.tbPassPhrase.Text;
                this.historyRepository.add(history);
                Refresh_HistoryList();
            }
        }

        private void Refresh_HistoryList()
        {
            if (histories != null)
            {
                histories.Clear();
            }
            histories = this.historyRepository.list;
            listBoxobj.ItemsSource = histories;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh_HistoryList();
        }

        private async void btnClearHistory_Click(object sender, RoutedEventArgs e)
        {
            if (histories.Count > 0)
            {
                MessageDialog msgDialog = new MessageDialog(CONFIRM_DELETE_HISTORY);
                msgDialog.Commands.Add(new UICommand(UICOMMAND_NO, new UICommandInvokedHandler(Command)));
                msgDialog.Commands.Add(new UICommand(UICOMMAND_YES, new UICommandInvokedHandler(Command)));
                await msgDialog.ShowAsync();
            }      
        }

        private void Command(IUICommand command)
        {
            if (command.Label.Equals(UICOMMAND_YES))
            {
                historyRepository.deleteAll();
                Refresh_HistoryList();
            }
        }

        private void btnAboute_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About)); 
        }
    }
}
