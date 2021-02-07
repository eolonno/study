using System;
using System.Collections;
using System.Collections.Generic;

namespace ЛР__12
{
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
}
