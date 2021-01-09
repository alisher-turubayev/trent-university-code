package sample;

import javafx.scene.Scene;
import javafx.scene.control.TextField;

class Calculator {
    static void Add (Scene scene, int numberOne, int numberTwo) {
        int result = numberOne + numberTwo;
        TextField fldExpression = (TextField)scene.lookup("#fldExpression");

        fldExpression.setText(Integer.toString(result));
    }

    static void Subtract (Scene scene, int numberOne, int numberTwo) {
        int result = numberOne - numberTwo;
        TextField fldExpression = (TextField)scene.lookup("#fldExpression");

        fldExpression.setText(Integer.toString(result));
    }

    static void Multiply (Scene scene, int numberOne, int numberTwo) {
        int result = numberOne * numberTwo;
        TextField fldExpression = (TextField)scene.lookup("#fldExpression");

        fldExpression.setText(Integer.toString(result));
    }

    static void Divide (Scene scene, int numberOne, int numberTwo) {
        int result;
        if (numberTwo != 0)
            result = numberOne / numberTwo;
        else
            result = 0;

        TextField fldExpression = (TextField) scene.lookup("#fldExpression");
        fldExpression.setText(Integer.toString(result));
    }
}
