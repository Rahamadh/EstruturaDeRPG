public static class Dado
{
    private static Random random = new Random();

    public static int RolarDado (int qnt, int face)
    {   int total = 0;
        for(int i = 0; i< qnt; i++)
        {
            total += random.Next(1,face +1);
            
        }
        return total;
    }
}