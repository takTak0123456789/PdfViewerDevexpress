using DevExpress.Xpf.PdfViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PdfViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PdfViewerControl pdfViewer;

        Tuple<int, int> firstTarget = new Tuple<int, int>(408, 700);
        Tuple<int, int> secondTarget = new Tuple<int, int>(300, 650);


        public MainWindow()
        {
            var viewModel = new PdfViewerVM();
            viewModel.PdfStream = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Demo.pdf");
            this.DataContext = viewModel;

            InitializeComponent();
        }
        void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Assuming you have one file that you care about, pass it off to whatever
                // handling code you have defined.
                HandleFileOpen(files[0]);

                e.Handled = true;
            }
        }

        private void HandleFileOpen(string inputFile)
        {
            var viewModel = this.DataContext as PdfViewerVM;
            if (viewModel != null)
            {
                viewModel.PdfStream = inputFile;
            }        
        }        
        private void PdfViewerControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var pdfViewer = sender as PdfViewerControl;

            PdfHitTestResult result = pdfViewer.HitTest(e.GetPosition(pdfViewer));
        }

        private void OnButtonGetPageSizeClick(object sender, RoutedEventArgs e)
        {
            
            var dimensions = pdfViewer?.GetPageSize(1);
        }

        private void GoToFirstTargetCommand(object sender, RoutedEventArgs e)
        {
            if (pdfViewer.SetPageNumberCommand.CanExecute(1))
            {
                pdfViewer.SetPageNumberCommand.Execute(1);
            }


            var position = pdfViewer.ConvertPixelToDocumentPosition(new Point(firstTarget.Item1 * (96 / 72), firstTarget.Item2 * (96 / 72)));

            pdfViewer.ZoomFactor = 3F;

            //pdfViewer.CursorMode = CursorModeType.MarqueeZoom;


            pdfViewer.ScrollIntoView(position, DevExpress.Xpf.DocumentViewer.ScrollIntoViewMode.Edge);

            //pdfViewer.ScrollToHorizontalOffset(firstTarget.Item1);
            //pdfViewer.ScrollToVerticalOffset(firstTarget.Item2);


        }

        private void GoToSecondTargetCommand(object sender, RoutedEventArgs e)
        {
            if (pdfViewer.SetPageNumberCommand.CanExecute(2))
            {
                pdfViewer.SetPageNumberCommand.Execute(2);
            }

            var position = pdfViewer.ConvertPixelToDocumentPosition(new Point(secondTarget.Item1 * (96/72), secondTarget.Item2 * (96 / 72)));

            pdfViewer.ZoomFactor = 3F;

            //pdfViewer.CursorMode = CursorModeType.MarqueeZoom;


            pdfViewer.ScrollIntoView(position, DevExpress.Xpf.DocumentViewer.ScrollIntoViewMode.Edge);

            //pdfViewer.ScrollToHorizontalOffset(300);
            //pdfViewer.ScrollToVerticalOffset(645);           

        }

        private void PdfViewerControl_Loaded(object sender, RoutedEventArgs e)
        {
            

            if (sender.GetType() == typeof(PdfViewerControl))
            {
                pdfViewer = sender as PdfViewerControl;
            }            
        }
    }
}
