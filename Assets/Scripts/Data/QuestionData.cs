using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/Question")]
public class QuestionData : ScriptableObject
{
    [SerializeField] public string sentence;
    public string Sentence => sentence;
}
