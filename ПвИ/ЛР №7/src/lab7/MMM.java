package lab7;

import lab7.FirstLayer.AAA;
import lab7.FirstLayer.FirstLayerClass;
import lab7.FirstLayer.SecondLayer.SecondLayerClass;
import lab7.FirstLayer.SecondLayer.ThirdLayer.FourthLayer.FourthLayerClass;
import lab7.FirstLayer.SecondLayer.ThirdLayer.ThirdLayerClass;

public class MMM {
    public static void main(String[] args){
        new FirstLayerClass();
        new SecondLayerClass();
        new ThirdLayerClass();
        new FourthLayerClass();
        new AAA().printMessage("Hello World!");
    }
}