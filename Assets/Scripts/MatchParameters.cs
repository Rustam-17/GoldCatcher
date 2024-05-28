public struct MatchParameters
{
    public string Team1Name { get; set; }
    public string Team2Name { get; set; }
    public string Score { get; set; }

    public MatchParameters(string team1Name, string team2Name, string score)
    {
        Team1Name = team1Name;
        Team2Name = team2Name;
        Score = score;
    }
}
