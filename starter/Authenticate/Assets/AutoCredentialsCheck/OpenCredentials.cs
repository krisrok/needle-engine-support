using System;
using UnityEditor;
using UnityEngine;

public static class AutoCredentials
{
#if UNITY_EDITOR
	[InitializeOnLoadMethod]
	private static void Init()
	{
		EditorGUI.hyperLinkClicked += OnHyperLinkClicked;
		Debug.LogFormat(LogType.Log, LogOption.NoStacktrace, null, "{0}", "Please open <a href=\"https://packages.needle.tools\">https://packages.needle.tools</a> in your browser and login using your github account. Then copy the credentials from the <i>Registry Info</i> window (top right button) to your clipboard and return to Unity.");
	}

	private static void OnHyperLinkClicked(object sender, EventArgs e)
	{
		if (e is EditorGUILayout.HyperLinkClickedEventArgs args)
		{
			if (args.hyperlinkInfos.TryGetValue("href", out var path))
			{
				if(path.StartsWith("https://"))
					Application.OpenURL(path);
			}
		}
	}

#endif
}