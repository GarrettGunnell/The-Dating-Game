using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/Question")]
public class QuestionData : ScriptableObject
{
    [SerializeField] private string sentence;
    public string Sentence => sentence;
}
