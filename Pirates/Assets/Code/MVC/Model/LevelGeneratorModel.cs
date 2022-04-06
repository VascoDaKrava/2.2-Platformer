namespace PiratesGame
{
    public sealed class LevelGeneratorModel
    {

        #region Fields

        private int _mapWidthBase = 20;
        private int _mapHeightBase = 12;

        private int _mapWidth = 3;

        private float _terrainPutFactor = 0.5f;
        private float _terrainContinueFactor = 0.5f;

        #endregion


        #region Properties

        public int MapWidth => _mapWidthBase * _mapWidth;
        public int MapHeight => _mapHeightBase;
        public int MapOffsetX => -_mapWidthBase * 3 / 2;
        public int MapOffsetY => -_mapHeightBase / 2;
        public int TerrainStartPositionX => _mapWidthBase / 2;
        public float TerrainPutFactor => _terrainPutFactor;
        public float TerrainContinueFactor => _terrainContinueFactor;

        #endregion

    }
}
