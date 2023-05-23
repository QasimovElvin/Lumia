using Lumia.DAL;

namespace Lumia.Services;

public class LayoutServices
{
    private readonly AppDbContext _context;

    public LayoutServices(AppDbContext context)
    {
        _context = context;
    }
    public Dictionary<string , string> GetServices()
    {
        return _context.Settings.ToList().ToDictionary(x=>x.Key, x => x.Value);
    }
}
