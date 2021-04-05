package sync;

public class U1901Bank
{
    int intTo;
    int intFrom = 220;
    public synchronized void calc(int intTransaction, long lngTimeout)
    {
        System.out.println("Before" + " " + intTo + " " + intFrom + " " + Thread.currentThread().getName());
        intFrom -=intTransaction;
        try {
            Thread.sleep(lngTimeout);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        intTo += intTransaction;
        System.out.println("After" + " " + intTo + " " + intFrom + " " + Thread.currentThread().getName());
    }
}
