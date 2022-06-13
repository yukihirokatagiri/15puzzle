namespace _15puzzle;

public partial class MainPage : ContentPage
{
    static int CELL_HEIGHT = 100;
    static int CELL_WIDTH = 100;
    static int BOARD_SIZE = 4;
    static int CELL_COUNT = BOARD_SIZE * BOARD_SIZE;
    static int MARGIN = 10;

	public MainPage()
	{
		InitializeComponent();

        var rowDefinition = new RowDefinition() { Height = new GridLength(CELL_HEIGHT) };
        var colDefinition = new ColumnDefinition() { Width = new GridLength(CELL_WIDTH) };

        Grid grid = new Grid();
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            grid.AddRowDefinition(rowDefinition);
            grid.AddColumnDefinition(colDefinition);
        }

        grid.Padding = new Thickness(10);

        for (int i = 0; i < CELL_COUNT; i++)
        {
            int row = i / BOARD_SIZE;
            int col = i % BOARD_SIZE;
            grid.Add(new BoxView
            {
                Color = Colors.LightGreen,
                Margin = new Thickness(MARGIN), 
            }, col, row);
        }

        // Add a row for the button.
        grid.AddRowDefinition(rowDefinition);
        Button button = new Button
        {
            Text = "a",
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
        };
        button.Clicked += (sender, args) => Console.WriteLine("Clicked");
        grid.Add(button, 0, 4);

        Title = "15 PUZZLE";
        Content = grid;
    }
}

