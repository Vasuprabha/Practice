using System;
using System.Collections.Generic;
using System.Linq;

public class cardHolder
{
    String cardNumber;
    int pinNumber;
    String userName;
    double balance;

    public cardHolder(String cardNumber, int pinNumber, String userName, double balance)
    {
        this.cardNumber = cardNumber;
        this.pinNumber = pinNumber;
        this.userName = userName;
        this.balance = balance;
    }

    public String getCardNumber()
    {
        return cardNumber;
    }

    public void setCardNumber(String newCardNumber)
    {
        cardNumber = newCardNumber;
    }
    public int getPinNumber()
    {
        return pinNumber;
    }
    public void setPinNumber(int newPinNumber)
    {
        pinNumber = newPinNumber;
    }
    public String getUserName()
    {
        return userName;
    }

    public void setUserName(String newUserName)
    {
        userName = newUserName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void SetBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            string input = Console.ReadLine();
            if (input != null)
            {
                double deposit = Double.Parse(input);
                currentUser.SetBalance(currentUser.getBalance() + deposit);
                Console.WriteLine("Your new balance is : " + currentUser.getBalance());
            }
            else
            {
                Console.WriteLine("Invalid input for deposit amount.");
            }
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw? ");
            string input = Console.ReadLine();
            if (input != null)
            {
                double withdraw = Double.Parse(input);
                if (currentUser.getBalance() < withdraw)
                {
                    Console.WriteLine("Insufficient balance!");
                }
                else
                {
                    currentUser.SetBalance(currentUser.getBalance() - withdraw);
                    Console.WriteLine("Amount rupees " + withdraw + " debited successfully!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for withdrawal amount.");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance : " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("123456",1234,"John",1500.00));
        cardHolders.Add(new cardHolder("234567",5678,"Joe",1000.00));
        cardHolders.Add(new cardHolder("112233",1111,"Prabha",500.00));
        cardHolders.Add(new cardHolder("445566",2222,"Anu",5000.00));
        cardHolders.Add(new cardHolder("115577",3333,"Priyanka",200.00));
        cardHolders.Add(new cardHolder("98765",4444,"Gayathri",2000.00));


        Console.WriteLine("Welcome to SampleATM");
        Console.WriteLine("Please insert your debit card ");
        String debitCardNumber;
        cardHolder currentUser = null;

        while (true)
        {
            try
            {
                debitCardNumber = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(args => args.getCardNumber() == debitCardNumber);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }

        Console.WriteLine("Please Enter your Pin ");
        int userPin = 0;
        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                if (input != null)
                {
                    userPin = int.Parse(input);
                    if (currentUser.getPinNumber() == userPin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Pin. Please try again");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for Pin.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input for Pin. Please try again");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getUserName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                string input = Console.ReadLine();
                if (input != null)
                {
                    option = int.Parse(input);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Please try again");
            }
            if (option == 1)
            {
                deposit(currentUser);
            }
            else if (option == 2)
            {
                withdraw(currentUser);
            }
            else if (option == 3)
            {
                balance(currentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please select correct option...");
                
            }
        } while (option != 4);
        Console.WriteLine("Thank you! Have a nice day");
    }

    
}
