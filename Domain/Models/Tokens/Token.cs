using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Tokens;

public class Token
{
    public string? AccesToken { get; set; }
    public string? RefreshToken { get; set; }
}
