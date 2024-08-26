using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    protected InputController inputs { get { return InputController.instance; } }
    protected StateMachineController machine { get { return StateMachineController.instance; } }

   public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }
}
