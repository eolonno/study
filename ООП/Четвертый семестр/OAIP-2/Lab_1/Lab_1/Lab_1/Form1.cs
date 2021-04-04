using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
  public partial class Form1 : Form
  {

    Calc calc;

    string str = "", strOld = "", strNew = "";
    int countApply = 1;
    int codeOp = 0;
    public Form1()
    {
      InitializeComponent();

      calc = new Calc();

      strField.Text = "Input string";
    }

    private void BtnOnClick(object sender, EventArgs e)
    {
      switch (((Button)sender).Name)
      {
        case "btn_1":
        {
          countApply = 3;
          opLabel.Text = "Change String";
          FreeBtn();
          btn_1.Enabled = false;
          codeOp = 1;
        }
        break;
        case "btn_2":
        {
          countApply = 2;
          opLabel.Text = "Delete String";
          FreeBtn();
          btn_2.Enabled = false;
          codeOp = 2;
        }
        break;
        case "btn_3":
        {
          countApply = 2;
          opLabel.Text = "Find symbol";
          FreeBtn();
          btn_3.Enabled = false;
          codeOp = 3;
        }
        break;
        case "btn_4":
        {
          countApply = 1;
          opLabel.Text = "String length";
          FreeBtn();
          btn_4.Enabled = false;
          codeOp = 4;
        }
        break;
        case "btn_5":
        {
          countApply = 1;
          opLabel.Text = "String vovels";
          FreeBtn();
          btn_5.Enabled = false;
          codeOp = 5;
        }
        break;
        case "btn_6":
        {
          countApply = 1;
          opLabel.Text = "String consonants";
          FreeBtn();
          btn_6.Enabled = false;
          codeOp = 6;
        }
        break;
        case "btn_7":
        {
          countApply = 1;
          opLabel.Text = "Sentences";
          FreeBtn();
          btn_7.Enabled = false;
          codeOp = 7;
        }
        break;
        case "btn_8":
        {
          countApply = 1;
          opLabel.Text = "Words";
          FreeBtn();
          btn_8.Enabled = false;
          codeOp = 8;
        }
        break;
        case "btn_clear":
        {
          btnClearFunc();
        }
        break;
        case "btn_apply":
        {
          btnApplyFunc();
        }
        break;

      }
    }

    private void btnClearFunc()
    {
      opLabel.Text = "Operation";
      FreeBtn();
      countApply = 1;
      if( codeOp == 0 ) {
        strField.Text = "Input string";
      }
      codeOp = 0;
    }

    private void btnApplyFunc()
    {
      switch (codeOp)
      {
        case 1:
        {
          changeString();
        }
        break;
        case 2:
        {
          deleteStirng();
        }
        break;
        case 3:
        {
          findSymbolByIndex();
        }
        break;
        case 4:
        {
          stringLength();
        }
        break;
        case 5:
        {
          vovels();
        }
        break;
        case 6:
        {
          consonants();
        }
        break;
        case 7:
        {
          sentences();
        }
        break;
        case 8:
        {
          words();
        }
        break;
        case 0:{
          btnClearFunc();
        }
        break;
      }
    }

    private void words()
    {
      if (countApply == 1)
      {
        if (CheckInputField())
        {
          str = strField.Text;

          int _val = calc.WordAm(str);
          if (_val == -1)
          {
            strField.Text = "Invalid value";
          }
          else
          {
            strField.Text = _val.ToString();
            btnClearFunc();
          }
        }
        else
        {
          MessageBox.Show("Invalid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void sentences()
    {
      if (countApply == 1)
      {
        if (CheckInputField())
        {
          str = strField.Text;

          int _val = calc.SentAm(str);
          if (_val == -1)
          {
            strField.Text = "Invalid value";
          }
          else
          {
            strField.Text = _val.ToString();
            btnClearFunc();
          }
        }
        else
        {
          MessageBox.Show("Invalid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void consonants()
    {
      if (countApply == 1)
      {
        if (CheckInputField())
        {
          str = strField.Text;

          int _val = calc.ConsAm(str);
          if (_val == -1)
          {
            strField.Text = "Invalid value";
          }
          else
          {
            strField.Text = _val.ToString();
            btnClearFunc();
          }
        }
        else
        {
          MessageBox.Show("Invalid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void vovels()
    {
      if (countApply == 1)
      {
        if (CheckInputField())
        {
          str = strField.Text;

          int _val = calc.VovelAm(str);
          if (_val == -1)
          {
            strField.Text = "Invalid value";
          }
          else
          {
            strField.Text = _val.ToString();
            btnClearFunc();
          }
        }
        else
        {
          MessageBox.Show("Invalid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }



    private void stringLength()
    {
      if (countApply == 1)
      {
        if (CheckInputField())
        {
          str = strField.Text;

          int _val = calc.Length(str);
          if (_val == -1)
          {
            strField.Text = "Invalid value";
          }
          else
          {
            strField.Text = _val.ToString();
            btnClearFunc();
          }
        }
        else
        {
          MessageBox.Show("Invalid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void findSymbolByIndex()
    {
      if (countApply == 2)
      {
        if (CheckInputField())
        {
          str = strField.Text;
          strField.Text = "Input index";
          countApply--;
        }
        else
        {
          MessageBox.Show("Invalid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      else if (countApply == 1)
      {
        if (CheckInputField())
        {
          strOld = strField.Text;
          try
          {
            string _str = calc.FindByInd(str, Int32.Parse(strOld));
            if (_str.Length == 0)
            {
              strField.Text = "Invalid value";
            }
            else
            {
              strField.Text = _str;
              btnClearFunc();
            }
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        else
        {
          MessageBox.Show("Invalid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void deleteStirng()
    {
      if (countApply == 2)
      {
        if (CheckInputField())
        {
          str = strField.Text;
          strField.Text = "Input substring to delete";
          countApply--;
        }
        else
        {
          MessageBox.Show("Invalid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      else if (countApply == 1)
      {
        if (CheckInputField())
        {
          strOld = strField.Text;
          string _str = calc.DelSub(str, strOld);
          if (_str.Length == 0)
          {
            strField.Text = "Invalid value";
          }
          else
          {
            strField.Text = _str;
            btnClearFunc();
          }
        }
        else
        {
          MessageBox.Show("Invalid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void changeString()
    {
      if (countApply == 3)
      {
        if (CheckInputField())
        {
          str = strField.Text;
          strField.Text = "Input substring to change";
          countApply--;
        }
        else
        {
          MessageBox.Show("Invalid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      else if (countApply == 2)
      {
        if (CheckInputField())
        {
          strOld = strField.Text;
          strField.Text = "Input new substring";
          countApply--;
        }
        else
        {
          MessageBox.Show("Invalid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      else if (countApply == 1)
      {
        if (CheckInputField())
        {
          strNew = strField.Text;
          string _str = calc.ChangeSub(str, strOld, strNew);
          if (_str.Length == 0)
          {
            strField.Text = "Invalid value";
          }
          else
          {
            strField.Text = _str;
            btnClearFunc();
          }
        }
        else
        {
          MessageBox.Show("Invalid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private bool CheckInputField()
    {
      if (strField.Text.Length > 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private void FreeBtn()
    {
      btn_1.Enabled = true;
      btn_2.Enabled = true;
      btn_3.Enabled = true;
      btn_4.Enabled = true;
      btn_5.Enabled = true;
      btn_6.Enabled = true;
      btn_7.Enabled = true;
      btn_8.Enabled = true;
    }

  }

}
