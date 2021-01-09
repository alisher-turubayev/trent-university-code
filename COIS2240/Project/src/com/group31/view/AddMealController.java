package com.group31.view;

import com.group31.application.MainApp;
import com.group31.database.DatabaseConnector;
import com.group31.model.Entry;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.TextField;

import java.sql.Date;
import java.time.LocalDate;

/**
 * Controller class for Add Meal screen. Allows the user to add or delete today meals.
 * Note that only today meals can be added or deleted by a user.
 * Handled by FXML, therefore the warnings of type "unused" are suppressed.
 */
@SuppressWarnings("unused")
public class AddMealController {
    // Take reference to DatabaseConnector from MainApp
    private final DatabaseConnector dbConnect = MainApp.dbConnect;
    // Reference to the MainApp instance: needed for method access
    private MainApp mainApp;
    // Values injected by FXML loader
    @FXML
    private Button btnAddMeal;
    @FXML
    private Button btnDeleteMeal;
    @FXML
    private ChoiceBox chbxMeals;
    @FXML
    private Button btnCancel;
    @FXML
    private TextField txtCalories;
    @FXML
    private TextField txtCarbs;
    @FXML
    private TextField txtFat;
    @FXML
    private TextField txtProtein;

    /**
     * No-args constructor. Invoked by FXML
     */
    public AddMealController() {
    }

    /**
     * Set the reference to MainApp instance for screen change
     * @param mainApp a reference to MainApp instance
     */
    public void setMainApp(MainApp mainApp) {
        this.mainApp = mainApp;
    }

    // Invoked by FXML loader. Populates the choice box with options
    // Note: warnings of type "unchecked" are suppressed because the choice box is
    // not defined to a particular type by FXML loader. Thus, setItems() operates in
    // raw data, causing the warning to pop up.
    @SuppressWarnings("unchecked")
    @FXML
    private void initialize() {
        try {
            Entry[] entries = dbConnect.getTodayStatistics();
            ObservableList<String> list = FXCollections.observableArrayList();

            for (Entry entry : entries) {
                list.add(entry.toString());
            }
            chbxMeals.setItems(list);
        } catch (Exception ex) {
            ex.printStackTrace();
            MainApp.createAlertError("Database error. Reinstall the program.");
        }
    }

    // Checks the data for integrity and adds an entry to the database
    @FXML
    private void addMeal() {
        double calories, carbs, fat, protein;

        try {
            // Try parsing numbers from text fields
            calories = Double.valueOf(txtCalories.getText());
            carbs = Double.valueOf(txtCarbs.getText());
            fat = Double.valueOf(txtFat.getText());
            protein = Double.valueOf(txtProtein.getText());
        } catch (NumberFormatException ex) {
            // Set all fields to red color
            txtCalories.setStyle("-fx-text-inner-color: red;");
            txtCarbs.setStyle("-fx-text-inner-color: red;");
            txtFat.setStyle("-fx-text-inner-color: red;");
            txtProtein.setStyle("-fx-text-inner-color: red;");
            // Create an alert
            MainApp.createAlertWarning("One or more contains illegal input. Please, try again");
            return;
        }

        // Check calories
        if (calories <= 100.0) {
            // Change color to red to signalize the error
            txtCalories.setStyle("-fx-text-inner-color: red;");
            // Create an alert to notify the user
            MainApp.createAlertWarning("Incorrect input in field 'Calories'. " +
                    "Please input a number that is larger than 100");
            return;
        }
        // Else, change color to black (might have been red last time we called this function,
        // so need to verify and then change to black color)
        else
            txtCalories.setStyle("-fx-text-inner-color: black;");

        // Check carbs
        if (carbs < 0.0) {
            txtCarbs.setStyle("-fx-text-inner-color: red;");
            MainApp.createAlertWarning("Incorrect input in field 'Carbohydrates'. " +
                    "Please input a number that is greater than or equal to 0");
            return;
        }
        else
            txtCarbs.setStyle("-fx-text-inner-color: black;");

        // Check fat
        if (fat < 0.0) {
            txtFat.setStyle("-fx-text-inner-color: red;");
            MainApp.createAlertWarning("Incorrect input in field 'Fat'. " +
                    "Please input a number that is greater than or equal to 0");
            return;
        }
        else
            txtFat.setStyle("-fx-text-inner-color: black;");

        // Check protein
        if (protein < 0.0) {
            txtProtein.setStyle("-fx-text-inner-color: red;");
            MainApp.createAlertWarning("Incorrect input in field 'Protein'. " +
                    "Please input a number that is greater than or equal to 0");
            return;
        }
        else
            txtProtein.setStyle("-fx-text-inner-color: black;");

        try {
            Entry entry = new Entry(Date.valueOf(LocalDate.now()),
                    calories, carbs, fat, protein);
            // Insert the entry
            dbConnect.addEntry(entry);
            // And switch back to Overview screen
            showOverviewScreen();
        } catch (Exception ex) {
            ex.printStackTrace();
            MainApp.createAlertError("Database error. Reinstall the program.");
        }
    }

    // Deletes a chosen meal from the database
    @FXML
    private void deleteMeal() {
        // If there are no items in the choice box, show warning and return
        if (chbxMeals.getItems().size() == 0) {
            MainApp.createAlertWarning("No items to choose from.");
            return;
        }

        // Try to find it in the database to delete
        String choice = (String)chbxMeals.getValue();
        try {
            // Get all values stored in today_meals
            Entry[] entries = dbConnect.getTodayStatistics();
            // Go through each entry and ch3ck
            // If true, delete
            for (Entry entry : entries) {
                if (entry.toString().equals(choice)) {
                    dbConnect.removeEntry(entry);
                    showOverviewScreen();
                    return;
                }
            }

            // Otherwise, notify that something went wrong. Mainly here for the debug purposes
            MainApp.createAlertWarning("For some reason, the entry that you were " +
                    "trying to delete could not be found.");
            showOverviewScreen();
        } catch (Exception ex) {
            ex.printStackTrace();
            MainApp.createAlertError("Database error. Reinstall the program.");
        }
    }

    // Switches the stage to the Overview screen
    @FXML
    private void showOverviewScreen() {
        mainApp.showOverviewScreen();
    }
}
