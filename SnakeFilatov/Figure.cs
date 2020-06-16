using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeFilatov
{
    class Figure
    {
        protected List<point> pList;

        public void Drow()
        {
            foreach (point p in pList)
            {
                p.draw();
            }
        }
        internal bool IsHit(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }
        private bool IsHit(point point)
        {
            foreach (var p in pList)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}