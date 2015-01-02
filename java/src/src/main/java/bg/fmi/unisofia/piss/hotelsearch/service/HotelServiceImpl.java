package bg.fmi.unisofia.piss.hotelsearch.service;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import bg.fmi.unisofia.piss.hotelsearch.db.DatabaseConnector;
import bg.fmi.unisofia.piss.hotelsearch.model.Hotel;

public class HotelServiceImpl implements HotelService {

	@Override
	public List<Hotel> getHotels(Integer stars, Integer location, Integer order) {

		List<Hotel> hotels = new ArrayList<Hotel>();

		Connection conn = DatabaseConnector.getInstance().getDbConnection();

		Statement stat;
		ResultSet rs;
		try {
			stat = conn.createStatement();
			rs = stat.executeQuery("select name from orders where id=" + order);
			String returnedOrder = null;
			if(rs.next()) {
				returnedOrder = rs.getString(1);
			}
			
			String query = "select h.name, l.name, stars, price "
					+ "from hotels as h, locations as l "
					+ " where h.location = l.id " + createWhereClause(stars, location)
					+ (returnedOrder != null 
					? " order by " + returnedOrder + " asc" 
					: "");
			
			rs = stat.executeQuery(query);
			while (rs.next()) {
				Hotel hotel = new Hotel(rs.getString(1),
						rs.getString(2), rs.getInt(3), rs.getDouble(4));
				hotels.add(hotel);
			}

			stat.close();
			DatabaseConnector.closeConnection(conn);
		} catch (SQLException e) {
			e.printStackTrace();
		}

		return hotels;

	}
	
	private String createWhereClause(Integer stars, Integer location) {
		String starsQuery = stars != null ? " and stars=" + stars : "";
		String locationQuery = location != null ? " and l.id=" + location : "";
		return starsQuery  + locationQuery;
	}
}
