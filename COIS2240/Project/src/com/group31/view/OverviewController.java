package com.group31.view;

import com.group31.application.MainApp;
import com.group31.database.DatabaseConnector;
import com.group31.model.Entry;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.chart.LineChart;
import javafx.scene.chart.PieChart;
import javafx.scene.chart.XYChart;
import javafx.scene.control.Button;
import javafx.scene.control.Label;

import java.util.Calendar;
import java.util.List;

/**
 * Controller class for overview screen. Displays today and monthly statistics on screen.
 * Handled by FXML, therefore the warnings of type "unused" are suppressed
 */
@SuppressWarnings("unused")
public class OverviewController {
    // Take reference to DatabaseConnector from MainApp
    private final DatabaseConnector dbConnect = MainApp.dbConnect;
    // Reference to MainApp instance: needed for method access
    private MainApp mainApp;
    // Values injected by FXML loader
    @FXML
    private PieChart chrtTodayStatistics;
    @FXML
    private LineChart chrtMonthlyStatistics;
    @FXML
    private Button btnAddMeal;
    @FXML
    private Button btnRecipes;
    @FXML
    private Label lblCalories;

    /**
     * No-args constructor. Invoked by FXML
     */
    public OverviewController () {
    }

    /**
     * Set the reference to MainApp instance for screen change
     * @param mainApp a reference to MainApp instance
     */
    public void setMainApp(MainApp mainApp) {
        this.mainApp = mainApp;
    }

    // Method that populates charts with data from the database
    @FXML
    private void initialize () {
        // If can, try to put data into the charts
        if (dbConnect != null) {
            setPieChart();
            setLineChart();

        }
    }

    // Puts the data from the database into pie chart and into the label
    // Note that this method does not directly connect to the database
    private void setPieChart () {
        try {
            // Get the data from the database
            Entry[] entries = dbConnect.getTodayStatistics();
            Entry total = new Entry();

            // Add all meals we get from the database
            for (Entry entry : entries) {
                total.add(entry);
            }

            // If the total is 0 - put insufficient data sign and stop the function
            if (total.equals(new Entry())) {
                lblCalories.setText("NO_DATA");
                return;
            }

            // Take total calorie intake and put it in a label
            String calories = String.valueOf(total.getCalories());
            lblCalories.setText(calories);

            // Create an array that holds the data for pie chart
            ObservableList<PieChart.Data> pieChartData =
                    FXCollections.observableArrayList(
                            new PieChart.Data("Carbohydrates", total.getCarbs()),
                            new PieChart.Data("Fat", total.getFat()),
                            new PieChart.Data("Protein", total.getProtein())
                    );
            // Inject data
            chrtTodayStatistics.setData(pieChartData);
        } catch (Exception ex) {
            ex.printStackTrace();
            MainApp.createAlertError("Database error. Reinstall the program.");
        }
    }

    // Puts the data from the database into line chart
    // Note: this method does not directly connect to the database
    //
    // Note: warnings of type "unchecked" are suppressed because Java was starting to act up
    // In actuality, the FXML loader does not specify the type of generic instance of type
    // LineChart, so the getData.add() method works in raw type, which causes warning to pop up
    @SuppressWarnings("unchecked")
    private void setLineChart() {
        try {
            // Get the data from the database
            List<Entry> data = dbConnect.getDailyStatistics();

            // This stores the series of data that we inject into the chart
            XYChart.Series<String, Double> calorieSeries = new XYChart.Series<>();

            // Iterate through the set and add data to Series
            for (Entry entry : data) {
                // POTATO CODE ALERT: EVACUATE IMMEDIATELY
                // This piece of code uses Calendar to get the day of month and the month of year
                // from the Date instance stored in Entry, because Oracle deprecated getDay() of java.sql.Date class.
                Calendar calendar = Calendar.getInstance();
                calendar.setTime(entry.getDate());

                int day = calendar.get(Calendar.DAY_OF_MONTH);
                int month = calendar.get(Calendar.MONTH);

                // Add in data to the series
                calorieSeries.getData().add(new XYChart.Data(day + "/" + month, entry.getCalories()));
            }

            // Update the chart
            chrtMonthlyStatistics.getData().add(calorieSeries);
        } catch (Exception ex) {
            ex.printStackTrace();
            MainApp.createAlertError("Database error. Reinstall the program.");
        }
    }

    // Changes the stage to show the Add Meal screen
    // Is attached to the button "Add a Meal"
    @FXML
    private void changeToAddMealScreen() {
        mainApp.showAddMealScreen();
    }

    // Changes the stage to show the Recipes screen
    // Is attached to the button "Check out Recipes"
    @FXML
    private void changeToRecipeScreen() {
        mainApp.showRecipeScreen();
    }
}
