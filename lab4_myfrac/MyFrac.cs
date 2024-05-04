using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace llblbl
{
	struct MyFrac
	{
		public long nom, denom;
		public MyFrac(long nom_, long denom_)
		{
			int sign = 1;
			if ((double)nom_ / denom_ < 0)
				sign = -1;
		
			long tnom_ = Math.Abs(nom_);
			long tdenom_ = Math.Abs(denom_);
			long gcd;
			while (true)
			{
				if (tnom_ % tdenom_ == 0)
				{
					gcd = tdenom_;
					break;
				}
				if (tdenom_ % tnom_ == 0)
				{
					gcd = tnom_;
					break;
				}
				if (tnom_ > tdenom_)
					tnom_ %= tdenom_;
				else
					tdenom_ %= tnom_;
			}
			nom = Math.Abs(nom_) / gcd * sign;
			denom = Math.Abs(denom_) / gcd;
		}
		public override string ToString()
		{
			return nom + "/" + denom;
		}

	}
}
