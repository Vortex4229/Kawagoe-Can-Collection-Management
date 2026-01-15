using System.Data;
using MySql.Data.MySqlClient;

namespace Kawagoe_Can_Collection_Management_API;

public class RootMethodsRepo {

	public static bool CreateRoom(MySqlConnection conn, string roomNumber, byte boxOwnership, string teacherName,
		byte collectionFrequency, DateOnly lastCollectionDate, byte requestedCollection) {
		var createRoomQuery =
			"INSERT INTO rooms(room_number, box_ownership, teacher_name, collection_frequency, last_collection_date," +
			" requested_collection) VALUES (@roomNumber, @boxOwnership, @teacherName, @collectionFrequency," +
			" @lastCollectionDate, @requestedCollection)";

		var createRoomCmd = new MySqlCommand(createRoomQuery, conn);
		createRoomCmd.Parameters.Add("@roomNumber", MySqlDbType.VarChar).Value = roomNumber;
		createRoomCmd.Parameters.Add("@boxOwnership", MySqlDbType.Byte).Value = boxOwnership;
		createRoomCmd.Parameters.Add("@teacherName", MySqlDbType.VarChar).Value = teacherName;
		createRoomCmd.Parameters.Add("@collectionFrequency", MySqlDbType.Byte).Value = collectionFrequency;
		createRoomCmd.Parameters.Add("@lastCollectionDate", MySqlDbType.Date).Value = lastCollectionDate;
		createRoomCmd.Parameters.Add("@requestedCollection", MySqlDbType.VarChar).Value = requestedCollection;

		var success = false;

		try {
			conn.Open();

			createRoomCmd.ExecuteNonQuery();
			success = true;
		}
		catch (MySqlException e) {
			Console.WriteLine(e);
		}
		finally {
			if (conn.State == ConnectionState.Open) conn.Close();
		}

		return success;
	}
}