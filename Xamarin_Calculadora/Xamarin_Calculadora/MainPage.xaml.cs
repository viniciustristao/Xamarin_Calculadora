using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace Xamarin_Calculadora
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        
        int currentState = 1;//estado da calculadora
        String mathOperator;//guardar os operadores matematicos
        Double firstNumber, secondNumber;//variaveis para armazenamento dos numeros

        public MainPage()
        {
            InitializeComponent();
            limpar(new object(), new EventArgs());
        }

        void limpar(Object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }

        void numeroSelecionado (object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            string pressionado = botao.Text;
            if(this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";
                if (currentState < 0)
                {
                    currentState *= -1;
                }
            }
            this.resultText.Text += pressionado;

            double number;
            if(double.TryParse(this.resultText.Text,out number))
            {
                this.resultText.Text = number.ToString("N0");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else{
                    secondNumber = number;
                }
            }
        }

        void onSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }

        void onCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result = calculate(firstNumber, secondNumber, mathOperator);

                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        private Double calculate(double firstNumber, double secondNumber, string mathOperator)
        {
            if (mathOperator.ToUpper().CompareTo("X")==0)
            {
                return firstNumber * secondNumber;
            }
            else
            {
                if (mathOperator.CompareTo("+") == 0)
                {
                    return soma(firstNumber, secondNumber);
                }
                else
                {
                    if (mathOperator.CompareTo("-") == 0)
                    {
                        return firstNumber - secondNumber;
                    }
                    else
                    {
                        return firstNumber / secondNumber;
                    }
                }
            }
        }


        private double soma(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

    }
}




/* 
*/