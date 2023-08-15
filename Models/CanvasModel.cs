using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.Models
{
    internal class CanvasModel
    {
        public string ToolType { get; set; } = string.Empty;
        public Color ToolColor { get; set; } = Colors.Black;
        public int ToolWidth { get; set; } = 5;
        public CanvasModel() { }
    }
}
