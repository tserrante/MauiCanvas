namespace Canvas.Views;

using Canvas.ViewModels;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

public partial class CanvasPage : ContentPage
{
	private CanvasViewModel viewModel;
	public CanvasPage()
	{
        InitializeComponent();
		
		viewModel = new CanvasViewModel();
		BindingContext = viewModel;
	}

	private void OnColorSelection(object sender, EventArgs e)
	{
		viewModel.ToolColor = Color.Parse((sender as Button).Text);
	}
	private async void OnSaveButtonPressed(object sender, EventArgs e) 
	{
		using var stream = await DrawingCanvas.GetImageStream(800, 800);
		using var memoryStream = new MemoryStream();
		stream.CopyTo(memoryStream);

		stream.Position = 0;
		memoryStream.Position = 0;

		
		string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		if(Directory.Exists(path))
		{
			await System.IO.File.WriteAllBytesAsync(string.Concat(path, @"\Test.png"), memoryStream.ToArray());
		}
	}

    private void ClearDrawingView_Clicked(object sender, EventArgs e)
    {
		DrawingCanvas.Lines.Clear();
    }
}

