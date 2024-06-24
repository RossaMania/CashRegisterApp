/*
This application manages transactions at a store check-out line. The
check-out line has a cash register, and the register has a cash till
that is prepared with a number of bills each morning. The till includes
bills of four denominations: $1, $5, $10, and $20. The till is used
to provide the customer with change during the transaction. The item
cost is a randomly generated number between 2 and 49. The customer
offers payment based on an algorithm that determines a number of bills
in each denomination.

Each day, the cash till is loaded at the start of the day. As transactions
occur, the cash till is managed in a method named MakeChange (customer
payments go in and the change returned to the customer comes out). A
separate "safety check" calculation that's used to verify the amount of
money in the till is performed in the "main program". This safety check
is used to ensure that logic in the MakeChange method is working as
expected.
*/

string? readResult = null;
bool useTestData = false;

Console.Clear();

int[] cashTill = new int[] { 0, 0, 0, 0 };
int registerCheckTillTotal = 0;

// registerDailyStartingCash: $1 x 50, $5 x 20, $10 x 10, $20 x 5 => ($350 total)
int[,] registerDailyStartingCash = new int[,] { { 1, 50 }, { 5, 20 }, { 10, 10 }, { 20, 5 } };

int[] testData = new int[] { 6, 10, 17, 20, 31, 36, 40, 41 };
int testCounter = 0;

LoadTillEachMorning(registerDailyStartingCash, cashTill);

registerCheckTillTotal = registerDailyStartingCash[0, 0] * registerDailyStartingCash[0, 1] + registerDailyStartingCash[1, 0] * registerDailyStartingCash[1, 1] + registerDailyStartingCash[2, 0] * registerDailyStartingCash[2, 1] + registerDailyStartingCash[3, 0] * registerDailyStartingCash[3, 1];

// display the number of bills of each denomination currently in the till
LogTillStatus(cashTill);

// display a message showing the amount of cash in the till
Console.WriteLine(TillAmountSummary(cashTill));

// display the expected registerDailyStartingCash total
Console.WriteLine($"Expected till value: {registerCheckTillTotal}\n\r");

var valueGenerator = new Random((int)DateTime.Now.Ticks);

int transactions = 100;

if (useTestData)
{
    transactions = testData.Length;
}

while (transactions > 0)
{
    transactions -= 1;
    int itemCost = valueGenerator.Next(2, 49);

    if (useTestData)
    {
        itemCost = testData[testCounter];
        testCounter += 1;
    }

    int paymentOnes = itemCost % 2;                 // value is 1 when itemCost is odd, value is 0 when itemCost is even
    int paymentFives = (itemCost % 10 > 7) ? 1 : 0; // value is 1 when itemCost ends with 8 or 9, otherwise value is 0
    int paymentTens = (itemCost % 20 > 13) ? 1 : 0; // value is 1 when 13 < itemCost < 20 OR 33 < itemCost < 40, otherwise value is 0
    int paymentTwenties = (itemCost < 20) ? 1 : 2;  // value is 1 when itemCost < 20, otherwise value is 2

    // display messages describing the current transaction
    Console.WriteLine($"Customer is making a ${itemCost} purchase");
    Console.WriteLine($"\t Using {paymentTwenties} twenty dollar bills");
    Console.WriteLine($"\t Using {paymentTens} ten dollar bills");
    Console.WriteLine($"\t Using {paymentFives} five dollar bills");
    Console.WriteLine($"\t Using {paymentOnes} one dollar bills");

try
{
    // MakeChange manages the transaction and updates the till
    MakeChange(itemCost, cashTill, paymentTwenties, paymentTens, paymentFives, paymentOnes);

    Console.WriteLine($"Transaction successfully completed.");
    registerCheckTillTotal += itemCost;
}
catch (InvalidOperationException e)
    {
        if (e.Message.Contains("The till is out of"))
        {
            Console.WriteLine($"Could not make transaction: {e.Message}");
            break; // Exit the loop if the store is closed due to insufficient denominations
        }
        else
        {
            Console.WriteLine($"Could not make transaction: {e.Message}");
        }
    }

    Console.WriteLine(TillAmountSummary(cashTill));
    Console.WriteLine($"Expected till value: {registerCheckTillTotal}\n\r");
    Console.WriteLine(); // This line is for spacing and debugging breakpoint.
}

