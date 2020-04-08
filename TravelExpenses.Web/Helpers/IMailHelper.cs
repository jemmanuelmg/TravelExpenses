using TravelExpenses.Common.Models;

namespace TravelExpenses.Web.Helpers
{
	public interface IMailHelper
	{
		Response SendMail(string to, string subject, string body);
	}
}
