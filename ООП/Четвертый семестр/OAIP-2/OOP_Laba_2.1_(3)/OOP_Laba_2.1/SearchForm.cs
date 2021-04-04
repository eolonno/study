using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Laba_2._1 {
  public partial class SearchForm : Form {

    int search_type;
    List<Flat> flats_temp;
    public SearchForm(int search_type, IEnumerable<Flat> flats) {
      InitializeComponent();


      flats_temp = (List<Flat>)flats;
      this.search_type = search_type;
    }

    private void Search(int type) {
      switch (type) {
        case 1: {
          bool flag = false;
          search_from_display.Nodes.Clear();
          if (System.Text.RegularExpressions.Regex.IsMatch(search_textbox.Text, @"[0,1,2,3,4,5,6,7,8,9,\b]")) {
            foreach (Flat flat_item in flats_temp) {
              if (flat_item.count == Convert.ToInt32(search_textbox.Text)) {
                search_from_display.Nodes.Add(flat_item.TakeItemTree());
                flag = true;
              }
            }
          }
          if (!flag) {
            MessageBox.Show("Квартир с таким количеством комнат не существует", "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          break;
        }
        case 2: {
          bool flag = false;
          search_from_display.Nodes.Clear();
          if (System.Text.RegularExpressions.Regex.IsMatch(search_textbox.Text, @"[0,1,2,3,4,5,6,7,8,9,\b]")) {
            foreach (Flat flat_item in flats_temp) {
              if (flat_item.year == search_textbox.Text) {
                search_from_display.Nodes.Add(flat_item.TakeItemTree());
                flag = true;
              }
            }
          }
          if (!flag) {
            MessageBox.Show("Квартир с таким годом не существует", "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          break;
        }
        case 3: {
          bool flag = false;
          search_from_display.Nodes.Clear();
          foreach (Flat flat_item in flats_temp) {
            if (System.Text.RegularExpressions.Regex.IsMatch(flat_item.addr.addr_region, $@"\w*{search_textbox.Text}\w*", System.Text.RegularExpressions.RegexOptions.IgnoreCase)) {
              search_from_display.Nodes.Add(flat_item.TakeItemTree());
              flag = true;
            }
          }
          if (!flag) {
            MessageBox.Show("Квартир с таким районом не существует", "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          break;
        }
        case 4: {
          bool flag = false;
          search_from_display.Nodes.Clear();
          foreach (Flat flat_item in flats_temp) {
            if (System.Text.RegularExpressions.Regex.IsMatch(flat_item.addr.addr_city, $@"\w*{search_textbox.Text}\w*", System.Text.RegularExpressions.RegexOptions.IgnoreCase)) {
              search_from_display.Nodes.Add(flat_item.TakeItemTree());
              flag = true;
            }
          }
          if (!flag) {
            MessageBox.Show("Квартир с таким городом не существует", "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          break;
        }
      }
    }

    private void search_btn_Click(object sender, EventArgs e) {
      Search(search_type);
    }
  }
}

