<<<<<<< HEAD:Core/Services/ITwisterService.cs
﻿using System.Collections.Generic;
using SquatFinder.Web.Core.Models;
=======
﻿using SquatFinder.Core.Models;
>>>>>>> master:SquatFinder.Core/Services/ITwisterService.cs

namespace SquatFinder.Core.Services
{
	public interface ITwisterService
	{
		IList<FinderDomain> GetFuzzyDomains(string domain);
	}
}