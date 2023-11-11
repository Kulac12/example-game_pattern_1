using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapController : MonoBehaviour
{

    //cool, warming, hot
    public enum State{
        Cool, Warming, Hot
    }

    public State CurrentState = State.Cool;
    private float _elapsedTimeInState =0;

    [Header("Dependencies")]
    [SerializeField]
    private MeshRenderer _grillRenderer;
    [SerializeField]
    private ParticleSystem _fireEmitter;
   // [SerializeField]
    //private Collider _damageTrigger; 

    [Header("Cool State")]
    [SerializeField]
    private float _coolDuraction =2;
    [SerializeField]
    private Color _coolColor = Color.black;

    [Header("Warming State")]
    [SerializeField]
    private float _warmingDuraction =1;
    [SerializeField]
    private Color _warmingColor = Color.red;


    [Header("Hot State")]
    [SerializeField]
    private float _hotDuraction = 2;
   // [SerializeField]
   // private Color _hotColor = Color.red;
    





    private void Update() {
        switch (CurrentState)
        {
            case State.Cool:
                DoCoolState();
                break;

            case State.Warming:
                DoWarmingState();
                break;
            case State.Hot:
                DoHotState();
                break;   
            
        }
        
    }
    



    private void DoCoolState(){
        
        if (_elapsedTimeInState == 0)
        {
            //perform setup on enter
             Debug.Log("Cool State ");
             _grillRenderer.material.SetColor("_Color", _coolColor);
        }
        
        _elapsedTimeInState += Time.deltaTime;
        
       
        if (_elapsedTimeInState >= _coolDuraction )
        {
            ChangeState(State.Warming);
        }


    }

    private void DoWarmingState(){
        if (_elapsedTimeInState == 0)
        {
            //perform setup on enter
             Debug.Log("Warming State ");
             _grillRenderer.material.SetColor("_Color", _warmingColor);
        }
        _elapsedTimeInState += Time.deltaTime;
       
       if (_elapsedTimeInState >= _warmingDuraction)
       {
            ChangeState(State.Hot);
       }



    }

    private void DoHotState () {

        if(_elapsedTimeInState == 0){
             Debug.Log("Hot State");
            // _damageTrigger.enable = true;
             _fireEmitter.Play();
        }
       
        _elapsedTimeInState += Time.deltaTime;
        if (_elapsedTimeInState>= _hotDuraction)
        {
          //  _damageTrigger.enable = false;
            _fireEmitter.Stop();
            ChangeState(State.Cool);
        }


    }

    public void ChangeState (State newState) {

        if(CurrentState == newState){
            return;
        }


        CurrentState = newState;
        _elapsedTimeInState = 0;

    }












}
