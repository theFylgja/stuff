//you can use this to make commands easier in console applications
//The best way to implement is :
Command cmd = new Command(next.Cmd);
//this will display "cmd>" in the console, after which you can type the actual command and using the method above will directly convert it into a Command object with three parts
//The command class has three major parts: the actual command(Cmd), and argument following it(Arg) and another argument, which is not required though(Post)
// so a command should look something like this:
// open file : file.txt
//In this case, Command would be open, Arg would be file and Post would be file.txt
// NOTE: There has to be a ':' before the post, else it won't recognize
//There will be a ToolBox library soon to use this concept.

public class Command
    {
        public string Cmd { get; set; }
        public string Arg { get; set; }
        public string Post { get; set; }
        public Command(string line)
        {
            char[] temp = line.ToCharArray();
            bool ext = false;
            bool done = false;
            int ext_start = 0;
            for(int i = 0; i < temp.Length; i++)
            {
                if(temp[i] == ':')
                {
                    ext = true;
                    ext_start = i;
                }
            }
            for(int i = 0; i < temp.Length; i++)
            {
                if(temp[i] == ' ' && done == false)
                {
                    Cmd = line.Substring(0, i);
                    if(ext == true)
                    {
                        Arg = line.Substring(i, ext_start - i);
                        Post = line.Substring(ext_start + 1);
                    }
                    else
                    {
                        Arg = line.Substring(i);
                        Post = null;
                    }
                    done = true;
                }
            }

            Cmd = Shorten(Cmd);
            if (Arg != null)
            {
                Arg = Shorten(Arg);
            }
            if (Post != null)
            {
                Post = Shorten(Post);
            }
        }
        //The shorten method just removes spaces at the beginning and end of a string, so it makes console applications more clean by removing space sensitivity
        private string Shorten(string input)
        {
            while (input.Substring(0, 1) == " ")
            {
                input = input.Substring(1);
            }
            while (input.Substring(input.Length - 1) == " ")
            {
                input = input.Substring(0, input.Length - 1);
            }
            return input;
        }
    }


//use this for Input or messages. If you use it together with the Command class above, you pretty much just need to switch the Command.Cmd

public class Next
    {
        public string Cmd()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("cmd>    ");
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }
        public string Arg()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("arg>    ");
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }
        public void Title(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Adv(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Err(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }


//The shorten method just removes spaces at the beginning and end of a string, so it makes console applications more clean by removing space sensitivity
public class Other
{
        private string Shorten(string input)
        {
            while (input.Substring(0, 1) == " ")
            {
                input = input.Substring(1);
            }
            while (input.Substring(input.Length - 1) == " ")
            {
                input = input.Substring(0, input.Length - 1);
            }
            return input;
        }
}
