using System.Runtime.Serialization;

namespace SquatFinder.Core.Models
{
	public enum AlgorithmType
	{
		[EnumMember(Value = "Original")] Original,
		[EnumMember(Value = "Bitsquatting")] Bitsquatting,
		[EnumMember(Value = "Homoglyph")] Homoglyph,
		[EnumMember(Value = "Hyphenation")] Hyphenation,
		[EnumMember(Value = "Insertion")] Insertion,
		[EnumMember(Value = "Omission")] Omission,
		[EnumMember(Value = "Repetition")] Repetition,
		[EnumMember(Value = "Replacement")] Replacement,
		[EnumMember(Value = "SubDomain")] SubDomain,
		[EnumMember(Value = "Transposition")] Transposition,
		[EnumMember(Value = "Vowel Swap")] VowelSwap,
		[EnumMember(Value = "Addition")] Addition,
		[EnumMember(Value = "Various")] Various,
		[EnumMember(Value = "Unknown")] Unknown
	}
}