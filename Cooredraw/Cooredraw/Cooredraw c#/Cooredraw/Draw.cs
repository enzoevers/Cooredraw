using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Cooredraw
{
    class Draw
    {
        static Bitmap _bmp;
        public static Bitmap bmp { get { return _bmp; } set { _bmp = value; } }


        static Coordinate _coordinate;
        static List<Coordinate> _pointsList = new List<Coordinate>();
        public static List<Coordinate> PointsList { get { return _pointsList; } }
        
                
        static pointsToDraw _thingsToDraw;
        static List<pointsToDraw> _pointsToDrawList = new List<pointsToDraw>();
        public static List<pointsToDraw> PointsToDrawList { get { return _pointsToDrawList; } set { _pointsToDrawList = value; } }



        static List<Point> _points = new List<Point>();
        public static List<Point> Points { get { return _points; } set { _points = value; } }


        static Pen pen;

        

        public static void drawPoint(Color backColor, Brush fontColor, int fontThickness, int X, int Y, Graphics g, string whatToDraw)
        {
            //Graphics g = Graphics.FromImage(_bmp);
            
            //g.CompositingQuality = CompositingQuality.HighQuality;
            pen = new Pen(fontColor, fontThickness);

            addPointToList(pen, X, Y);

            using (g)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                if (whatToDraw == pencil.Dot.ToString())
                {
                    drawDots(fontColor, fontThickness, X, Y, g);
                }
                else if (whatToDraw == pencil.Polygon.ToString())
                {
                    drawPolygon(g);
                }
                else if (whatToDraw == pencil.Line.ToString())
                {
                    drawLines(g);
                }
                else if (whatToDraw == pencil.Bezier.ToString())
                {
                    drawBezier(g);
                }
                else if (whatToDraw == pencil.Beziers.ToString())
                {
                    drawBeziers(g);
                }
                else if (whatToDraw == pencil.Curve.ToString())
                {
                    drawCurve(pen, g);
                }
            }
        }

        static void addPointToList(Pen pen, int X, int Y)
        {
            if (_pointsToDrawList.Count() > 0)
            {
                if (_pointsToDrawList[_pointsToDrawList.Count() - 1].PointValue.X != X || _pointsToDrawList[_pointsToDrawList.Count() - 1].PointValue.Y != Y)
                {
                    _thingsToDraw = new Draw.pointsToDraw(new Point(X, Y), pen);
                    _pointsToDrawList.Add(_thingsToDraw);
                    _points.Add(new Point(X, Y));
                }
            }
        }

        static void drawDots(Brush fontColor, int fontThickness, int X, int Y, Graphics g)
        {
            _coordinate = new Coordinate(X, Y, fontColor, fontThickness);
            _pointsList.Add(_coordinate);

            foreach (Coordinate c in _pointsList)
            {
                g.FillEllipse(c.FontCollor, c.X, c.Y, c.FontThickness, c.FontThickness);
            }
        }

        static void drawPolygon(Graphics g)
        {
            Point[] pointsToDraw = _points.ToArray<Point>();

            if (_points.Count() > 2)
            {
                g.DrawPolygon(pen, pointsToDraw);
            }
        }

        static void drawLines(Graphics g)
        {
            if (_pointsToDrawList.Count() > 2)
            {
                for (int i = 0; i < _pointsToDrawList.Count()-2; i++)
                {
                    g.DrawLine(_pointsToDrawList[i].Font, _pointsToDrawList[i].PointValue, _pointsToDrawList[i + 1].PointValue);
                } 
            }
        }


        static void drawBezier(Graphics g)
        {
            if (_pointsToDrawList.Count() > 4)
            {
                for (int i = 0; i < _pointsToDrawList.Count() - 4; i += 3)
                {
                    g.DrawBezier(_pointsToDrawList[i].Font, _pointsToDrawList[i].PointValue, _pointsToDrawList[i+1].PointValue, _pointsToDrawList[i + 2].PointValue, _pointsToDrawList[i + 3].PointValue);
                }               
            }
        }

        static void drawBeziers(Graphics g)
        {
            if (_points.Count() > 6)
            {
                Point[] pointsToDraw = { _pointsToDrawList[_pointsToDrawList.Count - 7].PointValue,
                    _pointsToDrawList[_pointsToDrawList.Count - 6].PointValue,
                    _pointsToDrawList[_pointsToDrawList.Count - 5].PointValue,
                    _pointsToDrawList[_pointsToDrawList.Count - 4].PointValue,
                    _pointsToDrawList[_pointsToDrawList.Count - 3].PointValue,
                    _pointsToDrawList[_pointsToDrawList.Count - 2].PointValue,
                    _pointsToDrawList[_pointsToDrawList.Count - 1].PointValue};
                g.DrawBeziers(pen, pointsToDraw);
            }
        }

        static void drawCurve(Pen pen, Graphics g)
       {
            foreach(var i in _pointsToDrawList)
            {
                _points.Add(i.PointValue);
            }

            Point[] pointsArray = _points.ToArray<Point>();

            if (_points.Count() > 2)
            {
                g.DrawCurve(pen, pointsArray);
            }
        }


        public class Coordinate
        {
            int _x;
            public int X { get { return _x; } }

            int _y;
            public int Y { get { return _y; } }

            Brush _fontCollor;
            public Brush FontCollor { get { return _fontCollor; } }

            int _fontThickness;
            public int FontThickness { get { return _fontThickness; } }


            public Coordinate(int X, int Y, Brush FontColor, int FontThickness)
            {
                _x = X;
                _y = Y;
                _fontCollor = FontColor;
                _fontThickness = FontThickness;
            }
        }

        public class pointsToDraw
        {
            Point _pointValue;
            public Point PointValue { get { return _pointValue; } }

            Pen _font;
            public Pen Font { get { return _font; } }


            public pointsToDraw(Point point, Pen pen)
            {
                _pointValue = point;
                _font = pen;
            }
        }
    }
}
