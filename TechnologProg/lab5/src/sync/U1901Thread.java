package sync;

public class U1901Thread extends Thread
{
    U1901Bank bankWork;
    int intTrans;
    long lngSleep;
    public U1901Thread(U1901Bank bank, int trans, long sleep)
    {
        this.bankWork = bank;
        this.intTrans = trans;
        this.lngSleep = sleep;
    }
    public void run()
    {
        bankWork.calc(intTrans, lngSleep);
    }
}
