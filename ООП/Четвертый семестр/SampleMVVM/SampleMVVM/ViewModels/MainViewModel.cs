using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

using SampleMVVM.Commands;
using System.Collections.ObjectModel;
using SampleMVVM.Models;

namespace SampleMVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<BookViewModel> BooksList { get; set; } 

        #region Constructor

        public MainViewModel(List<Book> books)
        {
            BooksList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
        }

        #endregion
    }
}
