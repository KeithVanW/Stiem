namespace Stiem.Model
{
    public class CartOverview
    {
        public string UserId { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public double TotalPrice { get; set; }
    }
}