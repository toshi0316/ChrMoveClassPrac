using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CAdd : CChr
    {
        /** 加速度*/
        const float FORCE = 0.5f;

        /** コンストラクタ*/
        public CAdd() : base()
        {
            type = CHRTYPE.CHR_ADD;
            label.Text = "ω";
        }

        protected override void Update()
        {
            posx += vx;
            // Xの速度を調整
            if (posx < Form1.ActiveForm.ClientSize.Width / 2)
            {
                vx += FORCE;
            }
            else
            {
                vx -= FORCE;
            }
            // Yの速度を調整
            posy += vy;
            // Yの速度を調整
            if (posy < Form1.ActiveForm.ClientSize.Height / 2)
            {
                vy += FORCE;
            }
            else
            {
                vy -= FORCE;
            }

            label.Left = (int)posx;
            label.Top = (int)posy;
        }

        /** キャラクターを生成*/
        public static void InstantiateChr()
        {
            we.Add(new CAdd());
        }
    }
}
