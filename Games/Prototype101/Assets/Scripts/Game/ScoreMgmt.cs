public static class ScoreMgmt {

    public static int _P1Score, _P2Score;
    public static int _P1Deaths, _P2Deaths;
    public static int _CurLevel = 1;

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

    public static int GetDeaths(string player)
    {
        if (player.Equals("Player2"))
        {
            return _P2Deaths;
        }
        else
        {
            return _P1Deaths;
        }
    }

    public static void IncreaseDeaths(string player)
    {
        if (player.Equals("Player2"))
        {
            _P2Deaths++;
        }
        else
        {
            _P1Deaths++;
        }
    }

    public static void ClearDeaths()
    {
        _P1Deaths = 0;
        _P2Deaths = 0;
    }

    public static int GetLevel() { return _CurLevel; }
    public static void IncreaseLevel() { _CurLevel++; }
    public static void ClearLevel() { _CurLevel = 1; }
}
