package lab8.Classes;

import lab8.Exceptions.*;

public class AAA {
    public AAA(Integer x) throws ExceptionAAA1 {
        if(x == null)
            throw new ExceptionAAA1();
    }

    public int methode(int x) throws ExceptionAAA2, ExceptionAAA3 {
        if(x == 0)
            throw new ExceptionAAA2();
        else if(x < 0)
            throw new ExceptionAAA3();

        return x;
    }
}
