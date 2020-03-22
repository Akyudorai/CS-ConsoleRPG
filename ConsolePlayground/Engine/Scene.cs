using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{

    public class Scene
    {
        public static Scene activeScene = null;
        public readonly List<Box2D> boxes = new List<Box2D>();

        public Menu menu = null;
        public Battle battle = null;


        public virtual void DrawScene() {}
        public virtual void DrawMenu() {}

        public virtual void LogPanel_2(string text, string text2) {}        
        public virtual void DrawHealthAndEnergy(Battle battle) {}        

        public void SetMenu(Menu menu)
        {
            this.menu = menu;
        }
    }
}
