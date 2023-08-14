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
	private async void OnSaveImagePressed(object sender, EventArgs e) 
	{
		//if(DrawingCanvas.has)
		using var stream = await DrawingCanvas.GetImageStream(800, 800);
		//DrawingCanvas.GetImageStream(DrawingCanvas.Lines, new Size(800, 800), DrawingCanvas.BackgroundColor);
		using var memoryStream = new MemoryStream();
		stream.CopyTo(memoryStream);

		stream.Position = 0;
		memoryStream.Position = 0;

#if WINDOWS

		//string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"Maui-Paint");
		string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		if(Directory.Exists(path))
		{
			await System.IO.File.WriteAllBytesAsync(string.Concat(path, @"\Test.png"), memoryStream.ToArray());
		}

#elif ANDROID

#elif IOS || MACCATALYST

#endif

	}
}

