using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Day10MonitoringStation;
using Day11SpacePolice.Day11SpacePolice;

namespace Day11SpacePolice
{
    internal class Panels
    {
        private readonly List<Panel> _panels = new List<Panel>();
        private Panel _currentPanel = new Panel(0, 0);
        private Direction _currentDirection = Direction.Up;

        private readonly Dictionary<Direction, Panel> _deltaPanel = new Dictionary<Direction, Panel>
        {
            {Direction.Up, new Panel(-1, 0)},
            {Direction.Right, new Panel(0, 1)},
            {Direction.Down, new Panel(+1, 0)},
            {Direction.Left, new Panel(0, -1)}
        };

        public void PaintAndMove(Color color, TurningDirection turningDirection)
        {
            PaintPanel(color);
            MoveRobot(turningDirection);
        }

        private void PaintPanel(Color color)
        {
            var existingPanel = _panels.FirstOrDefault(c => c.X == _currentPanel.X && c.Y == _currentPanel.Y);
            if (existingPanel == null)
            {
                _panels.Add(new Panel(_currentPanel.X, _currentPanel.Y, color));
            }
            else
            {
                if (existingPanel.Color != color)
                {
                    _panels.Remove(existingPanel);
                    _panels.Add(new Panel(_currentPanel.X, _currentPanel.Y, color));
                }
            }
        }

        private void MoveRobot(TurningDirection turningDirection)
        {
            switch (turningDirection)
            {
                case TurningDirection.Left:
                    _currentDirection = _currentDirection.Previous();
                    break;
                case TurningDirection.Right:
                    _currentDirection = _currentDirection.Next();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(turningDirection), turningDirection, null);
            }

            var deltaPanel = _deltaPanel[_currentDirection];
            _currentPanel = new Panel(_currentPanel.X + deltaPanel.X, _currentPanel.Y + deltaPanel.Y);
            var existingCurrentPanel = _panels.FirstOrDefault(p => p.X == _currentPanel.X && p.Y == _currentPanel.Y);
            if (existingCurrentPanel != null)
                _currentPanel = existingCurrentPanel;
        }

        public int NumberOfPanels => _panels.Count;

        public Color GetCurrentPanelColor() => _currentPanel.Color;

        public string Display()
        {
            int maxX = Math.Abs(_panels.WithMaximum(p => Math.Abs(p.X)).X);

            int maxY = Math.Abs(_panels.WithMaximum(p => Math.Abs(p.Y)).Y);

            StringBuilder result = new StringBuilder();

            for (int i = -maxX; i <= maxX; i++)
            {
                for (int j = -maxY; j <= maxY; j++)
                {
                    var paintedPanel = _panels.FirstOrDefault(p => p.X == i && p.Y == j);
                    if (paintedPanel != null)
                        result.Append(paintedPanel.Color == Color.White ? '#' : ' ');
                    else
                    {
                        result.Append(' ');
                    }
                }

                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}