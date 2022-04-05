using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ThirdPersonShooter-RPG/Quest")]
public class Quest : ScriptableObject
{
    public string description;
    public int itemsRequired;
    public float timeLimit;
}