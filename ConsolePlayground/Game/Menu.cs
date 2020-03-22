using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    public class Menu
    {
        public List<Option> commands;

        public class Option
        {
            public string dialog = "";
            public Event dialogEvent;

            public Option(string dialog, Event dialogEvent)
            {
                this.dialog = dialog;
                this.dialogEvent = dialogEvent;
            }

            public class Event
            {
                Action action;

                Action<Menu> action_MENU;
                Menu m;

                Action<Ability.Settings> action_ABILITY;
                Ability.Settings ability_settings;

                public Event(Action method)
                {
                    action = method;
                }
                
                public Event(Action<Menu> method, Menu menu)
                {
                    action_MENU = method;
                    m = menu;                    
                }

                public Event(Action<Ability.Settings> method, Ability.Settings settings)
                {
                    action_ABILITY = method;
                    ability_settings = settings;
                }
                
                public void Activate()
                {
                    if (action != null)
                    {
                        action.Invoke();
                    }

                    if (action_MENU != null)
                    {
                        action_MENU.Invoke(m);
                    }

                    if (action_ABILITY != null)
                    {
                        action_ABILITY.Invoke(ability_settings);
                    }
                }
            }
        }

        
    }
}
