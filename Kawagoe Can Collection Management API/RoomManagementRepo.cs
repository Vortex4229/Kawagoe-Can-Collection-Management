using System.Data;
using MySql.Data.MySqlClient;

namespace Kawagoe_Can_Collection_Management_API;

public class RoomManagementRepo {
	
	// get functions
	
	public static byte? GetBoxOwnership(MySqlConnection conn, string roomNumber) {
		var boxOwnershipQuery = "SELECT box_ownership FROM rooms WHERE room_number=@roomNumber";

		var boxOwnershipCmd = new MySqlCommand(boxOwnershipQuery, conn);

		byte? boxOwnership = null;

		try {
			conn.Open();

			boxOwnershipCmd.Parameters.Add("@roomNumber", MySqlDbType.VarChar).Value = roomNumber;

			var boxOwnershipCmdReader = boxOwnershipCmd.ExecuteReader();
			while (boxOwnershipCmdReader.Read())
				boxOwnership = boxOwnershipCmdReader.GetByte(0);
			boxOwnershipCmdReader.Close();
		}
		catch (MySqlException e) {
			Console.WriteLine(e);
		}
		finally {
			if (conn.State == ConnectionState.Open) conn.Close();
		}

		return boxOwnership;
	}
	
	public static string GetTeacherName(MySqlConnection conn, string roomNumber) {
		var teacherNameQuery = "SELECT teacher_name FROM rooms WHERE room_number=@roomNumber";

		var teacherNameCmd = new MySqlCommand(teacherNameQuery, conn);

		string teacherName = "";

		try {
			conn.Open();

			teacherNameCmd.Parameters.Add("@roomNumber", MySqlDbType.VarChar).Value = roomNumber;

			var teacherNameCmdReader = teacherNameCmd.ExecuteReader();
			while (teacherNameCmdReader.Read())
				teacherName = teacherNameCmdReader.GetString(0);
			teacherNameCmdReader.Close();
		}
		catch (MySqlException e) {
			Console.WriteLine(e);
		}
		finally {
			if (conn.State == ConnectionState.Open) conn.Close();
		}
		
		return teacherName;
	}

	public static byte? GetCollectionFrequency(MySqlConnection conn, string roomNumber) {
		var collectionFrequencyQuery = "SELECT collection_frequency FROM rooms WHERE room_number=@roomNumber";

		var collectionFrequencyCmd = new MySqlCommand(collectionFrequencyQuery, conn);

		byte? collectionFrequency = null;

		try {
			conn.Open();

			collectionFrequencyCmd.Parameters.Add("@roomNumber", MySqlDbType.VarChar).Value = roomNumber;

			var collectionFrequencyCmdReader = collectionFrequencyCmd.ExecuteReader();
			while (collectionFrequencyCmdReader.Read())
				collectionFrequency = collectionFrequencyCmdReader.GetByte(0);
			collectionFrequencyCmdReader.Close();
		}
		catch (MySqlException e) {
			Console.WriteLine(e);
		}
		finally {
			if (conn.State == ConnectionState.Open) conn.Close();
		}

		return collectionFrequency;
	}

	public static DateTime? GetLastCollectionDate(MySqlConnection conn, string roomNumber) {
		var lastCollectionDateQuery = "SELECT last_collection_date FROM rooms WHERE room_number=@roomNumber";

		var lastCollectionDateCmd = new MySqlCommand(lastCollectionDateQuery, conn);

		DateTime? lastCollectionDate = null;

		try {
			conn.Open();

			lastCollectionDateCmd.Parameters.Add("@roomNumber", MySqlDbType.VarChar).Value = roomNumber;

			var lastCollectionDateCmdReader = lastCollectionDateCmd.ExecuteReader();
			while (lastCollectionDateCmdReader.Read())
				lastCollectionDate = lastCollectionDateCmdReader.GetDateTime(0);
			lastCollectionDateCmdReader.Close();
		}
		catch (MySqlException e) {
			Console.WriteLine(e);
		}
		finally {
			if (conn.State == ConnectionState.Open) conn.Close();
		}
		
		return lastCollectionDate;
	}
	
	public static byte? GetRequestedCollection(MySqlConnection conn, string roomNumber) {
		var requestedCollectionQuery = "SELECT requested_collection FROM rooms WHERE room_number=@roomNumber";

		var requestedCollectionCmd = new MySqlCommand(requestedCollectionQuery, conn);

		byte? requestedCollection = null;
	
		try {
			conn.Open();

			requestedCollectionCmd.Parameters.Add("@roomNumber", MySqlDbType.VarChar).Value = roomNumber;

			var requestedCollectionCmdReader = requestedCollectionCmd.ExecuteReader();
			while (requestedCollectionCmdReader.Read())
				requestedCollection = requestedCollectionCmdReader.GetByte(0);
			requestedCollectionCmdReader.Close();
		}
		catch (MySqlException e) {
			Console.WriteLine(e);
		}
		finally {
			if (conn.State == ConnectionState.Open) conn.Close();
		}

		return requestedCollection;
	}
	
