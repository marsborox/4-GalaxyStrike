using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines;
    [SerializeField] TMP_Text dialogueText;
    int currentLine = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextDialogueLine()
    {
        currentLine++;
        dialogueText.text = timelineTextLines[currentLine];
    }
}
