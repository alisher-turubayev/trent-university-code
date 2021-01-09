/* Student name: Alisher Turubayev
 * Student ID: 0630908
 * Program: this is a flight booking system
 * The program supports three operations: booking a seat, canceling a booking and printing the already assigned seats
 * The program checks the surname for any spaces inputted, and asks for another input if incorrect
 * It is assumed that the input is always correct data type, so no data integrity check is required
 * 
 * Notice! There is no check for the surname correctness, so any surname containing numbers will be accepted as a correct one
*/
using System;

class Assignment4
{
    public static void Main()
    {
        //constants declaration
        //CODE_{CANCEL_BOOKING, PRINT, BOOK, QUIT}: char. Char codes for different operations
        const char CODE_CANCEL_BOOKING = 'C';
        const char CODE_PRINT = 'P';
        const char CODE_BOOK = 'B';
        const char CODE_QUIT = 'Q';
        //NUMBER_OF_SEATS: int. The size of the plane
        const int NUMBER_OF_SEATS = 10;
        //variables declaration
        //seatAssign: string[]. Saves the information about the passenger
        string[] seatAssign = new string[NUMBER_OF_SEATS];
        //operationCode: char. Contains the user input
        char operationCode;

        //prepare the array by populating it with empty strings
        for (int index = 0; index < seatAssign.Length; index++)
        {
            seatAssign[index] = "";
        }

        //greet the user
        Console.WriteLine("Welcome to Air Canada!");
        Console.WriteLine("'Fly The Flag'\n");
        Console.WriteLine("Thank you for using our new automatic booking system!\n");
        Console.WriteLine("Remember, there are codes for operations you can use:\n");
        Console.WriteLine("{0} for booking a seat", CODE_BOOK);
        Console.WriteLine("{0} to cancel your current booking", CODE_CANCEL_BOOKING);
        Console.WriteLine("{0} for displaying current airplane booking", CODE_PRINT);
        Console.WriteLine("{0} to close your personal account manager\n", CODE_QUIT);

        //start the loop
        do
        {
            //prompt the user to input the operation code
            Console.WriteLine("Please, input the operation code:");
            operationCode = Char.ToUpper(Convert.ToChar(Console.ReadLine()));

            switch (operationCode)
            {
                case CODE_QUIT:
                    Console.WriteLine("Terminating the program...\n");
                    break;
                case CODE_BOOK:
                    Booking(seatAssign);
                    break;
                case CODE_CANCEL_BOOKING:
                    Cancel(seatAssign);
                    break;
                case CODE_PRINT:
                    PrintSeats(seatAssign);
                    break;
                default:
                    Console.WriteLine("Operation code incorrect, please try again.\n");
                    break;
            }
        } while (operationCode != CODE_QUIT);

        //goodbye message :D
        Console.WriteLine("Thank you for flying with Air Canada!");
        Console.WriteLine("Goodbye!");
        Console.ReadLine();
    }

    /*
     * FindEmptySeat: int
     * Parameters: SeatAssign(string[] array) - the assignment of seats in the airplane
     * Returns: the index of the first available seat if found, or -1 otherwise
     * Purpose: to find the index of the first available seat
     */
    public static int FindEmptySeat(string[] SeatAssign)
    {
        //variable declaration
        //index: int. Stores the index of the first available seat. -1 by default
        int index = -1;
        
        //find the first available seat by using "for" cycle
        for(int current = 0; current < SeatAssign.Length; current++)
        {
            if (SeatAssign[current] == "")
            {
                //if found, set index to current and break the cycle
                index = current;
                break;
            }
        }

        //return index
        return index;
    }

