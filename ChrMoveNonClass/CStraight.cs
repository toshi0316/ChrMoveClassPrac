using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class CStraight
    {
        /** 自分のインスタンス*/
        static List<CStraight> we = new List<CStraight>();

        /** キャラクタータイプ*/
        enum CHRTYPE
        {
            CHR_STRAIGHT = 0,
            CHR_GRAVITY,
            CHR_ADD
        };
        /** キャラクターの動き*/
        CHRTYPE type;
        /** キャラクター表示用ラベル*/
        Label label;
        /** キャラクターX座標*/
        float posx;
        /** キャラクターY座標*/
        float posy;
        /** キャラクターX速度*/
        float vx;
        /** キャラクターY速度*/
        float vy;
        /** 最高速度*/
        const float MAX_SPEED = 10f;

        public CStraight()
        {
            // タイプを設定
            type = CHRTYPE.CHR_STRAIGHT;

            // ラベルを生成して追加
            label = new Label();
            label.Text = "○";
            label.AutoSize = true;
            label.Left = Form1.ActiveForm.ClientSize.Width / 2;
            label.Top = Form1.ActiveForm.ClientSize.Height / 2;
            // 座標の生成
            posx = Form1.ActiveForm.ClientSize.Width / 2;
            posy = Form1.ActiveForm.ClientSize.Height / 2;
            // 速度の追加
            vx = (float)(Form1.rand.NextDouble() * 2 * MAX_SPEED - MAX_SPEED);
            vy = (float)(Form1.rand.NextDouble() * 2 * MAX_SPEED - MAX_SPEED);
            // フォームに追加
            Form1.ActiveForm.Controls.Add(label);
        }


        protected void Update()
        {
            float nx, ny;
            // X移動
            nx = posx + vx;
            // 跳ね返り
            if ((nx < 0f) || (nx + label.Width > Form1.ActiveForm.ClientSize.Width))
            {
                vx = -vx;
                nx = posx + vx;
            }
            // Y移動
            ny = posy + vy;
            // 跳ね返り
            if ((ny < 0f) || (ny + label.Height > Form1.ActiveForm.ClientSize.Height))
            {
                vy = -vy;
                ny = posy + vy;
            }
            // 書き戻し
            posx = nx;
            posy = ny;
        }

        /** キャラクターを生成*/
        public static void InstantiateChr()
        {
            we.Add(new CStraight());
        }

        /** 登録済みの全てのキャラクターのUpdateを呼び出す*/
        public static void UpdateAll()
        {
            foreach (CStraight me in we)
            {
                me.Update();
            }
        }
    }
}
