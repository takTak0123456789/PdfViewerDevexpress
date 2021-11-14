using DevExpress.Pdf;
using DevExpress.Xpf.DocumentViewer;
using DevExpress.Xpf.PdfViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
            //if (pdfViewer.SetPageNumberCommand.CanExecute(1))
            //{
            //    pdfViewer.SetPageNumberCommand.Execute(1);
            //}


            var position = new PdfDocumentPosition(1, new PdfPoint(220, 235)); 
            //var position = new PdfDocumentPosition(1, new PdfPoint(364, 235)); 

            NavigateTo(position);


            //pdfViewer.ZoomFactor = 3F;

            //pdfViewer.CursorMode = CursorModeType.MarqueeZoom;


            //pdfViewer.ScrollIntoView(position, DevExpress.Xpf.DocumentViewer.ScrollIntoViewMode.Edge);

            //pdfViewer.ScrollToHorizontalOffset(firstTarget.Item1);
            //pdfViewer.ScrollToVerticalOffset(firstTarget.Item2);


        }

        private void GoToSecondTargetCommand(object sender, RoutedEventArgs e)
        {
            //if (pdfViewer.SetPageNumberCommand.CanExecute(2))
            //{
            //    pdfViewer.SetPageNumberCommand.Execute(2);
            //}

            var position = new PdfDocumentPosition(2, new PdfPoint(160, 390)); 
            //var position = new PdfDocumentPosition(2, new PdfPoint(415, 350)); 

            NavigateTo(position);

        }

        private void NavigateTo(PdfDocumentPosition position)
        {
            // var helper = ((IPdfViewer)pdfViewer).GetDocumentProcessorHelper();
            //var viewer = (DocumentViewerControl)pdfViewer;
            //var height = viewer.ActualHeight;
            //var width = viewer.ActualWidth;

            //var page = viewer.Document.Pages.ToList().First();

            //var pageSize = page.PageSize;

            //var cropBox = ((DevExpress.Xpf.PdfViewer.PdfPageViewModel)page).Page.CropBox;

            //float cropBoxWidth = (float)cropBox.Width;
            //float cropBoxHeight = (float)cropBox.Height;

            //int x = (int)((position.Point.X / (pdfViewer.ZoomFactor * 0.01)) - (cropBoxWidth / (pdfViewer.ZoomFactor * 0.01) / 2));
            //int y = (int)((position.Point.Y / (pdfViewer.ZoomFactor * 0.01)) - (cropBoxHeight / (pdfViewer.ZoomFactor * 0.01) / 2));

            //var pixels = pdfViewer.ConvertDocumentPositionToPixel(position);

            //pdfViewer.ScrollToHorizontalOffset(pixels.X);
            //pdfViewer.ScrollToVerticalOffset(pixels.Y);

            pdfViewer.ScrollIntoView(position, DevExpress.Xpf.DocumentViewer.ScrollIntoViewMode.TopLeft);

            pdfViewer.ZoomFactor = 2F;
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
