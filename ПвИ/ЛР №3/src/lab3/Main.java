package lab3;

public class Main {

    public static void main(String[] args)
    {
        //Task1();
        //Task2();
        //Task3();
        //Task4();

        JustStaticClass.Task5and6();
        System.out.println(JustStaticClass.SomeVariable);
    }

    private static void Task1()
    {
        // 1. Объяснить пример:
        int[] xx = new int[10];
        for (int i = 0; i< xx.length; i++)
        {
            xx[i] = i;
        }
        for(int i = 0; i < xx.length; i++)
        {
            System.out.println(xx[i]);
        }
    }

    private static void Task2()
    {
        // Объяснить пример
        int[][] xx = new int[5][5];
        for(int i = 0; i < xx.length; i++)
        {
            for(int j = 0; j < xx[i].length; j++)
            {
                xx[i][j] = i + j;
            }
        }

        for (int[] ints : xx) {
            for (int anInt : ints) {
                System.out.print(anInt);
            }
        }
    }

    private static void Task3()
    {
        System.out.println("256 >>> 8 = " + (256 >>> 8));

        int num = 1;
        num <<= 8;
        System.out.println("1 << 8 = " + num);

        num ^= 256;
        System.out.println("256 ^ 256 = " + num);

        System.out.println("14 & 6 = " + (14 & 6));

        System.out.println("~1 = " + ~1);
    }

    private static void Task4()
    {
        boolean or = true || false;
        boolean and = true && false;
        if(and == or ? true : false)
            System.out.println("Hello WOrld!");
        if(and == true)
            System.out.println("And = true");
        else if(or == true)
            System.out.println("Or = true");
        else
            System.out.println("And and or is not true");
    }
}
