using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Laba_1_1 {
  static class Program {
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    /*все потоки в этой программе выполняются в рамках одного процесса, 
     а управление программой осуществляется одним главным потоком*/
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault( false );
      Application.Run( new Form1() );
    }
  }
}
