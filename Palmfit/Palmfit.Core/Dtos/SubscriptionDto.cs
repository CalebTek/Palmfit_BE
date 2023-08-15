using Palmfit.Data.EntityEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Dtos
{
	public class SubscriptionDto
	{
		[EnumDataType(typeof(SubscriptionType))]
		public SubscriptionType Type { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

		public bool IsExpired { get; set; }

		[Required]
		public string SubscriptionId { get; set; }
	}
}
