using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Untangle
{
    public partial class GameForm : Form
    {
        #region FIELDS
        // Цвета интерфейса
        static Color GameFieldColor = Color.FromArgb(30, 30, 30), // поле игры, черный
            VertexColor = Color.FromArgb(236, 228, 183), // вершина, белый
            RightEdgeColor = Color.FromArgb(127, 176, 105), // непересекающееся ни с кем ребро, зеленый
            CrossEdgeColor = Color.FromArgb(211, 97, 53);   // пересекающееся ребро, красный

        int randomIterations = 1000, // количество итераций для рандомизации графа
            indentFromSide = 20,    // для расстановки по кругу вершин
            VertexSize = 20,    // размер вершины
            EdgeSize = 3,       // толщина ребра
            verticesCount,     // количество вершин
            activeVertexIndex,    // индекс активной вершины
            generationsCount,   // количество итераций для генерации рёбер, задаётся в коде
            level = 6,            // уровень сложности (начинается с 4 вершин)
            autoSolves = 0;
            

        // Картинка, для сохранения результата и отображения
        Bitmap bitmap;

        // Для графики
        Graphics graphics;

        // Всякие булевы штучки
        bool isWin, isMoveVertex, isPlay, isNewGame = true;

        public static string name;

        string results;

        // Списки ребер и вершин
        static List<Edge> Edges = new List<Edge>();
        public static List<Vertex> Vertices = new List<Vertex>();
        static List<Vertex> SolvedVertices = new List<Vertex>();
        static List<Edge> SolvedEdges = new List<Edge>();
        #endregion

        #region CONSTRUCTOR
        public GameForm()
        {
            InitializeComponent();
        }
        #endregion

        #region DESIGN GET-SETTERS
        
        public Design CrossEdgeDesign
        {
            get
            {
                return new Design(CrossEdgeColor, EdgeSize);
            }
            set
            {
                Design design = value;
                CrossEdgeColor = design.Color;
                EdgeSize = design.Size;
            }
        }

        public Design RightEdgeDesign
        {
            get
            {
                return new Design(RightEdgeColor, EdgeSize);
            }
            set
            {
                Design design = value;
                RightEdgeColor = design.Color;
                EdgeSize = design.Size;
            }
        }

        public Design VertexDesign
        {
            get
            {
                return new Design(VertexColor, VertexSize);
            }
            set
            {
                Design design = value;
                VertexColor = design.Color;
                VertexSize = design.Size;
            }
        }

        #endregion

        #region DEFAULT METHODS
        private void GameForm_Load(object sender, EventArgs e)
        {
            UpdateStartMenu();
            FileStream fs = new FileStream("result.txt", FileMode.OpenOrCreate);
            using (StreamReader sr = new StreamReader(fs))
            {
                results = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(Field.Width, Field.Height);
            graphics = Graphics.FromImage(bitmap);
            name = "";
            StartLevel();
        }

        private void Field_MouseDown(object sender, MouseEventArgs e)
        {
            if (isPlay)
            {
                Point current_position = new Point(e.X, e.Y);   // текущая позиция, куда кликнул
                for (int i = 0; i < verticesCount; i++)
                {
                    if (IsPoint(current_position, Vertices[i].Location))
                    {
                        activeVertexIndex = i;  // активная вершина
                        isMoveVertex = true;
                        return;
                    }
                }
            }
        }

        private void Field_MouseMove(object sender, MouseEventArgs e)
        { 
            if (isMoveVertex && isPlay)
            {
                Point current_position = new Point(e.X, e.Y);
                if (IsOnField(current_position))
                {
                    Vertices[activeVertexIndex].Location = current_position;
                    DrawAll();
                }
            }
        }

        private void Field_MouseUp(object sender, MouseEventArgs e)
        {
            if (isPlay)
            {
                DrawAll();
                isMoveVertex = false;
                if (isWin) IsWin(sender, e);
            }
        }

        private void GameForm_ClientSizeChanged(object sender, EventArgs e)
        {
            if (Field.Width > 0 && Field.Height > 0)
            {
                bitmap = new Bitmap(Field.Width, Field.Height);
                graphics = Graphics.FromImage(bitmap);
                DrawAll();
                UpdateStartMenu();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog svPicture = new SaveFileDialog())
            {
                svPicture.Filter = "PNG (*.png)|*.png|JPEG (*.jpeg)|*.jpeg|BMP (*.bmp)|*.bmp";
                if (svPicture.ShowDialog() == DialogResult.OK)
                {
                    string fileName = svPicture.FileName;
                    bitmap.Save(fileName);
                    MessageBox.Show("Saved!");
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainMenuButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Save your result?", "Attention", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                results += String.Format("{0}\t Level: {1}\t Solved himself: {2}\t Auto solve: {3}\n", name, level - 5, level - 5 - autoSolves, autoSolves);
            }
            else if (dr == DialogResult.Cancel) return;
            dr = MessageBox.Show("Are you want to exit to main menu?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                level = 6;
                Vertices.Clear();
                Edges.Clear();
                DrawAll();
                Text = "Untangle";
                StartButton.Show();
                ExitStartMenuButton.Show();
                RulesStartMenuButton.Show();
                TitleLabel.Show();
                TitleUnderLabel.Show();
                isPlay = false;
                isNewGame = true;
                MainMenuButton.Enabled = false;
            }        
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i].Location = SolvedVertices[i].Location;
            }

            for (int i = 0; i < Edges.Count; i++)
            {
                Edges[i].Location = SolvedEdges[i].Location;
            }

            DrawAll();
            autoSolves++;
            IsWin(sender, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1));
        }

        private void ExitStartMenuButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RulesStartMenuButton_Click(object sender, EventArgs e)
        {
            ShowRules();
        }

        private void RulesButton_Click(object sender, EventArgs e)
        {
            ShowRules();
        }

        private void AboutAppButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Untangle: The Puzzle Game\nCompilation date: 26.05.2018 22:55\nDevs: Zadvornov T., Vokhmyanin A., Vorobyov A.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region GRAPH ACTIONS

        /// <summary>
        /// Инициализация списка вершин
        /// </summary>
        private void InitializeVertices()
        {
            Vertices.Clear();   // очистка списка вершин
            Random random = new Random();
            verticesCount = level;   // рандомный выбор количества ребер
            generationsCount = random.Next(verticesCount + 1, verticesCount * verticesCount); // задание количества итераций для генерации рёбер

            double fi = 0;  // расстановка по кругу

            for (int i = 0; i < verticesCount; ++i) 
            {
                Vertices.Add(new Vertex(VertexDesign, new Point(Field.Width / 2 + (int)((Field.Width / 2 - indentFromSide) * Math.Cos(fi)), Field.Height / 2 + (int)((Field.Height / 2 - indentFromSide) * Math.Sin(fi)))));
                fi += 2 * Math.PI / verticesCount;
            }
        }

        /// <summary>
        /// Подсчет площади треугольника по трём точкам
        /// </summary>
        private int Area(Point a, Point b, Point c)
        {
            return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        }

        /// <summary>
        /// Пересекаются ли два ребра
        /// </summary>
        private bool AreCrossed(Point v11, Point v12, Point v21, Point v22)
        {
            double v1, v2, v3, v4;
            v1 = VectorMultiply(v22.X - v21.X, -(v22.Y - v21.Y), v11.X - v21.X, -(v11.Y - v21.Y));
            v2 = VectorMultiply(v22.X - v21.X, -(v22.Y - v21.Y), v12.X - v21.X, -(v12.Y - v21.Y));
            v3 = VectorMultiply(v12.X - v11.X, -(v12.Y - v11.Y), v21.X - v11.X, -(v21.Y - v11.Y));
            v4 = VectorMultiply(v12.X - v11.X, -(v12.Y - v11.Y), v22.X - v11.X, -(v22.Y - v11.Y));

            if (RealLess(v1 * v2, 0) && RealLess(v3 * v4, 0)) return true;
            else return false;
        }

        /// <summary>
        /// Правильное ли это ребро? (ни с кем не перескается и не записано в список рёбер)
        /// </summary>
        private bool IsRightEdge(Edge edge)
        {
            if (edge.Location.X != edge.Location.Y)
            {
                foreach (Edge currentEdge in Edges)
                    if (edge != currentEdge && AreCrossed(Vertices[edge.Location.X].Location, Vertices[edge.Location.Y].Location, Vertices[currentEdge.Location.X].Location, Vertices[currentEdge.Location.Y].Location))
                        return false;
                return true;
            }
            return false;
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs = new FileStream("result.txt", FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(results);
                sw.Close();
            }
        }

        /// <summary>
        /// Инициализация списка ребёр, соединение соседних вершин ребрами
        /// </summary>
        private void InitializeCircleEdges()
        {
            Edges.Clear();  // чистим список рёбер

            // мутим рёбра
            for (int i = 1; i < verticesCount; i++)
                Edges.Add(new Edge(RightEdgeDesign, new Point(i - 1, i)));

            Edges.Add(new Edge(RightEdgeDesign, new Point(verticesCount - 1, 0)));
        }

        /// <summary>
        /// Соединение рандомных вершин без пересечений
        /// </summary>
        private void InitializeRandomEdges()
        {
            Random random = new Random();
            for (int i = 0; i < generationsCount; i++)
            {
                Edge edge = new Edge(RightEdgeDesign, new Point(random.Next(0, verticesCount), random.Next(0, verticesCount)));

                if (!Edges.Contains(edge) && IsRightEdge(edge))
                    Edges.Add(edge);
            }
        }

        /// <summary>
        /// Если остались несоединенные возможные вершины, они соединятся с помощью этой функции
        /// </summary>
        private void InitializeRestEdges()
        {
            for (int i = 0; i < verticesCount; ++i)
            {
                for (int j = i + 1; j < verticesCount; ++j)
                {
                    Edge edge = new Edge(RightEdgeDesign, new Point(i, j));

                    if (!Edges.Contains(edge) && IsRightEdge(edge))
                    {
                        Edges.Add(edge);
                    }
                }
            }
        }

        /// <summary>
        /// Инициализация графа
        /// </summary>
        private void InitializeEdges()
        {
            InitializeCircleEdges();
            InitializeRandomEdges();
            InitializeRestEdges();
        }

        /// <summary>
        /// Раскидываем вершины рандомно
        /// </summary>
        private void RandomizeGraph()
        {
            Random random = new Random();
            for (int i = 0; i < randomIterations; ++i)
            {
                int first = random.Next(verticesCount), second = random.Next(verticesCount);
                Point point = Vertices[first].Location;
                Vertices[first].Location = Vertices[second].Location;   // swap
                Vertices[second].Location = point;
            }
        }
        
        /// <summary>
        /// Слишком много геометрии, сложна
        /// </summary>
        private bool IsPoint(Point sender, Point check)
        {
            return (sender.X - check.X) * (sender.X - check.X) + (sender.Y - check.Y) * (sender.Y - check.Y) <= VertexSize * VertexSize / 4;
        }

        /// <summary>
        /// Проверка, находится ли вершина на игровом поле
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private bool IsOnField(Point point)
        {
            return VertexSize / 2 <= point.X && point.X <= Field.Width - VertexSize / 2 && VertexSize / 2 <= point.Y && point.Y <= Field.Height - VertexSize / 2;
        }

        #endregion

        #region USER METHODS

        /// <summary>
        /// Обновление дизайна (цвета вершин, ребер, заднего плана и тд)
        /// </summary>
        private void UpdateAllDesign()
        { 
            isWin = true;

            graphics.Clear(GameFieldColor); // очистить игровое поле

            foreach (Edge edge in Edges)
            {
                if (IsRightEdge(edge))
                {
                    edge.Body = RightEdgeDesign;
                }          
                else 
                {
                    edge.Body = CrossEdgeDesign;
                    isWin = false; 
                }
            }
        }

        /// <summary>
        /// Нарисовать граф
        /// </summary>
        private void DrawAll()
        {
            UpdateAllDesign();
            foreach (Edge edge in Edges)
            {
                edge.Draw(graphics);
            }
            foreach (Vertex vertex in Vertices)
            {
                vertex.Draw(graphics);
            }
            Field.Image = bitmap;
        }

        /// <summary>
        /// Обновить начальное меню (при изменении размеров окна)
        /// </summary>
        private void UpdateStartMenu()
        {
            TitleLabel.Location = new Point(Width / 2 - 188, 75);
            TitleUnderLabel.Location = new Point(Width / 2, TitleLabel.Height + 60);
            StartButton.Location = new Point((Width / 2) - 120, Height / 2);
            RulesStartMenuButton.Location = new Point((Width / 2) - 120, Height / 2 + 99);
            ExitStartMenuButton.Location = new Point((Width / 2) - 120 + (StartButton.Width - ExitStartMenuButton.Width), (Height / 2) + 99);
        }

        /// <summary>
        /// Инициализация уровня
        /// </summary>
        private void StartLevel()
        {
            if (isNewGame)
            {
                while (name == "")
                {
                    Opacity = 0;
                    AuthForm form = new AuthForm();
                    DialogResult dr = form.ShowDialog();

                    if (dr == DialogResult.OK) break;
                    else
                    {
                        Opacity = 0.95;
                        return;
                    }
                }
            }
            Opacity = 0.95;

            isNewGame = false;
            TitleLabel.Hide();      // hide - скрыть
            TitleUnderLabel.Hide();
            StartButton.Hide();
            RulesStartMenuButton.Hide();
            ExitStartMenuButton.Hide();
            MainMenuButton.Enabled = true;

            InitializeVertices();
            InitializeEdges();

            SolvedVertices = new List<Vertex>();
            SolvedEdges = new List<Edge>();

            for (int i = 0; i < Vertices.Count; i++)
            {
                SolvedVertices.Add(new Vertex(VertexDesign, Vertices[i].Location));
            }

            for (int i = 0; i < Edges.Count; i++)
            {
                SolvedEdges.Add(new Edge(RightEdgeDesign, Edges[i].Location));
            }

            RandomizeGraph();
            isPlay = true;
            DrawAll();
            Text = String.Format("Untangle. Level: {0}", level - 5);    // подпись сверху
        }

        /// <summary>
        /// Если победил
        /// </summary>
        private void IsWin(object sender, MouseEventArgs e)
        {
            if (isPlay)
            {
                DialogResult dr = MessageBox.Show("You win!\nSave the graph picture?", "Congratz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    SaveButton_Click(sender, e);

                if (MessageBox.Show("Continue?", "Congratz", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    level++;
                    StartLevel();
                    isPlay = true;
                }
                else
                {
                    results += String.Format("{0}\t Level: {1}\t Solved himself: {2}\t Auto solve: {3}\n", name, level - 5, level - 5 - autoSolves, autoSolves);
                    level = 4;
                    Vertices.Clear();
                    Edges.Clear();
                    DrawAll();
                    Text = "Untangle";
                    StartButton.Show();
                    ExitStartMenuButton.Show();
                    RulesStartMenuButton.Show();
                    TitleLabel.Show();
                    TitleUnderLabel.Show();
                    isPlay = false;
                    MainMenuButton.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Произведение векторов
        /// </summary>
        private double VectorMultiply(double ax, double ay, double bx, double by)
        {
            return ax * by - bx * ay;
        }

        /// <summary>
        /// Сравнение двух double чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool RealLess(double a, double b)
        {
            double eps = 0.00001;
            return b - a > eps;
        }

        private void ShowRules()
        {
            MessageBox.Show("Дан плоский граф, у которого запутаны его вершины и рёбра. Требуется сделать так, чтобы рёбра не пересекались друг с другом. Чтобы распутать его требуется перемещать вершины по игровому полю. Если ребро подсвечивается красным цветом, значит оно пересекается с каким-то другим ребром. Если зелёным - ребро ни с кем не пересекается. С каждым уровнем граф увеличивает количество вершин (игра начинается с 4-6 вершин, выбирается случайно, далее 5-7 вершин и т.д.).", "Правила", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
