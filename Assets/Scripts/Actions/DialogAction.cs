using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAction : Action
{
    public int start_id = 0;
    public UnityEngine.UI.Text text = null;
    public Animator animator = null;
    private Dialog dialog = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Execute()
    {
        if (start_id > 0)
        {
            Debug.Log("excute action ok");
            dialog = Manager.getInstance().GetDialog(start_id);
            string character = dialog.GetCharacter();
            string content = dialog.GetContent();
            text.text = character.Length > 0 ? character + "：\n" + content : content;
            animator.SetTrigger("Show");
            StartCoroutine(Talk());
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerator Talk()
    {
        yield return 1;
        while(dialog.GetNext() != -1)
        {
            yield return new WaitUntil(() => Input.GetKeyDown("space"));
            animator.SetTrigger("Next");

            yield return new WaitForSeconds(0.5f);
            dialog = Manager.getInstance().GetDialog(dialog.GetNext());
            string character = dialog.GetCharacter();
            string content = dialog.GetContent();
            text.text = character.Length > 0 ? character + "：\n" + content : content;
            animator.SetTrigger("Next");
        }
        yield return new WaitUntil(() => Input.GetKeyDown("space"));
        animator.SetTrigger("End");
        completed = true;
        yield break;
    }
}
