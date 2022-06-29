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

            if (IsAdvantageOrWin())
            {
                return CalculateAdvantageOrWinScore();
            }

            return CalculateRegularScore();
        }

        private string CalculateRegularScore()
        {
            string score = "";
            int tempScore;

            int i = 1;
            if (i == 1) tempScore = m_score1;
            else
            {
                score += "-";
                tempScore = m_score2;
            }

            score += tempScore switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };

            i = 2;
            if (i == 1) tempScore = m_score1;
            else
            {
                score += "-";
                tempScore = m_score2;
            }

            score += tempScore switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };

            return score;
        }

        private string CalculateAdvantageOrWinScore()
        {
            string score;
            var minusResult = m_score1 - m_score2;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
            return score;
        }

        private bool IsAdvantageOrWin()
        {
            return m_score1 >= 4 || m_score2 >= 4;
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

        private bool HasSameScore()
        {
            return m_score1 == m_score2;
        }
    }
}
