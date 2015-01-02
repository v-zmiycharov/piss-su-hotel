package bg.fmi.unisofia.piss.hotelsearch.model;


public class Hotel {

	private String name;
	private int stars;
	private String location;
	private double price;
	
	public Hotel() {
	}
	
	public Hotel(String name, String location, int stars, double price) {
		this.name = name;
		this.location = location;
		this.stars = stars;
		this.price = price;
	}
	
	public Hotel(int id, String name, String location, int stars, double price) {
		this.name = name;
		this.location = location;
		this.stars = stars;
		this.price = price;
	}

	public int getStars() {
		return stars;
	}

	public void setStars(int stars) {
		this.stars = stars;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getLocation() {
		return location;
	}

	public void setLocation(String location) {
		this.location = location;
	}

	public double getPrice() {
		return price;
	}

	public void setPrice(double price) {
		this.price = price;
	}
}