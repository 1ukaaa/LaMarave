namespace ConsoleRPG
{
    class Gui
    {
        public static void Title(String str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            str = String.Format("==== {0} ====\n\n", str);

            Console.Write(str);
            Console.ResetColor();
        }

        public static void MenuTitle(String str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            str = String.Format("=== {0}\n", str);

            Console.Write(str);
            Console.ResetColor();
        }

        public static void MenuOption(int index, String str)
        {
            str = String.Format(" - ({0}) : {1}\n", index, str);

            Console.Write(str);
        }

        public static void Announcement(String str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            str = String.Format("\t(~) ({0})!\n", str);

            Console.Write(str);
            Console.ResetColor();
        }

        public static void GetInput(String str)
        {
            str = String.Format(" - {0} :", str);

            Console.Write(str);
        }

        public static int GetInputInt(String message)
        {
            Nullable<int> input = null;

            while (input == null)
            {
                try
                {
                    Gui.GetInput(message);

                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return input.Value;
        }
    }
}