using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCourseWork
{
    public class PlayerSender
    {
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public PlayerSender(Player player1, Player player2)
        {
            this.player1 = player1.Clone() as Player;
            this.player2 = player2.Clone() as Player;
        }
        public byte[] Output()
        {
            List<byte> list = new List<byte>();
            list.Add((byte)player1.List.Count);
            for (int i = 0; i < player1.List.Count; i++)
                list.Add(player1.List[i].ID);
            list.Add((byte)player2.List.Count);
            for (int i = 0; i < player2.List.Count; i++)
                list.Add(player2.List[i].ID);
            return list.ToArray();
        }
    }
}