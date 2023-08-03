using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();
        }

        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count { get { return this.Players.Count; } }
        //public int Count()
        //{
        //    return Players.Count;
        //}
        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            Players.Add(player);
            OpenPositions--;

            return $"Successfully added {player.Name} to the team. " +
                $"Remaining open positions: {OpenPositions}.";

        }
        public bool RemovePlayer(string name)
        {
            Player player = Players.FirstOrDefault(p => p.Name == name);
            bool isRemoved = Players.Remove(player);
            if (isRemoved == true)
            {
                OpenPositions++;
            }
            return isRemoved;
        }
        public int RemovePlayerByPosition(string position)
        {
            int countRemoved = Players.RemoveAll(p => p.Position == position);
            if (countRemoved > 0)
            {
                OpenPositions += countRemoved;
            }
            return countRemoved;
        }
        public Player RetirePlayer(string name)
        {
            if (this.Players.Any(p => p.Name == name))
            {
                Player retiredPlayer = this.Players.Find(p => p.Name == name);
                retiredPlayer.Retired = true;
                return retiredPlayer;
            }
            return null;
        }
        public List<Player> AwardPlayers(int games)
        {
            List<Player> playersAward = new List<Player>();
            playersAward = Players.Where(p => p.Games >= games).ToList();

            return playersAward;
        }
        public string Report()

            => $"Active players competing for Team {this.Name} from Group {this.Group}:" + Environment.NewLine +
                 string.Join(Environment.NewLine, this.Players.Where(p => !p.Retired));
        //List<Player> active = new List<Player>();
        //active = Players.Where(p => p.Retired == false).ToList();
        //StringBuilder sb = new StringBuilder();
        //sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
        //foreach (var item in active)
        //{
        //    sb.AppendLine(item.ToString());
        //}
        //return sb.ToString().TrimEnd();
        //string activePlayersInfo = string.Join(Environment.NewLine, Players.Where(p => !p.Retired).Select(p => p.ToString()));
        //return $"Active players competing for Team {Name} from Group {Group}:{Environment.NewLine}{activePlayersInfo}";

        //Console.WriteLine($"Active players competing for Team {Name} from Group {Group}:");
        //foreach (var item in active)
        //{
        //    Console.WriteLine(item.ToString());
        //}

    }
}
