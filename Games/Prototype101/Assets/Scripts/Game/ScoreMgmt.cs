public static class ScoreMgmt {

    public static int _P1Score, _P2Score;

    public static int GetScore(string player)
    {
        if (player.Equals("Player2"))
        {
            return _P2Score;
        }
        else
        {
            return _P1Score;
        }
    }

    public static void SetScore(string player, int score)
    {
        if (player.Equals("Player2"))
        {
            _P2Score = score;
        }
        else
        {
            _P1Score = score;
        }
    }

    public static void IncreaseScore(string player, int points)
    {
        if (player.Equals("Player2"))
        {
            _P2Score += points;
        }
        else
        {
            _P1Score += points;
        }
    }

    public static void DecreaseScore(string player, int points)
    {
        if (player.Equals("Player2"))
        {
            _P2Score -= points;
        }
        else
        {
            _P1Score -= points;
        }
    }

    public static void ClearScores()
    {
        _P1Score = 0;
        _P2Score = 0;
    }
}
