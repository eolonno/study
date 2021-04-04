using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
  interface ICalc
  {
    string ChangeSub(string str, string subStrOld, string subStrNew);
    string DelSub(string str, string removeStr);
    string FindByInd(string str, int b);
    int Length(string str);
    int VovelAm(string str);
    int ConsAm(string str);
    int SentAm(string str);
    int WordAm(string str);
  }
}
