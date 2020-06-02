namespace mobile.Models
{
    public enum MenuItemType
    {
        Products,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
