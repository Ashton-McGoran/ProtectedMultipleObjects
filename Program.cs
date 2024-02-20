using System;

namespace ProtectedMultipleObjects
{
    class Club
    {
        protected string name;
        protected string location;
        protected string[] members;

        public Club()
        {
            name = "Default Club";
            location = "Unknown";
            members = new string[0];
        }

        public Club(string name, string location, string[] members)
        {
            this.name = name;
            this.location = location;
            this.members = members;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetLocation()
        {
            return location;
        }

        public void SetLocation(string location)
        {
            this.location = location;
        }

        public string[] GetMembers()
        {
            return members;
        }

        public void SetMembers(string[] members)
        {
            this.members = members;
        }

        public virtual void AddData()
        {
            Console.WriteLine("Adding data to Club");
        }

        public virtual void DisplayData()
        {
            Console.WriteLine($"Name: {name}, Location: {location}, Members: {string.Join(", ", members)}");
        }
    }

    class SportsClub : Club
    {
        protected string sport;
        protected int teamCount;

        public SportsClub() : base()
        {
            sport = "Unknown";
            teamCount = 0;
        }

        public SportsClub(string name, string location, string[] members, string sport, int teamCount) : base(name, location, members)
        {
            this.sport = sport;
            this.teamCount = teamCount;
        }

        public string GetSport()
        {
            return sport;
        }

        public void SetSport(string sport)
        {
            this.sport = sport;
        }

        public int GetTeamCount()
        {
            return teamCount;
        }

        public void SetTeamCount(int teamCount)
        {
            this.teamCount = teamCount;
        }

        public override void AddData()
        {
            base.AddData();
            Console.WriteLine("Adding data to Sports Club");
        }

        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine($"Sport: {sport}, Team Count: {teamCount}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of clubs:");
            int numClubs = Convert.ToInt32(Console.ReadLine());

            Club[] clubs = new Club[numClubs];
            SportsClub[] sportsClubs = new SportsClub[numClubs];

            for (int i = 0; i < numClubs; i++)
            {
                Console.WriteLine($"\nEnter details for Club {i + 1}:");
                Console.WriteLine("Enter club name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter club location:");
                string location = Console.ReadLine();
                Console.WriteLine("Enter number of members:");
                int memberCount = Convert.ToInt32(Console.ReadLine());
                string[] members = new string[memberCount];
                for (int j = 0; j < memberCount; j++)
                {
                    Console.WriteLine($"Enter member {j + 1} name:");
                    members[j] = Console.ReadLine();
                }

                clubs[i] = new Club(name, location, members);
                clubs[i].AddData();

                Console.WriteLine("Enter club sport:");
                string sport = Console.ReadLine();
                Console.WriteLine("Enter team count:");
                int teamCount = Convert.ToInt32(Console.ReadLine());
                sportsClubs[i] = new SportsClub(name, location, members, sport, teamCount);
                sportsClubs[i].AddData();
            }

            Console.WriteLine("\nClub Details:");
            for (int i = 0; i < numClubs; i++)
            {
                Console.WriteLine($"\nDetails for Club {i + 1}:");
                clubs[i].DisplayData();
                sportsClubs[i].DisplayData();
            }
        }
    }
}
