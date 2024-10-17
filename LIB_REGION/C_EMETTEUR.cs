namespace LIB_REGION
{
  public class C_EMETTEUR
  {
    public int Id { get; set; }
    public string Adm { get; set; }
    public int Sup { get; set; }
    public string Sys { get; set; }
    public string Dpt { get; set; }
    public string CP { get; set; }
    public string Type { get; set; }
    public string Adr { get; set; }
    public float[] XY { get; set; }
    public string Etat { get; set; }

    public string Debug()
    {
      return $"{Id}{Adm}{Type}{Etat}";
    }
  }
}
