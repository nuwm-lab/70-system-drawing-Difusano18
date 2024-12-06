using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphDrawing
{
    public partial class Form1 : Form
    {
        Graphics graph; // Об'єкт для малювання
        public Form1()
        {
            InitializeComponent();
            graph = CreateGraphics(); // Ініціалізація об'єкта Graphics
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Очищуємо графіку при кожному кліку
            graph.Clear(this.BackColor);

            // Налаштування кольору та стилю пера
            Color penColor = Color.Blue;
            float penWidth = 2;
            Pen pen = new Pen(penColor, penWidth);

            // Початкові точки
            float xStart = 0.1f; // Початкове значення x
            float xEnd = 1.2f;   // Кінцеве значення x
            float step = 0.1f;   // Крок ∆x

            // Розміри форми
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Центруємо графік у формі
            float centerX = formWidth / 2;
            float centerY = formHeight / 2;

            // Масштабування для збільшення графіка
            float scaleX = 200; // Масштаб по X
            float scaleY = 500; // Масштаб по Y

            float prevX = centerX + xStart * scaleX;
            float prevY = centerY - CalculateFunction(xStart) * scaleY;

            // Малюємо графік функції
            for (float x = xStart + step; x <= xEnd; x += step)
            {
                float y = CalculateFunction(x);

                // Перетворюємо координати на масштаб форми
                float currentX = centerX + x * scaleX;
                float currentY = centerY - y * scaleY;

                // Малюємо лінію між двома точками
                graph.DrawLine(pen, prevX, prevY, currentX, currentY);

                // Оновлюємо попередні координати
                prevX = currentX;
                prevY = currentY;
            }
        }

        // Функція для розрахунку y = ln(0.5x) / (x^2 + 7.5)
        private float CalculateFunction(float x)
        {
            if (x <= 0) return 0; // Перевірка на коректність x
            return (float)(Math.Log(0.5 * x) / (Math.Pow(x, 2) + 7.5));
        }
    }
}
