using ISFATAAIOWATE.Context;
using ISFATAAIOWATE.Entities;


namespace ISFATAAIOWATE;

public class Helper
{
    private static MyDbContext _myDbContext;
    
    public static Employee Employee { get; set; }
    public static MyDbContext GetContext()
    {
        return _myDbContext ??= new();
    }
}