namespace BlazorApp.Services;

public class VotingService
{
    private readonly List<VoteOption> _voteOptions = new()
    {
        new VoteOption { Name = "C#", Votes = 0 },
        new VoteOption { Name = "JavaScript", Votes = 0 },
        new VoteOption { Name = "Python", Votes = 0 },
        new VoteOption { Name = "Java", Votes = 0 }
    };

    public event Func<Task>? OnVotesUpdated;

    public IReadOnlyList<VoteOption> GetVoteOptions() => _voteOptions.AsReadOnly();

    public async Task CastVote(string optionName)
    {
        var option = _voteOptions.Find(o => o.Name == optionName);
        if (option != null)
        {
            option.Votes++;
            if (OnVotesUpdated != null)
            {
                await OnVotesUpdated.Invoke();
            }
        }
    }

    public class VoteOption
    {
        public string Name { get; set; } = "";
        public int Votes { get; set; }
    }
} 