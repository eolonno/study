using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ЛР__10
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();
            book.Add(0, "Hello World!");
            book.Add(0, "Lorem Ipsum dolor");
            book.Add(0, "Sit amet consueror");
            book.Add(0, "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium");

            book.PrintBook();

            book.Remove(2);

            book.PrintBook();

            book.PageSearchByNumber(2);
            book.PageSearchByText("Hello World!");

            BookDictionary DictionaryBook = new BookDictionary();
            book.CloneToDictionary(ref DictionaryBook);

            DictionaryBook.Print();

            Console.WriteLine($"Вторая страница: {DictionaryBook[2]}");

            ObservableCollection<Book> BookInObservableCollection = new ObservableCollection<Book>();
            BookInObservableCollection.CollectionChanged += Book_CollectionChanged;

            BookInObservableCollection.Add(book);
            BookInObservableCollection.Add(new Book());

            BookInObservableCollection.RemoveAt(1);

        }
        private static void Book_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    
                    Console.WriteLine("Добавлен новый объект");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Удален объект");
                    break;
            }
        }
    class Book : IDictionary<int, string>
        {
            public ICollection<string> Values { get; }
            public ICollection<int> Keys { get; }
            public struct Page
            {
                public string _Text { get; private set; }
                public int _Number { get; private set; }
                public Page(string Text, int Number)
                {
                    _Text = Text;
                    _Number = Number;
                }
            }
            private List<Page> BookPages = new List<Page>();
            public int Count { get; private set; } = 0;
            public bool IsReadOnly { get; }

            string IDictionary<int, string>.this[int key] { get => BookPages[key]._Text; set => throw new NotImplementedException(); }

            public void Add(int Number, string Text)
            {
                BookPages.Add(new Page(Text, ++Count));
            }
            public bool Remove(int Number)
            {
                if (BookPages.Remove(BookPages[--Number]))
                {
                    Console.WriteLine("Успешно удалено.");
                    Count--;
                    for (int i = Number; i < Count; i++)
                    {
                        Page page = new Page(BookPages[i]._Text, i + 1);
                        BookPages[i] = page;
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("Ошибка удаления!");
                    return false;
                }
            }
            public void PageSearchByText(string Text)
            {
                foreach (Page page in BookPages)
                {
                    if (page._Text == Text)
                    {
                        Console.WriteLine($"Страница найдена!\nНомер: {page._Number}\nТекст: {page._Text}");
                        return;
                    }
                }
                Console.WriteLine("Страница не найдена!\n");
            }
            public void PageSearchByNumber(int Number)
            {
                try
                {
                    Console.WriteLine($"Страница найдена!\nНомер: {BookPages[Number - 1]._Number}\nТекст: {BookPages[Number - 1]._Text}\n");
                }
                catch (Exception)
                {
                    Console.WriteLine("Страница не найдена!\n");
                }
            }
            public void PrintBook()
            {
                Console.WriteLine("\n------------------------------------------------------");
                foreach (Page page in BookPages)
                    Console.WriteLine($"Номер страницы: {page._Number}\nТекст: {page._Text}");
                Console.WriteLine("------------------------------------------------------\n");
            }
            public void RemoveN(int start, int n)
            {
                BookPages.RemoveRange(start, n);
            }
            public void Insert(Page page, int index)
            {
                BookPages.Insert(index, page);
            }
            public void AddRange(Page[] pages)
            {
                BookPages.AddRange(pages);
            }
            public void CloneToDictionary(ref BookDictionary bookDictionary)
            {
                foreach (Page page in BookPages)
                    bookDictionary.Add(page._Number, page._Text);
            }
            bool IDictionary<int, string>.ContainsKey(int key)
            {
                throw new NotImplementedException();
            }

            bool IDictionary<int, string>.TryGetValue(int key, out string value)
            {
                throw new NotImplementedException();
            }

            void ICollection<KeyValuePair<int, string>>.Add(KeyValuePair<int, string> item)
            {
                throw new NotImplementedException();
            }

            void ICollection<KeyValuePair<int, string>>.Clear()
            {
                throw new NotImplementedException();
            }

            bool ICollection<KeyValuePair<int, string>>.Contains(KeyValuePair<int, string> item)
            {
                throw new NotImplementedException();
            }

            void ICollection<KeyValuePair<int, string>>.CopyTo(KeyValuePair<int, string>[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            bool ICollection<KeyValuePair<int, string>>.Remove(KeyValuePair<int, string> item)
            {
                throw new NotImplementedException();
            }

            IEnumerator<KeyValuePair<int, string>> IEnumerable<KeyValuePair<int, string>>.GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
        class BookDictionary
        {
            Dictionary<int, string> BookPages = new Dictionary<int, string>();
            List<int> Keys = new List<int>();
            public void Add(int key, string text)
            {
                BookPages.Add(key, text);
                Keys.Add(key);
            }
            public bool Print()
            {
                if (Keys == null)
                    return false ;
                foreach (int key in Keys)
                {
                    Console.WriteLine("\n------------------------------------------------------");
                    Console.WriteLine($"Номер страницы: {key}\nТекст: {BookPages[key]}");
                    Console.WriteLine("------------------------------------------------------\n");
                }
                return true;
            }
            public string PrintPage(int number)
            {
                return BookPages[number];
            }
            public string this[int number]
            {
                get => BookPages[number];
            }
        }
    }
}
