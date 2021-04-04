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
  public partial class RoomForm : Form {

    const int COUNT_ROOM = 5;
    int curr_count;
    int temp = 0; //отступ между groupbox

    List<Room> rooms;

    GroupBox room_item_wrap;
    Label room_item_label_1;
    Label room_item_label_2;
    Label room_item_label_3;
    TextBox room_item_metr;
    NumericUpDown room_item_window_count;
    RadioButton room_item_window_side_1;
    RadioButton room_item_window_side_2;
    Button room_item_btn_confirm;


    public RoomForm(List<Room> rooms) {
      InitializeComponent();

      this.rooms = rooms;
      curr_count = rooms.Count;

      if (curr_count != 0) {
        initRooms();
      }
    }

    private void room_btn_Click(object sender, EventArgs e) {
      addItem(curr_count, false);
    }

    private void initRooms() {
      for (int i = 0; i < curr_count; i++) {
        addItem(i, true);
      }
    }

    private void metr_input_KeyPress(object sender, KeyPressEventArgs e) {
      e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0-9\b]");
    }

    private void correct_value(object sender, EventArgs e) {
      TextBox textBox = (TextBox)sender;
      //проверка корректности ввода
      if (textBox.TextLength != 0) {
        if (textBox.Text == "") {
          textBox.Text = "1";
        } else if (Convert.ToInt32(textBox.Text) < 0 || Convert.ToInt32(textBox.Text) == 0) {
          textBox.Text = "1";
        } else if (Convert.ToInt32(textBox.Text) > 1000) {
          textBox.Text = "1000";
        }
      }
    }

    private void room_item_btn_confirm_click(object sender, EventArgs e) {
      if (room_item_metr.TextLength == 0) {
        MessageBox.Show("Введите корректные данные", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
      } else {
        Room room = new Room(this.room_item_wrap.Text,
                              Convert.ToInt32(this.room_item_metr.Text),
                              (int)this.room_item_window_count.Value,
                              this.room_item_window_side_1.Checked ? WinSide.Side_1 : WinSide.Side_2);
        rooms.Add(room);
      }
    }

    private void addItem(int id, bool isInit) {
      room_item_wrap = new GroupBox();
      room_item_label_1 = new Label();
      room_item_label_2 = new Label();
      room_item_label_3 = new Label();
      room_item_metr = new TextBox();
      room_item_window_count = new NumericUpDown();
      room_item_window_side_1 = new RadioButton();
      room_item_window_side_2 = new RadioButton();
      room_item_btn_confirm = new Button();

      if (id < COUNT_ROOM) {
        // 
        // room_item_wrap
        // 
        room_item_wrap.Controls.Add(room_item_btn_confirm);
        room_item_wrap.Controls.Add(room_item_label_3);
        room_item_wrap.Controls.Add(room_item_window_side_2);
        room_item_wrap.Controls.Add(room_item_window_side_1);
        room_item_wrap.Controls.Add(room_item_window_count);
        room_item_wrap.Controls.Add(room_item_label_2);
        room_item_wrap.Controls.Add(room_item_metr);
        room_item_wrap.Controls.Add(room_item_label_1);
        room_item_wrap.Location = new Point(10, 15 + temp);
        room_item_wrap.Name = $"room_item_wrap_{id}";
        room_item_wrap.Size = new Size(483, 71);
        room_item_wrap.TabIndex = 1;
        room_item_wrap.TabStop = false;
        if (isInit) {
          room_item_wrap.Text = rooms[id].room_name;
        } else {
          room_item_wrap.Text = room_add_input.Text;
        }

        // 
        // room_item_label_1
        // 
        room_item_label_1.AutoSize = true;
        room_item_label_1.Location = new Point(7, 21);
        room_item_label_1.Name = $"room_item_label_1_{id}";
        room_item_label_1.Size = new Size(35, 13);
        room_item_label_1.TabIndex = 0;
        room_item_label_1.Text = "Метраж комнаты";
        // 
        // room_item_metr
        // 
        room_item_metr.Location = new Point(10, 37);
        room_item_metr.Name = $"room_item_metr_{id}";
        room_item_metr.Size = new Size(100, 20);
        room_item_metr.TabIndex = 1;
        room_item_metr.KeyPress += new KeyPressEventHandler(metr_input_KeyPress);
        room_item_metr.TextChanged += correct_value;
        if (isInit) {
          room_item_metr.Text = rooms[id].room_metr.ToString();
        }
        //
        // room_item_label_2
        // 
        room_item_label_2.AutoSize = true;
        room_item_label_2.Location = new Point(127, 21);
        room_item_label_2.Name = $"room_item_label_2_{id}";
        room_item_label_2.Size = new Size(35, 13);
        room_item_label_2.TabIndex = 2;
        room_item_label_2.Text = "Количество окон";
        // 
        // room_item_window_count
        // 
        room_item_window_count.Location = new Point(130, 37);
        room_item_window_count.Name = $"room_item_window_count_{id}";
        room_item_window_count.Size = new Size(68, 20);
        room_item_window_count.TabIndex = 3;
        if (isInit) {
          room_item_window_count.Value = rooms[id].window_count;
        }

        // 
        // room_item_window_side_1
        // 
        room_item_window_side_1.AutoSize = true;
        room_item_window_side_1.Location = new Point(246, 37);
        room_item_window_side_1.Name = "room_item_window_side_1";
        room_item_window_side_1.Size = new Size(85, 17);
        room_item_window_side_1.TabIndex = 4;
        room_item_window_side_1.TabStop = true;
        room_item_window_side_1.Text = "Юг";
        room_item_window_side_1.UseVisualStyleBackColor = true;
        if (isInit) {
          room_item_window_side_1.Checked = rooms[id].window_side == WinSide.Side_1 ? true : false;
        }
        // 
        // room_item_window_side_2
        // 
        room_item_window_side_2.AutoSize = true;
        room_item_window_side_2.Location = new Point(309, 37);
        room_item_window_side_2.Name = "room_item_window_side_2";
        room_item_window_side_2.Size = new Size(85, 17);
        room_item_window_side_2.TabIndex = 5;
        room_item_window_side_2.TabStop = true;
        room_item_window_side_2.Text = "Юго-запад";
        room_item_window_side_2.UseVisualStyleBackColor = true;
        if (isInit) {
          room_item_window_side_2.Checked = rooms[id].window_side == WinSide.Side_2 ? true : false;
        }
        // 
        // test_label_3
        // 
        room_item_label_3.AutoSize = true;
        room_item_label_3.Location = new Point(246, 21);
        room_item_label_3.Name = $"room_item_label_3_{id}";
        room_item_label_3.Size = new Size(35, 13);
        room_item_label_3.TabIndex = 6;
        room_item_label_3.Text = "Сторона окон";
        //
        // room_item_btn_confirm
        //
        room_item_btn_confirm.Location = new Point(395, 35);
        room_item_btn_confirm.Size = new Size(75, 23);
        room_item_btn_confirm.Text = "Принять";
        room_item_btn_confirm.UseVisualStyleBackColor = true;
        room_item_btn_confirm.Click += new EventHandler(room_item_btn_confirm_click);

        splitContainer1.Panel2.Controls.Add(room_item_wrap);
        if (!isInit) {
          curr_count++;
        }
        temp += 75;
      }
    }
  }
}
