using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creates a scripatable object base for the attacks with its own habilities and stats

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Nuevo Movimiento ")]
public class MoveBase : ScriptableObject
{

    [SerializeField] private string name;
    public string Name => name;


    [TextArea] [SerializeField] private string description;
    public string Description => description;


    public ParticleSystem ParticleSystem;

    [SerializeField] private PokemonType type;
    [SerializeField] private int power;
    [SerializeField] private int accuracy;
    [SerializeField] private int pp;
    
    [SerializeField] private int priority;

    [SerializeField] private bool alwaysHit;
    [SerializeField] private MoveType moveType;
    [SerializeField] private MoveStatEffect effects;
    [SerializeField] private  List <SecondaryMoveStatEffect> secondaryEffects;   
    [SerializeField] private MoveTarget target;

    public PokemonType Type => type;
    public int Power => power;
    public int Accuracy => accuracy;
    public bool AlwaysHit => alwaysHit;
    public int PP => pp;
    public int Priority => priority;

    

    public MoveType MoveType => moveType;
    public MoveStatEffect Effects => effects;
    public List<SecondaryMoveStatEffect> SecondaryEffects => secondaryEffects;
    public MoveTarget Target => target;
    public bool isSpecialMove => moveType == MoveType.Special;

      
 

}


public enum MoveType 
{
    Physical,Special,Stats,


}

[System.Serializable]
public class MoveStatEffect
{
    [SerializeField]private List<StatBoosting> boostings;
    [SerializeField]private StatusConditionID status;
    [SerializeField] private StatusConditionID volatileStatus;

    public List<StatBoosting> Boostings => boostings;
    public StatusConditionID Status => status;
    public StatusConditionID VolatileStatus => volatileStatus;
}
[System.Serializable]
public class SecondaryMoveStatEffect : MoveStatEffect
{



    [SerializeField] private int chance;
    [SerializeField] private MoveTarget target;

    public int Chance
    {
        get => chance;
    }
    public MoveTarget Target
    {
        get => target;
    }
}





[System.Serializable]
public class StatBoosting
{
    public Stat stat;
    public int boost;
    public MoveTarget target;
}

public enum MoveTarget
{
    self,other
}
