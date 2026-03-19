using System.Windows;
using System.Windows.Controls;

namespace ConcurrentProgrammingApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavListBox.SelectedIndex = 0;
        }

        private void NavListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = NavListBox.SelectedIndex;
            
            switch (selectedIndex)
            {
                case 0:
                    ShowHome();
                    break;
                case 1:
                    ShowSemafori();
                    break;
                case 2:
                    ShowProduttoreConsumatore();
                    break;
                case 3:
                    ShowProblemiClassici();
                    break;
                case 4:
                    ShowSoluzioni();
                    break;
                case 5:
                    ShowRischi();
                    break;
            }
        }

        private void ShowHome()
        {
            ContentPanel.Children.Clear();
            ContentPanel.Children.Add(new Views.HomeView());
        }

        private void ShowSemafori()
        {
            ContentPanel.Children.Clear();
            ContentPanel.Children.Add(new Views.SemaforiView());
        }

        private void ShowProduttoreConsumatore()
        {
            ContentPanel.Children.Clear();
            ContentPanel.Children.Add(new Views.ProduttoreConsumerView());
        }

        private void ShowProblemiClassici()
        {
            ContentPanel.Children.Clear();
            ContentPanel.Children.Add(new Views.ProblemiClassiciView());
        }

        private void ShowSoluzioni()
        {
            ContentPanel.Children.Clear();
            ContentPanel.Children.Add(new Views.SoluzioniView());
        }

        private void ShowRischi()
        {
            ContentPanel.Children.Clear();
            ContentPanel.Children.Add(new Views.RischiView());
        }
    }
}
