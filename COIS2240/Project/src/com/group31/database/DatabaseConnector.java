package com.group31.database;

import com.group31.model.Entry;

import java.sql.*;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

/**
 * A class that handles all operations with the database within the program.
 * This class uses MySQL flavor of the SQL to operate on a database.
 *
 * Please refer to the documentation included with the project submission
 * in order to setup the database for the program to use.
 *
 * Note that at most one instance of DatabaseConnector should exist in program.
 * Having more can create unexpected behavior and will result in a crash, as two simultaneous accesses
 * to database raise SQLException.
 */
public class DatabaseConnector {
    // Database connection information
    private static final String DB_USERNAME = "application";
    private static final String DB_PASSWORD = "c3EjmeByo6Oo";
    private static final String DB_URL = "jdbc:mysql://localhost/calorie_tracker";
    // Database table names
    private static final String TABLE_DAY_STATISTICS = "day_statistics";
    private static final String TABLE_TODAY_MEALS = "today_meals";

    private Connection connect;
    private Statement statement;

    /**
     * Creates an instance of DatabaseConnector that connects to the database
     * using the specified static parameters.
     *
     * Note that at most one instance of DatabaseConnector should exist in com.group31.application
     * @throws SQLException if there is an error with connecting to database
     */
    public DatabaseConnector() throws SQLException {
        // Setup the connection with the database
        connect = DriverManager.getConnection(DB_URL +
                "?user=" + DB_USERNAME + "&password=" + DB_PASSWORD);
    }

    /**
     * Cleans up the database by deleting all old entries from today_meals
     * and converting them to the entries of day_statistics.
     *
     * @throws SQLException if there is an error with connecting to database
     */
    public void cleanUp() throws SQLException {
        // Note today's date for time comparison
        LocalDate today = LocalDate.now();

        statement = connect.createStatement();

        ResultSet resultSet = statement.executeQuery("SELECT * FROM " + TABLE_TODAY_MEALS);
        if (resultSet.next()) {
            // Go to last and get the date for it
            resultSet.last();
            LocalDate tableDate = resultSet.getDate(1).toLocalDate();

            if (tableDate.isBefore(today)) {
                statement.execute("TRUNCATE TABLE " + TABLE_TODAY_MEALS);
                // Move the pointer back for loop correctness
                resultSet.beforeFirst();

                Entry total = new Entry();
                while (resultSet.next()) {
                    Date date = resultSet.getDate(1);
                    double calories = resultSet.getDouble(2);
                    double carbs = resultSet.getDouble(3);
                    double fat = resultSet.getDouble(4);
                    double protein = resultSet.getDouble(5);

                    Entry entry = new Entry(date, calories, carbs, fat, protein);
                    total.add(entry);
                }

                PreparedStatement preparedStatement = connect
                        .prepareStatement("INSERT INTO " + TABLE_DAY_STATISTICS + " VALUES (?, ?, ?, ?, ?, NULL)");
                preparedStatement.setDate(1, total.getDate());
                preparedStatement.setDouble(2, total.getCalories());
                preparedStatement.setDouble(3, total.getCarbs());
                preparedStatement.setDouble(4, total.getFat());
                preparedStatement.setDouble(5, total.getProtein());

                preparedStatement.execute();
            }
        }
    }

    /**
     * Inserts a given Entry into the today_meals table of the database.
     * @param entry an Entry to insert into
     * @throws SQLException if there is an error with connecting to database
     */
    public void addEntry(Entry entry) throws SQLException {
        PreparedStatement preparedStatement = connect
                .prepareStatement("INSERT INTO " + TABLE_TODAY_MEALS + " VALUES (?, ?, ?, ?, ?, NULL)");
        preparedStatement.setDate(1, entry.getDate());
        preparedStatement.setDouble(2, entry.getCalories());
        preparedStatement.setDouble(3, entry.getCarbs());
        preparedStatement.setDouble(4, entry.getFat());
        preparedStatement.setDouble(5, entry.getProtein());

        preparedStatement.execute();
    }

    /**
     * Removes an Entry from table today_meals
     * @param entry an Entry to delete from the database
     * @throws SQLException if there is an error with connecting to database
     */
    public void removeEntry(Entry entry) throws SQLException {
        PreparedStatement preparedStatement = connect
                .prepareStatement("DELETE FROM " + TABLE_TODAY_MEALS
                        + " WHERE calories=? AND carbohydrates=? AND fat=? AND protein=? LIMIT 1");
        preparedStatement.setDouble(1, entry.getCalories());
        preparedStatement.setDouble(2, entry.getCarbs());
        preparedStatement.setDouble(3, entry.getFat());
        preparedStatement.setDouble(4, entry.getProtein());

        preparedStatement.execute();
    }

    /**
     * Returns an array of type Entry that is stored in today_meals table
     * @return an array of type Entry - data in the table
     * @throws SQLException if there is an error with connecting to database
     */
    public Entry[] getTodayStatistics() throws SQLException {
        statement = connect.createStatement();

        ResultSet resultSet = statement.executeQuery("SELECT * FROM " + TABLE_TODAY_MEALS);

        // Get the number of entries in the result set
        resultSet.last();
        int size = resultSet.getRow();

        // Create and populate array with data from database
        Entry[] entries = new Entry[size];
        resultSet.beforeFirst();

        int index = 0;
        while (resultSet.next()) {
            Date date = resultSet.getDate(1);
            double calories = resultSet.getDouble(2);
            double carbs = resultSet.getDouble(3);
            double fat = resultSet.getDouble(4);
            double protein = resultSet.getDouble(5);

            Entry entry = new Entry(date, calories, carbs, fat, protein);
            entries[index] = entry;
            index++;
        }

        return entries;
    }

    /**
     * Returns an array of type Entry that is stored in day_statistics table
     * @return array of type Entry - data in the table
     * @throws SQLException if there is an error with connecting to database
     */
    public List<Entry> getDailyStatistics() throws SQLException {
        statement = connect.createStatement();
        // Get the entries in the database ordered by date in ascending order
        ResultSet resultSet = statement.executeQuery("SELECT * FROM "
                + TABLE_DAY_STATISTICS + " ORDER BY date");

        List<Entry> output = new ArrayList<>();

        while (resultSet.next()) {
            // Only take first 31
            if (output.size() >= 31)
                break;

            Date date = resultSet.getDate(1);
            double calories = resultSet.getDouble(2);
            double carbs = resultSet.getDouble(3);
            double fat = resultSet.getDouble(4);
            double protein = resultSet.getDouble(5);

            // Create an instance of Entry to store the Entry
            Entry entry = new Entry(date, calories, carbs, fat, protein);

            // Create an instance of Calendar to get the day of month from table
            // I know, potato code, but what can you do if Oracle deprecates the
            // method of directly fetching the day of month from type Date
            Calendar calendar = Calendar.getInstance();
            calendar.setTime(resultSet.getDate(1));

            output.add(entry);
        }

        return output;
    }
}
