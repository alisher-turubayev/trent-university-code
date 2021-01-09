package com.group31.application;

import com.group31.database.DatabaseConnector;
import com.group31.view.AddMealController;
import com.group31.view.OverviewController;
import com.group31.view.RecipeController;
import javafx.application.Application;
import javafx.application.Platform;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.stage.Stage;

/**
 * The backbone of the application. Calls and references other classes that comprise this
 * software. Because it contains both main() and start(), it is invoked first by JVM.
 *
 * This class establishes connection to the database (by creating an instance of
 * {@link com.group31.database.DatabaseConnector})
 * and uses FXMLLoader that loads the scene and an appropriate controller. Controller classes
 * have a reference to the instance of MainApp to invoke the methods to change the scene. Those same classes
 * also use the reference to the instance of {@link com.group31.database.DatabaseConnector} to
 * conduct operations on a database.
 *
 * IMPORTANT: only one instance of {@link com.group31.database.DatabaseConnector} should exist at any point of
 * program execution. Creating two instances can create unexpected behaviour and will result in an application crash.
 * Refer to {@link com.group31.database.DatabaseConnector} and documentation that was submitted with the project files
 * for more information.
 *
 * @see com.group31.database.DatabaseConnector
 */
public class MainApp extends Application {
    /**
     * Instance of {@link com.group31.database.DatabaseConnector}, that is used by all other classes in the application.
     * @see com.group31.database.DatabaseConnector
     */
    public static DatabaseConnector dbConnect;
    // Needed to save the stage for scene change
    private Stage stage;
    // Constants denoting size of scene
    private static final int STAGE_WIDTH = 440;
    private static final int STAGE_HEIGHT = 530;
    // Contain the titles of each screen
    private static final String TITLE_OVERVIEW = "Overview";
    private static final String TITLE_ADD_MEAL = "Add a Meal";
    private static final String TITLE_RECIPES = "Recipes";

    /**
     * Invoked by main(), method shows the Overview screen to the user
     * @param stage passed by the JVM
     */
    @Override
    public void start(Stage stage) {
        this.stage = stage;
        showOverviewScreen();
    }

    /**
     * Main method. Invoked by JVM.
     * @param args JavaFX standard arguments. JVM provides them
     */
    public static void main(String[] args) {
        try {
            // Establish a connection to the database and clean it up
            dbConnect = new DatabaseConnector();
            dbConnect.cleanUp();
        } catch (Exception ex) {
            ex.printStackTrace();
            createAlertError("Database connector could not be initialized. Check the documentation in order to create an accessible database");
        }
        launch(args);
    }

    /**
     * Changes the stage to show the Overview screen
     */
    public void showOverviewScreen() {
        try {
            // Create a FXML loader and load the file
            FXMLLoader loader = new FXMLLoader();
            loader.setLocation(MainApp.class.getResource("/com/group31/view/overviewScreen.fxml"));
            // Get a parent and load the scene
            Parent root = loader.load();
            stage.setScene(new Scene(root, STAGE_WIDTH, STAGE_HEIGHT));
            stage.setTitle(TITLE_OVERVIEW);
            stage.setResizable(false);
            stage.show();

            // Give controller access to main app
            OverviewController controller = loader.getController();
            controller.setMainApp(this);
        } catch (Exception ex) {
            ex.printStackTrace();
            createAlertError("FXML file not found. Check the file integrity.");
        }
    }

    /**
     * Changes the stage to show the Add Meal screen
     */
    public void showAddMealScreen() {
        try {
            // Create a FXML loader and load the file
            FXMLLoader loader = new FXMLLoader();
            loader.setLocation(MainApp.class.getResource("/com/group31/view/addMealScreen.fxml"));
            // Get a parent and load the scene
            Parent root = loader.load();
            stage.setScene(new Scene(root, STAGE_WIDTH, STAGE_HEIGHT));
            stage.setTitle(TITLE_ADD_MEAL);
            stage.setResizable(false);
            stage.show();

            // Give controller access to main app
            AddMealController controller = loader.getController();
            controller.setMainApp(this);
        } catch (Exception ex) {
            ex.printStackTrace();
            createAlertError("FXML file not found. Check the file integrity.");
        }
    }

    /**
     * Changes the stage to show the Recipe screen
     */
    public void showRecipeScreen() {
        try {
            // Create a FXML loader and load the file
            FXMLLoader loader = new FXMLLoader();
            loader.setLocation(MainApp.class.getResource("/com/group31/view/recipeScreen.fxml"));
            // Get a parent and load the scene
            Parent root = loader.load();
            stage.setScene(new Scene(root, STAGE_WIDTH, STAGE_HEIGHT));
            stage.setTitle(TITLE_RECIPES);
            stage.setResizable(false);
            stage.show();

            // Give controller access to main app
            RecipeController controller = loader.getController();
            controller.setMainApp(this);
        } catch (Exception ex) {
            ex.printStackTrace();
            createAlertError("FXML file not found. Check the file integrity.");
        }
    }

    /**
     * Creates an alert of type ERROR and stops the program.
     *
     * Note that the alert is created using a runLater task, which means that the
     * alert might not show up immediately after the method call.
     * @param contentText the text to show in an alert box
     */
    public static void createAlertError (String contentText) {
        Platform.runLater(() -> {
            Alert alert = new Alert(Alert.AlertType.ERROR);
            alert.setTitle("Fatal error");
            alert.setContentText(contentText);
            alert.showAndWait();

            System.exit(-1);
        });
    }

    /**
     * Creates an alert of type WARNING.
     *
     * Note that the alert is created using a runLater task, which means that the
     * alert might not show up immediately after the method call.
     * @param contentText the text to show in an alert box
     */
    public static void createAlertWarning (String contentText) {
        Platform.runLater(() -> {
            Alert alert = new Alert(Alert.AlertType.WARNING);
            alert.setTitle("Warning");
            alert.setContentText(contentText);
            alert.showAndWait();
        });
    }
}
