﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MultiThreadedApp
{
    public partial class MainWindow : Window
    {
        private int shortDelay = 2000;
        private int mediumDelay = 5000;
        private int longDelay = 10000;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnExecuteClicked(object sender, RoutedEventArgs e)
        {
            ResultsWindow.Text = "Startup synchronous operation";
            Stopwatch timer = Stopwatch.StartNew();

            ShortRunningOperation();
            MediumRunningOperation();
            LongRunningOperation();

            timer.Stop();
            ResultsWindow.Text += $"{Environment.NewLine}Total running time: {timer.ElapsedMilliseconds / 1000} seconds";
        }

        private async void BtnAsyncClicked(object sender, RoutedEventArgs e)
        {
            ResultsWindow.Text = "Startup asynchronous operation";
            Stopwatch timer = Stopwatch.StartNew();

            await ShortRunningOperationAsync();
            await MediumRunningOperationAsync();
            await LongRunningOperationAsync();

            timer.Stop();
            ResultsWindow.Text += $"{Environment.NewLine}Total running time: {timer.ElapsedMilliseconds / 1000} seconds";
        }

        private async void BtnParallelClicked(object sender, RoutedEventArgs e)
        {
            ResultsWindow.Text = "Startup parallel operation";
            Stopwatch timer = Stopwatch.StartNew();

            timer.Stop();
            ResultsWindow.Text += $"{Environment.NewLine}Total running time: {timer.ElapsedMilliseconds / 1000} seconds";
        }

        private void ReportExecution(string method)
        {
            ResultsWindow.Text += $"{Environment.NewLine}Method {method} was completed. ";
        }

        private void ShortRunningOperation()
        {
            Thread.Sleep(shortDelay);
            ReportExecution(nameof(ShortRunningOperation));
        }

        private void MediumRunningOperation()
        {
            Thread.Sleep(mediumDelay);
            ReportExecution(nameof(MediumRunningOperation));
        }

        private void LongRunningOperation()
        {
            Thread.Sleep(longDelay);
            ReportExecution(nameof(LongRunningOperation));
        }

        private async Task ShortRunningOperationAsync()
        {
            await Task.Delay(shortDelay);
            ReportExecution(nameof(ShortRunningOperationAsync));
        }

        private async Task MediumRunningOperationAsync()
        {
            await Task.Delay(mediumDelay);
            ReportExecution(nameof(MediumRunningOperationAsync));
        }

        private async Task LongRunningOperationAsync()
        {
            await Task.Delay(longDelay);
            ReportExecution(nameof(LongRunningOperationAsync));
        }
    }
}