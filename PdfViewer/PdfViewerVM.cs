using DevExpress.Mvvm;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PdfViewer
{
    public class PdfViewerVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PdfViewerVM()
        {

        }


        private string pdfStream;
        public string PdfStream
        {
            get
            {
                return this.pdfStream;
            }

            set
            {
                if (value != this.pdfStream)
                {
                    this.pdfStream = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
