namespace BasicTutorial
{
    internal static class GameState
    {
        public static DungeonScreen Dungeon;

        public static void FirstDungeonSetup()
        {
            // Generate a map
            var gen = SadConsole.Tiles.DungeonMazeGenerator.Create(100, 100);

            Maps.Generators.DoorGenerator.Generate(gen.SadConsoleMap, gen.Rooms, "door", 20);

            // Temp SHOW ALL TILES
            //for (int x = 0; x < gen.SadConsoleMap.Width; x++)
            //    for (int y = 0; y < gen.SadConsoleMap.Height; y++)
            //        gen.SadConsoleMap.GetTerrain<Tile>(x, y).Flags = SadConsole.Helpers.SetFlag(gen.SadConsoleMap.GetTerrain<Tile>(x, y).Flags, (int)TileFlags.Seen | (int)TileFlags.InLOS | (int)TileFlags.Lighted);

            // Create player
            gen.SadConsoleMap.ControlledGameObject = new GameObjects.Player(gen.SadConsoleMap, gen.Rooms[0].InnerRect.Center);
            Dungeon = new DungeonScreen(gen.SadConsoleMap);

            //gen.SadConsoleMap.ControlledGameObject.MoveTo(gen.Rooms[0].InnerRect.Center);

            //gen.SadConsoleMap.GameObjects.Entities.Add(gen.SadConsoleMap.ControlledGameObject);
            //gen.SadConsoleMap.CenterViewPortOnPoint(gen.SadConsoleMap.ControlledGameObject.Position);

            ((GameObjects.Player)gen.SadConsoleMap.ControlledGameObject).RefreshVisibilityTiles();
        }
    }
}
