﻿using System.Collections;
using System.ComponentModel;
using System.Windows.Data;

namespace WPFDatagridPaging
{
   public class PagingCollectionView : CollectionView
   {
      private readonly IList _innerList;
      private readonly int _itemsPerPage;

      private int _currentPage = 1;

      public PagingCollectionView(IList innerList, int itemsPerPage)
          : base(innerList)
      {
         this._innerList = innerList;
         this._itemsPerPage = itemsPerPage;
      }

      public override int Count
      {
         get
         {
            return this._itemsPerPage;
         }
      }

      public int CurrentPage
      {
         get
         {
            return this._currentPage;
         }

         set
         {
            this._currentPage = value;
            this.OnPropertyChanged(new PropertyChangedEventArgs("CurrentPage"));
         }
      }

      public int ItemsPerPage
      {
         get
         {
            return this._itemsPerPage;
         }
      }

      public int PageCount
      {
         get
         {
            int pagecount = (this._innerList.Count + this._itemsPerPage - 1)
                / this._itemsPerPage;

            return (this._innerList.Count + this._itemsPerPage - 1)
                / this._itemsPerPage;
         }
      }

      private int EndIndex
      {
         get
         {
            var end = this._currentPage * this._itemsPerPage - 1;
            return (end > this._innerList.Count) ? this._innerList.Count : end;
         }
      }

      private int StartIndex
      {
         get
         {
            return (this._currentPage - 1) * this._itemsPerPage;
         }
      }

      public override object GetItemAt(int index)
      {
         var offset = index % (this._itemsPerPage);

         //added fix using condition
         if (((this.StartIndex + offset) >= this._innerList.Count))
            return new object();
         else
            return this._innerList[this.StartIndex + offset];
      }

      public void MoveToFirstPage()
      {
         if (this._currentPage >= 1)
         {
            this.CurrentPage = 1;
         }

         this.Refresh();
      }

      public void MoveToPreviousPage()
      {
         if (this._currentPage > 1)
         {
            this.CurrentPage -= 1;
         }

         this.Refresh();
      }

      public void MoveToNextPage()
      {
         if (this._currentPage < this.PageCount)
         {
            this.CurrentPage += 1;
         }

         this.Refresh();
      }

      public void MoveToLastPage()
      {
         if (this._currentPage < this.PageCount)
         {
            this.CurrentPage = this.PageCount;
         }

         this.Refresh();
      }
   }
}
