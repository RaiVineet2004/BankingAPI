using System;
namespace BankData.Model
{
	public class ResponseHandler
	{
		public static ApiResponse GetExceptionResponse(Exception ex)
		{
			ApiResponse response = new ApiResponse();
			response.Code = "1";
			
			response.Text = ex.Message;
			return response;
		}

		public static ApiResponse GetAppResponse(ResponseType type, object? contract)
		{
			ApiResponse response;
			response = new ApiResponse { ResponseData = contract };
			switch (type)
			{
                case ResponseType.Success:
					response.Code = "0";
					response.Text = "Success";
					break;
				case ResponseType.NotFound:
					response.Code = "2";
					response.Text = "NotFound";
					break;

			}
			return response;
		}
	}
}

