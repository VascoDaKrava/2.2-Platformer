using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;


namespace PiratesGame
{
    public sealed class LevelGeneratorController
    {

        #region Fields

        private LevelGeneratorView _view;
        private LevelGeneratorModel _model;

        private TileType[,] _map;

        #endregion


        #region CodeLifeCycles

        public LevelGeneratorController(LevelGeneratorView view)
        {
            _view = view;
            _model = new LevelGeneratorModel();

            _map = new TileType[_model.MapWidth, _model.MapHeight];
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
                    _map[x, y] = TileType.None;
                }
            }

            _view.TilemapWater.ClearAllTiles();
            _view.TilemapPlatform.ClearAllTiles();

            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
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
                        case TileType.GroundLeft:
                            _view.TilemapPlatform.SetTile(tilePosition, _view.TileLeft);
                            break;

                        case TileType.GroundCenter:
                            _view.TilemapPlatform.SetTile(tilePosition, _view.TileCenter[Random.Range(0, _view.TileCenter.Length)]);
                            break;

                        case TileType.GroundRight:
                            _view.TilemapPlatform.SetTile(tilePosition, _view.TileRight);
                            break;

                        case TileType.WaterUp:
                            _view.TilemapWater.SetTile(tilePosition, _view.TileWaterUp);
                            break;

                        case TileType.WaterDown:
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
                            if (_map[x - 1, y] == TileType.None)
                            {
                                _map[x, y] = TileType.GroundLeft;
                            }
                            else
                            {
                                if (_map[x - 1, y] == TileType.GroundRight)
                                {
                                    continue;
                                }

                                if (Random.Range(0.0f, 1.0f) < _model.TerrainContinueFactor)
                                {
                                    _map[x, y] = TileType.GroundCenter;
                                }
                                else
                                {
                                    _map[x, y] = TileType.GroundRight;
                                }
                            }
                        }
                        else
                        {
                            if (_map[x - 1, y] == TileType.GroundLeft || _map[x - 1, y] == TileType.GroundCenter)
                            {
                                _map[x, y] = TileType.GroundRight;
                            }
                        }
                    }
                    else
                    {
                        _map[x, y] = TileType.None;
                    }
                }

                if (_map[_model.MapWidth - 3, y] == TileType.GroundLeft ||
                    _map[_model.MapWidth - 3, y] == TileType.GroundCenter)
                {
                    _map[_model.MapWidth - 2, y] = TileType.GroundRight;
                }
            }
        }

        private void CorrectingTerrain()
        {
            for (int y = 2; y < _model.MapHeight - 2; y++)
            {
                for (int x = _model.TerrainStartPositionX; x < _model.MapWidth - 2; x++)
                {
                    if (_map[x + 1, y] == TileType.None)
                    {
                        switch (_map[x, y])
                        {
                            case TileType.GroundLeft:
                                _map[x, y] = TileType.None;
                                break;
                            case TileType.GroundCenter:
                                _map[x, y] = TileType.GroundRight;
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
                _map[x, 1] = TileType.WaterUp;
                _map[x, 0] = TileType.WaterDown;
            }
        }

        private bool CanMakeGround(int x, int y)
        {
            // case continue
            if (_map[x - 1, y] != TileType.None)
            {
                return CheckGroundForContinue(x, y);
            }
            // case new
            else
            {
                if (_map[x - 1, y - 1] == TileType.GroundRight)
                {
                    return true;
                }
                else
                {
                    if (_map[x, y - 1] == TileType.None &&
                        _map[x, y - 2] == TileType.None &&
                        _map[x - 1, y - 2] == TileType.None &&
                        _map[x + 1, y - 1] == TileType.None &&
                        _map[x + 1, y - 2] == TileType.None &&
                        _map[x + 2, y - 2] == TileType.None)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckGroundForContinue(int x, int y)
        {
            return
                _map[x, y - 1] == TileType.None &&
                _map[x, y - 2] == TileType.None &&
                _map[x + 1, y - 1] == TileType.None &&
                _map[x + 1, y - 2] == TileType.None;
        }

        #endregion

    }
}
