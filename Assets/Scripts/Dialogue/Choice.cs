using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public abstract class Choice : Dialogue
{

    #region Fields
    public List<string> ChoiceList;

    public List<int> ChoiceIndexList;

    public delegate void Chosen();
    public event Chosen OnChoose;
    public int SelectedChoice;

    private Text A;
    private Text B;
    private Image ACursor;
    private Image BCursor;

    public ChoiceHandler ChoiceHandler;
    #endregion

    #region Writing
    //Checks the progress of the textwriting, returns true if finished
    public override bool IsWriteDone()
    {
        if (base.IsWriteDone())
        {
            SpawnChoice();
            return true;
        }

        return false;
    }

    //Checks the progress of the textwriting, returns true if finished
    public override void FinishWrite()
    {
        base.FinishWrite();
        IsWriteDone();
    }
    #endregion

    #region Choice logic
    //Spawns the choice, and the cursor, so the player can choose
    protected virtual void SpawnChoice()
    {
        ChoiceHandler c = DialogueBoxClone.transform.Find("Canvas/Choice").GetComponent<ChoiceHandler>();
        c.OnChoose += OnChosen;
        ChoiceHandler = c;

        Text[] choices = c.GetComponentsInChildren<Text>();
        //Add data to option A
        A = choices[0];
        A.text = ChoiceList[0];
        ACursor = A.transform.GetChild(0).GetComponent<Image>();
        ACursor.enabled = true;

        //Add data to option B
        B = choices[1];
        B.text = ChoiceList[1];
        BCursor = A.transform.GetChild(0).GetComponent<Image>();
        BCursor.enabled = true;
    }

    public void OnChosen()
    {
        SelectedChoice = ChoiceHandler.chosen;
        if (OnChoose != null)
        {
            OnChoose();
        }

        ChoiceHandler.OnChoose -= OnChosen;
    }

    //Returns the ending int of the selected choice.
    #endregion

    #region Resetting
    public override void ResetDialogue()
    {
        base.ResetDialogue();

        SelectedChoice = 0;
        if (A.text != null)
        {
            A.text = "";
        }
        if (B.text != null)
        {
            B.text = "";
        }

        ACursor.enabled = false;
        BCursor.enabled = false;
    }
    #endregion
}