using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{    
    class Player : Controller
    {
        // Variables
        // -------------------------------------------
        Progress progress = new Progress();
        Text text = new Text();

        // Singleton
        // -------------------------------------------
        private static Player instance;
        public static Player GetInstance()
        {
            if (instance == null) instance = new Player();
            return instance;
        }


        // Methodology
        // -------------------------------------------

        // Initializes Player at Start of Game
        public void InitializePlayer(string name, Classes _class)
        {
            // Generates a new Player Profile
            profile = new Profile()
            {
                Name = name,
                _Class = _class,                
                _Stats  = _class.stats,
                Level = 1,
                Experience = 0
            };

            for (int i = 0; i < profile._Class.activeAbilities.Length; i++)
            {
                profile.Abilities.Add(profile._Class.activeAbilities[i]);
            }

            // Set up Entity
            entity = new Entity()
            {
                controller = this,
                maxHealth = profile._Stats.Health,
                currentHealth = profile._Stats.Health,
                maxEnergy = profile._Stats.Energy,
                currentEnergy = profile._Stats.Energy,
            };
        }

        // Handles Experience Gain and Leveling Up
        public void AddExperience(int amount)
        {
            // Cannot lose experience
            if (amount < 0) return;

            // Add the alloted experience amount to current experience
            profile.Experience += amount;

            // If it is equal to or greater than the required amount, level up
            if (profile.Experience >= (100 * Math.Pow(2, profile.Level - 2)))
            {
                profile.Level += 1;
                profile.Experience = 0;
                profile._Stats += profile._Class.statGrowth;
            }           
        }

        public void CreatePlayer()
        {
            // Desginating a Name
            // -------------------------------------------
            Console.Clear();
            text.CenterText("Designate a name for yourself: ");
            Console.CursorTop = (Console.WindowHeight / 2) + 2;
            Console.CursorLeft = (Console.WindowWidth / 2) - 3;
            string playerName = Console.ReadLine();
            System.Threading.Thread.Sleep(50);
            Console.Clear();

            bool prompt = true;
            while (prompt == true)
            {
                text.CenterText("Is this correct?");
                Console.CursorTop = (Console.WindowHeight / 2) + 2;
                Console.CursorLeft = (Console.WindowWidth / 2) - (playerName.Length / 2);
                Console.WriteLine(playerName);

                Console.CursorTop = (Console.WindowHeight / 2) + 6;
                Console.CursorLeft = (Console.WindowWidth / 2) - (text.YesNo().Length / 2);
                Console.WriteLine(text.YesNo());

                var input = Console.ReadKey();

                switch (input.KeyChar)
                {
                    case 'Y':
                    case 'y': prompt = false; break;
                    case 'N':
                    case 'n': CreatePlayer(); prompt = false; break;
                    default: break;
                }
            }

            // Selecting Your Class
            // -------------------------------------------       
            Classes _class = new Striker();

            bool classPrompt = true;
            while (classPrompt)
            {
                Console.Clear();
                text.CenterText("Please Select a Class\n\n");
                Console.CursorTop = (Console.WindowHeight / 2) + 2;

                string classList = "1.Striker\t2.Predator\t3.Advancer\t4.Sentinel\t5.Berzerker\t6.Siren\n" +
                    "7.Warden\t8.Ranger\t9.Gunslinger\tq.Oracle\tw.Defiler\n" +
                    "e.Dancer\tr.Reaver\tt.Arbiter\ty.Harbinger";
                Console.CursorLeft = (Console.WindowWidth / 2) - (classList.Length / 2) - 12;
                Console.WriteLine(classList);

                var classInput = Console.ReadKey();
                Console.CursorTop = (Console.WindowHeight / 2) + 4;
                switch (classInput.KeyChar)
                {
                    case '1': _class = new Striker(); break;
                    case '2': _class = new Predator(); break;
                    case '3': _class = new Avenger(); break;
                    case '4': _class = new Sentinel(); break;
                    case '5': _class = new Berzerker(); break;
                    case '6': _class = new Siren(); break;
                    case '7': _class = new Warden(); break;
                    case '8': _class = new Ranger(); break;
                    case '9': _class = new Gunslinger(); break;
                    case 'q': _class = new Oracle(); break;
                    case 'w': _class = new Defiler(); break;
                    case 'e': _class = new Dancer(); break;
                    case 'r': _class = new Reaver(); break;
                    case 't': _class = new Arbiter(); break;
                    case 'y': _class = new Harbinger(); break;
                    
                    default: break;
                }

                bool finalizePrompt = true;
                while (finalizePrompt == true)
                {
                    Console.Clear();
                    text.CenterText(_class.classDescription);
                    Console.CursorTop = (Console.WindowHeight / 2) + 2;

                    string s = "Choose this class?";
                    Console.CursorLeft = (Console.WindowWidth / 2) - (s.Length / 2);
                    Console.WriteLine(s);

                    Console.CursorTop = (Console.WindowHeight / 2) + 6;
                    Console.CursorLeft = (Console.WindowWidth / 2) - (text.YesNo().Length / 2);
                    Console.WriteLine(text.YesNo());

                    var input = Console.ReadKey();

                    switch (input.KeyChar)
                    {
                        case 'Y':
                        case 'y': finalizePrompt = false; classPrompt = false; break;
                        case 'N':
                        case 'n': finalizePrompt = false; break;
                        default: break;
                    }
                }
            }

            Console.Clear();
            InitializePlayer(playerName, _class);
        }

        

        /// <summary>
        /// Everything beyond this is old stuff and should be updated.
        /// </summary>

        public void UpdatePlayer()
        {
            Console.SetCursorPosition((Draw.GetInstance().gameWidth * 11 / 50), (Draw.GetInstance().gameHeight / 8) + 2);
            progress.PlayerExperience(profile.Experience, Convert.ToInt32(100 * Math.Pow(2, profile.Level - 2))); 
            System.Threading.Thread.Sleep(20); 
        }

       
    }
}
