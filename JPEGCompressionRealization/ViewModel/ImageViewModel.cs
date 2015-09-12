using JPEGCompressionRealization.Model;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using System.IO;

namespace JPEGCompressionRealization.ViewModel
{
    public class ImageViewModel : INotifyPropertyChanged
    {
        public ImageViewModel()
        {
            ImageModel = new ImageModel();
            OpenCommand = new Command(x => OpenImage());
            CompressCommand = new Command(x => CompressImage());            
        }

        public ImageModel ImageModel { get; set; }

        public ICommand OpenCommand { get; set; }

        public ICommand CompressCommand { get; set; }

        private BitmapImage _compressedImage;
        public BitmapImage CompressedImage
        {
            get
            {
                return _compressedImage;
            }
            set
            {
                _compressedImage = value;
                InvokePropertyChanged("CompressedImage");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void OpenImage()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = @"Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            fileDialog.CheckFileExists = true;
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() == true)
            {
                ImageModel.ImageModelPath = fileDialog.FileName;                
            }            
        }

        private void CompressImage()
        {
            if (string.IsNullOrEmpty(ImageModel.ImageModelPath))
            {
                MessageBox.Show("Please choose the image!");
                return;
            }

            var bmImage = ImageModel.Compressor.Compress(ImageModel.ImageModelPath);
            
            using (MemoryStream memory = new MemoryStream())
            {
                bmImage.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                var bmi = new BitmapImage();
                bmi.BeginInit();
                bmi.StreamSource = memory;
                bmi.CacheOption = BitmapCacheOption.OnLoad;
                bmi.EndInit();
                CompressedImage = bmi;
            }
        }
    }
}
