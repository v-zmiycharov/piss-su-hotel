package bg.fmi.unisofia.piss.hotelsearch.db;

import java.sql.Connection;
import java.sql.SQLException;

import org.h2.jdbcx.JdbcDataSource;

public class DatabaseConnector {

	private static DatabaseConnector instance = null;
	private JdbcDataSource ds = null;

	private DatabaseConnector() {
		ds = new JdbcDataSource();
		ds.setURL("jdbc:h2:D:\\h2_dbhotels_db");
		ds.setUser("sa");
		ds.setPassword("sa");
	}

	public static DatabaseConnector getInstance() {

		if (instance == null) {
			instance = new DatabaseConnector();
		}

		return instance;
	}

	public Connection getDbConnection() {
		Connection conn = null;
		if(ds != null) {
			try {
				conn = ds.getConnection();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}
		
		return conn;
	}

	public static void closeConnection(Connection conn) {
		if(conn != null) {
			try {
				conn.close();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}
	}

}
