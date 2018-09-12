using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Contacts;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Script203
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

		public MainPage()
        {
            this.InitializeComponent(); 			
        }
		
		private async void OnLoadContact(object sender, RoutedEventArgs e)
		{
			CurrentContact = await CreateContactAsync();
		}

		private Contact _currentContact;
		public Contact CurrentContact
		{
			get => _currentContact;
			set
			{
				_currentContact = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentContact)));
			}
		}

		public static async Task<Contact> CreateContactAsync()
		{			
			var assets = await Package.Current.InstalledLocation.GetFolderAsync("Assets");
			var imageFile = await assets.GetFileAsync("aspitalia.png");

			return new Contact
			{
				FirstName = "Mario",
				LastName = "Rossi",
				SourceDisplayPicture = imageFile
			};
		}
	}
}
