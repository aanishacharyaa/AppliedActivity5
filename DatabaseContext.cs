using SQLite;

public class DatabaseContext
{
    readonly SQLiteAsyncConnection _database;

    public DatabaseContext(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);

        // Delete existing data
          _database.DropTableAsync<Student>();
          _database.DropTableAsync<Course>();


        _database.CreateTableAsync<Student>().Wait();
        _database.CreateTableAsync<Course>().Wait();
    }

    public SQLiteAsyncConnection GetDatabaseConnection()
    {
        return _database;
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _database.Table<Student>().ToListAsync();
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        return await _database.Table<Course>().ToListAsync();
    }

    public async Task InitializeSampleData()
    {
        var students = new List<Student>
        {
            new Student { Name = "Alice", Age = 20 },
            new Student { Name = "Bob", Age = 22 },
            new Student { Name = "Carol", Age = 21 }
        };

        var courses = new List<Course>
        {
            new Course { Title = "Mathematics", Instructor = "Dr. Smith" },
            new Course { Title = "Physics", Instructor = "Prof. Johnson" },
            new Course { Title = "History", Instructor = "Ms. Brown" }
        };

        foreach (var student in students)
        {
            await _database.InsertAsync(student);
        }

        foreach (var course in courses)
        {
            await _database.InsertAsync(course);
        }
    }
}
