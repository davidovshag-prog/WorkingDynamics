using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorkingDynamics
{
    public partial class MainForm : Form
    {
        private TextBox[,] textBoxesA;
        private TextBox[,] textBoxesB;
        private TextBox[,] textBoxesC; // ��� ����������

        public MainForm()
        {
            InitializeComponent();

            // ������������ ComboBox ��� ������ ������
            cbRows.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRows.Items.Add("2");
            cbRows.Items.Add("3");
            cbRows.Items.Add("4");
            cbRows.Items.Add("5");
            cbRows.SelectedIndex = 0; // �� ������������� 2x2
        }

        private void cbRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            // �������� ����� ����� (n x n)
            int n = int.Parse(cbRows.SelectedItem.ToString());

            // 1. ������� ���� �������
            ClearMatrixView(ref textBoxesA, gbA);
            ClearMatrixView(ref textBoxesB, gbB);
            ClearMatrixView(ref textBoxesC, gbC);

            // 2. ������ ��� �������
            // ������� A (��� ��������)
            textBoxesA = BuildMatrixView(gbA, n, n, false);
            // ������� B (��� ��������)
            textBoxesB = BuildMatrixView(gbB, n, n, false);
            // ������� C (����� ��� ������� ����������)
            textBoxesC = BuildMatrixView(gbC, n, n, true);
        }

        /// <summary>
        /// ������� ����� GroupBox �� ������ TextBox
        /// </summary>
        private void ClearMatrixView(ref TextBox[,] boxes, GroupBox gb)
        {
            if (boxes != null)
            {
                foreach (var txtBox in boxes)
                {
                    gb.Controls.Remove(txtBox); // ��������� � �����
                    txtBox.Dispose(); // ��������� ���'���
                }
            }
            boxes = null; // ��������� �����
        }

        /// <summary>
        /// ������� � �������� ���� TextBox ��� �������
        /// </summary>
        private TextBox[,] BuildMatrixView(GroupBox gb, int n, int m, bool isReadOnly)
        {
            TextBox[,] boxes = new TextBox[n, m];

            // ������������ ����
            int width = 50;  // ������ ����
            int height = 25; // ������ ����
            int padding = 5; // ³�����
            int startX = 20; // ��������� ������� X
            int startY = 30; // ��������� ������� Y

            for (int i = 0; i < n; i++) // �����
            {
                for (int j = 0; j < m; j++) // �������
                {
                    boxes[i, j] = new TextBox
                    {
                        Location = new Point(startX + j * (width + padding), startY + i * (height + padding)),
                        Size = new Size(width, height),
                        ReadOnly = isReadOnly,
                        Text = "0", // �������� �� �������������
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
        /// ����� �������� � ���� TextBox � ������� ��'��� MyMatrix
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
                    // .TryParse - ������������ ������ � �����
                    if (!double.TryParse(boxes[i, j].Text, out data[i, j]))
                    {
                        // ���� ������� �� �����, ������ �������
                        boxes[i, j].Focus();
                        boxes[i, j].SelectAll();
                        throw new FormatException($"���������� �������� � ������ [{i + 1}, {j + 1}]");
                    }
                }
            }
            return new MyMatrix(data);
        }

        /// <summary>
        /// ³������� ��� � ��'���� MyMatrix � ����� TextBox
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
                MyMatrix a = GetMatrixFromUI(textBoxesA); // ������� �
                MyMatrix b = GetMatrixFromUI(textBoxesB); // ������� B
                MyMatrix c = MyMatrix.Add(a, b);         //  C = A + B
                DisplayMatrixInUI(c, textBoxesC);        // ���������
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}