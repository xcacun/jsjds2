using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : Singleton<Event>
{
   public Action<DialogManager> DialogerIn;
    public void CallDialogerIn(DialogManager dialoger)
    { DialogerIn.Invoke(dialoger); }
   public Action<DialogManager> DialogerOut;
    public void CallDialogerOut(DialogManager dialoger)
    { DialogerOut.Invoke(dialoger); }

    public Action<DialogManager> StartDialog;
    public void CallStartDialog(DialogManager dialoger)
        { StartDialog.Invoke(dialoger); }

    public Action<DialogManager> CancelDialog;
     public void CallCancelDialog(DialogManager dialoger)
    { CancelDialog.Invoke(dialoger); }

    public Action<DialogManager> EndDialog;
    public void CallEndDialog(DialogManager dialoger)
    { EndDialog.Invoke(dialoger); }

    public Action BarDisappearAct;
    public void CallBarDisappear()
    {
        BarDisappearAct.Invoke();
    }
    public Action RotateView;
    public void CallRotateView()
    {  RotateView.Invoke(); }
    public Action<IntroduceContentSO> IntroduceOnUI;
    public void CallIntroduceOnUI(IntroduceContentSO introduceWhat)
    { IntroduceOnUI?.Invoke(introduceWhat); }
 
    public Action IntroduceGameEnd;
    public void CallIntroduceGameEnd()
    { IntroduceGameEnd.Invoke(); }
}
public enum EIntroduceWhat
{ None,Roof,Beam,Dougong}
