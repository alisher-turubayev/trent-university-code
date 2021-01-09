import org.junit.Test;
import static org.junit.Assert.*;

public class LoanTest {
    /** Test getMonthlyPayment method */
    @Test
    public void getMonthlyPaymentTest() {
        // Load of 10,000 dollars for 3 years with 2.5% interest per year
        Loan l2y3am10k = new Loan(2.5, 3, 10000.0);
        double expected = 288.61;
        // assertEquals with delta because assertEquals is depreciated
        // delta - the max difference between two values where still considered equal
        // Here, the delta is 0 as the amount needs to be truncated to the nearest cent
        double calculated = Math.round(l2y3am10k.getMonthlyPayment() * 100.0) / 100.0;
        assertEquals(calculated, expected, 0.0);
    }

    /** Test setLoanAmount for exception */
    @Test (expected = Exception.class)
    public void setLoanAmountTest() throws Exception {
        Loan negative = new Loan();
        negative.setLoanAmount(-10000.0);
    }
}
