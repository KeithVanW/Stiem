namespace Stiem.Model
{
    public class Game
    {
        public int GameID { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Platform { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}