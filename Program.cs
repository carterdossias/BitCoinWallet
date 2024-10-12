namespace BitCoinWallet;

internal class Program
{
    //Class level field accessible by all methods
    static decimal balance = 1000.00m; // Initial balance

    public static void Main(string[] args)
    {
        Console.WriteLine($"************************************************");
        Console.WriteLine(" Welcome to your Bitcoin Wallet!");
        do
        {
            string choice = ShowMenu();

            if (choice == "1")
            {
                ShowBalance(); //executes show balance method
            }
            else if (choice == "2")
            {
                ReceiveBitcoin(); //executes receiveBitcoin method
                ShowBalance(); //executes show balance method
            }
            else if (choice == "3")
            {
                SendBitcoin(); //executes SendBitcoin Method
                ShowBalance();//executes show balance method
            }
            else if (choice == "4")
            {
                Exit(); // Executes exit method
                break; //Breaks out of the top level loop to end the program
            }
            else
            {
                Console.WriteLine($"************************************************");
                Console.WriteLine(" Invalid choice. Please select a valid option.");
            }
            //End Loop
        }
        while (true); // Loops infinitely until we reach BREAK 
    }


    private static String ShowMenu()
    {
        Console.WriteLine($"************************************************");
        Console.WriteLine(" Bitcoin Wallet Menu:");
        Console.WriteLine("  1. Check Balance");
        Console.WriteLine("  2. Receive Bitcoin");
        Console.WriteLine("  3. Send Bitcoin");
        Console.WriteLine("  4. Exit");

        Console.Write(" Please select an option: ");
        return Console.ReadLine();
    }

    static void ShowBalance()
    {
        Console.WriteLine($"************************************************");
        Console.WriteLine($" Your current balance is: {balance:F8} BTC.");
    }

    static void ReceiveBitcoin()
    {
        decimal receiveAmount;
        Console.Write(" Enter the amount of Bitcoin to receive: ");
        if (decimal.TryParse(Console.ReadLine(), out receiveAmount))
        {
            if (receiveAmount > 0)
            {
                //If the amount is valid, it will be added to the balance. A "Successfully received" message with the amount will be displayed.
                balance += receiveAmount;
                Console.WriteLine($"Successfully received {receiveAmount}");
            }
            else
            {
                //The amount must be positive, otherwise the message "Receive amount must be positive." will be displayed.
                Console.WriteLine("Receive amount must be positive");
            }

        }
        else
        {
            Console.WriteLine(" Invalid amount.");
        }
    }

    static void SendBitcoin()
    {

        Console.Write(" Enter the amount of Bitcoin to send: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal sendAmount))
        {
            if (sendAmount > 0)
            {
                if (sendAmount <= balance)
                {
                    //If the amount is valid, it will be subtracted from the balance.  A "Successfully sent" message with the amount will be displayed.
                    balance -= sendAmount;
                    Console.WriteLine($"Successfully sent {sendAmount}");
                }
                else
                {
                    //The amount must be less than or equal to the wallet balance, otherwise the message "Insufficient funds." will be displayed.
                    Console.WriteLine("Insufficient funds");
                }
            }
            else
            {
                //The amount must be positive, otherwise the message "Send amount must be positive." will be displayed.
                Console.WriteLine("Send amount must be positive");
            }
        }
        else
        {
            //The amount must be numeric, otherwise the message "Invalid amount." will be displayed.
            Console.WriteLine(" Invalid amount.");
        }

    }

    static void Exit()
    {
        Console.WriteLine("Thank you for using your Bitcoin Wallet. Goodbye!");
    }

}

