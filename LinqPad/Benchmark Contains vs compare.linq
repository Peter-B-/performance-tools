<Query Kind="Program">
  <RuntimeVersion>8.0</RuntimeVersion>
</Query>

void Main()
{
	testStrings.Length.DumpTell();
	Hashset().DumpTell();
	Compare().DumpTell();
}

bool IsInEquals(string test) =>
		test.Equals("EnvironmentParameterMessage", StringComparison.Ordinal) ||
		test.Equals("PressSetPointMessage", StringComparison.Ordinal) ||
		test.Equals("StripSetPointMessage", StringComparison.Ordinal) ||
		test.Equals("NewPressJobMessage", StringComparison.Ordinal) ||
		test.Equals("BlanksPressedMessage", StringComparison.Ordinal) ||
		test.Equals("PartRecognizedMessageV2", StringComparison.Ordinal);

bool IsInHashset(string test) => hashSet.Contains(test);
private static readonly HashSet<string> hashSet = new(StringComparer.Ordinal)
	{
		"EnvironmentParameterMessage",
		"PressSetPointMessage",
		"StripSetPointMessage",
		"NewPressJobMessage",
		"BlanksPressedMessage",
		"PartRecognizedMessageV2"
	};
	
	
int Hashset() => testStrings.Count(IsInHashset);
int Compare() => testStrings.Count(IsInEquals);

string[] testStrings = new[]{
		"EnvironmentParameterMessage",
		"PressSetPointMessage",
		"StripSetPointMessage",
		"NewPressJobMessage",
		"BlanksPressedMessage",
		"PartRecognizedMessageV2",

		"EnvironXXmeParameterMessage",
		"PressSetPntMessage",
		"StripSeXXointMessage",
		"NeXXwessJobMessage",
		"BlasPresseXXdMessage",
		"PartXXRecnizedMessageV2",

		"EnvironmentParameterMessage",
		"PressSetPyyntMessage",
		"StripSetPointMessage",
		"NewPressJobMessage",
		"BlanksPressedMessage",
		"PartRecognizedMessageV2",

		"EnvironXXmtParameterMessage",
		"PressSetPoiyyessage",
		"StripSetPXXntMessage",
		"NeXXwPressJobMessage",
		"BlanksPreeXXdMessage",
		"PartXXRognizedMessageV2",

		"EnvironmentParameterMessage",
		"PressSetPointMessage",
		"StripSetPointMessage",
		"NewPressJobMessage",
		"BlanksPressedMessage",
		"PartRecognizedMessageV2",

		"EnvirXXmentParameterMessage",
		"PressSetPointMyysage",
		"StripSetPXXntMessage",
		"NeXXwPssJobMessage",
		"BlanksPresXXdMessage",
		"PartXXRegnizedMessageV2",

		"",
		"a",
		"ab",

		"EnvironmentParameterMessagX",
		"PressSetPointMessagX",
		"StripSetPointMessagX",
		"NewPressJobMessagX",
		"BlanksPressedMessagX",
		"PartRecognizedMessageV3",
		};


// see 
// https://github.com/dotnet/runtime/blob/release/6.0/src/libraries/System.Private.CoreLib/src/System/SpanHelpers.Byte.cs#L1422
// https://github.com/dotnet/runtime/blob/release/8.0/src/libraries/System.Private.CoreLib/src/System/SpanHelpers.Byte.cs#L760
