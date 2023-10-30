using System;
namespace BankData.Model
{
	public class ApiResponse
	{

		public string? Code { get; set; }

		public string? Message { get; set; }

		public Object? ResponseData { get; set; }
        public string? Text { get; internal set; }
    }

	public enum ResponseType
	{
		Success,
		NotFound,
		Failure
	}
}

