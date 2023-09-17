using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

static class Board
{
    static List<BoardItem> items = new List<BoardItem>();
    static int totalItems = 0;

    public static List<BoardItem> Items
    {
        get;
        set;
    }

    public static void AddItem(BoardItem item)
    {
        if (!items.Contains(item))
        {
            totalItems++;
            items.Add(item);
        }
        else
            throw new InvalidOperationException("item already exists");
    }

    public static int TotalItems
    {
        get
        {
            return totalItems;
        }
    }
}