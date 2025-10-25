using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorkingDynamics
{
    public partial class MainForm : Form
    {
        private TextBox[,] textBoxesA;
        private TextBox[,] textBoxesB;
        private TextBox[,] textBoxesC; // Для результату

        public MainForm()
        {
            InitializeComponent();

            // Налаштування ComboBox для вибору розміру
            cbRows.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRows.Items.Add("2");
            cbRows.Items.Add("3");
            cbRows.Items.Add("4");
            cbRows.Items.Add("5");
            cbRows.SelectedIndex = 0; // За замовчуванням 2x2
        }

        private void cbRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Отримуємо новий розмір (n x n)
            int n = int.Parse(cbRows.SelectedItem.ToString());

            // 1. Очищуємо старі матриці
            ClearMatrixView(ref textBoxesA, gbA);
            ClearMatrixView(ref textBoxesB, gbB);
            ClearMatrixView(ref textBoxesC, gbC);

            // 2. Будуємо нові матриці
            // Матриця A (для введення)
            textBoxesA = BuildMatrixView(gbA, n, n, false);
            // Матриця B (для введення)
            textBoxesB = BuildMatrixView(gbB, n, n, false);
            // Матриця C (тільки для читання результату)
            textBoxesC = BuildMatrixView(gbC, n, n, true);
        }

        /// <summary>
        /// Повністю очищує GroupBox від старих TextBox
        /// </summary>
        private void ClearMatrixView(ref TextBox[,] boxes, GroupBox gb)
        {
            if (boxes != null)
            {
                foreach (var txtBox in boxes)
                {
                    gb.Controls.Remove(txtBox); // Видаляємо з форми
                    txtBox.Dispose(); // Звільняємо пам'ять
                }
            }
            boxes = null; // Обнуляємо масив
        }

        /// <summary>
        /// Створює і відображає сітку TextBox для матриці
        /// </summary>
        private TextBox[,] BuildMatrixView(GroupBox gb, int n, int m, bool isReadOnly)
        {
            TextBox[,] boxes = new TextBox[n, m];

            // Налаштування сітки
            int width = 50;  // Ширина поля
            int height = 25; // Висота поля
            int padding = 5; // Відступ
            int startX = 20; // Початкова позиція X
            int startY = 30; // Початкова позиція Y

            for (int i = 0; i < n; i++) // Рядки
            {
                for (int j = 0; j < m; j++) // Стовпці
                {
                    boxes[i, j] = new TextBox
                    {
                        Location = new Point(startX + j * (width + padding), startY + i * (height + padding)),
                        Size = new Size(width, height),
                        ReadOnly = isReadOnly,
                        Text = "0", // Значення за замовчуванням
                        Name = $"txt_{gb.Name}_{i}_{j}"
                    };
                    gb.Controls.Add(boxes[i, j]);
                }
            }

            int totalWidth = startX + m * (width + padding) + padding + 10;
            int totalHeight = startY + n * (height + padding) + padding + 10;
            gb.Size = new Size(totalWidth, totalHeight);

            return boxes;
        }


        /// <summary>
        /// Зчитує значення з полів TextBox і створює об'єкт MyMatrix
        /// </summary>
        private MyMatrix GetMatrixFromUI(TextBox[,] boxes)
        {
            int rows = boxes.GetLength(0);
            int cols = boxes.GetLength(1);
            double[,] data = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // .TryParse - перетворення тексту в число
                    if (!double.TryParse(boxes[i, j].Text, out data[i, j]))
                    {
                        // Якщо введено не число, кидаємо помилку
                        boxes[i, j].Focus();
                        boxes[i, j].SelectAll();
                        throw new FormatException($"Некоректне значення у комірці [{i + 1}, {j + 1}]");
                    }
                }
            }
            return new MyMatrix(data);
        }

        /// <summary>
        /// Відображає дані з об'єкта MyMatrix у полях TextBox
        /// </summary>
        private void DisplayMatrixInUI(MyMatrix m, TextBox[,] boxes)
        {
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    boxes[i, j].Text = m.Data[i, j].ToString("F2");
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MyMatrix a = GetMatrixFromUI(textBoxesA); // матриця А
                MyMatrix b = GetMatrixFromUI(textBoxesB); // матриця B
                MyMatrix c = MyMatrix.Add(a, b);         //  C = A + B
                DisplayMatrixInUI(c, textBoxesC);        // результат
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            try
            {
                MyMatrix a = GetMatrixFromUI(textBoxesA);
                MyMatrix b = GetMatrixFromUI(textBoxesB);
                MyMatrix c = MyMatrix.Subtract(a, b);   // C = A - B
                DisplayMatrixInUI(c, textBoxesC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            try
            {
                MyMatrix a = GetMatrixFromUI(textBoxesA);
                MyMatrix b = GetMatrixFromUI(textBoxesB);
                MyMatrix c = MyMatrix.Multiply(a, b);   // C = A * B
                DisplayMatrixInUI(c, textBoxesC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}