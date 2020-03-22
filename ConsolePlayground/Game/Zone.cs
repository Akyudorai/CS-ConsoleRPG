using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    public enum ZoneType { Empty, Grassland, City }

    class Zone
    {
        public Box2D box;
        public Vectors.Vector2Int coords;
        public ConsoleColor background;
        public string text;
        public string zoneDescription;
        public ZoneType zone;

        public Menu zoneMenu;
        public string zoneDialog;

        public Zone parent;

        #region Default Constructor

        public Zone() {
            background = ConsoleColor.Black;
            zoneDescription = "The area is a vast openness with no discerning details to it.";
            box = new Box2D(new Vectors.Vector2Int(0, 0), 0, 0);
            zone = ZoneType.Empty;

            zoneDialog = "";
            zoneMenu = new Menu()
            {
                commands = new List<Menu.Option>
                {
                    new Menu.Option("Wait", null)
                }
            };
        }

        #endregion

        public void DrawText()
        {
            Console.SetCursorPosition(box.GetCentreX(), box.GetCentreY());
            {
                Console.Write(text);
            }
        }

        public virtual void GenerateRandomEvent() { }

        public class Event
        {
            public string zoneDialog = "There doesn't seem to be anything of interest here";
            public Option[] eventOptions = null;
            
            public Event() {}

            public class Option
            {
                public string text = "";

                public Option() { }
            }
        }

    }
    
    class Grassland : Zone
    {
        public Grassland()
        {
            box = new Box2D(new Vectors.Vector2Int(0, 0), 0, 0);
            background = ConsoleColor.DarkGreen;
            zoneDescription = "The area consists of a grassy terrain with some slight hills.";
            zone = ZoneType.Grassland;

            zoneDialog = "Nothing much to see here";
            zoneMenu = new Menu()
            {
                commands = new List<Menu.Option>
                {
                    new Menu.Option("Move Along", new Menu.Option.Event(new Action(Player.GetInstance().SetState)))
                }
            };
        }

        public override void GenerateRandomEvent()
        {
            Random r = new Random();
            int i = r.Next(0, 100);

            if (i >= 60)
            {
                // Battle Encounter
                Player.GetInstance().state = Controller.State.combat;
                if (Player.GetInstance().state == Controller.State.combat)
                {
                    Game.GetInstance().scene.battle = new Battle();
                    Game.GetInstance().scene.battle.BattleLoop();
                }

            }
        }
    }

    class City : Zone
    {
        private Zone[] subZones;

        public City()
        {
            box = new Box2D(new Vectors.Vector2Int(0, 0), 0, 0);
            background = ConsoleColor.DarkGray;
            zoneDescription = "You're in a city, filled with shops and things to do.";
            zone = ZoneType.City;

            // Private 
            subZones = new Zone[]
            {
                new Castle(this),
                new Guild(this),
                new Store(this),
                new Blacksmith(this),
                new Tavern(this)
            };

            zoneDialog = "As you explore the city, there are a multitude of activities to partake in.";
            zoneMenu = new Menu()
            {
                commands = new List<Menu.Option>
                {
                    new Menu.Option("Visit the Castle", new Menu.Option.Event(new Action<Menu>(SetMenu => Game.GetInstance().scene.SetMenu(subZones[0].zoneMenu)), subZones[0].zoneMenu)),
                    new Menu.Option("Visit the Adventurers Guild", new Menu.Option.Event(new Action<Menu>(SetMenu => Game.GetInstance().scene.SetMenu(subZones[1].zoneMenu)), subZones[1].zoneMenu)),
                    new Menu.Option("Visit the General Store", new Menu.Option.Event(new Action<Menu>(SetMenu => Game.GetInstance().scene.SetMenu(subZones[2].zoneMenu)), subZones[2].zoneMenu)),
                    new Menu.Option("Visit the Blacksmith", new Menu.Option.Event(new Action<Menu>(SetMenu => Game.GetInstance().scene.SetMenu(subZones[3].zoneMenu)), subZones[3].zoneMenu)),
                    new Menu.Option("Visit the Tavern", new Menu.Option.Event(new Action<Menu>(SetMenu => Game.GetInstance().scene.SetMenu(subZones[4].zoneMenu)), subZones[4].zoneMenu)),
                    new Menu.Option("Leave the City", new Menu.Option.Event(new Action(Player.GetInstance().SetState)))                    
                }
            };  
            
            
        }

        private class Castle : Zone
        {
            public Castle(Zone parent)
            {
                box = new Box2D(new Vectors.Vector2Int(0, 0), 0, 0);
                background = ConsoleColor.Black;
                zoneDescription = "You're in the city Castle.";
                zone = ZoneType.Empty;

                this.parent = parent;

                zoneDialog = "Guards stand vigilent as you walk the hallway.";
                zoneMenu = new Menu()
                {
                    commands = new List<Menu.Option>
                    {
                        new Menu.Option("Leave the Castle", new Menu.Option.Event(new Action<Menu>(SetMenu => Game.GetInstance().scene.SetMenu(parent.zoneMenu)), parent.zoneMenu))
                    }
                };
            }
        }

        private class Guild : Zone
        {
            public Guild(Zone parent)
            {
                box = new Box2D(new Vectors.Vector2Int(0, 0), 0, 0);
                background = ConsoleColor.Black;
                zoneDescription = "You're in the Adventurer's Guild.";
                zone = ZoneType.Empty;

                this.parent = parent;

                zoneDialog = "The Guild has a few people hanging around.";
                zoneMenu = new Menu()
                {
                    commands = new List<Menu.Option>
                    {
                        new Menu.Option("Check Quest Board", null),
                        new Menu.Option("Leave the Guild", new Menu.Option.Event(new Action<Menu>(SetMenu => Game.GetInstance().scene.SetMenu(parent.zoneMenu)), parent.zoneMenu))
                    }
                };
            }
        }

        private class Store : Zone
        {
            public Store(Zone parent)
            {
                box = new Box2D(new Vectors.Vector2Int(0, 0), 0, 0);
                background = ConsoleColor.Black;
                zoneDescription = "You're in the General Store.";
                zone = ZoneType.Empty;

                this.parent = parent;

                zoneDialog = "The owner greets you expectantly.";
                zoneMenu = new Menu()
                {
                    commands = new List<Menu.Option>
                    {
                        new Menu.Option("Buy wares", null),
                        new Menu.Option("Sell wares", null),
                        new Menu.Option("Leave the Shop", new Menu.Option.Event(new Action<Menu>(SetMenu => Game.GetInstance().scene.SetMenu(parent.zoneMenu)), parent.zoneMenu))
                    }
                };
            }
        }

        private class Blacksmith : Zone
        {
            public Blacksmith(Zone parent)
            {
                box = new Box2D(new Vectors.Vector2Int(0, 0), 0, 0);
                background = ConsoleColor.Black;
                zoneDescription = "You're at the Blacksmiths.";
                zone = ZoneType.Empty;

                this.parent = parent;

                zoneDialog = "The Blacksmith grunts as you approach, but stays focused on his work.";
                zoneMenu = new Menu()
                {
                    commands = new List<Menu.Option>
                    {
                        new Menu.Option("Leave the Blacksmiths", new Menu.Option.Event(new Action<Menu>(SetMenu => Game.GetInstance().scene.SetMenu(parent.zoneMenu)), parent.zoneMenu))
                    }
                };
            }
        }

        private class Tavern : Zone
        {
            public Tavern(Zone parent)
            {
                box = new Box2D(new Vectors.Vector2Int(0, 0), 0, 0);
                background = ConsoleColor.Black;
                zoneDescription = "You're in the Tavern.";
                zone = ZoneType.Empty;

                this.parent = parent;

                zoneDialog = "The Tavern is filled with people enjoying their time off.";
                zoneMenu = new Menu()
                {
                    commands = new List<Menu.Option>
                    {
                        new Menu.Option("Rest", null),
                        new Menu.Option("Leave the Tavern", new Menu.Option.Event(new Action<Menu>(SetMenu => Game.GetInstance().scene.SetMenu(parent.zoneMenu)), parent.zoneMenu))
                    }
                };
            }
        }
    }
}