	public static string GetComment(MySqlConnection conn, string roomNumber) {
		var commentQuery = "SELECT comment FROM rooms WHERE room_number=@roomNumber";

		var commentCmd = new MySqlCommand(commentQuery, conn);

		string comment = "";

		try {
			conn.Open();

			commentCmd.Parameters.Add("@roomNumber", MySqlDbType.VarChar).Value = roomNumber;

			var commentCmdReader = commentCmd.ExecuteReader();
			while (commentCmdReader.Read())
				comment = commentCmdReader.IsDBNull(1) ? "" : commentCmdReader.GetString(0);
			
			commentCmdReader.Close();
		}
		catch (MySqlException e) {
			Console.WriteLine(e);
		}
		finally {
			if (conn.State == ConnectionState.Open) conn.Close();
		}
		
		return comment;
	}
	
	// set functions

	public static bool UpdateBoxOwnership(MySqlConnection conn, string roomNumber, byte boxOwnership) {
		var updateBoxOwnershipQuery = "UPDATE rooms SET box_ownership=@boxOwnership WHERE room_number=@roomNumber";

		var updateBoxOwnershipCmd = new MySqlCommand(updateBoxOwnershipQuery, conn);
		var success = false;

		try {
			conn.Open();

			updateBoxOwnershipCmd.Parameters.Add("@boxOwnership", MySqlDbType.Byte).Value = boxOwnership;
			updateBoxOwnershipCmd.ExecuteNonQuery();

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
	
	public static bool UpdateTeacherName(MySqlConnection conn, string roomNumber, string teacherName) {
		var updateTeacherNameQuery = "UPDATE rooms SET teacher_name=@teacherName WHERE room_number=@roomNumber";

		var updateTeacherNameCmd = new MySqlCommand(updateTeacherNameQuery, conn);
		var success = false;

		try {
			conn.Open();

			updateTeacherNameCmd.Parameters.Add("@teacherName", MySqlDbType.VarChar).Value = teacherName;
			updateTeacherNameCmd.ExecuteNonQuery();

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
	
	public static bool UpdateCollectionFrequency(MySqlConnection conn, string roomNumber, byte collectionFrequency) {
		var updateCollectionFrequencyQuery = "UPDATE rooms SET collection_frequency=@collectionFrequency WHERE room_number=@roomNumber";

		var updateCollectionFrequencyCmd = new MySqlCommand(updateCollectionFrequencyQuery, conn);
		var success = false;

		try {
			conn.Open();

			updateCollectionFrequencyCmd.Parameters.Add("@collectionFrequency", MySqlDbType.Byte).Value = collectionFrequency;
			updateCollectionFrequencyCmd.ExecuteNonQuery();

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
	
	public static bool UpdateLastCollectionDate(MySqlConnection conn, string roomNumber, DateOnly lastCollectionDate) {
		var updateLastCollectionDateQuery = "UPDATE rooms SET last_collection_date=@lastCollectionDate WHERE room_number=@roomNumber";

		var updateLastCollectionDateCmd = new MySqlCommand(updateLastCollectionDateQuery, conn);
		var success = false;

		try {
			conn.Open();

			updateLastCollectionDateCmd.Parameters.Add("@lastCollectionDate", MySqlDbType.Byte).Value = lastCollectionDate;
			updateLastCollectionDateCmd.ExecuteNonQuery();

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
	
	public static bool UpdateRequestedCollection(MySqlConnection conn, string roomNumber, byte requestedCollection) {
		var updateRequestedCollectionQuery = "UPDATE rooms SET requested_collection=@requestedCollection WHERE room_number=@roomNumber";

		var updateRequestedCollectionCmd = new MySqlCommand(updateRequestedCollectionQuery, conn);
		var success = false;

		try {
			conn.Open();

			updateRequestedCollectionCmd.Parameters.Add("@requestedCollection", MySqlDbType.Byte).Value = requestedCollection;
			updateRequestedCollectionCmd.ExecuteNonQuery();

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
	
	public static bool UpdateComment(MySqlConnection conn, string roomNumber, string comment) {
		var updateCommentQuery = "UPDATE rooms SET comment=@comment WHERE room_number=@roomNumber";

		var updateCommentCmd = new MySqlCommand(updateCommentQuery, conn);
		var success = false;

		try {
			conn.Open();

			updateCommentCmd.Parameters.Add("@comment", MySqlDbType.Byte).Value = comment;
			updateCommentCmd.ExecuteNonQuery();

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
