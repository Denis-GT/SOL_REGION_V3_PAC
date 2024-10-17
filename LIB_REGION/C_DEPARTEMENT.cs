


namespace LIB_REGION
{
  public class C_DEPARTEMENT
  {
    public int id { get; set; }
    public string region_code { get; set; }
    public string code { get; set; }
    public string name { get; set; }
    public string slug { get; set; }

    public string Debug()
    {
      return $"{id}{code}{name}";
    }
  }
}
