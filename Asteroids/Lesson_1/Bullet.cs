﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{

    /// <summary>
    /// Класс пуля
    /// </summary>
    class Bullet : BaseObject
    {
        /// <summary>
        /// Картинка пули
        /// </summary>
        private static Bitmap bullet;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos">Позиция на экране</param>
        /// <param name="dir">Изменение координат</param>
        /// <param name="size">Размер объекта</param>
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            bullet = new Bitmap(Image.FromFile($@"{Application.StartupPath}\bullet.png"), size);
        }

        /// <summary>
        /// Рисование пули
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(bullet, _pos);
        }

        /// <summary>
        /// Обновление пули
        /// </summary>
        public override void Update()
        {
            _pos.X = _pos.X + _dir.X;
            if (_pos.X > Game.Width) _pos.X = 0;
        }
    }
}
