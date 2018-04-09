using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueHandler : Interacter
{
    #region Fields
    public List<Dialogue> DialogueList;

    int Startindex;
    int Currentindex;
    #endregion

    // Use this for initialization
    void Start()
    {
        Startindex = 0;
        Currentindex = 0;
    }

    #region KeyChecks
    //Checks if the current dialogue is a log or a choice, and calls the correct CheckKey method
    void CheckKeys()
    {
        if (Active)
        {
            Dialogue currentdialogue = DialogueList[Currentindex];

            //If currentdialogue inherits from Choice
            if (currentdialogue.GetType().IsSubclassOf(typeof(Choice)))
            {
                CheckKeys(currentdialogue as Choice);
            }
            else //If currentdialogue inherits from Log
            {
                CheckKeys(currentdialogue as Log);
            }
        }
    }

    //Checks the keyinputs of the current dialogue, if it is a log
    void CheckKeys(Log currentdialogue)
    {
        if (Input.GetMouseButtonDown(0))
        {
            //If dialogue has ended
            if (currentdialogue.IsWriteDone())
            {
                NextDialogueLog(currentdialogue);
            }
            //If dialogue has not ended
            else
            {
                currentdialogue.FinishWrite();
            }
        }
        else
        {
            if (currentdialogue.IsWriteDone())
            {
                if (currentdialogue.Autonext)
                {
                    NextDialogueLog(currentdialogue);
                }
            }
        }
    }

    //Checks the keyinputs of the current dialogue, if it is a choice
    void CheckKeys(Choice currentdialogue)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!currentdialogue.IsWriteDone())
            {
                currentdialogue.FinishWrite();
            }
        }
    }
    #endregion

    #region Next Dialogue
    //Checks if the dialogue ends, and if not, selects the next dialogue
    void NextDialogueLog(Log currentdialogue)
    {
        DestroyDialogueBox();

        if (currentdialogue.EndDialogue)
        {
            EndDialogue(currentdialogue.EndResult);
        }
        else
        {
            Currentindex = currentdialogue.NextIndex;
            SpawnDialogueBox();
            DialogueList[Currentindex].StartDialogue();
        }
    }

    //Destroyes the current dialoguebox, and spawns the right next dialoguebox
    void NextDialogueChoice()
    {
        Choice c = (Choice)DialogueList[Currentindex];
        DestroyDialogueBox();

        Currentindex = c.ChoiceIndexList[c.SelectedChoice];
        c.OnChoose -= NextDialogueChoice;
        SpawnDialogueBox();
        DialogueList[Currentindex].StartDialogue();
    }
    #endregion

    #region Starting and ending
    //Starts the dialogue
    public override void Interact(GameObject player)
    {
        Currentindex = Startindex;
        SpawnDialogueBox();
        DialogueList[Currentindex].StartDialogue();

        Movement m = player.GetComponent<Movement>();

        Active = true;
        StartCoroutine(activate(m));
    }

    //Checks if the Dialogue is finished, and checks for input every frame
    IEnumerator activate(Movement player)
    {
        player.Locked = true;
        yield return new WaitForEndOfFrame();
        while (Active)
        {
            CheckKeys();
            yield return null;
        }
    }

    //Ends the dialogue, resets the handler, and unlocks player controls
    public void EndDialogue(int endresult)
    {
        ResetDialogue();
        Active = false;
    }

    //Resets the dialoguehandler and all its dialogue
    void ResetDialogue()
    {
        foreach (Dialogue i in DialogueList)
        {
            i.ResetDialogue();
        }

        Active = false;
    }
    #endregion

    #region Spawning and destroying
    //Spawns the dialogueBox
    void SpawnDialogueBox()
    {
        DialogueList[Currentindex].SpawnDialogueBox();

        if (DialogueList[Currentindex] is Choice)
        {
            Choice c = (Choice)DialogueList[Currentindex];
            c.OnChoose += NextDialogueChoice;
        }
    }

    //Destroys the dialogueBox
    void DestroyDialogueBox()
    {
        DialogueList[Currentindex].DestroyDialogueBox();
    }
    #endregion
}