var tomorrow = DateTime.Now.AddDays(1);
var issue = new Issue("App flow tests?", "We need to test the App!", tomorrow);
var task = new Task("Test the application flow", "Peter", tomorrow);

Board.AddItem(issue);
Board.AddItem(task);
Console.WriteLine(Board.TotalItems); // 2