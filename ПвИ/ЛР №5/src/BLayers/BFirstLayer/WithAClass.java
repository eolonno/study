package BLayers.BFirstLayer;

import FirstLayer.FirstLayerClass;

public class WithAClass {
    public static void CallFirstLayerClass(int number){
        new FirstLayerClass(number).PrintVariable();
    }
}
