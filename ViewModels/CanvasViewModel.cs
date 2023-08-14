using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canvas.Models;

namespace Canvas.ViewModels
{
    public partial class CanvasViewModel : INotifyPropertyChanged
    {
        //    private Color toolColor = Colors.Black;
        //    private int toolWidth = 5;
        CanvasModel canvasModel;
        public event PropertyChangedEventHandler PropertyChanged;
        
        
        public CanvasViewModel() 
        {
            canvasModel = new CanvasModel();
        }

        public Color ToolColor
        {
            get => canvasModel.ToolColor;
            set
            {
                canvasModel.ToolColor = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(ToolColor)));
            }
        }
        public int ToolWidth
        {
            get => canvasModel.ToolWidth;
            set
            {
                canvasModel.ToolWidth = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(ToolWidth)));
            }
        }
    }
}
