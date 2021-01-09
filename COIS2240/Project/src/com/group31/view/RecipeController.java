package com.group31.view;

import com.group31.application.MainApp;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.web.WebEngine;
import javafx.scene.web.WebView;

/**
 * Controller class for Recipes screen. Refers to the website where recipes are stored.
 * Handled by FXML, therefore, the warnings of type "unused" are suppressed
 */
@SuppressWarnings("unused")
public class RecipeController {
    // Reference to the MainApp instance: needed for method access
    private MainApp mainApp;
    // Values injected by FXML loader
    @FXML
    private WebView wbvRecipe;
    @FXML
    private Button btnOverview;

    /**
     * No-args constructor. Invoked by FXML
     */
    public RecipeController() {}

    /**
     * Set the reference to MainApp instance for screen change
     * @param mainApp a reference to MainApp instance
     */
    public void setMainApp(MainApp mainApp) {
        this.mainApp = mainApp;
    }

    // Starts to load the main web page
    @FXML
    private void initialize() {
        // Force mobile version to be loaded by providing fake userAgentString
        WebEngine webEngine = wbvRecipe.getEngine();
        webEngine.setJavaScriptEnabled(true);
        webEngine.setUserAgent("Mozilla/5.0 (Linux; Android 6.0.1; E6653 Build/32.2.A.0.253) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.98 Mobile Safari/537.36");

        webEngine.load("https://alisherturubayev.wixsite.com/website");
    }

    // Switches the stage to the Overview screen
    // Is attached to button "Back to Overview"
    @FXML
    private void changeToOverviewScreen() {
        mainApp.showOverviewScreen();
    }
}
