// Name: Alisher Turubayev	
// Code File: Fraction.cs
// Student Number: 0630908
// Fraction Class
// Class Description: Objects of this class will possess the data and operations
//    consistent with mathematical fractions.  There are two private data members 
//    to store the numerator and denominator.  Both of numerator and denominator 
//    have a read/write property. The fraction is reduced to the simplest form by
//    the Reduce method, which uses FindGCD. Also, there is a method ToString to 
//    convert the fraction to appropriate format. Finally, there are overloaded 
//    operators that permit two fractions to be multiplied, added and compared.

using System;
public class Fraction
{
    private int numerator;
    private int denominator;

    // Fraction(): No Parameter Constructor
    // Parameters: none
    public Fraction()
    {
        // set to default values: 0 and 1
        this.numerator = 0;
        this.denominator = 1;
    }

    // Fraction(int, int): Two Parameter Constructor
    // Parameters: num: int. The desired numerator for the new fraction
    //             and den: int. The desired denominator for the new fraction
    public Fraction(int num, int den)
    {
        // set values
        this.numerator = num;
        // notice: use of Property to ensure data validity and to reduce the fraction
        this.Denominator = den;
    }

    // Numerator: Property
    // Read/Write
    // No data integrity check required
    public int Numerator
    {
        // get property
        get
        {
            return this.numerator;
        }
        // set property
        set
        {
            this.numerator = value;
            this.Reduce();
        }
    }

    // Denominator: Property
    // Read/Write
    // Data integrity check is implemented: value cannot be 0
    public int Denominator
    {
        // get property
        get
        {
            return this.denominator;
        }
        // set property
        set
        {
            // check whether the value is zero
            if (value == 0)
                this.denominator = 1;
            else
            {
                // if value is not zero, put the value in denominator and reduce the fraction
                this.denominator = value;
                this.Reduce();
            }
        }
    }

    //-Reduce(): method
    // Parameters: none
    // Returns:    nothing
    // Purpose:    reduce the fraction to the simplest form
    private void Reduce()
    {
        // use FindGCD function to find the greatest common divisor
        int gcd = FindGCD(numerator, denominator);

        // divide both numerator and denominator by gcd
        this.numerator /= gcd;
        this.denominator /= gcd;
    }

    // ToString(): override method
    // Parameters: none
    // Returns:    string
    // Purpose:    convert the fraction to a proper string representation of form "number/number"
    public override string ToString()
    {
        // output: string. Stores the string representation of fraction
        string output;
        
        // create and store the value
        output = this.numerator.ToString() + "/" + this.denominator.ToString();
        
        // return the result
        return output;
    }

    // Multiply(Fraction, Fraction): operator
    // Parameters:  fract1/2: Fraction. Fractions to be multiplied
    // Returns:     fract: Fraction. Multiplication result
    // Purpose:     multiply two fractions by multiplying numerators and denominators together 
    public static Fraction operator *(Fraction fract1, Fraction fract2)
    {
        // fract: Fraction. Stores the final fraction after the multiplication operation
        Fraction fract = new Fraction
        {
            numerator = fract1.numerator * fract2.numerator,
            denominator = fract1.denominator * fract2.denominator
        };

        // reduce the fraction
        fract.Reduce();
        
        // return the result
        return fract;
    }

    // Add(Fraction, Fraction): operator
    // Parameters:  fract1/2: Fraction. Fractions to be added
    // Returns:     fract: Fraction. Addition result
    // Purpose:     add two fractions by finding least common multiple of both denominators 
    public static Fraction operator +(Fraction fract1, Fraction fract2)
    {
        // copy{1, 2}: Fraction. Stores the copies of numerators of two fractions for addition
        int copy1 = fract1.numerator, copy2 = fract2.numerator;

        // lcm: int. Stores the least commmon multiple of both denominators
        int lcm = FindLCM(fract1.denominator, fract2.denominator);

        // use lcm to equalize the denominators
        // if the denominator equals to the lcm, do nothing
        // else, multiply by the lcm divided by the denominator
        copy1 *= (lcm == fract1.denominator ? 1 : lcm / fract1.denominator);
        copy2 *= (lcm == fract2.denominator ? 1 : lcm / fract2.denominator);
        
        // fract: Fraction. Stores the final fraction after the addition operation
        Fraction fract = new Fraction
        {
            numerator = copy1 + copy2,
            denominator = lcm
        };

        // reduce the fraction
        fract.Reduce();
        
        // return the result
        return fract;
    }

