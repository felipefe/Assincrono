public class Program
{
    public static void Main(string[] args)
    {
        var tasks = new List<Task>();

        //Liga tudo
        var taskA = LigarTV();
        var taskB = PegarControles();
        tasks.Add(taskA);
        tasks.Add(taskB);
        LigarXbox();

        //Espera
        tasks.ForEach(tsk => {
            tsk.Wait();
        });
        
        Console.WriteLine("APARELHOS PRONTOS!");
        Console.WriteLine($"CONTROLES PRONTOS: {taskB.Result}!");
    }

    //public static async void LigarTV()
    public static async Task LigarTV()
    {
        await Task.Run(() =>
        {
            for (int i = 1; i <= 10; i++)
            {
                ;
                Console.WriteLine($"Ligando a TV {i}");
                Thread.Sleep(1000);
            }
            Console.WriteLine("** TV Ligada! **");
        });
    }

    public static async Task<int> PegarControles()
    {
        var controlesDisponiveis = 3;
        var controlesProntos = 0;
        await Task.Run(() =>
        {
            for (int i = 0; i < controlesDisponiveis; i++)
            {
                Console.WriteLine($"Controle {i} pronto");
                Thread.Sleep(6000);
                controlesProntos++;
            }
            Console.WriteLine("** Controles OK **");
        });
        return controlesProntos;
    }

    public static void LigarXbox()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Ligando XBox {i}");
            Thread.Sleep(1000);
        }
        Console.WriteLine("** XBox Ligado **");
    }

}