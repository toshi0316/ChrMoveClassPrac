using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        /** 乱数*/
        public static Random rand = new Random();
        
        /**フォームの初期化*/
        public Form1()
        {
            InitializeComponent();
        }

        /**タイマー呼び出し*/
        private void timer1_Tick(object sender, EventArgs e)
        {
            CChr.UpdateAll();
        }

        /** 直線移動キャラ生成*/
        private void button1_Click(object sender, EventArgs e)
        {
            CStraight.InstantiateChr();
        }

        /** 重力キャラ生成*/
        private void button2_Click(object sender, EventArgs e)
        {
            CGravity.InstantiateChr();
        }

        /** 加速キャラ生成*/
        private void button3_Click(object sender, EventArgs e)
        {
            CAdd.InstantiateChr();
        }     
    }
}
