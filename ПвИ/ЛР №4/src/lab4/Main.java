package lab4;

public class Main {

    public static void main(String[] args) {
        // Task #1
        CCC CCCWithoutParameters = new CCC();
        CCC CCCWithParameters = new CCC(10, 5);

        System.out.println("CCC:");
        System.out.println("sum(): " + CCCWithParameters.sum());
        System.out.println("ssub(12, 2): " + CCC.ssub(12, 2));

        // Task #2
        DDD DDDWithParameters = new DDD(1, 3);
        DDD DDDWithoutParameters = new DDD();

        System.out.println("\nDDD:");
        System.out.println("sum(): " + DDDWithParameters.sum());
        System.out.println("ssub(12, 2): " + CCC.ssub(12, 2));
        System.out.println("calc(): " + DDDWithParameters.calc());
    }
}
