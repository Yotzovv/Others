namespace RookieTask.Client.Interfaces
{
    public interface ILogoController
    {
        string ConstructRow(int dashesRepetition, int middle, ref int starsCount, ref int dashesCount, int n, int a);
    }
}
