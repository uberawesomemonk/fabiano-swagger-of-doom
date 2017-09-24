
namespace wServer.realm.worlds
{
    public class TheShatters : World
    {
        public TheShatters()
        {
            Name = "The Shatters";
            ClientWorldName = "The Shatters";
            Dungeon = true;
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.shittersmep.jm", MapType.Json);
        }
    }
}