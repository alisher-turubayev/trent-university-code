/* Application for SQL export to CSV
 * 
 * Written by Alisher Turubayev and Vanshree Mathur,
 *	Trent University
 * 
 * Uses MySQL.Data package. Copyright Oracle and/or its affiliates 2004, 2018
 */

using System;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

class Script
{
	// Stores connection information in a string
	const string connectionString = "Database=projectDB;Data Source=localhost;User Id=root;Password=";

	public static void Main(string[] args)
	{
		// Stores predefined set of tables in a database to export
		string[] tableNames = {"product", "manufacturer", "productorder", "service", "serviceorder",
			"employee", "department", "customer"};
		
		// Greet the user
		Console.WriteLine("Welcome to Database Exporter!");

		// For each table in a database, call ExportToCSV function
		foreach (string tableName in tableNames)
		{
			Console.WriteLine("Exporting data from table '{0}'...", tableName);
			ExportToCSV(tableName);
			Console.WriteLine("Table exported!");
		}

		Console.WriteLine("Database export complete!");
		Console.ReadLine();
	}

	private static void ExportToCSV (string tableName)
	{
		// Store the file path and file name
		string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
			fileName = tableName + ".csv";

		// Get data from the table
		StringBuilder data = GetDataFromTable(tableName);

		// Write the data to the file
		File.WriteAllText(Path.Combine(filePath, fileName), data.ToString());
	}
	
	private static StringBuilder GetDataFromTable (string tableName)
	{
		// Stores the result of a query
		StringBuilder result = new StringBuilder();

		// Create a new database connection
		MySqlConnection connection = new MySqlConnection(connectionString);

		try
		{
			// Stores the index
			int index = 0;
			// Stores the row in CSV format
			string row = "";

			// Open the connection
			connection.Open();
			
			// Make a query to output column names of a table
			string query = "SELECT column_name FROM information_schema.columns WHERE table_name='" + tableName + "'";

			// Execute first query and use reader to read the result
			MySqlCommand command = new MySqlCommand(query, connection);
			MySqlDataReader reader = command.ExecuteReader();

			// While we have data in the reader
			while (reader.Read())
			{
				row += reader[0];
				if (index < reader.FieldCount)
					row += ",";
			}
			// Add the row to the result
			result.AppendLine(row);

			// Close the reader
			reader.Close();

			// Change the query to output all rows in a table
			query = "SELECT * FROM " + tableName;
			// Execute first query and use reader to read the result
			command = new MySqlCommand(query, connection);
			reader = command.ExecuteReader();

			// While we have data in the reader
			while (reader.Read())
			{
				// Stores the row in CSV format
				row = "";
				index = 0;
				// Add each column to the row string
				while (index < reader.FieldCount)
				{
					// Stores the next column
					string buffer = reader[index].ToString();
					// Sanitize the buffer - remove all commas from the column, replace with space
					// Also, remove all plus signs
					buffer = buffer.Replace(',', ' ');
					buffer = buffer.Replace('+', ' ');
					// Add the buffer to the row
					row += buffer;
					// If not last column, add comma
					if (index < reader.FieldCount - 1)
						row += ",";
					// Increase the index
					index++;
				}

				// Insert a row
				result.AppendLine(row);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Exception: " + ex.ToString());
		}

		// Close the connection
		connection.Close();

		// Return result
		return result;
	}
}
