<Query Kind="Statements" />

ShouldExport(new Message("OtherMessage"))
	.Dump();


bool ShouldExport(Message message) =>
	message.Source.Equals("PressSetPointMessage", StringComparison.Ordinal) ||
	message.Source.Equals("StripSetPointMessage", StringComparison.Ordinal);

record Message(string Source);


