using RealStateRentSystem;
using System.Collections.Generic;

public static class RealStateIdScope
{
    private static Stack<int> idStack = new Stack<int>();

    public static void PushCurrentId()
    {
        idStack.Push(Utils.realstateid);
    }

    public static void PopId()
    {
        if (idStack.Count > 0)
        {
            idStack.Pop();
            Utils.realstateid = idStack.Peek();
        }
    }
}