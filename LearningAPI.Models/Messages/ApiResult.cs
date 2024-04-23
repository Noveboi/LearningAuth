using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models.Messages;


public class ApiResult<T>
{
	private ApiResult(Error error)
	{
		Error = error;
	}
	private ApiResult(T? data)
	{
		Data = data;
	}


	public Error? Error { get; }
	public T? Data { get; }

	public static ApiResult<T> NotOk(Error error) => new(error);
	public static ApiResult<T> Ok(T? data = default) => new(data);

	public bool IsOk => Error == null;
}

public class ApiResult
{
	private ApiResult(Error? error)
	{
		Error = error;
	}


	public Error? Error { get; }

	public static ApiResult NotOk(Error error) => new(error);
	public static ApiResult Ok() => new(null);

	public bool IsOk => Error == null;
}
