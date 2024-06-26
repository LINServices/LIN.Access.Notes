namespace LIN.Access.Notes;


public class Build
{


    public static void Init(string? url = null)
    {
        Service._Service = new();
        Service._Service.SetDefault(url ?? "https://api.notes.linplatform.com/");
        //Service._Service.SetDefault("http://localhost:6001/");
    }


}