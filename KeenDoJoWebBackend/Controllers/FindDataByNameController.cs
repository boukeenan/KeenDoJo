using Microsoft.AspNetCore.Mvc;

namespace KeenDoJoWebBackend.Controllers
{
	[ApiController]
	[Route("controller")]
	public class FindDataByNameController : ControllerBase
	{
		private readonly string _name = "Find data by name";

		private readonly ILogger<FindDataByNameController> _logger;

		public FindDataByNameController(ILogger<FindDataByNameController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetDataByName")]
		public IEnumerable<DataByName> Get()
		{
			return Enumerable.Range(1, 5).Select(mel => new DataByName
			{
				TableName = "Table Name",
				ColumnName = "Column Name",
				Details = "Details"
			});
		}
	}
}
