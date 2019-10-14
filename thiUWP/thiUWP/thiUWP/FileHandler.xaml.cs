using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace thiUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FileHandler : Page
    {
        public FileHandler()
        {
            this.InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string sampleFile = DateTime.Now.ToString("yyyy-MM-dd-hh-mm") + ".txt";

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile tokenFile = storageFolder.CreateFileAsync(sampleFile, Windows.Storage.CreationCollisionOption.ReplaceExisting).GetAwaiter().GetResult();
            Windows.Storage.FileIO.WriteTextAsync(tokenFile, this.contentFiles.Text).GetAwaiter().GetResult();

            Debug.WriteLine(tokenFile.Path);
        }

        private string readFile(string sampleFile)
        {
            try
            {
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile tokenFile = storageFolder.GetFileAsync(sampleFile).GetAwaiter().GetResult();
                Debug.WriteLine(tokenFile.Path);
                var token = Windows.Storage.FileIO.ReadTextAsync(tokenFile).GetAwaiter().GetResult();

                this.contentFiles.Text = token;
                Debug.WriteLine(tokenFile.Path);

                return this.contentFiles.Text;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

                return null;
            }
        }
    }
}