    /*
     * FindCustomerSeat: int
     * Parameters: SeatAssign(string[] array) - the assignment of seats in the airplane
     *             and cName(string) - the name of the customer to be found
     * Returns: the index of the passenger's seat if found, or -1 otherwise       
     * Purpose: to find the index of the passenger's seat
     */
    public static int FindCustomerSeat(string[] SeatAssign, string cName)
    {
        //variable declaration
        //index: int. Stores the index of the seat registered on a customer name. -1 by default
        int index = -1;

        //find the passenger's seat by using "for" cycle
        for (int current = 0; current < SeatAssign.Length; current++)
        {
            if (SeatAssign[current] == cName)
            {
                //if found, set index to current and break the cycle
                index = current;
                break;
            }
        }
        return index;
    }

    /*
     * Booking: void
     * Parameters: SeatAssign(string[] array) - the assignment of seats in the airplane
     * Retuns: nothing
     * Purpose: to book the seat
     */
    public static void Booking(string[] SeatAssign)
    {
        //variable declaration
        //cName: string. Stores the surname of the customer
        string cName;
        //seatNumber: int. Stores the seat's number
        int seatNumber;

        //start the loop and check for the input to be free of spaces
        do
        {
            //prompt the user to input the surname
            Console.WriteLine("To book the seat, we need your surname");
            Console.WriteLine("Please, input your surname only without any spaces:");
            //remove extra spaces at beggining and end
            cName = Console.ReadLine().Trim();
        } while (cName == "" || cName.Contains(" "));

        //call FindEmptySeat function
        seatNumber = FindEmptySeat(SeatAssign);
        if (seatNumber == -1)
        {
            //if no seat is found, return a message
            Console.WriteLine("Sorry, dear {0}. There are currently no seats available for this flight.\n", cName);
        }
        else
        {
            //save the booking
            SeatAssign[seatNumber] = cName;

            //inform the user of the successful booking
            Console.WriteLine("Operation successful! Dear {0}, you have successfully booked seat number {1}.\n", cName, seatNumber);
        }
    }
    
    /*
     * Cancel: void
     * Parameters: SeatAssign(string[] array) - the assignment of seats in the airplane
     * Returns: nothing
     * Purpose: to cancel the booking
     */
    public static void Cancel(string[] SeatAssign)
    {
        //variable declaration
        //cName: string. Stores the surname of the customer
        string cName;
        //seatNumber: int. Stores the seat's number
        int seatNumber;

        //start the loop and check for the input to be free of spaces
        do
        {
            //prompt the user to input the surname
            Console.WriteLine("To cancel the booking, we need your surname");
            Console.WriteLine("Please, input your surname only without any spaces:");
            //remove extra spaces at beggining and end
            cName = Console.ReadLine().Trim();
        } while (cName == "" || cName.Contains(" "));

        //call FindEmptySeat function
        seatNumber = FindCustomerSeat(SeatAssign, cName);
        if (seatNumber == -1)
        {
            //if no seat is found, return a message
            Console.WriteLine("Sorry, dear {0}. There is no booking on your name.\n", cName);
        }
        else
        {
            //save the booking
            SeatAssign[seatNumber] = "";

            //inform the user of the successful booking
            Console.WriteLine("Operation successful! Dear {0}, you have successfully cancelled the booking on seat number {1}.\n", cName, seatNumber);
        }
    }

    /*
     * PrintSeats: void
     * Parameters: SeatAssign(string[] array) - the assignment of seats in the airplane
     * Returns: nothing
     * Purpose: to print all bookings
     */
    public static void PrintSeats(string[] SeatAssign)
    {
        //variable declaration
        //hasBookings: boolean. Used to store if any seat has a passenger attached to it
        bool hasBooking = false;

        for (int index = 0; index < SeatAssign.Length; index++)
        {
            if (SeatAssign[index] != "")
            {
                hasBooking = true;
                break;
            }
        }

        if (hasBooking)
        {
            Console.WriteLine("These seats have been booked:");
            //print the seat and passenger's name
            for (int index = 0; index < SeatAssign.Length; index++)
            {
                //if there is a booking, output the booking
                if (SeatAssign[index] != "")
                {
                    Console.WriteLine("Seat #{0} by {1}", index, SeatAssign[index]);
                }
            }
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("There are currently no records of bookings in the system.\n");
        }
    }
    //Just Monika <3
}

