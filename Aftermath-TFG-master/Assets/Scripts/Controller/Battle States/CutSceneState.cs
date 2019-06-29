using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CutSceneState : BattleState 
{
	ConversationController conversationController;
	ConversationData data;

	protected override void Awake ()
	{
		base.Awake ();
		conversationController = owner.GetComponentInChildren<ConversationController>();
	}

	public override void Enter ()
	{
		base.Enter ();
		if (IsBattleOver())
		{
			if (DidPlayerWin())
				data = Resources.Load<ConversationData>("Conversations/OutroSceneWin");
			else
				data = Resources.Load<ConversationData>("Conversations/OutroSceneLose");
		}
		else
		{
            if(SceneManager.GetActiveScene().name == "BattleFront" || SceneManager.GetActiveScene().name == "Test")	data = Resources.Load<ConversationData>("Conversations/BattleFrontIntro");
            else data = Resources.Load<ConversationData>("Conversations/AmbushIntro");
        }
		conversationController.Show(data);
	}

	public override void Exit ()
	{
		base.Exit ();
		if (data)
			Resources.UnloadAsset(data);
	}

	protected override void AddListeners ()
	{
		base.AddListeners ();
		ConversationController.completeEvent += OnCompleteConversation;
	}

	protected override void RemoveListeners ()
	{
		base.RemoveListeners ();
		ConversationController.completeEvent -= OnCompleteConversation;
	}

	protected override void OnFire (object sender, InfoEventArgs<int> e)
	{
		base.OnFire (sender, e);
		conversationController.Next();
	}

	void OnCompleteConversation (object sender, System.EventArgs e)
	{
		if (IsBattleOver())
			owner.ChangeState<EndBattleState>();
		else
			owner.ChangeState<SelectUnitState>();
	}
}
