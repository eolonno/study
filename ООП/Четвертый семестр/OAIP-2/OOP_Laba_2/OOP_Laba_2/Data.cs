using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laba_2 {
  class Data {
   
    string name;
    int value;
    int ID = 0;
    public string Name { get; set; }
    public int Value { get; set; }
    
    public Data(){
      this.name = Name;
      this.value = Value;
      ID++;
    }

  }


}
