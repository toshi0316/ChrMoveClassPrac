using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    /** CChrは抽象クラス。　new CChr()はできない。継承する*/
    abstract class CChr
    {
        /** 自分のインスタンス*/
        protected static List<CChr> we = new List<CChr>();

        /** キャラクタータイプ*/
        protected enum CHRTYPE
        {
            CHR_STRAIGHT = 0,
            CHR_GRAVITY,
            CHR_ADD
        };
        /** キャラクターの動き*/
        protected CHRTYPE type;
        /** キャラクター表示用ラベル*/
        protected Label label;
        /** キャラクターX座標*/
        protected float posx;
        /** キャラクターY座標*/
        protected float posy;
        /** キャラクターX速度*/
        protected float vx;
        /** キャラクターY速度*/
        protected float vy;
        /** 最高速度*/
        protected const float MAX_SPEED = 10f;


        /**コンストラクタ*/
        public CChr()
        {
            // ラベルを生成して追加
            label = new Label();         
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

        /** 更新処理の抽象関数。これでUpdateの呼び出しが可能になる*/
        protected abstract void Update();

        /** 登録済みの全てのキャラクターのUpdateを呼び出す*/
        public static void UpdateAll()
        {
            foreach (CChr me in we)
            {
                me.Update();
            }
        }

        

    }
}