    // Greater Than or Equal(Fraction, Fraction): operator
    // Parameters:  fract1/2: Fraction. Fractions to be compared
    // Returns:     bool. Whether the fraction one is bigger or equal to second one
    // Purpose:     comparator
    public static bool operator >=(Fraction fract1, Fraction fract2)
    {
        // copy{1, 2}: int. Stores the copies of the numerators of two fractions for comparison
        int copy1 = fract1.numerator, copy2 = fract2.numerator;

        // lcm: int. Stores the least commmon multiple of both denominators
        int lcm = FindLCM(fract1.denominator, fract2.denominator);

        // use lcm to equalize the numerators
        // if the denominator equals to the lcm, do nothing
        // else, multiply by the lcm divided by the denominator
        copy1 *= (lcm == fract1.denominator ? 1 : lcm / fract1.denominator);
        copy2 *= (lcm == fract2.denominator ? 1 : lcm / fract2.denominator);

        // return the result
        return copy1 >= copy2;  
    }

    // Less Than or Equal operator(Fraction, Fraction): operator
    // Parameters:  fract1/2: Fraction. Fractions to be compared
    // Returns:     bool. Whether the fraction one is less than or equal to second one
    // Purpose:     comparator
    public static bool operator <=(Fraction fract1, Fraction fract2)
    {
        // copy{1, 2}: int. Stores the copies of the numerators of two fractions for comparison
        int copy1 = fract1.numerator, copy2 = fract2.numerator;

        // lcm: int. Stores the least commmon multiple of both denominators
        int lcm = FindLCM(fract1.denominator, fract2.denominator);

        // use lcm to equalize the numerators
        // if the denominator equals to the lcm, do nothing
        // else, multiply by the lcm divided by the denominator
        copy1 *= (lcm == fract1.denominator ? 1 : lcm / fract1.denominator);
        copy2 *= (lcm == fract2.denominator ? 1 : lcm / fract2.denominator);

        // return the result
        return copy1 <= copy2;
    }
    
    //-FindGCD(int, int): int
    // Parameters:  {a, b}: int. Two numbers to find the GCD for
    // Returns:     int. Greatest commmon divisor for the two numbers
    // Purpose:     to find the greatest commmon divisor using Euclid's algorithm. O(log(min(a, b)))
    private static int FindGCD (int a, int b)
    {
        // start the loop
        while (b != 0)
        {
            // find the remainder
            a %= b;
            
            // swap the values
            Swap(ref a, ref b);
        }
        
        // return the result
        return a;
    }

    //-FindLCM(int, int): int
    // Parameters:  {a, b}: int. Two numbers to find the LCM for
    // Returns:     int. Least common multiply for the two numbers
    // Purpose:     to find the least common multiple using formula: "a * b / gcd(a, b)". O(log(min(a, b)))
    private static int FindLCM (int a, int b)
    {
        // return the result
        return a * b / FindGCD(a, b);
    }

    //-Swap(int, int): void
    // Parameters:  {a, b}: int. Two variables to be swapped
    // Returns:     nothing
    // Purpose:     to swap the values
    private static void Swap (ref int a, ref int b)
    {
        // temporary: int. Stores the value of the first variable for swapping operation
        int temporary = a;
        
        // swap the values
        a = b;
        b = temporary;
    }
}
//Just Monika <3