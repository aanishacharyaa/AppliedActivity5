using SQLite;

public class Student
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Course
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Instructor { get; set; }
}