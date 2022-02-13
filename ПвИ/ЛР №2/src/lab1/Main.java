package lab1;

public class Main {

    public static void main(String[] args) {
        // Task #1
        // 1.1
        int a1 = 10,
            b1 = 3,
            degree = 2;
        System.out.println("Task #1.1: " + (Math.pow(a1, degree) - Math.pow(b1, degree)));

        // 1.2
        float a2 = 15,
              b2 = 25;
        degree = 3;
        System.out.println("Task #1.2: " + (Math.pow(a2, degree) - Math.pow(b2, degree)));

        // 1.3
        double a3, b3;
        a3 = 12;
        b3 = 6;
        degree = 4;
        System.out.println("Task #1.3: " + (Math.pow(a3, degree) - Math.pow(b3, degree)));

        // Task #2
        // 2.1
        char a = 'a';
        char b = 'b';
        System.out.println("Task #2.1: " + (a + b));

        // 2.2
        System.out.println("Task #2.2: " + (a - b));
    }
}
