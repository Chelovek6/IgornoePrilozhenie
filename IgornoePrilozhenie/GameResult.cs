using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IgornoePrilozhenie
{
    public class GameResults
    {
        
        public string UserName { get; set; }
        public int GamersPoint { get; set; }
        public int OpponentDefeated { get; set; }

        public GameResults(string userName, int score1, int score2)
        {
            UserName = userName;
            GamersPoint = score1;
            OpponentDefeated = score2;
        }
    }
}
