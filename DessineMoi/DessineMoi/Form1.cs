using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibDraw;

namespace DessineMoi
{
    enum TypeIDrawable
    {
        Rectangle,
        Carre,
        Circle,
        Image,
        Complexshape
    }

    public partial class Form1 : Form
    {
        Point LocUp, LocDown;
        Graphics graph;
        Point TopLeft, TopRight, BottomLeft, BottomRight;
        List<IDrawable> ActiveShapes;
        List<ComplexShape> ComplexShapesList;

        Color ActColor
        {
            get { return colorDialog1.Color; }
        }

        bool FilledStatus
        {
            get { return checkBox1.Checked; }
        }

        string FileName
        {
            get { return openFileDialog1.FileName; }
        }

        public Form1()
        {
            InitializeComponent();

            comboBoxSelectShape.DataSource = Enum.GetValues(typeof(TypeIDrawable));
            comboBoxSelectShape.SelectedIndex = 0;

            ActiveShapes = new List<IDrawable>();
            bindingSourceActShapes.DataSource = ActiveShapes;
            comboBoxActiveShapes.DataSource = bindingSourceActShapes;

            ComplexShapesList = new List<ComplexShape>();
            bindingSourceComplexShapeList.DataSource = ComplexShapesList;
            comboBoxActiveCplxShapes.DataSource = bindingSourceComplexShapeList;

            graph = pictureBox1.CreateGraphics();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            LocDown = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            LocUp = e.Location;
            CheckCoordinates(LocUp, LocDown);
            IDrawable temp;
            switch (comboBoxSelectShape.SelectedItem.ToString())
            {
                case "Rectangle":
                    temp = new Rect(TopLeft, FilledStatus, ActColor, BottomRight.X - TopLeft.X, BottomRight.Y - TopLeft.Y);
                    temp.Draw(graph);
                    bindingSourceActShapes.Add(temp);
                    break;
                case "Carre":
                    temp = new Square(TopLeft, FilledStatus, ActColor, BottomRight.X - TopLeft.X);
                    temp.Draw(graph);
                    bindingSourceActShapes.Add(temp);
                    break;
                case "Circle":
                    temp = new Circle(TopLeft, FilledStatus, ActColor, BottomRight.X - TopLeft.X);
                    temp.Draw(graph);
                    bindingSourceActShapes.Add(temp);
                    break;
                case "Image":
                    if (FileName != "openFileDialog1")
                    {
                        temp = new MyImage(TopLeft, FileName);
                        temp.Draw(graph);
                        bindingSourceActShapes.Add(temp);
                    }
                    break;
                case "Complexshape":
                    ComplexShapesList.ElementAt(bindingSourceComplexShapeList.Position).TopLeft = TopLeft;
                    ComplexShapesList.ElementAt(bindingSourceComplexShapeList.Position).Draw(graph);
                    break;
            }
            
        }

        private void CheckCoordinates(Point A, Point B)
        {
            TopLeft = new Point(Math.Min(A.X, B.X), Math.Min(A.Y, B.Y));
            TopRight = new Point(Math.Max(A.X, B.X), Math.Min(A.Y, B.Y));
            BottomLeft = new Point(Math.Min(A.X, B.X), Math.Max(A.Y, B.Y));
            BottomRight = new Point(Math.Max(A.X, B.X), Math.Max(A.Y, B.Y));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            bindingSourceActShapes.Clear();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void buttonCreateCplxShape_Click(object sender, EventArgs e)
        {
            bindingSourceComplexShapeList.Add(new ComplexShape());
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ComplexShapesList.ElementAt(bindingSourceComplexShapeList.Position).ShapeList.Add(ActiveShapes.ElementAt(bindingSourceActShapes.Position));
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            bindingSourceComplexShapeList.RemoveCurrent();
        }
    }
}
