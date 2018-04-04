using UnityEngine.UI;

public class CharChoice : Choice
{
    public Image Picture;

    #region Spawning
    //Spawns the proper dialoguebox on the position of the camera
    public override void SpawnDialogueBox()
    {
        base.SpawnDialogueBox();

        Image I = DialogueBoxClone.transform.Find("Canvas/Image").GetComponent<Image>();

        if (I != null)
        {
            I = Picture;
        }
    }
    #endregion
}