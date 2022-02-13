package lab3;

public class JustStaticClass {
    public static int SomeVariable = 5;
    public static void Task5and6()
    {
        // if
        if(SomeVariable > 0)
            System.out.println("SomeVariable is positive");
        else
            System.out.println("SomeVariable is negative or 0");

        // for
        String someString = "Hello, World!";
        for(int i = 0; i < someString.length(); i++)
        {
            System.out.print(someString.charAt(i) + ' ');
        }
        System.out.println();

        // while
        int iterationsCount = SomeVariable;
        while(--iterationsCount != 0)
        {
            System.out.print(iterationsCount + ' ');
        }
        System.out.println();

        // do while
        do {
            System.out.print(iterationsCount + ' ');
        } while (++iterationsCount != SomeVariable);
        System.out.println();

        // switch
        switch (SomeVariable)
        {
            case 5: System.out.println("SomeVariable is equal to 5"); break;
            default: System.out.println("SomeVariable is not equal to 5"); break;
        }
    }
}
