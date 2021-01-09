package com.group31.model;

import java.sql.Date;
import java.time.LocalDate;

/**
 * Support class to store the entries from the database. Has five fields that are only
 * modifiable within the class. Getter method for each field exists so that the data
 * can be accessed.
 */
public class Entry {
    private final Date date;
    private double calories;
    private double carbs;
    private double fat;
    private double protein;

    /**
     * Initializes an instance of class with all fields set to zero and date set to today
     */
    public Entry () {
        date = Date.valueOf(LocalDate.now());
    }

    /**
     * Initializes an instance of class with provided data
     * @param date the date of an entry
     * @param calories calories in a meal
     * @param carbs carbohydrates in a meal
     * @param fat fats in a meal
     * @param protein proteins in a meal
     */
    public Entry(Date date, double calories, double carbs, double fat, double protein) {
        this.date = date;
        this.calories = calories;
        this.carbs = carbs;
        this.fat = fat;
        this.protein = protein;
    }

    /**
     * Returns the date stored in an Entry
     * @return date stamp for an instance
     */
    public Date getDate() {
        return date;
    }

    /**
     * Returns the calories stored in an Entry
     * @return calories count for an instance
     */
    public double getCalories() {
        return calories;
    }

    /**
     * Returns the carbohydrates stored in an Entry
     * @return carbohydrates count for an instance
     */
    public double getCarbs() {
        return carbs;
    }

    /**
     * Returns the fats stored in an Entry
     * @return fats count for an instance
     */
    public double getFat() {
        return fat;
    }

    /**
     * Returns the proteins stored in an Entry
     * @return proteins count for an instance
     */
    public double getProtein() {
        return protein;
    }

    /**
     * Adds an instance of Entry to the current instance
     * @param b instance of Entry to be added to a current one
     */
    public void add (Entry b) {
        calories += b.calories;
        carbs += b.carbs;
        fat += b.fat;
        protein += b.protein;
    }

    /**
     * Returns true if the current instance of type Entry is the same as argument.
     *
     * Note that the comparison is only done on four fields. Date is not compared.
     * @param obj the object to check
     * @return true if the object passed is same as current instance of Entry
     */
    @Override
    public boolean equals(Object obj) {
        if (obj instanceof Entry) {
            Entry entry = (Entry)obj;
            return this.calories == entry.calories
                    && this.carbs == entry.carbs
                    && this.fat == entry.fat
                    && this.protein == entry.protein;
        }

        return false;
    }

    /**
     * Returns a string representation of Entry
     * @return string representation
     */
    @Override
    public String toString() {
        return "Calories: " + calories +
                ", carbs: " + carbs +
                ", fat: " + fat +
                ", protein: " + protein;
    }
}
