namespace PotapanjeBrodova
{
    public enum RezultatGađanja
    {
        Promašaj,
        Pogodak,
        Potopljen
    }

    public interface IGađani
    {
        RezultatGađanja Gađaj(Polje polje);
    }
}
