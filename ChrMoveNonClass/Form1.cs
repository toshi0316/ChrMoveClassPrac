using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        /** キャラクタータイプ*/
        enum CHRTYPE
        {
            CHR_STRAIGHT=0,
            CHR_GRAVITY,
            CHR_ADD
        };
        /** キャラクターの動き*/
        List<CHRTYPE> types = new List<CHRTYPE>();
        /** キャラクター表示用ラベル*/
        List<Label> labels = new List<Label>();
        /** キャラクターX座標*/
        List<float> posxs = new List<float>();
        /** キャラクターY座標*/
        List<float> posys = new List<float>();
        /** キャラクターX速度*/
        List<float> vxs = new List<float>();
        /** キャラクターY速度*/
        List<float> vys = new List<float>();
        /** 乱数*/
        public static Random rand = new Random();
        /** 重力加速度*/
        const float GRAVITY = 5f;
        /** 加速度*/
        const float FORCE = 0.5f;
        /** 最高速度*/
        const float MAX_SPEED = 10f;


        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float nx, ny;

            CChr.UpdateAll();
            
            for (int i = 0; i < labels.Count; i++)
            {
                // ラベルの種類を特定する
                switch (types[i])
                {
                        // 中心に加速
                    case CHRTYPE.CHR_ADD:
                        posxs[i] += vxs[i];
                        // Xの速度を調整
                        if (posxs[i] < ClientSize.Width / 2)
                        {
                            vxs[i] += FORCE;
                        }
                        else
                        {
                            vxs[i] -= FORCE;
                        }
                        // Yの速度を調整
                        posys[i] += vys[i];
                        // Yの速度を調整
                        if (posys[i] < ClientSize.Height / 2)
                        {
                            vys[i] += FORCE;
                        }
                        else
                        {
                            vys[i] -= FORCE;
                        }
                        break;
                }

                // 場所を更新
                labels[i].Left = (int)posxs[i];
                labels[i].Top = (int)posys[i];
            }
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
            InstantiateChr(CHRTYPE.CHR_ADD);
        }

        /** キャラクター文字*/
        private string[] CHRMOJI = {
                                   "○","◆","∵"
                                };

        /** キャラクターを新規に生成して、画面の中央に出力*/
        private int InstantiateChr(CHRTYPE type)
        {
            // タイプを追加
            types.Add(type);
            int idx = types.Count - 1;

            // ラベルを生成して追加
            labels.Add(new Label());
            labels[idx].Text = CHRMOJI[(int)type];
            labels[idx].AutoSize = true;
            labels[idx].Left = ClientSize.Width / 2;
            labels[idx].Top = ClientSize.Height / 2;
            // 座標の生成
            posxs.Add(ClientSize.Width / 2);
            posys.Add(ClientSize.Height / 2);
            // 速度の追加
            vxs.Add((float)(rand.NextDouble() * 2 * MAX_SPEED - MAX_SPEED));
            vys.Add((float)(rand.NextDouble() * 2 * MAX_SPEED - MAX_SPEED));
            // フォームに追加
            Controls.Add(labels[idx]);

            return idx;
        }
    }
}
