using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filsparande
{
    class PlayerScore
    {
        private int score;
        private string name;

        public PlayerScore(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public int Score { get => score; set => score = value; }
        public string Name { get => name; set => name = value; }
    }
}
