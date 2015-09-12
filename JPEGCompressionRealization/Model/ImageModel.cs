using JPEGCompressionRealization.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPEGCompressionRealization.Model
{
    public class ImageModel : INotifyPropertyChanged
    {
        public ImageModel()
        {
            Compressor = new JPEGCompressor();
        }

        private string _imageModelPath;
        public string ImageModelPath
        {
            get
            {
                return _imageModelPath;
            }
            set
            {
                _imageModelPath = value;
                InvokePropertyChanged("imageModelPath");
            }
        }

        public ICompressor Compressor { get; set; }

        private void InvokePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
