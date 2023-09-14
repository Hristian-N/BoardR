using System.ComponentModel;

static class Board
{
    public static List<BoardItem> items = new List<BoardItem>();

    public static void Add(BoardItem item)
    {
        items.Add(item);
    }
}