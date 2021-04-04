using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
  class NotStrException : Exception
  {
    public NotStrException(string message) : base(message) { }
  }

  public class Calc : ICalc
  {

    public string ChangeSub(string str, string subStrOld, string subStrNew)
    {
      try
      {
        if (str != null && subStrOld != null && subStrNew != null)
        {
          return str.Replace(subStrOld, subStrNew);
        }
      }
      catch (NotStrException ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return "";
    }

    
    public string DelSub(string str, string removeStr)
    {
      try
      {
        return str.Replace(removeStr, "");
      }
      catch (NotStrException ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return "";
    }

    public string FindByInd(string str, int index)
    {
      try
      {
        return str.Substring(index, 1);
      }
      catch (NotStrException ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return "";
    }

    public int Length(string str)
    {
      try
      {
        return str.Length;
      }
      catch (NotStrException ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return -1;
    }

    public int VovelAm(string str)
    {
      try
      {
        int n = 0;
        string b = str.ToLower();
        char[] vovels = new char[5] { 'a', 'e', 'o', 'i', 'u' };
        for (int i = 0; i < b.Length; i++)
          for (int j = 0; j < 5; j++)
            if (b[i] == vovels[j])
              n++;
        return n;
      }
      catch (NotStrException ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return -1;
    }

    public int ConsAm(string str)
    {
      try
      {
        return str.Length - VovelAm(str);
      }
      catch (NotStrException ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return -1;
    }

    public int SentAm(string str)
    {
      try
      {
        int i = 0;
        if (str[str.Length - 1] != '.' || str[str.Length - 1] != '!' || str[str.Length - 1] != '?')
          i++;
        if (str[0] == '.')
          str.Remove(0, 1);
        for (int j = 0; j < str.Length; j++)
        {
          if (str[j] == '.' || str[j] == '!' || str[j] == '?') i++;
        }
        return i;
      }
      catch (NotStrException ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return -1;
    }

    public int WordAm(string str)
    {
      try
      {
        int i = 1; //Так как последнее слово не в счет!
        if (str[0] == ' ')
          str.Remove(0, 1);
        if (str[str.Length - 1] == ' ')
          str.Remove(0, 1);
        for (int j = 0; j < str.Length; j++)
        {
          if (str[j] == ' ') i++;
        }
        return i;
      }
      catch (NotStrException ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return -1;
    }

  }

}
