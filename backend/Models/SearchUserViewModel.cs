namespace backend.Models;

public class SearchUserViewModel
{
    public SearchUserViewModel(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; set; }
    public bool IsLoading { get; set; } = false;
    public bool IsSent { get; set; } = false;
}