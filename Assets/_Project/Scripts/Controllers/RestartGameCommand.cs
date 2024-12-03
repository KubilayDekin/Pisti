using strange.extensions.command.impl;
using UnityEngine.SceneManagement;

namespace Pisti
{
	public class RestartGameCommand : Command
	{
		public override void Execute()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}