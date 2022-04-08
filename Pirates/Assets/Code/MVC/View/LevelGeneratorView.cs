using UnityEngine;
using UnityEngine.Tilemaps;


namespace PiratesGame
{
    public sealed class LevelGeneratorView : MonoBehaviour
    {

        #region Fields

        [Space]
        [SerializeField]
        private Tilemap _tilemapPlatform;

        [SerializeField]
        private Tile _tileLeft;
        
        [SerializeField]
        private Tile _tileRight;
        
        [SerializeField]
        private Tile[] _tileCenter;

        [Space]
        [SerializeField]
        private Tilemap _tilemapWater;

        [SerializeField]
        private Tile _tileWaterUp;

        [SerializeField]
        private Tile _tileWaterDown;

        #endregion


        #region Properties

        public Tile TileLeft => _tileLeft;
        public Tile TileRight => _tileRight;
        public Tile[] TileCenter => _tileCenter;
        public Tile TileWaterUp => _tileWaterUp;
        public Tile TileWaterDown => _tileWaterDown;
        public Tilemap TilemapPlatform => _tilemapPlatform;
        public Tilemap TilemapWater => _tilemapWater;

        #endregion

    }
}
