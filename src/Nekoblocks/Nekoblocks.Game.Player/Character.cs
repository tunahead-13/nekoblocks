using Nekoblocks.Game.Objects;

namespace Nekoblocks.Game.Player;

public class Character : Part
{
    public Character()
    {
        Name = "Character";
        Transform.SetScale(4, 5, 1);
    }
}