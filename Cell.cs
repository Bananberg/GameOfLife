using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Cell
    {
        bool m_alive;
        Position m_position;
        
        public Cell(Position p_pos)
        {
            m_position = p_pos;
            m_alive = false; 
        }

        public void SetAlive(bool alive)
        {
            m_alive = alive; 
        }
    }
}

struct Position
{
    int x, y;
}
