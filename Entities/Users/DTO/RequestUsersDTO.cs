namespace PreezieCodingTask.Helpers.Users
{
    public class RequestUsersDTO
    {
        public string Email { get; set; } = string.Empty;

        public int PageSize { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
