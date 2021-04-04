using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OOP_Laba_4_5 {
  class RichTExtBoxCreatetor {
    public static RichTextBox CreateRichTextBox(RoutedEventHandler contextMenuEventHandler_Click,
        DragEventHandler richTextBoxEventHandler_DragOver,
        DragEventHandler richTextBoxEventHandler_DragDrop,
        TextChangedEventHandler richTextBoxEventHandler_OnTextChange
    ) {
      //---------------- Создание контекстного меню
      ContextMenu contextMenu = new ContextMenu();
      MenuItem item = new MenuItem { Header = "Close" };
      item.Click += contextMenuEventHandler_Click;
      contextMenu.Items.Add( item );
      //----------------
      //---------------- Создание пустого rich text box
      RichTextBox richTextBox = new RichTextBox() {
        Name = "tmpRichText",
      };
      //----------------
      //---------------- Задание drag and drop
      richTextBox.AllowDrop = true;
      richTextBox.AddHandler( RichTextBox.DragOverEvent, richTextBoxEventHandler_DragOver, true );
      richTextBox.AddHandler( RichTextBox.DropEvent, richTextBoxEventHandler_DragDrop, true );
      //----------------
      //---------------- Назначение контекстного меню/ прокрутки
      richTextBox.ContextMenu = contextMenu;
      richTextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
      richTextBox.TextChanged += richTextBoxEventHandler_OnTextChange;

      return richTextBox;
    }
  }
}
