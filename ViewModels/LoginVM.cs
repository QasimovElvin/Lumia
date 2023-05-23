﻿using System.ComponentModel.DataAnnotations;

namespace Lumia.ViewModels;

public class LoginVM
{
    public string EmailOrUsername { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
