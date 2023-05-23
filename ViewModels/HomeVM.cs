using Lumia.Models;

namespace Lumia.ViewModels;

public class HomeVM
{
    public List<Serv> Servs { get; set; }
    public About Abouts { get; set; }
    public Slider Sliders { get; set; }
    public List<Team> Teams { get; set; }
    public List<WhatWeDo> WhatWeDos { get; set; }
}
