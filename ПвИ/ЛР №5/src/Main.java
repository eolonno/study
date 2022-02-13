// Task #1
//public class Main {
//
//    public static void main(String[] args) {
//        FirstLayer.FirstLayerClass l1 = new FirstLayer.FirstLayerClass(1);
//        FirstLayer.SecondLayer.SecondLayerClass1 l2c1 = new FirstLayer.SecondLayer.SecondLayerClass1(2);
//        FirstLayer.SecondLayer.SecondLayerClass2 l2c2 = new FirstLayer.SecondLayer.SecondLayerClass2(3);
//        FirstLayer.SecondLayer.ThirdLayer.FourthLayer.FourthClass1 l4c1 = new FirstLayer.SecondLayer.ThirdLayer.FourthLayer.FourthClass1(4);
//        FirstLayer.SecondLayer.ThirdLayer.FourthLayer.FourthClass2 l4c2 = new FirstLayer.SecondLayer.ThirdLayer.FourthLayer.FourthClass2(5);
//
//        l1.PrintVariable();
//        l2c1.PrintVariable();
//        l2c2.PrintVariable();
//        l4c1.PrintVariable();
//        l4c2.PrintVariable();
//    }
//}


// Task #2
//import FirstLayer.SecondLayer.ThirdLayer.FourthLayer.*;
//public class Main {
//
//    public static void main(String[] args) {
//        FirstLayer.FirstLayerClass l1 = new FirstLayer.FirstLayerClass(1);
//        FirstLayer.SecondLayer.SecondLayerClass1 l2c1 = new FirstLayer.SecondLayer.SecondLayerClass1(2);
//        FirstLayer.SecondLayer.SecondLayerClass2 l2c2 = new FirstLayer.SecondLayer.SecondLayerClass2(3);
//        FourthClass1 l4c1 = new FirstLayer.SecondLayer.ThirdLayer.FourthLayer.FourthClass1(4);
//        FourthClass2 l4c2 = new FirstLayer.SecondLayer.ThirdLayer.FourthLayer.FourthClass2(5);
//
//        l1.PrintVariable();
//        l2c1.PrintVariable();
//        l2c2.PrintVariable();
//        l4c1.PrintVariable();
//        l4c2.PrintVariable();
//    }
//}

// Task #3
//import FirstLayer.*;
//public class Main {
//
//    public static void main(String[] args) {
//        FirstLayerClass l1 = new FirstLayerClass(1);
//        FirstLayer.SecondLayer.SecondLayerClass1 l2c1 = new FirstLayer.SecondLayer.SecondLayerClass1(2);
//        FirstLayer.SecondLayer.SecondLayerClass2 l2c2 = new FirstLayer.SecondLayer.SecondLayerClass2(3);
//        FirstLayer.SecondLayer.ThirdLayer.FourthLayer.FourthClass1 l4c1 = new FirstLayer.SecondLayer.ThirdLayer.FourthLayer.FourthClass1(4);
//        FirstLayer.SecondLayer.ThirdLayer.FourthLayer.FourthClass2 l4c2 = new FirstLayer.SecondLayer.ThirdLayer.FourthLayer.FourthClass2(5);
//
//        l1.PrintVariable();
//        l2c1.PrintVariable();
//        l2c2.PrintVariable();
//        l4c1.PrintVariable();
//        l4c2.PrintVariable();
//    }
//}

// Task #4
//import FirstLayer.*;
//import FirstLayer.SecondLayer.*;
//import FirstLayer.SecondLayer.ThirdLayer.FourthLayer.*;
//public class Main {
//
//    public static void main(String[] args) {
//        FirstLayerClass l1 = new FirstLayerClass(1);
//        SecondLayerClass1 l2c1 = new SecondLayerClass1(2);
//        SecondLayerClass2 l2c2 = new SecondLayerClass2(3);
//        FourthClass1 l4c1 = new FourthClass1(4);
//        FourthClass2 l4c2 = new FourthClass2(5);
//
//        l1.PrintVariable();
//        l2c1.PrintVariable();
//        l2c2.PrintVariable();
//        l4c1.PrintVariable();
//        l4c2.PrintVariable();
//    }
//}

// Task #5
import BLayers.BFirstLayer.*;
import BLayers.BFirstLayer.BSecondLayer.*;
import BLayers.BFirstLayer.BSecondLayer.BThirdLayer.BFourthLayer.*;
import FirstLayer.*;
import FirstLayer.SecondLayer.*;
import FirstLayer.SecondLayer.ThirdLayer.FourthLayer.*;
public class Main {

    public static void main(String[] args) {
        FirstLayerClass l1 = new FirstLayerClass(1);
        SecondLayerClass1 l2c1 = new SecondLayerClass1(2);
        SecondLayerClass2 l2c2 = new SecondLayerClass2(3);
        FourthClass1 l4c1 = new FourthClass1(4);
        FourthClass2 l4c2 = new FourthClass2(5);

        var bl1 = new BFirstLayerClass(1);
        var bl2c1 = new BSecondLayerClass1(2);
        var bl2c2 = new BSecondLayerClass2(3);
        var bl4c1 = new BFourthClass1(4);
        var bl4c2 = new BFourthClass2(5);

        l1.PrintVariable();
        l2c1.PrintVariable();
        l2c2.PrintVariable();
        l4c1.PrintVariable();
        l4c2.PrintVariable();

        System.out.println();

        bl1.PrintVariable();
        bl2c1.PrintVariable();
        bl2c2.PrintVariable();
        bl4c1.PrintVariable();
        bl4c2.PrintVariable();
        System.out.println();

        // Task 6
        WithAClass.CallFirstLayerClass(12);
        System.out.println();

        // Task 7
        new ExtendsBClass(9).PrintVariable();
    }
}