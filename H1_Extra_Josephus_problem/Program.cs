namespace H1_Extra_Josephus_problem
{
    internal class Program
    {
        // DISCLAIMER! Used chat-gpt to figure out what a cyclist pattern is, as well as the math formula:
        // J(N, K) = (J(N - 1, K) + K - 1) % N + 1
        // N is the number of soldiers. K is the kill interval. J(N, K) is the position of the survivor.
        // Chat-gpt was not used to generate any of the code itself.

        static void Main()
        {
            // Calls the controller
            Controller();
        }

        #region Controllers

        static void Controller()
        {
            while (true)
            {
                // User input to handle the calculation
                NormalOutputView("Write soldier amount:");
                string soldiersStr = Console.ReadLine();

                // Validate the input of both soldier and interval
                if(!ValidInput(soldiersStr) || soldiersStr.Length == 0)
                {
                    NormalOutputView("ERROR\nWrite only numbers!");
                    continue;
                }

                int soldiers = int.Parse(soldiersStr);

                NormalOutputView("Write interval:");
                string intervalStr = Console.ReadLine();

                if (!ValidInput(intervalStr) || intervalStr.Length == 0)
                {
                    NormalOutputView("ERROR\nWrite only numbers!");
                    continue;
                }

                int interval = int.Parse(intervalStr);

                // Variable which will be outputted and used for calculations
                int survivor = 0;

                for (int i = 0; i < soldiers; i++)
                {
                    // Unsure if math is correct, but result is 31 if solders is 41 and interval is 3, which the assignment says it should be,
                    // however it does not look correct on the illustration, which is on the assignment

                    // Does some magic math
                    survivor = (survivor + interval - 1) % (i + 1) + 1;
                    ResultView(survivor);
                }
            }
        }

        static bool ValidInput(string readline)
        {
            // Only allow characters 0-9
            string validCharacters = "0123456789";

            // Bool to keep track of if any chars has not been a valid character.
            bool valid = true;

            // For each char in the readline string
            foreach (char line in readline.ToCharArray())
            { 
                // if validCharacters does not contain the char from readline then valid boolean is false
                if (!validCharacters.Contains(line))
                {
                    valid = false;
                }
            }

            // If valid is true then return true, else false
            if (valid)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region Views

        static void NormalOutputView(string text)
        {
            Console.WriteLine(text);
        }

        static void ResultView(int survivor)
        {
            Console.WriteLine($"The survivor is {survivor}");
        }

        #endregion
    }
}

/* All output if soldiers = 41 and interval = 3. Compare with illustration located on my github H1_Extra_Josephus_problem/H1_Extra_Josephus_problem/Illustration.jpg
1
2
2
1
4
1
4
7
1
4
7
10
13
2
5
8
11
14
17
20
2
5
8
11
14
17
20
23
26
29
1
4
7
10
13
16
19
22
25
28
31
 */
