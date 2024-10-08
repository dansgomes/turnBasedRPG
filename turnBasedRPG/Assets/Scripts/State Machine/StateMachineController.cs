using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateMachineController : MonoBehaviour
{
    public static StateMachineController instance;

    State _current;
    bool busy;
    public State current { get { return _current;}}
    public Transform selector;
    public TileLogic selectedTile;
    public List<Unit> units;

    [Header("ChooseActionState")]
    public List<Image> chooseActionButtons;
    public Image chooseActionSelection;
    public PanelPositioner chooseActionPanel;

    [Header("SkillSelectionState")]
    public List<Image> skillSelectionButtons;
    public Image skillSelectionSelection;
    public PanelPositioner skillSelectionPanel;
    public Sprite skillSelectionBlocked;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeTo<LoadState>();
    }

    public void ChangeTo<T>() where T : State
    {
        State state = GetState<T>();
        if (_current != state)
            ChangeState(state);

    }
        public T GetState<T>() where T : State
    {
        T target = GetComponent<T>();
        if (target == null)
            target = gameObject.AddComponent<T>();
        return target;
    }

    protected void ChangeState(State value)
    {
        if (busy)
            return;
        busy = true;

        if (_current!= null)
        {
            _current.Exit();
        }

        _current = value;
        if (_current != null)
            _current.Enter();

        busy = false;
    }
    
}
