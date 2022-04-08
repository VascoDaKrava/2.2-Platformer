using UnityEngine;


namespace PiratesGame
{
    public sealed class LevelGeneratorController
    {

        #region Fields

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
        }

        #endregion


        #region Methods

        public void GenerateLevel()
        {
            ClearMap();
            GenerateMap();
            DrawTiles();
        }

        public void ClearMap()
        {
            for (int x = 0; x < _model.MapWidth; x++)
            {
                for (int y = 0; y < _model.MapHeight; y++)
                {
                    _map[x, y] = TileTypes.None;
                }
            }

            _view.TilemapWater.ClearAllTiles();
            _view.TilemapPlatform.ClearAllTiles();
        }

        private void GenerateMap()
        {
            GenerateTerrain();
            CorrectingTerrain();
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
                            _view.TilemapPlatform.SetTile(tilePosition, _view.TileCenter[Random.Range(0, _view.TileCenter.Length)]);
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
            for (int y = 2; y < _model.MapHeight - 2; y++)
            {
                for (int x = _model.TerrainStartPositionX; x < _model.MapWidth - 2; x++)
                {
                    if (CanMakeGround(x, y))
                    {
                        if (Random.Range(0.0f, 1.0f) < _model.TerrainPutFactor)
                        {
                            if (_map[x - 1, y] == TileTypes.None)
                            {
                                _map[x, y] = TileTypes.GroundLeft;
                            }
                            else
                            {
                                if (_map[x - 1, y] != TileTypes.GroundRight)
                                {
                                    if (Random.Range(0.0f, 1.0f) < _model.TerrainContinueFactor)
                                    {
                                        _map[x, y] = TileTypes.GroundCenter;
                                    }
                                    else
                                    {
                                        _map[x, y] = TileTypes.GroundRight;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (_map[x - 1, y] == TileTypes.GroundLeft || _map[x - 1, y] == TileTypes.GroundCenter)
                            {
                                _map[x, y] = TileTypes.GroundRight;
                            }
                        }
                    }
                    else
                    {
                        _map[x, y] = TileTypes.None;
                    }
                }

                if (_map[_model.MapWidth - 3, y] == TileTypes.GroundLeft ||
                    _map[_model.MapWidth - 3, y] == TileTypes.GroundCenter)
                {
                    _map[_model.MapWidth - 2, y] = TileTypes.GroundRight;
                }
            }
        }

        private void CorrectingTerrain()
        {
            for (int y = 2; y < _model.MapHeight - 2; y++)
            {
                for (int x = _model.TerrainStartPositionX; x < _model.MapWidth - 2; x++)
                {
                    if (_map[x + 1, y] == TileTypes.None)
                    {
                        switch (_map[x, y])
                        {
                            case TileTypes.GroundLeft:
                                _map[x, y] = TileTypes.None;
                                break;
                            case TileTypes.GroundCenter:
                                _map[x, y] = TileTypes.GroundRight;
                                break;
                            default:
                                break;
                        }
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
                _map[x + 1, y - 1] == TileTypes.None &&
                _map[x + 1, y - 2] == TileTypes.None)
                {
                    return true;
                }
            }
            // case new
            else
            {
                if (_map[x - 1, y - 1] == TileTypes.GroundRight)
                {
                    return true;
                }
                else
                {
                    if (_map[x, y - 1] == TileTypes.None &&
                        _map[x, y - 2] == TileTypes.None &&
                        _map[x - 1, y - 2] == TileTypes.None &&
                        _map[x + 1, y - 1] == TileTypes.None &&
                        _map[x + 1, y - 2] == TileTypes.None &&
                        _map[x + 2, y - 2] == TileTypes.None)
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
