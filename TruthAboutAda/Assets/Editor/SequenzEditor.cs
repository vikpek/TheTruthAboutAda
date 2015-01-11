using UnityEngine;
using UnityEditor;
using System.Collections;

public class SequenzEditor : EditorWindow
{
	GameObject sectionCon;
	GameObject eventCon;

	bool init;

	void OnGUI()
	{
		if( init ) // Normal Screen
		{

		} else // Init Screen
		{

		}
	}

	void OnFocus()
	{
		// TODO : Update Selection/Data
	}

	[MenuItem("Window/SequenzEditor")]
	static void ShowWindow()
	{
		SequenzEditor window = (SequenzEditor)EditorWindow.GetWindow( typeof( SequenzEditor ) );
		window.Init();
	}

	void Init()
	{
		if( !init )
		{
			sectionCon = GameObject.Find("SectionContainer");
			eventCon = GameObject.Find("EventContainer");
			if( sectionCon != null && eventCon != null )
			{
				if( sectionCon.transform.childCount == 0 )
				{
					// TODO : Create A Section (first)
				} else
				{
					// TODO : Select first "Section"
				}
				init = true;
			}
		}
	}
}