using Level.Config;
using Level.Model;
using Level.Presenter;
using Level.View;
using UnityEngine;

public class Entry : MonoBehaviour
{
    private ILevelModel _model;
    private LevelPresenter _presenter;
    private ILevelView _view;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private LevelConfig _levelConfig;

    void Start()
    {
        _model = new LevelModel(_levelConfig);
        _view = Instantiate(_prefab).GetComponent<ILevelView>();
        _presenter = new LevelPresenter(_view, _model);
        _model.StartLevel();
    }
}