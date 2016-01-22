using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CGravity : CChr
    {
        /** 重力加速度*/
        const float GRAVITY = 5f;

        /** コンストラクタ*/
        public CGravity() : base()
        {
            type = CHRTYPE.CHR_GRAVITY;
            label.Text = "-◆-";
            vy = 0f;
        }

        protected override void Update()
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
            posx = nx;
            // Y移動
            vy += GRAVITY;
            ny = posy + vy;
            if (ny + label.Height > Form1.ActiveForm.ClientSize.Height)
            {
                // 速度反転
                vy = -vy;
                ny = Form1.ActiveForm.ClientSize.Height - label.Height;
            }
            posy = ny;

            label.Left = (int)posx;
            label.Top = (int)posy;

        }

        /** キャラクターを生成*/
        public static void InstantiateChr()
        {
            we.Add(new CGravity());
        }
    }
}
