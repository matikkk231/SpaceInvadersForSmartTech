using System;
using Level.Config;
using Level.Model;
using Level.Presenter;
using Level.View;
using UnityEngine;

public class Entry : MonoBehaviour, IDisposable
{
    private ILevelModel _model;
    private LevelPresenter _presenter;
    private ILevelView _view;
    [SerializeField] private GameObject _levelPrefab;
    [SerializeField] private LevelConfig _levelConfig;

    void Start()
    {
        _model = new LevelModel(_levelConfig);
        _view = Instantiate(_levelPrefab).GetComponent<ILevelView>();
        _presenter = new LevelPresenter(_view, _model);
        _model.StartLevel();
        AddListeners();
    }

    private void AddListeners()
    {
        _model.LevelWon += OnLevelWon;
    }

    private void RemoveListeners()
    {
        _model.LevelWon -= OnLevelWon;
    }

    private void OnLevelWon()
    {
        Debug.Log("level WON!!!");
    }

    private void OnDestroy()
    {
        Dispose();
    }

    public void Dispose()
    {
        _presenter?.Dispose();
        RemoveListeners();
    }
}