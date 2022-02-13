package lab8;

import lab8.Classes.AAA;

public class Main {

    public static void main(String[] args) {
        try{
            System.out.print("Correct one: ");
            var x = new AAA(10);
            System.out.println(x.methode(10));
        }catch (Exception e){
            System.out.println(e);
            System.out.println("Message: " + e.getMessage());
            e.printStackTrace();
        }

        try{
            System.out.print("Should throw ExceptionAAA1: ");
            var x = new AAA(null);
            System.out.println(x.methode(10));
        }catch (Exception e){
            System.out.println(e.toString());
            System.out.println("Message: " + e.getMessage());
            e.printStackTrace();
        }

        try{
            System.out.print("Should throw ExceptionAAA2: ");
            var x = new AAA(10);
            System.out.println(x.methode(0));
        }catch (Exception e){
            System.out.println(e.toString());
            System.out.println("Message: " + e.getMessage());
            e.printStackTrace();
        }

        try{
            System.out.print("Should throw ExceptionAAA3: ");
            var x = new AAA(10);
            System.out.println(x.methode(-2));
        }catch (Exception e){
            System.out.println(e.toString());
            System.out.println("Message: " + e.getMessage());
            e.printStackTrace();
        }
        System.out.println("All was caught");
    }
}
