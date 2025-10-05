using RealStateRentSystem;
using System.Collections.Generic;

public static class RealStateIdOwnerScope
{
    private static Stack<int> idStack = new Stack<int>();

    public static void PushCurrentId()
    {
        idStack.Push(Utils.realstateidowner);
    }

    public static void PopId()
    {
        if (idStack.Count > 0)
        {
            Utils.realstateidowner = idStack.Pop();
        }
    }
}

public static class CareerIDScope
{
    private static Stack<int> idStack = new Stack<int>();

    public static void PushCurrentId()
    {
        idStack.Push(Utils.CareerID);
    }

    public static void PopId()
    {
        if (idStack.Count > 0)
        {
            Utils.CareerID = idStack.Pop();
        }
    }
}

public static class PhoneIDScope
{
    private static Stack<int> idStack = new Stack<int>();

    public static void PushCurrentId()
    {
        idStack.Push(Utils.PhoneID);
    }

    public static void PopId()
    {
        if (idStack.Count > 0)
        {
            Utils.PhoneID = idStack.Pop();
        }
    }
}