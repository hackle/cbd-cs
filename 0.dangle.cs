public enum Result { Win, Loss, Tie }
public static class MatchResult 
{
    /* 
        Solution: 
        if my score is more than opponent's score, then *set* result to "Win",
        if my score is less than opponent's score, then *set* result to "Loss",
        otherwise, set result to "Tie",
        finally, return the result
        ...
    */
    public static Result Calculate(int myScore, int opponentScore)
    {
        Result result;

        if (myScore > opponentScore) {
            result = Result.Win;
        } else if (myScore < opponentScore) {
            result = Result.Loss;
        } else {
            result = Result.Tie;
        }

        return result;
    }

    /* 
        Let's be less imperative.
        if my score is more than opponent's score, then result is "Win",
        if my score is less than opponent's score, then result is "Loss",
        otherwise, result is "Tie"
        ...
    */
    public static Result matchResultNoAssign(int myScore, int opponentScore) 
    {
        if (myScore > opponentScore) {
            return Result.Win;
        } 
        
        if (myScore < opponentScore) {
            return Result.Loss;
        } 
        
        return Result.Tie;
    }

    /* 
        Given my score and opponent score, 
        the result must be one of the possibilities: a win, a loss or a tie
    */
    public static Result matchResult1(int myScore, int opponentScore) 
    {
        return Result.Tie;
    }

    /*
        Given my score and opponent score, 
        and the methods Win, Loss and Tie are calculated,
        the result can be found by trying all methods until success
    */
    public static Result matchResult2(int myScore, int opponentScore) 
    {
        return Result.Tie;
    }
}