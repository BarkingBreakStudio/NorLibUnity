using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class StringFilteredEventListener : StringEventListener
{

	public string RegexFilter = "";

	protected override void Respond(string value)
	{
		if(Regex.IsMatch(value, RegexFilter))
			OnEventRaised?.Invoke(value);
	}


	
}
