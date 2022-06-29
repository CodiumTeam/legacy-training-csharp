namespace Tennis
{
    public class TennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            if (HasSameScore())
            {
                return CalculateScoreWithSameScore();
            }

            if (IsAdvantage())
            {
                return CalculateAdvantageScore();
            }

            if (IsWin())
            {
                return CalculateWinScore();
            }

            return CalculateRegularScore();
        }

        private bool HasSameScore()
        {
            return m_score1 == m_score2;
        }

        private string CalculateScoreWithSameScore()
        {
            return m_score1 switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }

        private bool IsAdvantage()
        {
            return IsAdvantageOrWin() && Math.Abs(DifferenceOfScores()) == 1;
        }

        private bool IsAdvantageOrWin()
        {
            return m_score1 >= 4 || m_score2 >= 4;
        }

        private string CalculateAdvantageScore()
        {
            return DifferenceOfScores() == 1 ? "Advantage player1" : "Advantage player2";
        }

        private bool IsWin()
        {
            return IsAdvantageOrWin() && Math.Abs(DifferenceOfScores()) != 1;
        }

        private string CalculateWinScore()
        {
            return DifferenceOfScores() >= 2 ? "Win for player1" : "Win for player2";
        }

        private string CalculateRegularScore()
        {
            string CalculateScore(int score)
            {
                return score switch
                {
                    0 => "Love",
                    1 => "Fifteen",
                    2 => "Thirty",
                    3 => "Forty"
                };
            }

            return CalculateScore(m_score1) + "-" + CalculateScore(m_score2);
        }

        private int DifferenceOfScores()
        {
            return m_score1 - m_score2;
        }
    }
}