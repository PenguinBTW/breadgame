using System.Reflection.Metadata;

namespace breadgame;

class Make {
   public string name;
   public string loadsave;
   public string savegame;
   public bool repeat;
   public Int32 xp;
   public Int32 randomnumber;
   public string answer;
   public string breadtype;
   public string likebuy;
   public string purch;

   public void makebread() {
    Random rnd = new Random();
		for (int j = 0; j < 1; j++)
		{
			randomnumber = rnd.Next(1, 5);
            xp += randomnumber;
            Console.WriteLine("You made " + breadtype + " which was rated " + randomnumber + "/4 giving you " + randomnumber + " xp");
            Console.WriteLine("press enter to continue");
		}
   } 
   public void makeroll() {
    Random rnd = new Random();
		for (int j = 0; j < 1; j++)
		{
			randomnumber = rnd.Next(1, 6);
            xp += randomnumber;
            Console.WriteLine("You made " + breadtype + " which was rated " + randomnumber + "/5 giving you " + randomnumber + " xp");
            Console.WriteLine("press enter to continue");
		}
   }
    public void makebaguette() {
    Random rnd = new Random();
		for (int j = 0; j < 1; j++)
		{
			randomnumber = rnd.Next(2, 7);
            xp += randomnumber;
            Console.WriteLine("You made " + breadtype + " which was rated " + randomnumber + "/6 giving you " + randomnumber + " xp");
            Console.WriteLine("press enter to continue");
		}
   }
   public void makesourdough() {
    Random rnd = new Random();
		for (int j = 0; j < 1; j++)
		{
			randomnumber = rnd.Next(3, 10);
            xp += randomnumber;
            Console.WriteLine("You made " + breadtype + " which was rated " + randomnumber + "/10 giving you " + randomnumber + " xp");
            Console.WriteLine("press enter to continue");
		}
   }

}

class Program
{
    static void Main(string[] args)
    {
        Make user = new Make();
        Console.WriteLine("Do you want to load from save, yes or no");
        user.loadsave = Console.ReadLine();
        if (user.loadsave == "yes") {
            TextReader tr = new StreamReader("SavedGame.bread");
            string breadtypestring = tr.ReadLine();
            string xpstring = tr.ReadLine();
            string namestring = tr.ReadLine();
            user.xp = Convert.ToInt32(xpstring);
            user.breadtype = breadtypestring;
            user.name = namestring;
            tr.Close();
        } else {
            user.breadtype = "bread"; 
            Console.WriteLine("Hello and welcome to the bread game, what is your name");
            user.name = Console.ReadLine();
        }
        user.repeat = true;
        
        Console.WriteLine("Hello " + user.name + " lets begin");
        while (user.repeat == true) {
        Console.WriteLine("To make your best unlocked bread say make, to list all commands say help\nTo buy new bread say shop");
        user.answer = Console.ReadLine();
        if (user.answer == "make") {
            if (user.breadtype == "bread") {
                user.makebread();
            } else if (user.breadtype == "roll") {user.makeroll(); }
            else if (user.breadtype == "baguette") {user.makebaguette();}
            else if (user.breadtype == "sourdough") {user.makesourdough();}
        }else if (user.answer == "help")
        {
            Console.WriteLine("\nxp - to view current xp\nbread type - view current best unlocked bread type\nmake - make best bread you own\nshop - lets you buy new bread with xp\nexit - quit the program\n\npress enter to continue");
        }else if (user.answer == "xp")
        {
            Console.WriteLine("your current xp is " + user.xp);
            Console.WriteLine("press enter to continue");
        }else if (user.answer == "bread type")
        {
            Console.WriteLine("Your best bread type is " + user.breadtype);
            Console.WriteLine("press enter to continue");
        } else if (user.answer == "shop")
        {
            Console.WriteLine("Your current bread type is " + user.breadtype + "\n0 Bread - default\n1 Roll - 5xp\n2 Baguette - 20xp\n3 Sourdough - 100xp\n\ncurrent xp = " + user.xp);
            Console.WriteLine("Would you like to buy a new bread, yes or no");
            user.likebuy = Console.ReadLine();
            if (user.likebuy == "yes") {
                Console.WriteLine("Say the number of the bread you would like to buy\n\nDO NOT BUY A WORSE BREAD THAN YOUR CURRENT, IT WILL BE REPLACED");
                user.purch = Console.ReadLine();
                if (user.purch == "1") { if (user.xp > 5) { user.xp -= 5;  user.breadtype = "roll"; Console.WriteLine("Your new bread type is a roll\nyou have " + user.xp + " xp left\n\nPress enter to go back");}
                else if (user.xp < 5) { Console.WriteLine("Sorry you only have " + user.xp + " xp");}} 
                else if (user.purch == "2") { if (user.xp > 20) { user.xp -= 20;  user.breadtype = "baguette"; Console.WriteLine("Your new bread type is a baguette\nyou have " + user.xp + " xp left\n\nPress enter to go back");}
                else if (user.xp < 20) { Console.WriteLine("Sorry you only have " + user.xp + " xp");}}
                else if (user.purch == "3") { if (user.xp > 100) { user.xp -= 100; user.breadtype = "sourdough"; Console.WriteLine("Your new bread type is a sourdough\nyou have " + user.xp + " xp left\n\nPress enter to go back");}
                else if (user.xp < 100) { Console.WriteLine("Sorry you only have " + user.xp + " xp");}}
                else {Console.WriteLine("Sorry thats not an option\n\npress enter to go back");}
                
            } else { Console.WriteLine("\npress enter to go back");}
            
        }else if (user.answer == "exit")
        {
            Console.WriteLine("Would you like to save your game (this will overwrite your previous save)\n say yes or no");
            user.savegame = Console.ReadLine();
            if (user.savegame == "yes") { 
                TextWriter tw = new StreamWriter("SavedGame.bread");
                tw.WriteLine(user.breadtype);
                tw.WriteLine(user.xp);
                tw.WriteLine(user.name);
                tw.Close();
            }

           user.repeat = false;
           Console.WriteLine("Thank you for playing, goodbye");
        } else {Console.WriteLine("sorry thats not a command, press enter to continue");}
        user.answer = "";

        Console.ReadKey();
        }
    }
}