Console.WriteLine("Press the Enter key to exit");
do
{
    readResult = Console.ReadLine();

} while (readResult == null);


static void LoadTillEachMorning(int[,] registerDailyStartingCash, int[] cashTill)
{
    cashTill[0] = registerDailyStartingCash[0, 1];
    cashTill[1] = registerDailyStartingCash[1, 1];
    cashTill[2] = registerDailyStartingCash[2, 1];
    cashTill[3] = registerDailyStartingCash[3, 1];
}

// The MakeChange method manages the money till during each transaction. It updates the till and returns a message to the main program.
// The MakeChange method accepts a cash payment and then determines how many bills of each denomination must be returned to the customer.
// MakeChange first checks that the customer's payment covers the transaction.
// If sufficient, it determines the change using the largest to smallest bill denominations.
static void MakeChange(int cost, int[] cashTill, int twenties, int tens = 0, int fives = 0, int ones = 0)
{
    // Calculate the amountPaid before modifying the till
    int amountPaid = twenties * 20 + tens * 10 + fives * 5 + ones;

    // Perform checks before modifying the till
    if (amountPaid < cost)
        throw new InvalidOperationException("Not enough money provided to complete the transaction.");

    int changeNeeded = amountPaid - cost;

    // Now modify the till only if the transaction can be completed
    cashTill[3] += twenties;
    cashTill[2] += tens;
    cashTill[1] += fives;
    cashTill[0] += ones;

     // If the transaction cannot be completed due to insufficient change, revert the till modification
    try
    {
        Console.WriteLine("Cashier Returns:");
        while (changeNeeded > 0)
        {
            if (changeNeeded >= 20 && cashTill[3] > 0)
            {
                cashTill[3]--;
                changeNeeded -= 20;
                Console.WriteLine("\t A twenty");
            }
            else if (changeNeeded >= 10 && cashTill[2] > 0)
            {
                cashTill[2]--;
                changeNeeded -= 10;
                Console.WriteLine("\t A ten");
            }
            else if (changeNeeded >= 5 && cashTill[1] > 0)
            {
                cashTill[1]--;
                changeNeeded -= 5;
                Console.WriteLine("\t A five");
            }
            else if (changeNeeded >= 1 && cashTill[0] > 0)
            {
                cashTill[0]--;
                changeNeeded -= 1;
                Console.WriteLine("\t A one");
            }
             else
            {
                // Determine the denomination that is missing
                string missingDenomination = (changeNeeded >= 20) ? "twenty" : 
                                             (changeNeeded >= 10) ? "ten" : 
                                             (changeNeeded >= 5) ? "five" : "one";

                // If no appropriate denomination is available, throw an exception and revert changes
                throw new InvalidOperationException($"The till is unable to make change for the cash provided! Out of {missingDenomination} dollar bills! Store closed!");
            }
        }

        // If all change is given successfully, print transaction success message
        Console.WriteLine("Customer has been given change!");
    }
    catch (InvalidOperationException e)
    {
        // Revert the till to its original state before the transaction
        cashTill[3] -= twenties;
        cashTill[2] -= tens;
        cashTill[1] -= fives;
        cashTill[0] -= ones;

        // Re-throw the exception for higher-level handling
        throw new InvalidOperationException(e.Message);
    }
}


// The LogTillStatus method uses the cashTill array to report the current contents of the till.
static void LogTillStatus(int[] cashTill)
{
    Console.WriteLine("The till currently has:");
    Console.WriteLine($"{cashTill[3] * 20} in twenties");
    Console.WriteLine($"{cashTill[2] * 10} in tens");
    Console.WriteLine($"{cashTill[1] * 5} in fives");
    Console.WriteLine($"{cashTill[0]} in ones");
    Console.WriteLine();
}

// The TillAmountSummary method uses the cashTill array to calculate of the current cash balance that's available in till.
static string TillAmountSummary(int[] cashTill)
{
    return $"The till has {cashTill[3] * 20 + cashTill[2] * 10 + cashTill[1] * 5 + cashTill[0]} dollars";

}
