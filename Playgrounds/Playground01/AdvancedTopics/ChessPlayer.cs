namespace AdvancedTopics
{
    public class ChessPlayer
    {
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"{Id,3}| Name: {FirstName + " " + LastName,30}, Rating: {Rating}, Country: {Country,4}, Born: {BirthYear,5}";
        }

        public static ChessPlayer ParseFideData(string line)
        {
            string[] parts = line.Split(';');
            return new ChessPlayer()
            {
                Id          = int.Parse(parts[0].Trim()),
                FirstName   = parts[1].Split(',')[1].Trim(),
                LastName    = parts[1].Split(',')[0].Trim(),
                Country     = parts[3].Trim(),
                Rating      = int.Parse(parts[4].Trim()),
                BirthYear   = int.Parse(parts[6].Trim())
            };
        }
    }
}
