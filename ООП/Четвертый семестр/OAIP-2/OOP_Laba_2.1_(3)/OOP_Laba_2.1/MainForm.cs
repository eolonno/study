using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace OOP_Laba_2._1 {

  public partial class MainForm : Form {

    Flat flat;
    List<Flat> flats;
    public List<Room> rooms;

    Timer timer;

    GroupBox room_item_wrap;
    Label room_item_label_1;
    Label room_item_label_2;
    Label room_item_label_3;
    TextBox room_item_metr;
    NumericUpDown room_item_window_count;
    RadioButton room_item_window_side_1;
    RadioButton room_item_window_side_2;
    Button room_item_btn_confirm;

    decimal summ;

    int[] addr_data_selected = new int[5];
    string[] addr_data_selected_name = new string[5];


    int temp = 0;
    public int count_room = 0;

    bool flag = false;
    bool stay = false;

    string[] flat_year_value = new string[2];

    public MainForm() {

      flats = new List<Flat>();
      rooms = new List<Room>();

      InitializeComponent();

      flat_year.DataSource = flat_year_data;
      flat_year.DisplayMember = "Name";
      flat_year.ValueMember = "Value";

      addr_country.DataSource = country;
      addr_country.DisplayMember = "Name";
      addr_country.ValueMember = "Value";

      status_bar_label.Text = "";
      Objects.Text = "";
      timer = new Timer() { Interval = 1000 };
      timer.Tick += timer_tick;
      timer.Start();
    }

    void timer_tick(object sender, EventArgs e) {
      status_bar_date.Text = DateTime.Now.ToLongDateString();
      status_bar_time.Text = DateTime.Now.ToLongTimeString();
    }

    #region Data
    List<Data> flat_year_data = new List<Data> {
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

    List<Data> house_bel_6 = new List<Data>{
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



    private void metr_input_KeyPress(object sender, KeyPressEventArgs e) {
      e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0-9\b]");
    }

    private void correct_value(object sender, EventArgs e) {
      //проверка корректности ввода
      if (flat_metr.TextLength != 0) {
        if (flat_metr.Text == "") {
          flat_metr.Text = "1";
        } else if (Convert.ToInt32(flat_metr.Text) < 0 || Convert.ToInt32(flat_metr.Text) == 0) {
          flat_metr.Text = "1";
        } else if (Convert.ToInt32(flat_metr.Text) > 1000) {
          flat_metr.Text = "1000";
        }
      }
    }

    private void flat_year_SelectedIndexChanged(object sender, EventArgs e) {
      Data temp_value_flat_year = (Data)flat_year.SelectedItem;
      flat_year_value[0] = temp_value_flat_year.Name;
      flat_year_value[1] = temp_value_flat_year.Value.ToString();
    }


    private void summ_button_confirm_Click(object sender, EventArgs e) {
      if (flat_metr.TextLength == 0) {
        MessageBox.Show("Введите корректные данные", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
      } else {
        if (!save_to_xml.Enabled) {
          save_to_xml.Enabled = true;
          flag = true;
        }

        flat = new Flat($"Квартира №{ flats.Count() }",
                         Convert.ToInt32(flat_metr.Text),
                         rooms.Count,
                         flat_year_value[0],
                         Convert.ToInt32(flat_year_value[1]),
                         new Option(flat_option_1.Checked,
                                     flat_option_2.Checked,
                                     flat_option_3.Checked,
                                     flat_option_4.Checked,
                                     flat_option_5.Checked),
                         (flat_mat_1.Checked ? MatType.Mat_1 :
                           flat_mat_2.Checked ? MatType.Mat_2 :
                           flat_mat_3.Checked ? MatType.Mat_3 :
                           flat_mat_4.Checked ? MatType.Mat_4 :
                           flat_mat_5.Checked ? MatType.Mat_5 :
                           flat_mat_6.Checked ? MatType.Mat_6 : new MatType()),
                         new Address(addr_data_selected_name[0],
                                      addr_data_selected_name[1],
                                      addr_data_selected_name[2],
                                      addr_data_selected_name[3],
                                      addr_data_selected_name[4],
                                      addr_data_selected[4]),
                         rooms);
        summ_display.Text = flat.GetSumm().ToString();
        flats.Add(flat);
      }
    }

    private void save_to_xml_Click(object sender, EventArgs e) {
      if (flag) {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Flat>));

        using (FileStream fs = new FileStream("laba_2.xml", FileMode.OpenOrCreate)) {
          xmlSerializer.Serialize(fs, flats);
        }

        save_to_xml.Enabled = false;

        rooms.Clear();
        Objects.Text = "Объектов: " + flats.Count.ToString();

      }
    }

    private void show_xml_Click(object sender, EventArgs e) {
      try {

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Flat>));

        using (FileStream fs = new FileStream("laba_2.xml", FileMode.OpenOrCreate)) {

          flats = (List<Flat>)xmlSerializer.Deserialize(fs);

          xml_display.Nodes.Clear();

          foreach (Flat item in flats) {
            xml_display.Nodes.Add(item.TakeItemTree());
          }
          Objects.Text = "Объектов: " + flats.Count.ToString();
          }

      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }
    }


    private void addr_country_SelectedIndexChanged(object sender, EventArgs e) {
      Data temp = (Data)addr_country.SelectedItem;
      addr_data_selected[0] = temp.Value;
      addr_data_selected_name[0] = temp.Name;

      switch (addr_data_selected[0]) {
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
      addr_data_selected[1] = temp.Value;
      addr_data_selected_name[1] = temp.Name;


      switch (addr_data_selected[1]) {
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
      addr_data_selected[2] = temp.Value;
      addr_data_selected_name[2] = temp.Name;

      switch (addr_data_selected[2]) {
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
      addr_data_selected[3] = temp.Value;
      addr_data_selected_name[3] = temp.Name;

      switch (addr_data_selected[3]) {
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
      addr_data_selected[4] = temp.Value;
      addr_data_selected_name[4] = temp.Name;
    }

    private void delete_xml_Click(object sender, EventArgs e) {
      File.Delete("laba_2.xml");
    }

    private void search_by_room(object sender, EventArgs e) {
      SearchForm form2 = new SearchForm(1, flats);
      form2.Owner = this;
      form2.Text = "Поиск по комнатам";
      status_bar_label.Text = "Поиск по комнатам";
      form2.Show();

      if (!stay) toolStrip1.Visible = false;
    }

    private void search_by_year(object sender, EventArgs e) {
      SearchForm form2 = new SearchForm(2, flats);
      form2.Owner = this;
      form2.Text = "Поиск по году";
      status_bar_label.Text = "Поиск по году";
      form2.Show();

      if (!stay) toolStrip1.Visible = false;
    }

    private void search_by_region(object sender, EventArgs e) {
      SearchForm form2 = new SearchForm(3, flats);
      form2.Owner = this;
      form2.Text = "Поиск по району";
      status_bar_label.Text = "Поиск по району";
      form2.Show();

      if (!stay) toolStrip1.Visible = false;
    }

    private void search_by_city(object sender, EventArgs e) {
      SearchForm form2 = new SearchForm(4, flats);
      form2.Owner = this;
      form2.Text = "Поиск по городу";
      status_bar_label.Text = "Поиск по городу";
      form2.Show();

      if (!stay) toolStrip1.Visible = false; ;
    }

    private void sort_by_square(object sender, EventArgs e) {
      xml_display.Nodes.Clear();
      var sort = from item in flats
                 orderby item.metr
                 select item;
      foreach (var i in sort) {
        xml_display.Nodes.Add(i.TakeItemTree());
      }
      status_bar_label.Text = "Сортировка по площади";

      if (!stay) toolStrip1.Visible = false;
    }

    private void sort_by_cost(object sender, EventArgs e) {
      xml_display.Nodes.Clear();
      var sort = from item in flats
                 orderby item.summ
                 select item;
      foreach (var i in sort) {
        xml_display.Nodes.Add(i.TakeItemTree());
      }
      status_bar_label.Text = "Сортировка по цене";

      if (!stay) toolStrip1.Visible = false;
     }

    private void save_to_result_search(object sender, EventArgs e) {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Flat>));

      if (File.Exists("laba_3_result_search.xml")) {
        File.Delete("laba_3_result_search.xml");
      }

      using (FileStream fs = new FileStream("laba_3_result_search.xml", FileMode.OpenOrCreate)) {
        xmlSerializer.Serialize(fs, flats);
      }

      rooms.Clear();

      if (!stay) toolStrip1.Visible = false;
    }

    private void save_to_result_sort(object sender, EventArgs e) {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Flat>));

      if (File.Exists("laba_3_result_sort.xml")) {
        File.Delete("laba_3_result_sort.xml");
      }

      using (FileStream fs = new FileStream("laba_3_result_sort.xml", FileMode.OpenOrCreate)) {
        xmlSerializer.Serialize(fs, flats);
      }

      save_to_xml.Enabled = false;

      rooms.Clear();

      if (!stay) toolStrip1.Visible = false;
    }

    private void load_results_search(object sender, EventArgs e) {
      try {

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Flat>));

        using (FileStream fs = new FileStream("laba_3_result_search.xml", FileMode.OpenOrCreate)) {

          flats = (List<Flat>)xmlSerializer.Deserialize(fs);

          xml_display.Nodes.Clear();

          foreach (Flat item in flats) {
            xml_display.Nodes.Add(item.TakeItemTree());
          }
        }

      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      } finally {
        if (!stay) toolStrip1.Visible = false;
      }
    }

    private void load_results_sort(object sender, EventArgs e) {
      try {

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Flat>));

        using (FileStream fs = new FileStream("laba_3_result_sort.xml", FileMode.OpenOrCreate)) {

          flats = (List<Flat>)xmlSerializer.Deserialize(fs);

          xml_display.Nodes.Clear();

          foreach (Flat item in flats) {
            xml_display.Nodes.Add(item.TakeItemTree());
          }
        }

      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }
    }

    private void about_btn_click(object sender, EventArgs e) {
      MessageBox.Show("Dev by Yana Dubatovka (FIT, 2-9); \n Environment: " + Environment.Version.ToString(), "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void button1_Click(object sender, EventArgs e) {
      RoomForm form = new RoomForm(rooms);
      form.Owner = this;
      form.Text = "Управление комнатами";
      form.Show();


      //SearchForm form2 = new SearchForm(1, flats);
      //form2.Owner = this;
      //form2.Text = "Поиск по комнатам";
      //form2.Show();
    }


    private void main_wrap_Panel2_MouseHover_1(object sender, EventArgs e) {
      toolStrip1.Visible = true;
    }

        private void tab_flat_Click(object sender, EventArgs e)
        {

        }

        private void panel_1_wrap_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xml_display_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void func_stay(object sender, EventArgs e)
        {
            stay = true;
        }

        private void func_not_stay(object sender, EventArgs e)
        {
            stay = false;
        }

        private void clear_all(object sender, EventArgs e)
        {
            xml_display.Nodes.Clear();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


    }
}
