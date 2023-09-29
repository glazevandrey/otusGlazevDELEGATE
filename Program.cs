namespace otusGlazevDELEGATE
{
    public static class Program
    {
        static void Main(string[] args)
        {

            // пункт 1 ДЗ
            FirstIssue.Work();

            //след пункты ДЗ
            var token = new CancellationTokenSource();
            

            // имитация отмены поиска токеном
            Task.Run(() => { Thread.Sleep(2000); token.Cancel(); });

            OtherIssues.Work(token.Token);
        }
      
    }
}