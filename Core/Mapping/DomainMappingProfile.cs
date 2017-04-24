using AutoMapper;
using SquatFinder.Web.Core.Models;

namespace SquatFinder.Web.Core.Mapping
{
	public class DomainMappingProfile : Profile
	{
		public DomainMappingProfile()
		{
			CreateMap<DnsTwisterDomain, FinderDomain>()
				.ForMember(d => d.AlgorithmType,
					op => op.ResolveUsing(o => MapAlgorithmType(o.AlgorithmType)));
		}

		public static AlgorithmType MapAlgorithmType(string algorithmType)
		{
			switch (algorithmType)
			{
				case "Original*":
					return AlgorithmType.Original;
				case "Addition":
					return AlgorithmType.Addition;
				case "Bitsquatting":
					return AlgorithmType.Bitsquatting;
				case "Homoglyph":
					return AlgorithmType.Homoglyph;
				case "Hyphenation":
					return AlgorithmType.Hyphenation;
				case "Insertion":
					return AlgorithmType.Insertion;
				case "Omission":
					return AlgorithmType.Omission;
				case "Repetition":
					return AlgorithmType.Repetition;
				case "Replacement":
					return AlgorithmType.Replacement;
				case "Subdomain":
					return AlgorithmType.SubDomain;
				case "Transposition":
					return AlgorithmType.Transposition;
				case "Vowel swap":
					return AlgorithmType.VowelSwap;
				case "Various": 
					return AlgorithmType.Various;
			}

			return AlgorithmType.Unknown;
		}
	}
}