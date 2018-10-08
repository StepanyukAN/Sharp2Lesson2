using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    class Asteroid : BaseObject
    {
        /// <summary>
        /// Картинка астероида
        /// </summary>
        private Bitmap asteroid;
        private static Random random = new Random();

        /// <summary>
        /// В конструкторе добавляем к каждому астероиду картинку
        /// </summary>
        /// <param name="pos">Позиция на экране</param>
        /// <param name="dir">Приращение</param>
        /// <param name="size">Размер</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            asteroid = new Bitmap(AddAsteroid(),size);
            
        }

        /// <summary>
        /// Реализованный абстрактный метод для рисования объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(asteroid, _pos.X, _pos.Y);

        }

        /// <summary>
        /// Реализованный абстрактный метод для обновления объекта на экране
        /// </summary>
        public override void Update()
        {
            _pos.X = _pos.X + _dir.X;
            _pos.Y = _pos.Y + _dir.Y;
            if (_pos.X < 0) _dir.X = -_dir.X;
            if (_pos.X + _size.Width > Game.Width) _dir.X = -_dir.X;
            if (_pos.Y < 0) _dir.Y = -_dir.Y;
            if (_pos.Y + _size.Height > Game.Height) _dir.Y = -_dir.Y;
        }

        /// <summary>
        /// Метод загрузки случайной картинки астероида
        /// </summary>
       private static Image AddAsteroid()
        {
            Image i= Image.FromFile($"{Application.StartupPath}\\0{random.Next(1, 5)}.png");
            return i;
        }
    }
}
