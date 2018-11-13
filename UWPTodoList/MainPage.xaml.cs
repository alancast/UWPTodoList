using UWPTodoList.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPTodoList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        #region NavigationView event handlers
        private void nvTopLevelNav_Loaded(object sender, RoutedEventArgs e)
        {
            // set the initial SelectedItem
            foreach (NavigationViewItemBase item in nvTopLevelNav.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "Home_Page")
                {
                    nvTopLevelNav.SelectedItem = item;
                    break;
                }
            }
            contentFrame.Navigate(typeof(TodoListPage));
        }

        private void nvTopLevelNav_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            //Only happens when selection is changed, so if you reclick on the same selection nothing happens
            //for this example we will just go with ItemInvoked (and will leave this empty) so it triggers every time
        }

        private void nvTopLevelNav_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                //contentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                TextBlock ItemContent = args.InvokedItem as TextBlock;
                if (ItemContent != null)
                {
                    switch (ItemContent.Tag)
                    {
                        case "Nav_Home":
                            contentFrame.Navigate(typeof(TodoListPage));
                            break;

                        case "Nav_Shop":
                            //contentFrame.Navigate(typeof(ShopPage));
                            break;

                        case "Nav_ShopCart":
                            //contentFrame.Navigate(typeof(CartPage));
                            break;

                        case "Nav_Message":
                            //contentFrame.Navigate(typeof(MessagePage));
                            break;

                        case "Nav_Print":
                            //contentFrame.Navigate(typeof(PrintPage));
                            break;
                    }
                }
            }
        }
        #endregion
    }
}
