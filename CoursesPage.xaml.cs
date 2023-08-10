namespace AppliedActivity5;

public partial class CoursesPage : ContentPage
{
	public CoursesPage()
	{
		InitializeComponent();
        LoadCourses();
    }

    private async void LoadCourses()
    {
        try
        {
            var courses = await App.DatabaseContext.GetDatabaseConnection().Table<Course>().ToListAsync();
            CoursesListView.ItemsSource = courses;
        }
        catch (Exception ex)
        {
            // Handle error
        }
    }
}