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

        public virtual void DrawScene() {}
        public virtual void DrawDialog() {}
    }
}
