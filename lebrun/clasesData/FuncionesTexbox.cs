using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lebrun.clasesData
{
    class FuncionesTexbox
    {


        public void txtOnlyDecimal(object sender, KeyPressEventArgs e, TextBox textBox)
        {

            if (textBox.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }

                if (e.KeyChar == '\r')
                {
                    SendKeys.Send("{TAB}");
                }

            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }

                if (e.KeyChar == '\r') 
                {
                    SendKeys.Send("{TAB}");

                }

            }
        }

        public void OnlyNumbers(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        
        }

        public void tab(object sender, KeyPressEventArgs e) 
        {
            if (e.KeyChar == '\r')
            {

                SendKeys.Send("{TAB}");
                e.Handled = false;
            }
        }

        public void onlyNumberWithTab(object sender, KeyPressEventArgs e) 
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '\r')
            {
                SendKeys.Send("{TAB}");
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

     public void only2Decimal(object sender, KeyPressEventArgs e,TextBox textBox) 
        {
 
          if (e.KeyChar ==8 ) {
             e.Handled = false;
             return;
           }

          if (e.KeyChar == 13)
          {
              SendKeys.Send("{TAB}");
              e.Handled = false;
              return;
          }

           bool IsDec = false;
            int nroDec = 0;

           for (int i=0 ; i<textBox.Text.Length; i++) {
             if (textBox.Text[i] == ',' )
                IsDec = true;

             if (IsDec && nroDec++ >=2) {
                e.Handled = true;
                return;
             }
           }

           if (e.KeyChar >= 48 && e.KeyChar <= 57)
               e.Handled = false;
           else if (e.KeyChar == 46 || e.KeyChar == 44)
           {
               e.KeyChar =',';
               e.Handled = (IsDec) ? true : false;
           }
           else
               e.Handled = true;

        }





        public void montosD(object sender, KeyPressEventArgs e,TextBox textBox) {

            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;

            }

            if (e.KeyChar == 8)
            {
                e.Handled = false;

            }
            if ((e.KeyChar == '.') || (e.KeyChar == ','))
            {
                if (existeCaracter(textBox))
                {
                    e.Handled = true;

                }
            }

            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;

            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < textBox.Text.Length; i++)
            {
                if ((textBox.Text[i] == '.') || (textBox.Text[i] == ','))
                    IsDec = true;


                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;

                }
            }
        }
        
        private Boolean existeCaracter(TextBox textBox)
        {
            int i;
            int contador = 1;
            Boolean centinela = false;
            for (i = 0; i < textBox.Text.Length; i++)
            {
                if ((textBox.Text[i] == ',') || (textBox.Text[i] == '.'))
                {
                    contador = contador + 1;
                    if (contador > 1)
                    {
                        centinela = true;
                        break;
                    }

                }
            }
            return centinela;
        }



        public void conDecimalesDefinidos(object sender, KeyPressEventArgs e, TextBox textBox,int numberDecimal)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < textBox.Text.Length; i++)
            {
                if (textBox.Text[i] == ',')
                    IsDec = true;

                if (IsDec && nroDec++ >= numberDecimal)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46 || e.KeyChar == 44)
            {
                e.KeyChar = ',';
                e.Handled = (IsDec) ? true : false;
            }
            else
                e.Handled = true;

        }

        public bool isNull(string evaluar)
        {
            if (evaluar == null)
            {
                return true;
            }
            else { return false; }
        }

        public decimal Truncate(decimal pImporte, int pNumDecimales)
        {
            decimal wRt = 0;
            decimal wPot10 = 1;

            for (int i = 1; i <= pNumDecimales; i++)
            {
                wPot10 = wPot10 * 10;
            }

            wRt = pImporte * wPot10;
            wRt = decimal.Truncate(wRt);
            wRt = wRt / wPot10;
            wRt = decimal.Round(wRt, 2);

            return wRt;
        }

        public void sinCharEspeciales(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar >= 45 && e.KeyChar <= 57) || (e.KeyChar >= 97 && e.KeyChar <= 122) || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar == 8))
                e.Handled = false;
            else
                e.Handled = true;

            if (e.KeyChar == '\r')
            {

                SendKeys.Send("{TAB}");
                e.Handled = false;
            }

        }

        public void conDecimalesDefinidosNegativo(object sender, KeyPressEventArgs e, TextBox textBox, int numberDecimal)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < textBox.Text.Length; i++)
            {
                if (textBox.Text[i] == ',')
                    IsDec = true;

                if (IsDec && nroDec++ >= numberDecimal)
                {
                    e.Handled = true;
                    return;
                }
            }


            if (e.KeyChar == 45)
            {

                bool negativo = false;
                int nroSigno = 0;

                for (int i = 0; i < textBox.Text.Length; i++)
                {
                    if (textBox.Text[i] == '-')
                    {
                        negativo = true;
                        nroSigno++;
                    }


                    if (negativo && i > 0 || nroSigno == 1)
                    {
                        e.Handled = true;
                        return;
                    }
                    else if (!negativo && i == 0)
                    {
                        e.Handled = false;
                        return;
                    }
                }

            }



            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 45)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 46 || e.KeyChar == 44)
            {
                e.KeyChar = ',';
                e.Handled = (IsDec) ? true : false;
            }
            else
                e.Handled = true;




        }

        public void txtWithoutPunctuation_Symbol_Letter(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }

            if (Char.IsSymbol(e.KeyChar)) //no se puede colocar simbolo de dolar, + , etc
            {
                e.Handled = true;
            }

            if (Char.IsLetter(e.KeyChar)) // no se permite letras 
            {
                e.Handled = true;
            }
        }

        public void txtWithoutNumber(object sender, KeyPressEventArgs e)
        {

            if (Char.IsNumber(e.KeyChar)) //no se puede colocar simbolo de dolar, + , etc
            {
                e.Handled = true;
            }
        }

        public void enter(object sender, KeyPressEventArgs e)
        {
            int i = 0;
            while (i == 0)
            {
                if (e.KeyChar == 13)
                {
                    ++i;
                }
            }
        }


    }//fin clase
}
