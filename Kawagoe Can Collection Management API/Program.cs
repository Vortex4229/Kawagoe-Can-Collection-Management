using Kawagoe_Can_Collection_Management_API;
using MySql.Data.MySqlClient;

namespace Kawagoe_Can_Collection_Management_API;

public class Program {
	public static void Main(string[] args) {
		var builder = WebApplication.CreateBuilder(args);
		
		builder.Services.AddAuthorization();
		
		builder.Services.AddOpenApi();

		var app = builder.Build();
		
		if (app.Environment.IsDevelopment()) app.MapOpenApi();

		app.UseHttpsRedirection();
		
		// connection management
		var connectionString = builder.Configuration.GetConnectionString("kccd") ??
		                       throw new Exception("No connection string found");
		var conn = new MySqlConnection(connectionString);
		
		// root method API calls
		app.MapGet(
			"/api/createRoom/{roomNumber}/{boxOwnership}/{teacherName}/{collectionFrequency}/{lastCollectionDate}/{requestedCollection}",
			(string roomNumber, byte boxOwnership, string teacherName, byte collectionFrequency,
					string lastCollectionDate, byte requestedCollection) =>
				$"{RootMethodsRepo.CreateRoom(conn, roomNumber, boxOwnership, teacherName, collectionFrequency, DateOnly.Parse(lastCollectionDate), requestedCollection)}")
			.WithName("Create Room");
			
		// room management API calls -- get
		app.MapGet("/api/getBoxOwnership/{roomNumber}", (string roomNumber) => 
			$"{RoomManagementRepo.GetBoxOwnership(conn, roomNumber)}").WithName("Get Box Ownership");
		
		app.MapGet("api/getTeacherName/{roomNumber}", (string roomNumber) => 
			$"{RoomManagementRepo.GetTeacherName(conn, roomNumber)}").WithName("Get Teacher Name");
		
		app.MapGet("/api/getCollectionFrequency/{roomNumber}", (string roomNumber) => 
			$"{RoomManagementRepo.GetCollectionFrequency(conn, roomNumber)}").WithName("Get Collection Frequency");
		
		app.MapGet("/api/getLastCollectionDate/{roomNumber}", (string roomNumber) => 
			$"{RoomManagementRepo.GetLastCollectionDate(conn, roomNumber)}").WithName("Get Last Collection Date");
		
		app.MapGet("/api/getRequestedCollection/{roomNumber}", (string roomNumber) => 
			$"{RoomManagementRepo.GetRequestedCollection(conn, roomNumber)}").WithName("Get Requested Collection");
		
		app.MapGet("/api/getComment/{roomNumber}", (string roomNumber) => 
			$"{RoomManagementRepo.GetComment(conn, roomNumber)}").WithName("Get Comment");
		
		// room management API calls -- set
		app.MapGet("api/updateBoxOwnership/{roomNumber}/{boxOwnership}", (string roomNumber, byte boxOwnership) =>
			$"{RoomManagementRepo.UpdateBoxOwnership(conn, roomNumber, boxOwnership)}");
		
		app.MapGet("api/updateTeacherName/{roomNumber}/{teacherName}", (string roomNumber, string teacherName) =>
			$"{RoomManagementRepo.UpdateTeacherName(conn, roomNumber, teacherName)}");
		
		app.MapGet("api/updateCollectionFrequency/{roomNumber}/{collectionFrequency}", (string roomNumber, byte collectionFrequency) =>
			$"{RoomManagementRepo.UpdateCollectionFrequency(conn, roomNumber, collectionFrequency)}");
		
		app.MapGet("api/updateLastCollectionDate/{roomNumber}/{lastCollectionDate}", (string roomNumber, DateOnly lastCollectionDate) =>
			$"{RoomManagementRepo.UpdateLastCollectionDate(conn, roomNumber, lastCollectionDate)}");
		
		app.MapGet("api/updateRequestedCollection/{roomNumber}/{requestedCollection}", (string roomNumber, byte requestedCollection) =>
			$"{RoomManagementRepo.UpdateRequestedCollection(conn, roomNumber, requestedCollection)}");
		
		app.MapGet("api/updateComment/{roomNumber}/{comment}", (string roomNumber, string comment) =>
			$"{RoomManagementRepo.UpdateComment(conn, roomNumber, comment)}");
		
		app.Run();
	}
}