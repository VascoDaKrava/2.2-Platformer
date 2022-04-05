using UnityEngine;


namespace PiratesGame
{
    public sealed class LevelGeneratorController
    {

        #region Fields

        private System.Random _random;

        private LevelGeneratorView _view;
        private LevelGeneratorModel _model;

        private TileTypes[,] _map;

        #endregion


        #region CodeLifeCycles

        public LevelGeneratorController(LevelGeneratorView view)
        {
            _view = view;
            _model = new LevelGeneratorModel();

            _map = new TileTypes[_model.MapWidth, _model.MapHeight];
            _random = new System.Random();
        }

        #endregion


        #region Methods

        public void GenerateLevel()
        {
            GenerateMap();
            DrawTiles();
        }

        public void ClearMap()
        {
            _view.TilemapWater.ClearAllTiles();
            _view.TilemapPlatform.ClearAllTiles();
        }

        private void GenerateMap()
        {
            GenerateTerrain();
            GenerateWatter();
        }

        private void DrawTiles()
        {
            for (int x = 0; x < _model.MapWidth; x++)
            {
                for (int y = 0; y < _model.MapHeight; y++)
                {
                    Vector3Int tilePosition = new Vector3Int(_model.MapOffsetX + x, _model.MapOffsetY + y, 0);

                    switch (_map[x, y])
                    {
                        case TileTypes.GroundLeft:
                            _view.TilemapPlatform.SetTile(tilePosition, _view.TileLeft);
                            break;

                        case TileTypes.GroundCenter:
                            _view.TilemapPlatform.SetTile(tilePosition, _view.TileCenter[_random.Next(_view.TileCenter.Length)]);
                            break;

                        case TileTypes.GroundRight:
                            _view.TilemapPlatform.SetTile(tilePosition, _view.TileRight);
                            break;

                        case TileTypes.WaterUp:
                            _view.TilemapWater.SetTile(tilePosition, _view.TileWaterUp);
                            break;

                        case TileTypes.WaterDown:
                            _view.TilemapWater.SetTile(tilePosition, _view.TileWaterDown);
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private void GenerateTerrain()
        {
            Debug.LogWarning("MAP = " + _model.MapWidth + " : " + _model.MapOffsetX);
            for (int y = 2; y < _model.MapHeight - 2; y++)
            {
                for (int x = -_model.MapOffsetX; x < _model.MapWidth - 1; x++)
                {
                    Debug.LogWarning(x + " : " + y);
                    if (CanMakeGround(x, y))
                    {
                        _map[x, y] = TileTypes.GroundLeft;
                    }
                }
            }
        }

        private void GenerateWatter()
        {
            for (int x = 0; x < _model.MapWidth; x++)
            {
                _map[x, 1] = TileTypes.WaterUp;
                _map[x, 0] = TileTypes.WaterDown;
            }
        }

        private bool CanMakeGround(int x, int y)
        {
            // case continue
            if (_map[x - 1, y] != TileTypes.None)
            {
                if (_map[x, y - 1] == TileTypes.None &&
                _map[x, y - 2] == TileTypes.None &&
                _map[x + 1, y - 1] == TileTypes.None)
                {
                    return true;
                }
            }
            // case new
            else
            {
                if (_map[x - 1, y - 1] != TileTypes.None)
                {
                    return true;
                }
                else
                {
                    if (_map[x, y - 1] == TileTypes.None &&
                        _map[x, y - 2] == TileTypes.None &&
                        _map[x - 1, y - 2] == TileTypes.None)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        #endregion

    }
}
