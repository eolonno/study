using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace OOP_Laba_2 {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();



      flat_year.DataSource = flats;
      flat_year.DisplayMember = "Name";
      flat_year.ValueMember = "Value";

      addr_country.DataSource = country;
      addr_country.DisplayMember = "Name";
      addr_country.ValueMember = "Value";

      room_combobox_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      room_combobox_1.DataSource = room_windows_1;
      room_combobox_1.DisplayMember = "Name";
      room_combobox_1.ValueMember = "Value";

      room_combobox_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      room_combobox_2.DataSource = room_windows_2;
      room_combobox_2.DisplayMember = "Name";
      room_combobox_2.ValueMember = "Value";

      room_combobox_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      room_combobox_3.DataSource = room_windows_3;
      room_combobox_3.DisplayMember = "Name";
      room_combobox_3.ValueMember = "Value";


      flat_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

      addr_house.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      addr_house.DisplayMember = "0";
      addr_street.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      addr_street.DisplayMember = "0";
      addr_region.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      addr_region.DisplayMember = "0";
      addr_city.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      addr_city.DisplayMember = "0";
      addr_country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      addr_country.DisplayMember = "0";


    }


    double SUMM = 0;


    const int cost_one_window = 6000;
    const double south = 1.7;
    const double south_west = 1.5;
    const double cost_one_metre = 6000;
    const int flat_metr_max = 1000;
    const int cost_flat_room = 50000;

    int flat_metr_value, flat_number_value, flat_year_select, flat_option_value = 0,
      flat_material_value = 0;

    double flat_confirm_summ = 0;
    string flat_year_select_name;

    //addr_tab
    int addr_country_select, addr_city_select, addr_region_select, addr_street_select, addr_house_select, addr_number_select;



    double addr_summ = 0;

    string[ ] addr_names = new string[ 5 ];

    //room_tab
    string room_name;
    string[ ] room_names = new string[ 3 ];


    int[ ] room_textBox_value = new int[ 3 ];
    int[ ] room_comboBox_value = new int[ 3 ];
    int[ ] room_numeric_value = new int[ 3 ];
    double[ ] room_confirm_summ = new double[ 3 ];


    //data
    #region
    List<Data> flats = new List<Data> {
      new Data { Name = "1970", Value = 19700},
      new Data { Name = "1975", Value = 19750},
      new Data { Name = "1990", Value = 19900},
      new Data { Name = "1999", Value = 19990},
      new Data { Name = "2002", Value = 20020},
      new Data { Name = "2007", Value = 20070},
      new Data { Name = "2012", Value = 20120},
      new Data { Name = "2015", Value = 20150}
    };

    List<Data> country = new List<Data>{
      new Data { Name = "Беларусь", Value = 0 },
      new Data { Name = "Россия", Value = 1 },
      new Data { Name = "Украина", Value = 2 },
      new Data { Name = "Казахстан", Value = 3 }
    };

    List<Data> city_bel = new List<Data>{
      new Data { Name = "Минск", Value = 0 },
      new Data { Name = "Брест", Value = 1 }
    };

    List<Data> city_rus = new List<Data>{
      new Data { Name = "Москва", Value = 2 },
      new Data { Name = "Питер", Value = 3 }
    };

    List<Data> city_ukr = new List<Data>{
      new Data { Name = "Киев", Value = 4 },
      new Data { Name = "Полтава", Value = 5 }
    };

    List<Data> city_kz = new List<Data>{
      new Data { Name = "Караганда", Value = 6 },
      new Data { Name = "Астана", Value = 7 }
    };

    List<Data> region_bel_1 = new List<Data>{
      new Data { Name = "Район 1.1 Бел", Value = 0 },
      new Data { Name = "Район 1.2 Бел", Value = 1 }
    };

    List<Data> region_bel_2 = new List<Data>{
      new Data { Name = "Район 2.1 Бел", Value = 2 },
      new Data { Name = "Район 2.2 Бел", Value = 3 }
    };

    List<Data> region_rus_1 = new List<Data>{
      new Data { Name = "Район 1.1 рус", Value = 4 },
      new Data { Name = "Район 1.2 рус", Value = 5 }
    };

    List<Data> region_rus_2 = new List<Data>{
      new Data { Name = "Район 2.1 рус", Value = 6 },
      new Data { Name = "Район 2.2 рус", Value = 7 }
    };

    List<Data> region_ukr_1 = new List<Data>{
      new Data { Name = "Район 1.1 укр", Value = 8 },
      new Data { Name = "Район 1.2 укр", Value = 9 }
    };

    List<Data> region_ukr_2 = new List<Data>{
      new Data { Name = "Район 2.1 укр", Value = 10 },
      new Data { Name = "Район 2.2 укр", Value = 11 }
    };

    List<Data> region_kz_1 = new List<Data>{
      new Data { Name = "Район 1.1 kz", Value = 12 },
      new Data { Name = "Район 1.2 kz", Value = 13 }
    };

    List<Data> region_kz_2 = new List<Data>{
      new Data { Name = "Район 2.1 kz", Value = 14 },
      new Data { Name = "Район 2.2 kz", Value = 15 }
    };

    List<Data> street_bel_1 = new List<Data>{
      new Data { Name = "Улица 1.1 бел", Value = 0 },
      new Data { Name = "Улица 1.2 бел", Value = 1 }
    };

    List<Data> street_bel_2 = new List<Data>{
      new Data { Name = "Улица 2.1 бел", Value = 2 },
      new Data { Name = "Улица 3.2 бел", Value = 3 }
    };

    List<Data> street_bel_3 = new List<Data>{
      new Data { Name = "Улица 3.1 бел", Value = 4 },
      new Data { Name = "Улица 3.2 бел", Value = 5 }
    };

    List<Data> street_bel_4 = new List<Data>{
      new Data { Name = "Улица 4.1 бел", Value = 6 },
      new Data { Name = "Улица 4.2 бел", Value = 7 }
    };

    List<Data> street_rus_1 = new List<Data>{
      new Data { Name = "Улица 1.1 rus", Value = 8 },
      new Data { Name = "Улица 1.2 rus", Value = 9 }
    };

    List<Data> street_rus_2 = new List<Data>{
      new Data { Name = "Улица 2.1 rus", Value = 10 },
      new Data { Name = "Улица 3.2 rus", Value = 11 }
    };

    List<Data> street_rus_3 = new List<Data>{
      new Data { Name = "Улица 3.1 rus", Value = 12 },
      new Data { Name = "Улица 3.2 rus", Value = 13 }
    };

    List<Data> street_rus_4 = new List<Data>{
      new Data { Name = "Улица 4.1 rus", Value = 14 },
      new Data { Name = "Улица 4.2 rus", Value = 15 }
    };

    List<Data> street_ukr_1 = new List<Data>{
      new Data { Name = "Улица 1.1 ukr", Value = 16 },
      new Data { Name = "Улица 1.2 ukr", Value = 17 }
    };

    List<Data> street_ukr_2 = new List<Data>{
      new Data { Name = "Улица 2.1 ukr", Value = 18 },
      new Data { Name = "Улица 3.2 ukr", Value = 19 }
    };

    List<Data> street_ukr_3 = new List<Data>{
      new Data { Name = "Улица 3.1 ukr", Value = 20 },
      new Data { Name = "Улица 3.2 ukr", Value = 21 }
    };

    List<Data> street_ukr_4 = new List<Data>{
      new Data { Name = "Улица 4.1 ukr", Value = 22 },
      new Data { Name = "Улица 4.2 ukr", Value = 23 }
    };

    List<Data> street_kz_1 = new List<Data>{
      new Data { Name = "Улица 1.1 kz", Value = 24 },
      new Data { Name = "Улица 1.2 kz", Value = 25 }
    };

    List<Data> street_kz_2 = new List<Data>{
      new Data { Name = "Улица 2.1 kz", Value = 26 },
      new Data { Name = "Улица 3.2 kz", Value = 27 }
    };

    List<Data> street_kz_3 = new List<Data>{
      new Data { Name = "Улица 3.1 kz", Value = 28 },
      new Data { Name = "Улица 3.2 kz", Value = 29 }
    };

    List<Data> street_kz_4 = new List<Data>{
      new Data { Name = "Улица 4.1 kz", Value = 30 },
      new Data { Name = "Улица 4.2 kz", Value = 31 }
    };

    List<Data> house_bel_1 = new List<Data>{
      new Data { Name = "Дом 1.1 бел", Value = 10000 },
      new Data { Name = "Дом 1.2 бел", Value = 11000 }
    };

    List<Data> house_bel_2 = new List<Data>{
      new Data { Name = "Дом 2.1 бел", Value = 12000 },
      new Data { Name = "Дом 3.2 бел", Value = 13000 }
    };

    List<Data> house_bel_3 = new List<Data>{
      new Data { Name = "Дом 3.1 бел", Value = 14000 },
      new Data { Name = "Дом 3.2 бел", Value = 15000 }
    };

    List<Data> house_bel_4 = new List<Data>{
      new Data { Name = "Дом 4.1 бел", Value = 16000 },
      new Data { Name = "Дом 4.2 бел", Value = 17000 }
    };

    List<Data> house_bel_5 = new List<Data>{
      new Data { Name = "Дом 5.1 бел", Value = 18000 },
      new Data { Name = "Дом 5.2 бел", Value = 19000 }
    };

    List<Data> house_bel_6= new List<Data>{
      new Data { Name = "Дом 6.1 бел", Value = 20000 },
      new Data { Name = "Дом 6.2 бел", Value = 21000 }
    };

    List<Data> house_bel_7 = new List<Data>{
      new Data { Name = "Дом 7.1 бел", Value = 22000 },
      new Data { Name = "Дом 7.2 бел", Value = 23000 }
    };

    List<Data> house_bel_8 = new List<Data>{
      new Data { Name = "Дом 8.1 бел", Value = 24000 },
      new Data { Name = "Дом 8.2 бел", Value = 25000 }
    };

    List<Data> house_rus_1 = new List<Data>{
      new Data { Name = "Дом 1.1 rus", Value = 26000 },
      new Data { Name = "Дом 1.2 rus", Value = 27000 }
    };

    List<Data> house_rus_2 = new List<Data>{
      new Data { Name = "Дом 2.1 rus", Value = 28000 },
      new Data { Name = "Дом 3.2 rus", Value = 29000 }
    };

    List<Data> house_rus_3 = new List<Data>{
      new Data { Name = "Дом 3.1 rus", Value = 30000 },
      new Data { Name = "Дом 3.2 rus", Value = 31000 }
    };

    List<Data> house_rus_4 = new List<Data>{
      new Data { Name = "Дом 4.1 rus", Value = 32000 },
      new Data { Name = "Дом 4.2 rus", Value = 33000 }
    };

    List<Data> house_rus_5 = new List<Data>{
      new Data { Name = "Дом 5.1 rus", Value = 34000 },
      new Data { Name = "Дом 5.2 rus", Value = 35000 }
    };

    List<Data> house_rus_6 = new List<Data>{
      new Data { Name = "Дом 6.1 rus", Value = 36000 },
      new Data { Name = "Дом 6.2 rus", Value = 37000 }
    };

    List<Data> house_rus_7 = new List<Data>{
      new Data { Name = "Дом 7.1 rus", Value = 38000 },
      new Data { Name = "Дом 7.2 rus", Value = 39000 }
    };

    List<Data> house_rus_8 = new List<Data>{
      new Data { Name = "Дом 8.1 rus", Value = 40000 },
      new Data { Name = "Дом 8.2 rus", Value = 41000 }
    };

    List<Data> house_ukr_1 = new List<Data>{
      new Data { Name = "Дом 1.1 ukr", Value = 42000 },
      new Data { Name = "Дом 1.2 ukr", Value = 43000 }
    };

    List<Data> house_ukr_2 = new List<Data>{
      new Data { Name = "Дом 2.1 ukr", Value = 44000 },
      new Data { Name = "Дом 3.2 ukr", Value = 45000 }
    };

    List<Data> house_ukr_3 = new List<Data>{
      new Data { Name = "Дом 3.1 ukr", Value = 46000 },
      new Data { Name = "Дом 3.2 ukr", Value = 47000 }
    };

    List<Data> house_ukr_4 = new List<Data>{
      new Data { Name = "Дом 4.1 ukr", Value = 48000 },
      new Data { Name = "Дом 4.2 ukr", Value = 49000 }
    };

    List<Data> house_ukr_5 = new List<Data>{
      new Data { Name = "Дом 5.1 ukr", Value = 50000 },
      new Data { Name = "Дом 5.2 ukr", Value = 51000 }
    };

    List<Data> house_ukr_6 = new List<Data>{
      new Data { Name = "Дом 6.1 ukr", Value = 52000 },
      new Data { Name = "Дом 6.2 ukr", Value = 53000 }
    };

    List<Data> house_ukr_7 = new List<Data>{
      new Data { Name = "Дом 7.1 ukr", Value = 54000 },
      new Data { Name = "Дом 7.2 ukr", Value = 55000 }
    };

    List<Data> house_ukr_8 = new List<Data>{
      new Data { Name = "Дом 8.1 ukr", Value = 56000 },
      new Data { Name = "Дом 8.2 ukr", Value = 57000 }
    };

    List<Data> house_kz_1 = new List<Data>{
      new Data { Name = "Дом 1.1 kz", Value = 58000 },
      new Data { Name = "Дом 1.2 kz", Value = 59000 }
    };

    List<Data> house_kz_2 = new List<Data>{
      new Data { Name = "Дом 2.1 kz", Value = 60000 },
      new Data { Name = "Дом 3.2 kz", Value = 61000 }
    };

    List<Data> house_kz_3 = new List<Data>{
      new Data { Name = "Дом 3.1 kz", Value = 62000 },
      new Data { Name = "Дом 3.2 kz", Value = 63000 }
    };

    List<Data> house_kz_4 = new List<Data>{
      new Data { Name = "Дом 4.1 kz", Value = 64000 },
      new Data { Name = "Дом 4.2 kz", Value = 65000 }
    };

    List<Data> house_kz_5 = new List<Data>{
      new Data { Name = "Дом 5.1 kz", Value = 66000 },
      new Data { Name = "Дом 5.2 kz", Value = 67000 }
    };

    List<Data> house_kz_6 = new List<Data>{
      new Data { Name = "Дом 6.1 kz", Value = 68000 },
      new Data { Name = "Дом 6.2 kz", Value = 69000 }
    };

    List<Data> house_kz_7 = new List<Data>{
      new Data { Name = "Дом 7.1 kz", Value = 70000 },
      new Data { Name = "Дом 7.2 kz", Value = 71000 }
    };

    List<Data> house_kz_8 = new List<Data>{
      new Data { Name = "Дом 8.1 kz", Value = 72000 },
      new Data { Name = "Дом 8.2 kz", Value = 73000 }
    };


    List<Data> room_windows_1 = new List<Data> {
      new Data { Name = "Юго-Запад", Value = 15 },
      new Data { Name = "Юг", Value = 17 }
    };

    List<Data> room_windows_2 = new List<Data> {
      new Data { Name = "Юго-Запад", Value = 15 },
      new Data { Name = "Юг", Value = 17 }
    };

    List<Data> room_windows_3 = new List<Data> {
      new Data { Name = "Юго-Запад", Value = 15 },
      new Data { Name = "Юг", Value = 17 }
    };


    #endregion




    




    //flat
    #region
    private void flat_metr_TextChanged(object sender, EventArgs e) {
    //проверка корректности ввода
      if( flat_metr.TextLength != 0 ){
        if (flat_metr.Text == "") {
          flat_metr.Text = "1";
        }
        else if ( Convert.ToInt32( flat_metr.Text ) > 0 && Convert.ToInt32( flat_metr.Text ) <= flat_metr_max ) {
          flat_metr_value = Convert.ToInt32( flat_metr.Text );
        }
        else if ( Convert.ToInt32( flat_metr.Text ) < 0 || Convert.ToInt32( flat_metr.Text ) == 0 ) {
          flat_metr_value = 1;
          flat_metr.Text = "1";
        }
        else if ( Convert.ToInt32( flat_metr.Text ) > flat_metr_max ) {
          flat_metr_value = flat_metr_max;
          flat_metr.Text = flat_metr_max.ToString();
        }
      }
      else {
        flat_metr_value = 1;
      }
    }

    //ввод в метраж только цифр
    private void flat_metr_KeyPress(object sender, KeyPressEventArgs e) {
      e.Handled = !System.Text.RegularExpressions.Regex.IsMatch( e.KeyChar.ToString(), @"[0,1,2,3,4,5,6,7,8,9,\b]" );
    }

    //flat_year
    private void flat_year_SelectedIndexChanged(object sender, EventArgs e) {
      Data flat = (Data)flat_year.SelectedItem;
      flat_year_select_name = flat.Name;
      flat_year_select = flat.Value;
    }

    //flat_option
    private void flat_option_1_CheckedChanged(object sender, EventArgs e) {
      CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
      if (checkBox.Checked == true) {
        flat_option_value += 1000;
      }
      else {
        flat_option_value -= 1000;
      }
    }

    private void flat_option_2_CheckedChanged(object sender, EventArgs e) {
      CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
      if (checkBox.Checked == true) {
        flat_option_value += 1500;
      }
      else {
        flat_option_value -= 1500;
      }
    }

    private void flat_option_3_CheckedChanged(object sender, EventArgs e) {
      CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
      if (checkBox.Checked == true) {
        flat_option_value += 2000;
      }
      else {
        flat_option_value -= 2000;
      }
    }

    private void flat_option_4_CheckedChanged(object sender, EventArgs e) {
      CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
      if (checkBox.Checked == true) {
        flat_option_value += 4000;
      }
      else {
        flat_option_value -= 4000;
      }
    }

    private void flat_option_5_CheckedChanged(object sender, EventArgs e) {
      CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
      if (checkBox.Checked == true) {
        flat_option_value += 3000;
      }
      else {
        flat_option_value -= 3000;
      }
    }

    private void flat_option_6_CheckedChanged(object sender, EventArgs e) {
      CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
      if (checkBox.Checked == true) {
        flat_option_value += 2500;
      }
      else {
        flat_option_value -= 2500;
      }
    }


    //flat_material
    private void flat_material_1_CheckedChanged(object sender, EventArgs e) {
      // приводим отправителя к элементу типа RadioButton
      RadioButton radioButton = (RadioButton)sender;
      if (radioButton.Checked) {
        flat_material_value += 500;
      }
      else{
        flat_material_value -= 500;
      }
    }

    private void flat_material_2_CheckedChanged(object sender, EventArgs e) {
      // приводим отправителя к элементу типа RadioButton
      RadioButton radioButton = (RadioButton)sender;
      if (radioButton.Checked) {
        flat_material_value += 700;
      }
      else {
        flat_material_value -= 700;
      }
    }

    private void flat_material_3_CheckedChanged(object sender, EventArgs e) {
      // приводим отправителя к элементу типа RadioButton
      RadioButton radioButton = (RadioButton)sender;
      if (radioButton.Checked) {
        flat_material_value += 1000;
      }
      else {
        flat_material_value -= 1000;
      }
    }

    private void flat_material_4_CheckedChanged(object sender, EventArgs e) {
      // приводим отправителя к элементу типа RadioButton
      RadioButton radioButton = (RadioButton)sender;
      if (radioButton.Checked) {
        flat_material_value += 1500;
      }
      else {
        flat_material_value -= 1500;
      }
    }

    private void flat_material_5_CheckedChanged(object sender, EventArgs e) {
      // приводим отправителя к элементу типа RadioButton
      RadioButton radioButton = (RadioButton)sender;
      if (radioButton.Checked) {
        flat_material_value += 2500;
      }
      else {
        flat_material_value -= 2500;
      }
    }

    private void flat_material_6_CheckedChanged(object sender, EventArgs e) {
      // приводим отправителя к элементу типа RadioButton
      RadioButton radioButton = (RadioButton)sender;
      if (radioButton.Checked) {
        flat_material_value += 5500;
      }
      else {
        flat_material_value -= 5500;
      }
    }

    private void flat_number_ValueChanged(object sender, EventArgs e) {
      flat_number_value = (int)flat_number.Value;
    }

    private void flat_confirm_Click(object sender, EventArgs e) {
      if (flat_metr.Text != "") {
        flat_confirm_summ =
          ( flat_metr_value * cost_one_metre ) +
          ( flat_number_value * cost_flat_room ) +
          flat_year_select + flat_option_value + flat_material_value;
      }
      else {
        MessageBox.Show(
        "Введите площадь",
        "Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error );
      }
    }

    #endregion

    //addr_country
    private void addr_country_SelectedIndexChanged(object sender, EventArgs e) {
      Data temp = (Data)addr_country.SelectedItem;
      addr_country_select = temp.Value;
      addr_names[ 0 ] = temp.Name;

      switch (addr_country_select) {
        case 0:
          addr_city.DataSource = city_bel;
          addr_city.DisplayMember = "Name";
          addr_city.ValueMember = "Value";
          break;
        case 1:
          addr_city.DataSource = city_rus;
          addr_city.DisplayMember = "Name";
          addr_city.ValueMember = "Value";
          break;
        case 2:
          addr_city.DataSource = city_ukr;
          addr_city.DisplayMember = "Name";
          addr_city.ValueMember = "Value";
          break;
        case 3:
          addr_city.DataSource = city_kz;
          addr_city.DisplayMember = "Name";
          addr_city.ValueMember = "Value";
          break;
        default:
          break;
      }
    }

    private void addr_city_SelectedIndexChanged(object sender, EventArgs e) {
      Data temp = (Data)addr_city.SelectedItem;
      addr_city_select = temp.Value;
      addr_names[ 1 ] = temp.Name;


      switch (addr_city_select) {
        case 0:
          addr_region.DataSource = region_bel_1;
          addr_region.DisplayMember = "Name";
          addr_region.ValueMember = "Value";
          break;
        case 1:
          addr_region.DataSource = region_bel_2;
          addr_region.DisplayMember = "Name";
          addr_region.ValueMember = "Value";
          break;
        case 2:
          addr_region.DataSource = region_rus_1;
          addr_region.DisplayMember = "Name";
          addr_region.ValueMember = "Value";
          break;
        case 3:
          addr_region.DataSource = region_rus_2;
          addr_region.DisplayMember = "Name";
          addr_region.ValueMember = "Value";
          break;
        case 4:
          addr_region.DataSource = region_ukr_1;
          addr_region.DisplayMember = "Name";
          addr_region.ValueMember = "Value";
          break;
        case 5:
          addr_region.DataSource = region_ukr_2;
          addr_region.DisplayMember = "Name";
          addr_region.ValueMember = "Value";
          break;
        case 6:
          addr_region.DataSource = region_kz_1;
          addr_region.DisplayMember = "Name";
          addr_region.ValueMember = "Value";
          break;
        case 7:
          addr_region.DataSource = region_kz_2;
          addr_region.DisplayMember = "Name";
          addr_region.ValueMember = "Value";
          break;
        default:
          break;
      }

    }

    private void addr_region_SelectedIndexChanged(object sender, EventArgs e) {
      Data temp = (Data)addr_region.SelectedItem;
      addr_region_select = temp.Value;
      addr_names[ 2 ] = temp.Name;
       
      switch (addr_region_select) {
        case 0:
          addr_street.DataSource = street_bel_1;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 1:
          addr_street.DataSource = street_bel_2;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 2:
          addr_street.DataSource = street_bel_3;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 3:
          addr_street.DataSource = street_bel_4;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 4:
          addr_street.DataSource = street_rus_1;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 5:
          addr_street.DataSource = street_rus_2;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 6:
          addr_street.DataSource = street_rus_3;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 7:
          addr_street.DataSource = street_rus_4;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 8:
          addr_street.DataSource = street_ukr_1;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 9:
          addr_street.DataSource = street_ukr_2;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 10:
          addr_street.DataSource = street_ukr_3;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 11:
          addr_street.DataSource = street_ukr_4;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 12:
          addr_street.DataSource = street_kz_1;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 13:
          addr_street.DataSource = street_kz_2;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 14:
          addr_street.DataSource = street_kz_3;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        case 15:
          addr_street.DataSource = street_kz_4;
          addr_street.DisplayMember = "Name";
          addr_street.ValueMember = "Value";
          break;
        default:
          break;
      }
    }

    private void addr_street_SelectedIndexChanged(object sender, EventArgs e) {
      Data temp = (Data)addr_street.SelectedItem;
      addr_street_select = temp.Value;
      addr_names[ 3 ] = temp.Name;

      switch (addr_street_select) {
        case 0:
          addr_house.DataSource = house_bel_1;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 1:
          addr_house.DataSource = house_bel_2;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 2:
          addr_house.DataSource = house_bel_3;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 3:
          addr_house.DataSource = house_bel_4;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 4:
          addr_house.DataSource = house_bel_5;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 5:
          addr_house.DataSource = house_bel_6;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 6:
          addr_house.DataSource = house_bel_7;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 7:
          addr_house.DataSource = house_bel_8;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 8:
          addr_house.DataSource = house_rus_1;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 9:
          addr_house.DataSource = house_rus_2;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 10:
          addr_house.DataSource = house_rus_3;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 11:
          addr_house.DataSource = house_rus_4;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 12:
          addr_house.DataSource = house_rus_5;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 13:
          addr_house.DataSource = house_rus_6;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 14:
          addr_house.DataSource = house_rus_7;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 15:
          addr_house.DataSource = house_rus_8;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 16:
          addr_house.DataSource = house_ukr_1;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 17:
          addr_house.DataSource = house_ukr_2;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 18:
          addr_house.DataSource = house_ukr_3;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 19:
          addr_house.DataSource = house_ukr_4;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 20:
          addr_house.DataSource = house_ukr_5;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 21:
          addr_house.DataSource = house_ukr_6;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 22:
          addr_house.DataSource = house_ukr_7;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 23:
          addr_house.DataSource = house_ukr_8;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 24:
          addr_house.DataSource = house_kz_1;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 25:
          addr_house.DataSource = house_kz_2;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 26:
          addr_house.DataSource = house_kz_3;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 27:
          addr_house.DataSource = house_kz_4;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 28:
          addr_house.DataSource = house_kz_5;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 29:
          addr_house.DataSource = house_kz_6;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 30:
          addr_house.DataSource = house_kz_7;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        case 31:
          addr_house.DataSource = house_kz_8;
          addr_house.DisplayMember = "Name";
          addr_house.ValueMember = "Value";
          break;
        default:
          break;
      }
    }

    private void addr_house_SelectedIndexChanged(object sender, EventArgs e) {
      Data temp = (Data)addr_house.SelectedItem;
      addr_house_select = temp.Value;
      addr_names[ 4 ] = temp.Name;
    }
    
    private void add_flat_input_TextChanged(object sender, EventArgs e) {
      room_name = add_flat_input.Text;
    }
    
    private void room_texbox_KeyPress(object sender, KeyPressEventArgs e) {
      e.Handled = !System.Text.RegularExpressions.Regex.IsMatch( e.KeyChar.ToString(), @"[0,1,2,3,4,5,6,7,8,9,\b]" );
    }

   int room_count = 0;

   
    private void add_flat_btn_Click(object sender, EventArgs e) {
     
      if ( room_count == 0 ) {
        room_groupbox_1.Text = room_name;
        room_groupbox_1.Visible = true;
        room_count++;
      } 
      else if ( room_count == 1 ) {
        room_groupbox_2.Text = room_name;
        room_groupbox_2.Visible = true;
        room_count++;
      }
      else if ( room_count == 2 ) {
        room_groupbox_3.Text = room_name;
        room_groupbox_3.Visible = true;
        room_count++;
      }

      MessageBox.Show( room_count.ToString() ); 
     
      // sad
      #region
      //room_count++;
      //GroupBox groupBox = new GroupBox();
      //ComboBox comboBox = new ComboBox();
      //Label label_1 = new Label();
      //Label label_2 = new Label();
      //Label label_3 = new Label();
      //NumericUpDown numericUpDown = new NumericUpDown();
      //TextBox textBox = new TextBox();
      //Button button = new Button();


      //if ( room_count < 4 ) {

      //  button.Location = new System.Drawing.Point( 435, 32 );
      //  button.Name = "room_btn_confirm_" + room_count;
      //  button.Size = new System.Drawing.Size( 62, 23 );
      //  button.TabIndex = 23;
      //  button.Text = "Принять";
      //  button.UseVisualStyleBackColor = true;


      //  comboBox.Name = "room_combobox_" + room_count;
      //  comboBox.Location = new System.Drawing.Point( 288, 33 );
      //  comboBox.Size = new System.Drawing.Size( 121, 21 );
      //  room_add_event_comboBox();
      //  comboBox.TabIndex = 21;
      //  comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      //  comboBox.DataSourceChanged += comboBox_DataSourceChanged;

      //  label_1.Name = "room_label_1_" + room_count;
      //  label_1.Text = "Сторона окон";
      //  label_1.AutoSize = true;
      //  label_1.Location = new System.Drawing.Point( 285, 16 );
      //  label_1.Size = new System.Drawing.Size( 76, 13 );

      //  numericUpDown.Location = new System.Drawing.Point( 142, 34 );
      //  numericUpDown.Name = "room_numeric_" + room_count;
      //  numericUpDown.Size = new System.Drawing.Size( 120, 20 );
      //  numericUpDown.TabIndex = 19;

      //  label_2.Name = "room_label_2_" + room_count;
      //  label_2.Text = "Количество окон";
      //  label_2.AutoSize = true;
      //  label_2.Location = new System.Drawing.Point( 139, 16 );
      //  label_2.Size = new System.Drawing.Size( 93, 13 );

      //  textBox.Location = new System.Drawing.Point( 16, 33 );
      //  textBox.Name = "room_textbox_" + room_count;
      //  textBox.Size = new System.Drawing.Size( 100, 20 );
      //  textBox.TabIndex = 17;
      //  textBox.TextChanged += new System.EventHandler( room_texbox_TextChanged );
      //  textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler( room_texbox_KeyPress );

      //  label_3.Name = "room_label_2_" + room_count;
      //  label_3.Text = "Площадь";
      //  label_3.AutoSize = true;
      //  label_3.Location = new System.Drawing.Point( 16, 16 );
      //  label_3.Size = new System.Drawing.Size( 54, 13 );

      //  groupBox.Controls.Add( button );
      //  groupBox.Controls.Add( comboBox );
      //  groupBox.Controls.Add( label_1 );
      //  groupBox.Controls.Add( numericUpDown );
      //  groupBox.Controls.Add( label_2 );
      //  groupBox.Controls.Add( textBox );
      //  groupBox.Controls.Add( label_3 );

      //  groupBox.Size = new System.Drawing.Size( 520, 75 );
      //  if ( room_count == 1 ) {
      //    groupBox.Location = new System.Drawing.Point( 8, 84 );
      //  }
      //  else if ( room_count == 2 ) {
      //    groupBox.Location = new System.Drawing.Point( 8, 164 );
      //  }
      //  else if( room_count == 3 ) {
      //    groupBox.Location = new System.Drawing.Point( 8, 244 );
      //  }

      //  groupBox.TabIndex = 0;
      //  groupBox.TabStop = false;
      //  groupBox.Name = "room_groupbox_" + room_count;
      //  groupBox.Text = room_name;

      //  tab_room.Controls.Add( groupBox );

      //  room_groupBox.Add( groupBox );
      //  room_comboBox.Add( comboBox );
      //  room_NumericUpDown.Add( numericUpDown );
      //  room_TextBox.Add( textBox );
      //  room_btn.Add( button );

      //  room_add_event_btn();
      //}
      #endregion
    }

    private void room_textbox_1_TextChanged(object sender, EventArgs e) {
      //проверка корректности ввода
      if (room_textbox_1.TextLength != 0) {
        if (room_textbox_1.Text == "") {
          room_textbox_1.Text = "1";
        }
        else if (Convert.ToInt32( room_textbox_1.Text ) > 0 && Convert.ToInt32( room_textbox_1.Text ) <= flat_metr_max) {
          room_textBox_value[ 0 ] = Convert.ToInt32( room_textbox_1.Text );
        }
        else if (Convert.ToInt32( room_textbox_1.Text ) < 0 || Convert.ToInt32( room_textbox_1.Text ) == 0) {
          room_textBox_value[ 0 ] = 1;
          room_textbox_1.Text = "1";
        }
        else if (Convert.ToInt32( room_textbox_1.Text ) > flat_metr_max) {
          room_textBox_value[ 0 ] = flat_metr_max;
          room_textbox_1.Text = flat_metr_max.ToString();
        }
      }
      else {
        room_textBox_value[ 0 ] = 1;
      }
    }

    private void room_textbox_2_TextChanged(object sender, EventArgs e) {
      //проверка корректности ввода
      if (room_textbox_2.TextLength != 0) {
        if (room_textbox_1.Text == "") {
          room_textbox_1.Text = "1";
        }
        else if (Convert.ToInt32( room_textbox_2.Text ) > 0 && Convert.ToInt32( room_textbox_2.Text ) <= flat_metr_max) {
          room_textBox_value[ 1 ] = Convert.ToInt32( room_textbox_2.Text );
        }
        else if (Convert.ToInt32( room_textbox_2.Text ) < 0 || Convert.ToInt32( room_textbox_2.Text ) == 0) {
          room_textBox_value[ 1 ] = 1;
          room_textbox_2.Text = "1";
        }
        else if (Convert.ToInt32( room_textbox_2.Text ) > flat_metr_max) {
          room_textBox_value[ 1 ] = flat_metr_max;
          room_textbox_2.Text = flat_metr_max.ToString();
        }
      }
      else {
        room_textBox_value[ 1 ] = 1;
      }
    }

    private void room_textbox_3_TextChanged(object sender, EventArgs e) {
      //проверка корректности ввода
      if (room_textbox_3.TextLength != 0) {
        if (room_textbox_1.Text == "") {
          room_textbox_1.Text = "1";
        }
        else if (Convert.ToInt32( room_textbox_3.Text ) > 0 && Convert.ToInt32( room_textbox_3.Text ) <= flat_metr_max) {
          room_textBox_value[ 2 ] = Convert.ToInt32( room_textbox_3.Text );
        }
        else if (Convert.ToInt32( room_textbox_3.Text ) < 0 || Convert.ToInt32( room_textbox_3.Text ) == 0) {
          room_textBox_value[ 2 ] = 1;
          room_textbox_3.Text = "1";
        }
        else if (Convert.ToInt32( room_textbox_3.Text ) > flat_metr_max) {
          room_textBox_value[ 2 ] = flat_metr_max;
          room_textbox_3.Text = flat_metr_max.ToString();
        }
      }
      else {
        room_textBox_value[ 2 ] = 1;
      }
    }

    private void save_to_xml_Click(object sender, EventArgs e) {
      XDocument xdoc = new XDocument();
      // создаем первый элемент
      XElement tab_1 = new XElement( "tab" );

      XElement x_flat_metr = new XElement( "flat_metr", flat_metr_value.ToString() );
      XElement x_flat_numeric = new XElement( "flat_numeric", flat_number_value.ToString() );
      XElement x_flat_year = new XElement( "flat_year", flat_year_select_name );
      XElement x_flat_option = new XElement( "flat_option", flat_option_value.ToString() );
      XElement x_flat_material = new XElement( "flat_material", flat_material_value.ToString() );
      // добавляем атрибут и элементы в первый элемент
      tab_1.Add( x_flat_metr );
      tab_1.Add( x_flat_numeric );
      tab_1.Add( x_flat_year );
      tab_1.Add( x_flat_option );
      tab_1.Add( x_flat_material );

      // создаем второй элемент
      XElement tab_2 = new XElement( "tab" );

      XElement room_1 = new XElement( "room" );
      XElement room_2 = new XElement( "room" );
      XElement room_3 = new XElement( "room" );

      switch (room_count) {
        case 1: {
          XAttribute room_name_1 = new XAttribute( "room_name", room_names[ 0 ] );
          XElement room_square_1 = new XElement( "room_square", room_textBox_value[ 0 ].ToString() );
          XElement room_window_1 = new XElement( "room_window", room_numeric_value[ 0 ].ToString() );
          XElement room_side_1 = new XElement( "room_side", room_comboBox_value[ 0 ].ToString() );
          room_1.Add( room_name_1 );
          room_1.Add( room_square_1 );
          room_1.Add( room_window_1 );
          room_1.Add( room_side_1 );

          tab_2.Add( room_1 );
          }
          break;
        case 2: {
          XAttribute room_name_1 = new XAttribute( "room_name", room_names[ 0 ] );
          XElement room_square_1 = new XElement( "room_square", room_textBox_value[ 0 ].ToString() );
          XElement room_window_1 = new XElement( "room_window", room_numeric_value[ 0 ].ToString() );
          XElement room_side_1 = new XElement( "room_side", room_comboBox_value[ 0 ].ToString() );
          room_1.Add( room_name_1 );
          room_1.Add( room_square_1 );
          room_1.Add( room_window_1 );
          room_1.Add( room_side_1 );

          XAttribute room_name_2 = new XAttribute( "room_name", room_names[ 1 ] );
          XElement room_square_2 = new XElement( "room_square", room_textBox_value[ 1 ].ToString() );
          XElement room_window_2 = new XElement( "room_window", room_numeric_value[ 1 ].ToString() );
          XElement room_side_2 = new XElement( "room_side", room_comboBox_value[ 1 ].ToString() );
          room_2.Add( room_name_2 );
          room_2.Add( room_square_2 );
          room_2.Add( room_window_2 );
          room_2.Add( room_side_2 );
          
          tab_2.Add( room_1 );
          tab_2.Add( room_2 );
        }
          break;
        case 3:{
          XAttribute room_name_1 = new XAttribute( "room_name", room_names[ 0 ] );
          XElement room_square_1 = new XElement( "room_square", room_textBox_value[ 0 ].ToString() );
          XElement room_window_1 = new XElement( "room_window", room_numeric_value[ 0 ].ToString() );
          XElement room_side_1 = new XElement( "room_side", room_comboBox_value[ 0 ].ToString() );
          room_1.Add( room_name_1 );
          room_1.Add( room_square_1 );
          room_1.Add( room_window_1 );
          room_1.Add( room_side_1 );

          XAttribute room_name_2 = new XAttribute( "room_name", room_names[ 1 ] );
          XElement room_square_2 = new XElement( "room_square", room_textBox_value[ 1 ].ToString() );
          XElement room_window_2 = new XElement( "room_window", room_numeric_value[ 1 ].ToString() );
          XElement room_side_2 = new XElement( "room_side", room_comboBox_value[ 1 ].ToString() );
          room_2.Add( room_name_2 );
          room_2.Add( room_square_2 );
          room_2.Add( room_window_2 );
          room_2.Add( room_side_2 );

          XAttribute room_name_3 = new XAttribute( "room_name", room_names[ 2 ] );
          XElement room_square_3 = new XElement( "room_square", room_textBox_value[ 2 ].ToString() );
          XElement room_window_3 = new XElement( "room_window", room_numeric_value[ 2 ].ToString() );
          XElement room_side_3 = new XElement( "room_side", room_comboBox_value[ 2 ].ToString() );
          room_3.Add( room_name_3 );
          room_3.Add( room_square_3 );
          room_3.Add( room_window_3 );
          room_3.Add( room_side_3 );

          tab_2.Add( room_1 );
          tab_2.Add( room_2 );
          tab_2.Add( room_3 );
          }
          break;
        default:
          break;
      }

      XElement tab_3 = new XElement( "tab" );

      XElement x_addr_country = new XElement( "addr_country", addr_names[ 0 ] );
      XElement x_addr_city = new XElement( "addr_city", addr_names[ 1 ] );
      XElement x_addr_region = new XElement( "addr_region", addr_names[ 2 ] );
      XElement x_addr_street = new XElement( "addr_street", addr_names[ 3 ] );
      XElement x_addr_house = new XElement( "addr_house", addr_names[ 4 ] );

      tab_3.Add( x_addr_country );
      tab_3.Add( x_addr_city );
      tab_3.Add( x_addr_region );
      tab_3.Add( x_addr_street );
      tab_3.Add( x_addr_house );


      // создаем корневой элемент
      XElement x_form = new XElement( "form" );
      // добавляем в корневой элемент
      x_form.Add( tab_1 );
      x_form.Add( tab_2 );
      x_form.Add( tab_3 );
      // добавляем корневой элемент в документ
      xdoc.Add( x_form );
      //сохраняем документ
      xdoc.Save( "laba_2.xml" );
      
    }

    private void display_xml_Click(object sender, EventArgs e) {

      if( System.IO.File.Exists( "laba_2.xml" ) ) {
        XDocument xdoc = XDocument.Load( "laba_2.xml" );

        MessageBox.Show( xdoc.ToString(), "Xml документ", MessageBoxButtons.OK, MessageBoxIcon.Information );
      }
      else {
        MessageBox.Show( "Файла не существует\nсначала сохраните в XML", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
      }


    }

    private void main_btn_Click(object sender, EventArgs e) {

      SUMM = flat_confirm_summ + room_confirm_summ[ 0 ] + room_confirm_summ[ 1 ] + room_confirm_summ[ 2 ] + addr_house_select;
      summ_display.Text = SUMM.ToString();

    }

        private void flat_material_wrap_Enter(object sender, EventArgs e)
        {

        }

        private void summ_display_TextChanged(object sender, EventArgs e)
        {

        }

        private void room_numeric_1_ValueChanged(object sender, EventArgs e) {
      room_numeric_value[ 0 ] = (int)room_numeric_1.Value;
    }

    private void room_numeric_2_ValueChanged(object sender, EventArgs e) {
      room_numeric_value[ 1 ] = (int)room_numeric_2.Value;
    }

    private void room_numeric_3_ValueChanged(object sender, EventArgs e) {
      room_numeric_value[ 2 ] = (int)room_numeric_3.Value;
    }

    private void room_combobox_1_SelectedIndexChanged(object sender, EventArgs e) {
      Data temp = (Data)room_combobox_1.SelectedItem;
      room_comboBox_value[ 0 ] = temp.Value;
    }

    private void room_combobox_2_SelectedIndexChanged(object sender, EventArgs e) {
      Data temp = (Data)room_combobox_2.SelectedItem;
      room_comboBox_value[ 1 ] = temp.Value;
    }

    private void room_combobox_3_SelectedIndexChanged(object sender, EventArgs e) {
      Data temp = (Data)room_combobox_3.SelectedItem;
      room_comboBox_value[ 2 ] = temp.Value;
    }

    private void room_confirm_1_Click(object sender, EventArgs e) {
      if( room_textbox_1.Text != "" ) {
        room_confirm_summ[ 0 ] = ( room_textBox_value[ 0 ] * cost_one_metre ) + ( room_numeric_value[ 0 ] * cost_one_window * ( (double)room_comboBox_value[ 0 ]/10 ));
        room_names[ 0 ] = room_name;
      }
      else {
        MessageBox.Show(
        "Введите площадь",
        "Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error );
      }
    }

    private void room_confirm_2_Click(object sender, EventArgs e) {
      if (room_textbox_2.Text != "") {
        room_confirm_summ[ 1 ] = ( room_textBox_value[ 1 ] * cost_one_metre ) + ( room_numeric_value[ 1 ] * cost_one_window * ( (double)room_comboBox_value[ 1 ] / 10 ) );
        room_names[ 1 ] = room_name;
      }
      else {
        MessageBox.Show(
        "Введите площадь",
        "Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error );
      }
    }

    private void room_confirm_3_Click(object sender, EventArgs e) {
      if (room_textbox_3.Text != "") {
        room_confirm_summ[ 2 ] = ( room_textBox_value[ 2 ] * cost_one_metre ) + ( room_numeric_value[ 2 ] * cost_one_window * ( (double)room_comboBox_value[ 2 ] / 10 ) );
        room_names[ 2 ] = room_name;
      }
      else {
        MessageBox.Show(
        "Введите площадь",
        "Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error );
      }
    }


    //List<GroupBox> room_groupBox = new List<GroupBox>();
    //List<ComboBox> room_comboBox = new List<ComboBox>();
    //List<NumericUpDown> room_NumericUpDown = new List<NumericUpDown>();
    //List<TextBox> room_TextBox = new List<TextBox>();
    //List<Button> room_btn = new List<Button>();

    //private void room_texbox_TextChanged(object sender, EventArgs e) {
    //  foreach (var item in room_TextBox) {
    //    //проверка корректности ввода
    //    if (item.Text == "") {
    //      item.Text = "1";
    //    }
    //    else if (item.TextLength > 1 && item.Text[ 0 ] == '0') {
    //      item.Text = "1";
    //    }
    //    else if (Convert.ToInt32( item.Text ) < 0 || Convert.ToInt32( item.Text ) == 0) {
    //      item.Text = "1";
    //    }
    //    else if (Convert.ToInt32( item.Text ) > flat_metr_max) {
    //      item.Text = flat_metr_max.ToString();
    //    }
    //  }
    //}



    //ввод в метраж только цифр
    //private void room_btn_confirm_1_Click( object sender, EventArgs e ){ }
    //private void room_add_event_btn(){
    //  foreach (var btn_item in room_btn) {
    //    switch (room_btn.Count()) {
    //      case 1:
    //        room_btn.ElementAt( room_btn.Count() - 1 ).Click += room_btn_confirm_1;
    //        break;
    //      case 2:
    //        room_btn.ElementAt( room_btn.Count() - 1 ).Click += room_btn_confirm_2;
    //        break;
    //      case 3:
    //        room_btn.ElementAt( room_btn.Count() - 1 ).Click += room_btn_confirm_3;
    //        break;
    //    }
    //  }
    //}

    //private void room_add_event_comboBox() {
    //  room_comboBox.ForEach( delegate (ComboBox i) {
    //    switch (room_comboBox.Count()) {
    //      case 1:
    //        room_comboBox.ElementAt( 0 ).Click += room_comboBox_SelectedIndexChanged_1;
    //        break;
    //      case 2:
    //        room_comboBox.ElementAt( 1 ).Click += room_comboBox_SelectedIndexChanged_2;
    //        break;
    //      case 3:
    //        room_comboBox.ElementAt( 2 ).Click += room_comboBox_SelectedIndexChanged_3;
    //        break;
    //    }
    //  } );
    //}

    //private void room_btn_confirm_1(object sender, EventArgs e) {
    //  if ( room_TextBox.ElementAt( 0 ).Text == "" ) {
    //    MessageBox.Show(
    //      "Введите площадь",
    //      "Error",
    //      MessageBoxButtons.OK,
    //      MessageBoxIcon.Error );

    //  }
    //  else{
    //    room_textBox_value[ 0 ] = Convert.ToInt32( room_TextBox.ElementAt( 0 ).Text );
    //  }
    //}

    //private void room_btn_confirm_2(object sender, EventArgs e) {
    //  if (room_TextBox.ElementAt( 1 ).Text != "" ) {
    //    room_textBox_value[ 1 ] = Convert.ToInt32( room_TextBox.ElementAt( 1 ).Text );
    //  }
    //  else {
    //    MessageBox.Show(
    //    "Введите площадь",
    //    "Error",
    //    MessageBoxButtons.OK,
    //    MessageBoxIcon.Error );
    //  }
    //}

    //private void room_btn_confirm_3(object sender, EventArgs e) {
    //  if (room_TextBox.ElementAt( 2 ).Text != "" ) {
    //    room_textBox_value[ 2 ] = Convert.ToInt32( room_TextBox.ElementAt( 2 ).Text );
    //  }
    //  else {
    //    MessageBox.Show(
    //    "Введите площадь",
    //    "Error",
    //    MessageBoxButtons.OK,
    //    MessageBoxIcon.Error );
    //  }
    //}

    //private void room_comboBox_SelectedIndexChanged_1(object sender, EventArgs e) {
    //  if ( (string)room_comboBox.ElementAt(0).SelectedItem == "Юго-Запад" ) {
    //    room_comboBox_value[ 0 ] = 10000;
    //  }
    //  else if ((string)room_comboBox.ElementAt( 0 ).SelectedItem == "Юг") {
    //    room_comboBox_value[ 0 ] = 15000;
    //  }

    //}

    //private void room_comboBox_SelectedIndexChanged_2(object sender, EventArgs e) {
    //  if ((string)room_comboBox.ElementAt( 1 ).SelectedItem == "Юго-Запад") {
    //    room_comboBox_value[ 1 ] = 10000;
    //  }
    //  else if ((string)room_comboBox.ElementAt( 1 ).SelectedItem == "Юг") {
    //    room_comboBox_value[ 1 ] = 15000;
    //  }

    //}

    //private void room_comboBox_SelectedIndexChanged_3(object sender, EventArgs e) {
    //  if ((string)room_comboBox.ElementAt( 2 ).SelectedItem == "Юго-Запад") {
    //    room_comboBox_value[ 2 ] = 10000;
    //  }
    //  else if ((string)room_comboBox.ElementAt( 2 ).SelectedItem == "Юг") {
    //    room_comboBox_value[ 2 ] = 15000;
    //  }
    //}
  }
}
