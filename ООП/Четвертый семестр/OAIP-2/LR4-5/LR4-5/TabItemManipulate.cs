using System.Collections.Generic;
using System.Windows.Controls;

namespace OOP_Laba_4_5 {
  class TabItemManipulate {
    static List<TabItem> tabItems = new List<TabItem>();

    public static void NewTabItem(string tabItemHeader, RichTextBox richTextBoxContent, TabControl aimedTabControl) {
      TabItem newTabItem = new TabItem() {
        Header = new TextBlock { Text = tabItemHeader },
        Content = richTextBoxContent
      };
      aimedTabControl.Items.Add( newTabItem );

      tabItems.Add( newTabItem );
      newTabItem.Focus();
    }

    public static RichTextBox GetCurrentRichTextBox(TabControl aimedTabControl) {
      int index = aimedTabControl.SelectedIndex;
      TabItem tabItem = tabItems[ index ];

      RichTextBox currentRichText = tabItem.Content as RichTextBox;

      return currentRichText;
    }

    public static TabItem GetTabItemByIndex(int index) {
      return tabItems[ index ];
    }

    public static int GetIndex {
      get => tabItems.Count;
    }

  }
}
