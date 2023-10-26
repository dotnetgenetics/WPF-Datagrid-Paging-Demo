using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDatagridPaging
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private readonly PagingCollectionView _cview;
      private object PagingData;

      public MainWindow()
      {
         InitializeComponent();
         InitializeDataContextView();
         this._cview = (PagingCollectionView)PagingData;
         this.DataContext = this._cview;
      }

      private void InitializeDataContextView()
      {
         PagingData = new PagingCollectionView(
            new List<object>
              {
                     new { Animal = "Lion", Eats = "Tiger" },
                     new { Animal = "Bird", Eats = "Worm" },
                     new { Animal = "Rat", Eats = "Cheese" },
                     new { Animal = "Tiger", Eats =  "Bear" },
                     new { Animal = "Bear", Eats = "Oh my" },
                     new { Animal = "Fish", Eats = "Shrimps" },
                     new { Animal = "Goat", Eats = "Grass" },
                     new { Animal = "Wait", Eats = "Oh my isn't an animal" },
                     new { Animal = "Oh well", Eats = "Who is counting anyway" },
                     new { Animal = "Need better content", Eats = "For posting on stackoverflow" }
              }, 3);  //3 is items per page
      }

      private void OnFirstClicked(object sender, RoutedEventArgs e)
      {
         this._cview.MoveToFirstPage();
      }

      private void OnPreviousClicked(object sender, RoutedEventArgs e)
      {
         this._cview.MoveToPreviousPage();
      }

      private void OnNextClicked(object sender, RoutedEventArgs e)
      {
         this._cview.MoveToNextPage();
      }

      private void OnLastClicked(object sender, RoutedEventArgs e)
      {
         this._cview.MoveToLastPage();
      }
   }
}
