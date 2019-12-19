using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day13CarePackage
{
    public class Screen
    {
        private readonly Dictionary<(BigInteger x, BigInteger y), Tile> _tiles = new Dictionary<(BigInteger x, BigInteger y), Tile>();

        public void Set(BigInteger x, BigInteger y, Tile tile) => _tiles[(x, y)] = tile;

        public int GetNumberOfBlockTiles() => _tiles.Count(t => t.Value == Tile.Block);

        public BigInteger GetBallPosition() => _tiles.First(t => t.Value == Tile.Ball).Key.x;

        public BigInteger GetPaddlePosition() => _tiles.First(t => t.Value == Tile.HorizontalPaddle).Key.x;
    }
}