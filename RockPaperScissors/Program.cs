var player1 = new Player("John");
var player2 = new Player("Eunhye");

var round = new Round(new[] { player1, player2 });
var winners = round.Play();

var winnerString = "";
foreach (var winner in winners)
{
    winnerString += winner.Name;

    winnerString += winner == winners[^1] ? "." : ", ";
}

Console.WriteLine($"축하합니다, {winnerString}. 당신이 이겼습니다.");



enum Action
{
    Rock,
    Paper,
    Scissors
}

class Player
{
    public string Name { get; }

    public Player(string name)
    {
        Name = name;
    }

    public Action GetAction()
    {
        Console.Write($"{Name}, 가위, 바위, 보 중에 하나 고르세요:    ");

        string input;
        Action? result;

        do
        {
            input = Console.ReadLine()!;
            result = input.ToLower() switch
            {
                "바위" => Action.Rock,
                "보" => Action.Paper,
                "가위" => Action.Scissors,
                _ => null
            };
        } while (result == null);

        return (Action)result;
    }
}

internal class Round
{
    private static List<Player> GetWinners(List<Player> rocks, List<Player> papers, List<Player> scissors)
    {
        int rockPlayed = rocks.Count > 0 ? 1 : 0;
        int paperPlayed = papers.Count > 0 ? 1 : 0;
        int scissorPlayed = scissors.Count > 0 ? 1 : 0;
        
        if (rockPlayed + paperPlayed + scissorPlayed > 2)
        {
            // if everything was played, it is a draw.
            return new List<Player>();
        }
        else if (rockPlayed + paperPlayed + scissorPlayed <= 1)
        {
            // if only one is played, it is a draw
            return new List<Player>();
        }
        else if (rockPlayed == 1)
        {
            return scissorPlayed == 1 ? rocks : papers;
        }
        else
        {
            // rock didn't play, so paper and scissors did. scissors wins
            return scissors;
        }
        
    }
    
    public Player[] Players { get; }

    public Round(Player[] players)
    {
        Players = players;
    }

    /// <summary>
    /// Play a round of rock paper scissors
    /// </summary>
    /// <returns>
    /// Returns the winners of the round.
    /// If there are no winners, returns an empty array.
    /// </returns>
    public List<Player> Play()
    {
        List<Player> scissors = new();
        List<Player> papers = new();
        List<Player> rocks = new();
        
        foreach (var player in Players)
        {
            var action = player.GetAction();
            
            switch (action)
            {
                case Action.Rock:
                    rocks.Add(player);
                    break;
                case Action.Paper:
                    papers.Add(player);
                    break;
                case Action.Scissors:
                    scissors.Add(player);
                    break;
            }
        }

        return GetWinners(rocks, papers, scissors);
    }
}