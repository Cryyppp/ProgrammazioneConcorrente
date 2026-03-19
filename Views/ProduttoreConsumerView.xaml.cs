using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ConcurrentProgrammingApp.Views
{
    public partial class ProduttoreConsumerView : UserControl
    {
        private ObservableCollection<int> bufferItems;
        private int empty = 6;
        private int full = 0;
        private int mutex = 1;
        private bool isRunning = false;
        private CancellationTokenSource? cancellationTokenSource;

        public ProduttoreConsumerView()
        {
            InitializeComponent();
            bufferItems = new ObservableCollection<int>();
            BufferDisplay.ItemsSource = bufferItems;
            UpdateUI();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                PlayButton.IsEnabled = false;
                PauseButton.IsEnabled = true;
                cancellationTokenSource = new CancellationTokenSource();
                _ = RunSimulation(cancellationTokenSource.Token);
            }
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning)
            {
                isRunning = false;
                PlayButton.IsEnabled = true;
                PauseButton.IsEnabled = false;
                cancellationTokenSource?.Cancel();
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            isRunning = false;
            PlayButton.IsEnabled = true;
            PauseButton.IsEnabled = false;
            cancellationTokenSource?.Cancel();
            
            bufferItems.Clear();
            empty = 6;
            full = 0;
            mutex = 1;
            LogBox.Text = "Simulazione ripristinata.";
            UpdateUI();
        }

        private async Task RunSimulation(CancellationToken cancellationToken)
        {
            int itemId = 1;
            
            while (isRunning && !cancellationToken.IsCancellationRequested)
            {
                // Produttore
                if (empty > 0)
                {
                    await Task.Delay(800, cancellationToken);
                    empty--;
                    full++;
                    bufferItems.Add(itemId);
                    LogBox.Text += $"\n[Produttore] Inserito item #{itemId}";
                    itemId++;
                    UpdateUI();
                }

                if (!isRunning || cancellationToken.IsCancellationRequested) break;

                // Consumatore
                if (full > 0)
                {
                    await Task.Delay(1200, cancellationToken);
                    full--;
                    empty++;
                    if (bufferItems.Count > 0)
                    {
                        int removed = bufferItems[0];
                        bufferItems.RemoveAt(0);
                        LogBox.Text += $"\n[Consumatore] Prelevato item #{removed}";
                    }
                    UpdateUI();
                }

                await Task.Delay(500, cancellationToken);
            }
        }

        private void UpdateUI()
        {
            Dispatcher.Invoke(() =>
            {
                EmptyValue.Text = empty.ToString();
                FullValue.Text = full.ToString();
                MutexValue.Text = mutex.ToString();

                // Render buffer items
                BufferDisplay.Items.Clear();
                foreach (var item in bufferItems)
                {
                    var border = new Border
                    {
                        Width = 40,
                        Height = 40,
                        CornerRadius = new CornerRadius(4),
                        Background = new SolidColorBrush(Color.FromRgb(0, 255, 136)),
                        Child = new TextBlock
                        {
                            Text = item.ToString(),
                            Foreground = new SolidColorBrush(Color.FromRgb(13, 15, 26)),
                            FontWeight = FontWeights.Bold,
                            TextAlignment = TextAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            FontFamily = new System.Windows.Media.FontFamily("JetBrains Mono, Courier New")
                        }
                    };
                    BufferDisplay.Items.Add(border);
                }
            });
        }
    }
}
