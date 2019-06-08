﻿using System.Collections.Generic;
using GoRogue.MapGeneration;
using Microsoft.Xna.Framework;
using SadConsole;
using SadConsole.Maps;
using SadConsole.Maps.Generators;

namespace BasicTutorial.Maps.Generators
{
    public static class DoorGenerator
    {
        public static void Generate(SadConsole.Tiles.TileMap map, IEnumerable<Region> rooms, string doorBlueprint, int leaveFloorAloneChance = 20)
        {
            bool PercentageCheck(int outOfHundred) => outOfHundred != 0 && GoRogue.Random.SingletonRandom.DefaultRNG.Next(101) < outOfHundred;

			foreach (var room in rooms)
				foreach (var point in room.Connections)
					if (!PercentageCheck(leaveFloorAloneChance))
						map.SetTerrain(SadConsole.Tiles.Tile.Factory.Create(doorBlueprint, point));
        }
    }
}