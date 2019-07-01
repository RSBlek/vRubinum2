using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2
{
    public class LoginSuccessResult
    {
        public String Username { get; internal set; }
        public Empire? Empire { get; internal set; }
        public List<SelectCharacter> Characters { get; } = new List<SelectCharacter>();
    }
}
