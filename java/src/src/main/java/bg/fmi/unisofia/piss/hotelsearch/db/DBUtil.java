package bg.fmi.unisofia.piss.hotelsearch.db;

import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;

import bg.fmi.unisofia.piss.hotelsearch.db.DatabaseConnector;

public class DBUtil {
	public static void createTable() {
		try {
			Connection conn = DatabaseConnector.getInstance().getDbConnection();
			Statement statement = conn.createStatement();
			
			statement.execute("drop table if exists locations, orders, hotels");
			statement.execute("create table if not exists "
					+ "locations(id int not null primary key,"
					+ " name varchar(255) not null)");
			
			
			statement.execute("insert into locations values(1, 'Банско')");
			statement.execute("insert into locations values(2, 'Белмекен')");
			statement.execute("insert into locations values(3, 'Боровец')");
			statement.execute("insert into locations values(4, 'Витоша')");
			statement.execute("insert into locations values(5, 'Добринище')");
			statement.execute("insert into locations values(6, 'Пампорово')");
			statement.execute("insert into locations values(7, 'Рибарица')");
			statement.execute("insert into locations values(8, 'Цигов чарк')");
			statement.execute("insert into locations values(9, 'Чепеларе')");
			
			statement.execute("create table if not exists "
					+ "orders(id int not null primary key,"
					+ " name varchar(255) not null)");
			
			statement.execute("insert into orders values(1, 'name')");
			statement.execute("insert into orders values(2, 'price')");
			statement.execute("insert into orders values(3, 'stars')");
			
			String createHotels = "create table if not exists "
					+ "hotels(id int not null primary key, "
					+ "name varchar(255) not null, "
					+ "location int not null, "
					+ "stars integer not null, "
					+ "price double not null, "
					+ "foreign key (location) references locations(id))";
			statement.execute(createHotels);
			
			statement.execute("insert into hotels values(1, 'Хилтън', 2, 5, 100)");
			statement.execute("insert into hotels values(2, 'Тифани', 4, 4, 70)");
			statement.execute("insert into hotels values(3, 'Балкан', 3, 4, 80)");
			statement.execute("insert into hotels values(4, 'Централ', 9, 2, 25)");
			statement.execute("insert into hotels values(5, 'Боровец', 4, 3, 90)");
			statement.execute("insert into hotels values(6, 'Гранд хотел софия', 5, 3, 80)");
			statement.execute("insert into hotels values(7, 'Хемус', 2, 5, 120)");
			statement.execute("insert into hotels values(8, 'Самоков', 1, 3, 45)");
			statement.execute("insert into hotels values(9, 'Нирвана', 1, 5, 130)");
			statement.execute("insert into hotels values(10, 'Бтр', 3, 4, 95)");
			statement.execute("insert into hotels values(11, 'Златен рог', 5, 1, 25)");
			statement.execute("insert into hotels values(12, 'Слънце', 7, 4, 90)");
			statement.execute("insert into hotels values(13, 'Ирис', 8, 3, 60)");
			statement.execute("insert into hotels values(14, 'Лудогорие', 7, 5, 160)");
			statement.execute("insert into hotels values(15, 'Капанци', 9, 2, 50)");
			statement.execute("insert into hotels values(16, 'Симеон', 8, 3, 70)");
			statement.execute("insert into hotels values(17, 'Виктория', 9, 2, 20)");
			statement.execute("insert into hotels values(18, 'Sunny beach', 6, 1, 10)");
			statement.execute("insert into hotels values(19, 'ММЦ Приморско', 6, 1, 8)");
			statement.execute("insert into hotels values(20, 'Ивайловград', 7, 3, 60)");
			statement.execute("insert into hotels values(21, 'Царевец', 1, 4, 70)");
			statement.execute("insert into hotels values(22, 'Баден-Баден', 5, 5, 230)");
			statement.execute("insert into hotels values(23, 'Гладен-Гладен', 7, 4, 70)");
			statement.execute("insert into hotels values(24, 'Ренесанс', 6, 5, 120)");
			statement.execute("insert into hotels values(25, 'Шератон', 4, 3, 70)");
			statement.execute("insert into hotels values(26, 'Милко', 3, 5, 250)");
			statement.execute("insert into hotels values(27, 'Варна', 2, 2, 70)");
			statement.execute("insert into hotels values(28, 'Шумен', 2, 3, 120)");
			statement.execute("insert into hotels values(29, 'Орел', 1, 8, 100)");
			statement.execute("insert into hotels values(30, 'Валя', 5, 4, 150)");
			statement.close();
			DatabaseConnector.closeConnection(conn);
			
		} catch (SQLException e) {
			e.printStackTrace();
		}
		
	}
}
