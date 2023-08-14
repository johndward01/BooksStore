using Microsoft.JSInterop;

namespace BooksStore;

public class JsSample
{
    [JSInvokable("AddTwoNumbers")]
    public static int Sum(int firstNumber, int secondNumber)
    {
        return firstNumber + secondNumber;
    }
}
