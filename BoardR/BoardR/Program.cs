var item = new BoardItem("Rewrite everything", DateTime.Now.AddDays(1));

// compilation error if you uncomment the next line:
// item.title = "Rewrite everything immediately!!!";

item.Title = "Rewrite everything"; // property 'set'-ing
Console.WriteLine(item.Title); // property 'get'-ing

item.Title = "Huh?"; // Exception thrown: Please provide a title with length between 5 and 30 chars

Console.ReadLine(); // to pause console and not exit