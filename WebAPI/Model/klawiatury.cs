namespace WebAPI.Model
{
    public enum KeyboardType
    {
        Membranowa,
        Nożycowa,
        Mechaniczna,
        Optyczna,
        Hybrydowa
    }

    public class Klawiatura
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public KeyboardType Type { get; set; }
    }
}
