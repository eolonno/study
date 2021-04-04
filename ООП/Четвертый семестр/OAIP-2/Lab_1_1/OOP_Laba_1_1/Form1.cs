using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Laba_1_1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


     int size = 0;
     List<User> users;
     Random rnd = new Random();
     delegate void Comparator(List<User> users);
        Comparator comp;

   
    void Ascending(List<User> users)
    {
        var sortedUsers = from u in users
                          orderby u.Age ascending
                          select u;

        foreach(User user in sortedUsers)
        {
                display_2.Items.Add(user.ToString());
            }
        }

    private void Descending(List<User> users)
    {
        var sortedUsers = from u in users
                          orderby u.Age descending
                          select u;
            
        foreach (User user in sortedUsers)
        {
             display_2.Items.Add(user.ToString());
        }
    }

    private void sort_as_Click(object sender, EventArgs e) {
         display_2.Items.Clear();
            comp = Ascending;
            comp(users);

    }

    
    private void sort_des_Click(object sender, EventArgs e) {
      display_2.Items.Clear();
            comp = Descending;
            comp(users);
        }

    private void linq_2_Click(object sender, EventArgs e) {
      display_2.Items.Clear();


      var selectedUsers = from user in users
                          where user.Age > 25 && user.Age < 70
                          select user;

      foreach (User user in selectedUsers) {
                display_2.Items.Add("Пользователи с возрастом от 25 до 70 лет:");
                display_2.Items.Add( user.ToString() );
      }


     
    }

    private void linq_3_Click(object sender, EventArgs e) {
      display_2.Items.Clear();

      bool result1 = users.All( u => u.Age > 20 ); // true
      if (result1)
        display_2.Items.Add( "У всех пользователей возраст больше 20" );
      else
        display_2.Items.Add( "Есть пользователи с возрастом меньше 20" );
    }

    private void col_size_ValueChanged(object sender, EventArgs e) {
      size = (int)col_size.Value;
    }

    private void linq_1_Click(object sender, EventArgs e) {
      display_2.Items.Clear();


      var count = ( from u in users select u ).Count();

      
      display_2.Items.Add( $"Количестов элементов в коллекции {count}");

    }


    private void gen_Click(object sender, EventArgs e) {

      display_1.Items.Clear();

      users = new List<User>();
      for (int i = 0; i < size; i++) {
        users.Add( new User {
          Name = $"Пользователь_{i}", Age = rnd.Next( 3, 100 )
        } );
      }


      foreach (User user in users) {
        display_1.Items.Add( user.ToString() );
      }
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void display_1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class User {
    private string name;
    private int age;

    public int Age{ get; set; }
    public string Name{ get; set; }


    public User(){
      name = Name;
      age = Age;
    }


    public override string ToString() {
      return $"{ this.Name } с возрастом { this.Age }";
    }
  }
}
