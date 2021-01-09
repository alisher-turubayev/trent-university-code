package sample;

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

public class Main extends Application {
    private TextField fldExpression;
    private boolean isSecond;
    private boolean toClear;
    private int operationCode;
    private int numberOne;
    private Scene scene;

    private void handleNumberButton (ActionEvent event) {
        Button btnCurrent = (Button)event.getSource();
        if (toClear) {
            fldExpression.clear();
            toClear = false;
        }
        fldExpression.appendText(btnCurrent.getText());
    }

    private void applyOperation () throws Exception {
        switch (operationCode) {
            case 1:
                Calculator.Add(scene, numberOne, Integer.parseInt(fldExpression.getText()));
                break;
            case 2:
                Calculator.Subtract(scene, numberOne, Integer.parseInt(fldExpression.getText()));
                break;
            case 3:
                Calculator.Multiply(scene, numberOne, Integer.parseInt(fldExpression.getText()));
                break;
            case 4:
                Calculator.Divide(scene, numberOne, Integer.parseInt(fldExpression.getText()));
                break;
            default:
                throw new Exception("applyOperation(): Incorrect operation code");
        }
    }

    private void setActionListeners (Scene scene) {
        Button btnOne = (Button)scene.lookup("#btnOne");
        Button btnTwo = (Button)scene.lookup("#btnTwo");
        Button btnThree = (Button)scene.lookup("#btnThree");
        Button btnFour = (Button)scene.lookup("#btnFour");
        Button btnFive = (Button)scene.lookup("#btnFive");
        Button btnSix = (Button)scene.lookup("#btnSix");
        Button btnSeven = (Button)scene.lookup("#btnSeven");
        Button btnEight = (Button)scene.lookup("#btnEight");
        Button btnNine = (Button)scene.lookup("#btnNine");
        Button btnZero = (Button)scene.lookup("#btnZero");

        btnOne.setOnAction(this::handleNumberButton);
        btnTwo.setOnAction(this::handleNumberButton);
        btnThree.setOnAction(this::handleNumberButton);
        btnFour.setOnAction(this::handleNumberButton);
        btnFive.setOnAction(this::handleNumberButton);
        btnSix.setOnAction(this::handleNumberButton);
        btnSeven.setOnAction(this::handleNumberButton);
        btnEight.setOnAction(this::handleNumberButton);
        btnNine.setOnAction(this::handleNumberButton);
        btnZero.setOnAction(this::handleNumberButton);

        Button btnAdd = (Button)scene.lookup("#btnAdd");
        btnAdd.setOnAction((event) -> {
            if (isSecond) {
                try {
                    applyOperation();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
            else
                isSecond = true;

            toClear = true;
            numberOne = Integer.parseInt(fldExpression.getText());
            operationCode = 1;
        });

        Button btnSubtract = (Button)scene.lookup("#btnSubtract");
        btnSubtract.setOnAction((event) -> {
            if (isSecond) {
                try {
                    applyOperation();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
            else
                isSecond = true;

            toClear = true;
            numberOne = Integer.parseInt(fldExpression.getText());
            operationCode = 2;
        });

        Button btnMultiply = (Button)scene.lookup("#btnMultiply");
        btnMultiply.setOnAction((event) -> {
            if (isSecond) {
                try {
                    applyOperation();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
            else
                isSecond = true;

            toClear = true;
            numberOne = Integer.parseInt(fldExpression.getText());
            operationCode = 3;
        });

        Button btnDivide = (Button)scene.lookup("#btnDivide");
        btnDivide.setOnAction((event) -> {
            if (isSecond) {
                try {
                    applyOperation();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
            else
                isSecond = true;

            toClear = true;
            numberOne = Integer.parseInt(fldExpression.getText());
            operationCode = 4;
        });
    }

    @Override
    public void start(Stage primaryStage) throws Exception{
        Parent root = FXMLLoader.load(getClass().getResource("main.fxml"));
        scene = new Scene(root, 265, 195);

        fldExpression = (TextField)scene.lookup("#fldExpression");

        numberOne = 0;

        setActionListeners(scene);

        primaryStage.setTitle("SimpleCalculator");
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    public static void main(String[] args) {
        launch(args);
    }
}
