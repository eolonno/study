package lab8.Exceptions;

public class ExceptionAAA3 extends Exception {
    @Override
    public String getMessage(){
        return "Parameter cannot be negative";
    }
}
