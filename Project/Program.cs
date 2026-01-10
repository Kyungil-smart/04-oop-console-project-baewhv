// See https://aka.ms/new-console-template for more information


using System.Text;
using Project;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;
        
        GameManager GM = new GameManager();
        GM.Run();
        
    }
}