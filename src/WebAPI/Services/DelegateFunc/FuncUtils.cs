namespace DemoWebAPI.Services.DelegateFunc;

public delegate int SumFunc(int x, int y);

public class FuncUtils
{
    public static int SumFunc(int x, int y)
        => x + y;
}
