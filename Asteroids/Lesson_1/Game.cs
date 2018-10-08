using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        /// <summary>
        /// Предоставляет доступ к главному буферу графического контекста
        /// для текущего приложения
        /// </summary>
        private static BufferedGraphicsContext _context;

        /// <summary>
        /// Буфер для рисования
        /// </summary>
        public static BufferedGraphics Buffer;

        /// <summary>
        /// Массив объектов
        /// </summary>
        private static BaseObject[] _objs;

        private static Random rand = new Random();

        /// <summary>
        /// Пуля
        /// </summary>
        private static Bullet _bullet;

        /// <summary>
        /// Массив астероидов
        /// </summary>
        private static Asteroid[] _asteroids;



        /// <summary>
        /// Ширина игрового поля
        /// </summary>
        public static int Width { get; set; }

        /// <summary>
        /// Высота игрового поля
        /// </summary>
        public static int Height { get; set; }
        
        static Image image = Image.FromFile($@"{Application.StartupPath}\Galactic.jpg");

        /// <summary>
        /// Фоновая картинка.
        /// </summary>
        static Bitmap background;

        static Game()
        {
        }

        /// <summary>
        /// Целевой метод для события Timer.Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }



        /// <summary>
        /// Загрузка графики формы
        /// </summary>
        /// <param name="form">Экземпляр формы</param>
        public static void Init(Form form)
        {
           
            // Графическое устройство для вывода графики
            
            Graphics g;


            
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();


            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;


            ////Выброс исключений (задача 4). Для работы раскомментировать

            //if (Width < 0 || Height < 0)
            //{
            //    throw new ArgumentOutOfRangeException("Поле не может иметь отрицательный размер");
            //}
            //else if (Width > 1000 || Height > 1000)
            //{
            //    throw new ArgumentOutOfRangeException("Размер поля не может быть больше 1000");
            //}

            
            background = new Bitmap(image, Width, Height);

            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в
            //буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            //Создаем экземпляр таймера
            Timer timer = new Timer { Interval = 40 };
            timer.Start();

            //Подписываем метод Timer_Tick на событие timer.Tick
            timer.Tick += Timer_Tick;


        }

        /// <summary>
        /// Рисование объектов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.DrawImage(background, 0, 0);
            foreach (BaseObject obj in _objs)
            obj.Draw();
            foreach (var asteroid in _asteroids)
            asteroid.Draw();
            _bullet.Draw();
            Buffer.Render();
        }

        /// <summary>
        /// Обновление объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (var asteroid in _asteroids)
            {
                asteroid.Update();

                //Сделать так, чтобы при столкновении пули с астероидом они регенерировались в разных концах экрана.
                if (asteroid.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    asteroid.Pos = new Point(rand.Next(0, Width), rand.Next(0, Height));
                    _bullet.Pos = new Point(0, rand.Next(0, Height));
                }
            }
            _bullet.Update();
        }


        /// <summary>
        /// Загрузка объектов в игру
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[30];
            _bullet = new Bullet(new Point(0, 200), new Point(10, 0), new Size(50, 12));
            _asteroids = new Asteroid[3];

            for (int i = 0; i < _objs.Length; i++)
            {
                int r = rand.Next(5, 50);
                _objs[i] = new Star(new Point(600, rand.Next(0, Game.Height)), new Point(-r, r), new Size(r, r));
            }
            for (int i = 0; i < _asteroids.Length; i++)
            {
                int r = rand.Next(5, 15);
                _asteroids[i] = new Asteroid(new Point(600, rand.Next(0, Game.Height)), new Point(r, r), new Size(50, 50));
            }
        }
    }
}
