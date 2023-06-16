using System;
using Level.Config;
using Level.Model;
using Level.Presenter;
using Level.View;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        _presenter = new LevelPresenter(_view, _model, _levelConfig);
        _model.StartLevel();
        AddListeners();
    }

    private void AddListeners()
    {
        _model.LevelWon += OnLevelWon;
        _model.LevelLoosed += OnLevelLoosed;
    }

    private void RemoveListeners()
    {
        _model.LevelWon -= OnLevelWon;
        _model.LevelLoosed -= OnLevelLoosed;
    }

    private void OnLevelWon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().path);
    }

    private void OnLevelLoosed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().path);
    }

    private void OnDestroy()
    {
        Dispose();
    }

    public void Dispose()
    {
        _presenter?.Dispose();
        RemoveListeners();
        _model = null;
    }
}