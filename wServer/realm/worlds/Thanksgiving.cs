namespace wServer.realm.worlds
{
    public class Thanksgiving : World
    {
        public Thanksgiving()
        {
            Name = "Thanksgiving Portal";
            ClientWorldName = "Thanksgiving Portal";
            Dungeon = true;
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.thanksgiving.jm", MapType.Json);
        }
    }
}