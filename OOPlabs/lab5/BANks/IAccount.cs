namespace BANks
{
    public interface IAccount
    {
        Trancation withdrawals(Person person, double sum);
        Trancation refill(double sum);
        Trancation transfer(Person person, double sum, int AccountID);
    }
}